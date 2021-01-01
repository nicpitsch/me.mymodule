"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Me.MyModule.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
