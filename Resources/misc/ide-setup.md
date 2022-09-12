# Editor

Unity needs the usage of an IDE (Integrated Development Environment) for writing scripts.

Unity scrips are written in C#. This document walks you through setting up Visual Studio and VSCode.

Note that for this class we will be using **Visual Studio** and not VSCode. However, the installation process for VSCode has been included in case this becomes your IDE of choice in the future.


## Visual Studio Installation

> *Note that you are likely to install Visual Studio when installing Unity from the Unity Hub. Follow these instructions if you did not install it or if you wish to reinstall it.*

1. [Download Visual Studio](https://visualstudio.microsoft.com).

2. Install Visual Studio and follow the installation prompts. When asked what packages to install, the .NET package should be sufficient for the purposes of this class.

3. Launch Visual Studio. You may ignore the login prompt as we will be using our personal edition.


## VSCode Installation

1. Download and Install VSCode.

2. Install C# extension from the VSCode Extension Marketplace

3. Create a `.cs` file.

4. If you see the following error `The .NET Core SDK cannot be located. .NET Core debugging will not be enabled. Make sure the .NET Core SDK is install and is on the path.`, follow these instructions:

    1. [Download .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/sdk-for-vs-doce).

        * If you are on an M1 Mac, download the **Arm64** version of the SDK.

    2. Add .NET SDK to the PATH using the following command:
    
    > `echo 'export PATH=$PATH:usr/local/share/dotnet/dotnet' >> ~/.zshrc`


## Troubleshooting

* Select your Unity IDE in the following path within the Unity Editor application:

> Preferences > External Tools > External Script Editor

* If IntelliSense isn't working in VisualStudio, got to the External Script Editor menu listed above, and make sure that all the `Generate .csproj files for:` options are checked. Then click on the `Regenerate project files` button.
