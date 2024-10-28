# 🐙 Git Status Shell Extension: Windows Explorer Overlay Icons

A Windows shell extension built with **SharpShell** and **LibGit2Sharp** to display file statuses in a Git repository using icon overlays.

## 📑 Table of Contents
- [Overview](#ℹ️-overview)
- [Features](#📋-features)
- [Installation](#🚀-installation)
- [Troubleshooting](#🔧-troubleshooting)
- [FAQ](#❓-faq)
- [To-Do](#📝-to-do)
- [Acknowledgments](#🙏-acknowledgments)
- [Contributing](#🧑‍💻-contributing)
- [License](#📄-license)

## ℹ️ Overview

This tool was developed for two main reasons:

1. **Learning**: A personal project to understand how Windows shell integration works.
2. **Lightweight Alternative**: A lightweight alternative to TortoiseGit, focused solely on overlay icons, avoiding unnecessary additional features.

## 📋 Features

- 🗂️ **File Status Overlays**: Shows the current Git status of files directly in Windows Explorer.
- ⚙️ **Real-Time Updates**: Overlays update automatically when file status changes.
- 💻 **Native Integration**: Seamless integration with Windows Explorer.
- 🪶 **Lightweight**: Minimal system resource impact.

## 🚀 Installation

⚠️ **Prerequisites**: 
- Administrator rights
- .NET Framework 4.7.2 installed
- Git installed and configured
- Visual Studio 2022
- Windows 10 (1809) or higher

### Manual Installation Procedure

1. **Clone the repository**:
   ```bash
   git clone https://github.com/berik-99/GitStatusOverlay.git
   ```

2. **Build the project**:
   - Open the solution in Visual Studio 2022
   - Select Release configuration
   - Build the solution

3. **DLL Preparation**:
   - Copy the generated `.dll` file to an accessible location.
   - ⚠️ Note: Once registered, the DLL will be locked by the system.

4. **Register the Shell Extension**:
   ```bash
   # For 64-bit systems
   ServerRegistrationManager.exe install "[path]\GitStatusOverlay.ShellExtension.dll" -codebase -os64
   
   # For 32-bit systems
   ServerRegistrationManager.exe install "[path]\GitStatusOverlay.ShellExtension.dll" -codebase -os32
   ```

5. **Restart Explorer**:
   ```bash
   taskkill /F /IM explorer.exe
   start explorer.exe
   ```

### Uninstallation

1. **Unregister the Shell Extension**:
   ```bash
   ServerRegistrationManager.exe uninstall "[path]\GitStatusOverlay.ShellExtension.dll"
   ```

2. **Restart Explorer**:
   ```bash
   taskkill /F /IM explorer.exe
   start explorer.exe
   ```

## 🔧 Troubleshooting

### Overlays not appearing
1. Check the registry:
   ```
   Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers
   ```
2. Verify the presence of keys related to `GitStatusOverlay`. If they are present, check how many keys are listed. Windows has a limitation of 15 overlay icons. 

3. If there are more than 15 keys, you will need to remove some to allow for proper functionality.

### Common Errors
- **Error 1**: DLL not registered
  - Solution: Re-run registration as administrator.
  
- **Error 2**: Conflict with other overlays
  - Solution: Temporarily uninstall other software using overlays.

### Diagnostic Logging

To view logs, launch the program located in the **Tools** folder named `SharpShell.Easy.Log.v1.0`. Special thanks to the creators of [SharpShell-Easy-Log](https://github.com/ElektroStudios/SharpShell-Easy-Log) for providing a helpful logging tool!

## ❓ FAQ

**Q**: Is it compatible with other Git software?  
**A**: Yes, it can coexist with Git GUI, SourceTree, etc.

**Q**: What's the system performance impact?  
**A**: Minimal impact, uses approximately 20MB RAM.

**Q**: Does it support remote repositories?  
**A**: Yes, it shows file status relative to configured remote.

## 📝 To-Do

- 📦 **Automated Installer**: 
  - [ ] Develop an installer to simplify distribution and installation.
  - [ ] Installation wizard with configuration options.
  - [ ] Automatic handling of existing overlays.
  - [ ] Automated uninstallation process.
- 🔄 **Updates**:
  - [ ] Auto-update system.
  - [ ] New version notifications.
- 🎨 **UI**:
  - [ ] Configuration panel.
  - [ ] Color customization.

## 🙏 Acknowledgments

A big thank you to all the developers of the libraries used in this project:

- [SharpShell](https://github.com/dwmkerr/sharpshell): A .NET shell extension framework that simplifies the creation of Windows shell extensions.
- [LibGit2Sharp](https://github.com/libgit2/libgit2sharp): A .NET wrapper for the libgit2 library, providing Git integration.
- [SharpShell-Easy-Log](https://github.com/ElektroStudios/SharpShell-Easy-Log): A logging tool for SharpShell extensions, thanks to the creators for their contribution!

## 🧑‍💻 Contributing

Contributions are welcome! To contribute:

1. 🍴 Fork the repository.
2. 🔧 Create a branch (`git checkout -b feature/AmazingFeature`).
3. 💾 Commit changes (`git commit -m 'Add AmazingFeature'`).
4. 📤 Push to branch (`git push origin feature/AmazingFeature`).
5. 🔄 Open a Pull Request.

## 📄 License

This project is distributed under the MIT License. See the `LICENSE` file for details.
