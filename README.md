# 🐙 Git Status Shell Extension

A Windows shell extension built with SharpShell to display file statuses in a Git repository using icon overlays.

## ℹ️ Project Purpose

This tool was developed for two main reasons:

1. **Learning**: A personal interest in understanding how Windows shell integration works.
2. **Lightweight Alternative**: Previously, I used TortoiseGit, which, while feature-rich, felt too "heavy" for my needs. It includes context menu Git commands, which I found unnecessary and didn't want to clutter the system. This tool focuses solely on displaying overlay icons.

## 📋 Features

- 🗂️ **File Status Overlays**: Shows the current Git status of files directly in Windows Explorer.
- ⚙️ **Real-Time Updates**: Automatically updates icon overlays when file statuses change.
- 💻 **Seamless Integration**: Integrates smoothly with Windows Explorer, providing visual feedback on Git status without needing to open another application.

## 🚀 Getting Started & Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/berik-99/GitStatusOverlay.git
   ```
2. **Build the project**:
   Open the solution in Visual Studio 2022 (or later) and build it. The project targets .NET Framework 4.7.2.

3. **Prepare the DLL**:
   Copy the generated `.dll` file to an accessible location. Once registered, the DLL will be locked by the system, making it difficult to remove without unregistering.

4. **Register the Shell Extension**:
   The `ServerRegistrationManager.exe` tool, located in the `Tools` folder, is used for registering and unregistering the shell extension.

   - **To install**:
     Run the following command as administrator, adjusting the path and architecture accordingly:
     ```bash
     ServerRegistrationManager.exe install "path\to\your\GitStatusOverlay.ShellExtension.dll" -codebase -os64|os32
     ```
     Use `-os64` for 64-bit or `-os32` for 32-bit systems.

   - **To uninstall**:
     Run the command without parameters and replace `install` with `uninstall`:
     ```bash
     ServerRegistrationManager.exe uninstall "path\to\your\GitStatusOverlay.ShellExtension.dll"
     ```

5. **Restart Explorer**:
   After installing or uninstalling, restart the system process `explorer.exe` for changes to take effect.

## 🛠 Requirements

- .NET Framework 4.7.2
- SharpShell library
- Windows OS
- Visual Studio 2022 (Visual Studio 2019 may work but is untested)

## 🔧 To-Do

- 📦 **Installer**: Develop an installer to automate the distribution and installation process.

## 🙏 Acknowledgments

This project was made possible by the following libraries:

- [SharpShell](https://github.com/dwmkerr/sharpshell): For providing shell extension support in .NET.
- [LibGit2Sharp](https://github.com/libgit2/libgit2sharp): For enabling seamless Git repository integration.

## 🧑‍💻 Contributing

Contributions are welcome! Feel free to open issues or submit pull requests to improve this project.

## 📄 License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
