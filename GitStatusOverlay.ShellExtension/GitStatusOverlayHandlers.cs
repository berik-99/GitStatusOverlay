using SharpShell.Attributes;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GitStatusOverlay.ShellExtension;

[ComVisible(true)]
[RegistrationName($"    {nameof(GitUntrackedOverlayHandler)}")]
public class GitUntrackedOverlayHandler : BaseGitStatusOverlayHandler
{
    protected override bool CanShowOverlay(GitEntry entry) => entry.Status == GitStatus.Untracked;
    protected override Icon GetOverlayIcon() => Properties.Resources.Untracked;
}

[ComVisible(true)]
[RegistrationName($"    {nameof(GitModifiedOverlayHandler)}")]
public class GitModifiedOverlayHandler : BaseGitStatusOverlayHandler
{
    protected override bool CanShowOverlay(GitEntry entry) => entry.Status == GitStatus.Modified || entry.Status == GitStatus.ModifyStaged;
    protected override Icon GetOverlayIcon() => Properties.Resources.Modified;
}

[ComVisible(true)]
[RegistrationName($"    {nameof(GitStagedOverlayHandler)}")]
public class GitStagedOverlayHandler : BaseGitStatusOverlayHandler
{
    protected override bool CanShowOverlay(GitEntry entry) => entry.Status == GitStatus.Staged;
    protected override Icon GetOverlayIcon() => Properties.Resources.Staged;
}

[ComVisible(true)]
[RegistrationName($"    {nameof(GitDeletedOverlayHandler)}")]
public class GitDeletedOverlayHandler : BaseGitStatusOverlayHandler
{
    protected override bool CanShowOverlay(GitEntry entry) => entry.Status == GitStatus.Deleted;
    protected override Icon GetOverlayIcon() => Properties.Resources.Deleted;
}

[ComVisible(true)]
[RegistrationName($"    {nameof(GitIgnoredOverlayHandler)}")]
public class GitIgnoredOverlayHandler : BaseGitStatusOverlayHandler
{
    protected override bool CanShowOverlay(GitEntry entry) => entry.Status == GitStatus.Ignored;
    protected override Icon GetOverlayIcon() => Properties.Resources.Ignored;
}

[ComVisible(true)]
[RegistrationName($"    {nameof(GitCleanOverlayHandler)}")]
public class GitCleanOverlayHandler : BaseGitStatusOverlayHandler
{
    protected override bool CanShowOverlay(GitEntry entry) => entry.Status == GitStatus.Clean;
    protected override Icon GetOverlayIcon() => Properties.Resources.Clean;
}
