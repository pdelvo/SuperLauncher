# SuperLauncher

TODO: Add more for non-technical users.

## Building

To build SuperLauncher, you simply need to do the following command at the root of the repository
(Windows only):

    msbuild.exe

If you want to use the web project locally, you should add it to a local IIS instance and create
a SQL database using create_tables.sql. Update the `web.config` with the connection string, and
fill in other details (described in a comment at the top of the file).