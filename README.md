# SuperLauncher

TODO: Add more for non-technical users.

## Building

If you want to build from source, it's a bit complicated. There are two things included in
SuperLauncher's repository - SuperLauncher, the client application, and the web application
that runs the world/mod/skin/texture pack/etc repositories. You only have to build the
client application - it will use the global repositories like normal.

### Building SharpLauncher

To build, you may use msbuild or xbuild like normal, or Visual Studio, SharpDevelop, Mono
Develop, etc. However, SuperLauncher depends on webkit for certain parts of the UI
(namely, those that access the web repository). Eventually, I'll add a post-build task
to copy these, but for now, manually copy the contents of lib/webkit/ to your bin folder.
Then, you will be able to run SharpLauncher.

### Building web

The web project is simple, you can build it like any other MVC 3 project. If you want to use
it, though, you need to set it up in IIS (or any other web server), with a hostname of
`slreposervice.com`, which is where SharpLauncher looks for the repository. You also need to
modify your hosts file so that `slreposervice.com` points to your local instance, rather
than the global one.