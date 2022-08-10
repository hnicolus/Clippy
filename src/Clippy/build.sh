dotnet restore -r osx-x64
dotnet msbuild -t:BundleApp -p:RuntimeIdentifier=osx-x64 -p:CFBundleDisplayName=Clippy -property:Configuration=Release -p:UseAppHost=true