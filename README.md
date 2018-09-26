# VirtualBox Accessable Starter

This small and very simple application solves most importent accessability ishue of [VirtualBox Virtualisation selution](http://virtualbox.org), and makes it accessable for screenreader users,
It Can make accessable guest controls in vm window, that is fully unaccessable for blind users in new vbox versions by starting vm by special way.

## details

The cause of inaccessability of guest controls is that vm process is hardened to prevent other applications to crash the vm.
To work with app, ScreenReader need to enject code to it's process. It can not to do it with protected vm process.
VBox has salution of this problem. This is a special vm running mode, called "separate" mode.
In this mode, VirtualBox starts vm in background mode and then start interface to control it in separate process.
This gui process is not hardened and accessable for many screenreaders. The hardened vm process are staying in background.

This app makes that easily.
You need only start this app and then double click on your vm name or press enter key on it. App automaticly starts it by passing the "--type separate" command line argument to VBoxManage.

## Build

To build this app:
1. Download VisualStudeo 2010 or higher. It can be iwen unregistered version. We need only command line tools, bundled with it. Warning! You must install visual basic component because this app written on VisualBasic.
2. Open the visual studeo command line and then change directory to download place.
3. Run:
`MsBuild VirtualBoxAccessableStarter.vbproj`
4. Builded file can be found in bin\release dir.


