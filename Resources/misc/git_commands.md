# Notes

* If you do not want a file to be considered for committing, include its name in the `.gitignore` file contained in the main repository.

# Git Commands

> *Note that words within curly braces {} represent placeholders and should be replaced.*

**Authentication**

* `git config --global user.name "{Your GitHub username}"` --> Set your global repository.
    * Confirm proper settings with `git config --global user.name`

* `git config --global user.email "{Your GitHub email}"` --> Set your global repository.
    * Confirm proper settings with `git config --global user.email`

> Note: For setting credentials only for one local repository, omit the `--global` flag.

**Add**

* `git add {file_name}` --> Stage file for it to be included in the next commit.

* `git add -A` --> Stage all files for them to be included in the next commit.

**Commit**

* `git commit -m "{Your message}"` --> Add a commit to the local repository with a given message as denoted by the `-m` flag.
    * The message is important for you to be able to keep track of the changes applied in this commit.
    * If you forget to add a message and simply use `git commit`, the `vim` editor will open. To insert a message in `vim`, follow these instructions:
        * Press `i` to enter `--INSERT--` mode.
        * Type your message.
        * Press `esc` to exit `--INSERT--` mode.
        * Press `:` to enter command mode.
        * Enter `wq` or `x`, and press `return`.
        > `w` stands for write. `q` stands for quit. `x` is an abbreviation of `wq`.

* `git commit -a -m "{Your message}"` --> Add and commit all files in one command.

**Push**

* `git push` --> Push changes from the local repository to the remote repository.

**Pull**

* `git pull` --> Pull changes from the remote repository to the local repository.

**Clone**

* `git clone {GitHub repository} .` --> Clone remote repository to current folder (as per the `.`).
