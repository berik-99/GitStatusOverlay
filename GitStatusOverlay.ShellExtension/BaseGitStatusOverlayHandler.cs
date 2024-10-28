using SharpShell.Interop;
using SharpShell.SharpIconOverlayHandler;
using System;

namespace GitStatusOverlay.ShellExtension;

public abstract class BaseGitStatusOverlayHandler : SharpIconOverlayHandler
{
    protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
    {
        try
        {
            GitEntry entry = new(path);
            return CanShowOverlay(entry);
        }
        catch (GitEntryException ex)
        {
            return false;
        }
        catch (Exception ex)
        {
            LogError($"Unexpected exception: {ex.Message}", ex);
            return false;
        }
    }

    protected abstract bool CanShowOverlay(GitEntry entry);

    protected override int GetPriority()
    {
        return 30;
    }
}
