  # VirtualBox Accessible Starter
=======
# VirtualBox Accessible Starter

This small and very simple application solves the most important accessibility issue of the [VirtualBox Virtualization solution](http://virtualbox.org) and makes it accessible to screen reader users.  
It Can make guest controls in the VM window accessible by starting VBox in a special way, as these controls are completely inaccessible for blind users in new versions of VBox.

## Details

The cause of inaccessibility of guest controls is that the VM process is reinforced to prevent other applications from crashing the VM.  
To work with an app, a screen reader needs to inject code into the process of that app. It cannot however do it to a protected VM process.  
VBox has a solution for this problem. This is a special VM running mode called the Separate mode.  
In this mode, VirtualBox starts the VM in background mode and then starts the interface to control it in a separate process.  
This GUI process is not reinforced and is accessible for many screen readers. The reinforced VM process stays in background.

This app makes that easy.  

You need only to start this app and then double-click your VM name or press the Enter key after focusing it. The app automatically starts the VM by passing the `separate` argument to VirtualBox Main Api
You can use the context menu to start machines in standard and background mode. Also, if machine is in saved state, you can reset it's state using this menu.
## Building
Warning: this app must be built for spesific version of vbox. For example, the app, builtn for 5x version, will not work with 6x version do to changes in it's com api.
To build this app, you must have virtualBox correctly installed even if you already have client library.
To build this app:
1. Open the virtualBox installation directory. In this directory, you should found the client library (VBoxClient.dll). If your system is 64-bit os, you should take the files from x86 directory because this is 32 bit app.
2. copy this file to some place on your pc and rename it as "Interop.VirtualBox.dll"
3. open project dir and then place this dll in obj\x86\release folder.
4. Download [https://visualstudio.com](Microsoft Visual Studio 2010 or higher). It can be a demo version or Visual Studio Community Edition. We need only command-line tools bundled with it. **Warning**! You must install the Visual Basic component as this app is written in Visual Basic.
5. Open the Visual Studio Command Prompt and then change directory to the folder where you downloaded or cloned the app.
6. Run the following:
`MsBuild VirtualBoxAccessableStarter.vbproj`
7. The resulting file can be found in the `bin/release` folder. Warning! The `Interop.VirtualBox.dll` file, placed in building results directory, is the VirtualBox Main Api library. It must be placed in same directory with application file to it will be able to communicate with VirtualBox. Also you need to copy localisations files if you vont to app will be fully localized.

## License
This software is distributed under the GNU GPL V3 license (see the License file in the root of the repository).  
Copyrihgt © 2018, Ilya Paschuk.
=======
