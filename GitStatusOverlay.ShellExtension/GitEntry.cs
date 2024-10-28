using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitStatusOverlay.ShellExtension;

public class GitEntry
{
    public GitEntry(string path)
    {
        FilePath = path;
        string repoPath = Repository.Discover(FilePath);
        if (repoPath != null)
        {
            using var repo = new Repository(repoPath);
            FilePath = Path.GetFullPath(FilePath);
            if (File.Exists(FilePath))
            {
                IsDirectory = false;
                Status = GetFileStatus(repo);
            }
            else if (Directory.Exists(FilePath))
            {
                IsDirectory = true;
                if (!FilePath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    FilePath += Path.DirectorySeparatorChar;
                Status = GetDirectoryStatus(repo);
            }
            else
            {
                throw new GitEntryException("The specified path does not exist.", FilePath);
            }
        }
        else
        {
            throw new GitEntryException("No Git repository found for the specified path.", FilePath);
        }

    }

    public string FilePath { get; }
    public bool IsDirectory { get; }
    public GitStatus Status { get; }

    private GitStatus GetFileStatus(Repository repo)
    {
        var fileStatus = repo.RetrieveStatus(FilePath);

        if (fileStatus.HasFlag(FileStatus.NewInWorkdir))
            return GitStatus.Untracked;

        if (fileStatus.HasFlag(FileStatus.NewInIndex))
            return GitStatus.Staged;

        if (fileStatus.HasFlag(FileStatus.ModifiedInIndex))
            return GitStatus.ModifyStaged;

        if (fileStatus.HasFlag(FileStatus.ModifiedInWorkdir))
            return GitStatus.Modified;

        if (fileStatus.HasFlag(FileStatus.DeletedFromWorkdir))
            return GitStatus.Deleted;

        if (fileStatus.HasFlag(FileStatus.Ignored))
            return GitStatus.Ignored;

        return GitStatus.Clean;
    }

    private GitStatus GetDirectoryStatus(Repository repo)
    {
        var status = repo.RetrieveStatus();


        string relativePath = FilePath.Equals(repo.Info.WorkingDirectory)
            ? string.Empty
            : FilePath.Substring(repo.Info.WorkingDirectory.Length).TrimStart(Path.DirectorySeparatorChar);
        relativePath = relativePath.Replace(Path.DirectorySeparatorChar, '/');
        if (!string.IsNullOrEmpty(relativePath) && repo.Ignore.IsPathIgnored(relativePath))
            return GitStatus.Ignored;

        List<StatusEntry> folderFiles = status.Where(entry => entry.FilePath.StartsWith(relativePath)).ToList();
        bool hasUntrackedFiles = folderFiles.Any(f => f.State.HasFlag(FileStatus.NewInWorkdir));
        bool hasModifiedFiles = folderFiles.Any(f => f.State.HasFlag(FileStatus.ModifiedInWorkdir) || f.State.HasFlag(FileStatus.ModifiedInIndex));
        bool hasDeletedFiles = folderFiles.Any(f => f.State.HasFlag(FileStatus.DeletedFromWorkdir));
        return hasUntrackedFiles || hasModifiedFiles || hasDeletedFiles ? GitStatus.Modified : GitStatus.Clean;
    }
}

public class GitEntryException : Exception
{
    public GitEntryException(string message) : base(message) { }

    public GitEntryException(string message, string filePath) : base($"{message} Path: {filePath}") { }
}
