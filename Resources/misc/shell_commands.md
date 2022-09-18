# Notes

* In the terminal/shell, `.` represents the current directory.


# Shell Commands

> *Note that words within curly braces {} represent placeholders and should be replaced.*

* `pwd` --> Show current path

* `mkdir {dir_name}` --> Create new directory

* `cd` --> Go to home directory
* `cd ..` --> Go to parent directory
    * You can navigate your system file using the `cd` command. Use `..` to go to parent folders, and `/` to go into a folder:
        * e.g., `cd ../path/in/parent/folder`

* `touch {file_name}` --> Create new file. When creating files this way, include the extension.

* `ls` --> List files and folders in folder.
* `ls -A` --> List all destinations in folder, including hidden files.
    * As opposed to `-a` flag, `-A` does not list implied paths, such as `.` and `..`

* `rm {file_name}` --> Remove specified file. This command also works for empty folders.
* `rm -r {folder_name}` --> Remove specified folder, and every file contained.
    * The `-r` causes the `rm` command to execute recursively, meaning over and over again for all the contents of the folder until reaching the root (i.e., the specified folder).
    * **Be very careful with this command!!**


# Setting Up the Code Command to Open Scripts with VSCode

To be able to use the `code` command in a terminal to open scripts with VSCode, follow these instructions:

1. Make sure VSCode is on your Applications folder.

2. Open VSCode and open the Command Palette with the shortcut **Shift + Command + P**.

3. Type `shell command`, and choose the **Shell Command: Install 'code' command in PATH** option.

## Usage

* `code {file_name}` --> Open script with VSCode. Include the file extension.
