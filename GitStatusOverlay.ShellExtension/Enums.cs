namespace GitStatusOverlay.ShellExtension;

public enum GitStatus
{
    Untracked,      // File non tracciato
    Modified,       // File modificato
    ModifyStaged,   // File modificato e aggiunto all'indice
    Staged,         // File aggiunto all'indice
    Deleted,        // File eliminato
    Ignored,        // File ignorato
    Clean           // File non modificato
}
