# Editor

Unity needs the usage of an IDE (Integrated Development Environment) for writing scripts.

Unity scrips are written in C#.

## VSCode Installation

1. Download and Install VSCode

2. Install C# extension from the VSCode Extension Marketplace

3. Create a `.cs` file.

4. If you see the following error `The .NET Core SDK cannot be located. .NET Core debugging will not be enabled. Make sure the .NET Core SDK is install and is on the path.`, follow these instructions:

    1. [Download .NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet/sdk-for-vs-doce).

        * If you are on an M1 Mac, download the **Arm64** version of the SDK.

    2. Add .NET SDK to the PATH using the following command:
    
    > `echo 'export PATH=$PATH:usr/local/share/dotnet/dotnet' >> ~/.zshrc`

## Set VSCode as your IDE in Unity

* Preferences > External Tools > External Script Editor
