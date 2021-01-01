XCOPY "..\Client\bin\Debug\net5.0\Me.MyModule.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Client\bin\Debug\net5.0\Me.MyModule.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Server\bin\Debug\net5.0\Me.MyModule.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Server\bin\Debug\net5.0\Me.MyModule.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Shared\bin\Debug\net5.0\Me.MyModule.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Shared\bin\Debug\net5.0\Me.MyModule.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net5.0\" /Y
XCOPY "..\Server\wwwroot\Modules\Me.MyModule\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\Me.MyModule\" /Y /S /I
