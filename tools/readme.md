# Installing Visual Studio

To simplify installing Visual Studio the provided `.vsconfig` has the workloads and components needed by the course. To use this file do the following.

1. Go to the download [link](https://visualstudio.microsoft.com/downloads/) for Visual studio.
1. Download the installer for `Visual Studio Community` and run it.
1. In the installer select the option to use an exported configuration.
1. Select the provided `.vsconfig` file.
1. Set the destination where Visual Studio should be installed.
1. Click `Install` to install Visual Studio

# Configuring Visual Studio

To provide a more consistent environment between class and home you may optionally use the provided `.vssettings` file to adjust Visual Studio to use the same settings. To use this file do the following.

1. Open Visual Studio.
1. Go to `Tools\Import and Export Settings`.
1. Select the option to import.
1. Optionally back up your existing settings.
1. Use the `Browse` button to find the `.vssettings` file in your repository and click `Next`.
1. Select the top checkbox to import all the existing settings and click `Finish`.

After importing the settings be sure to go to `Tools\Options` and then `Projects and Solutions\Locations` and adjust the default location for projects to use your repository folder so you do not have to change it each time.
