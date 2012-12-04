# SuperLauncher

TODO: Add more for non-technical users.

## Building

To build SuperLauncher, you simply need to do the following command at the root of the repository
(Windows only):

    msbuild.exe

If you want to use the web project locally, you should add it to a local IIS instance and install
[this database provider](http://sourceforge.net/projects/sqlite-dotnet2/files/). Then, set up your
hosts file to point www.slreposervice.com to localhost, and SuperLauncher will use your local
instance. The site uses Entity Framework, so you can probably swap out the database provider if you
want.