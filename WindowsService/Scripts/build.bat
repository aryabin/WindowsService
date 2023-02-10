@echo off
set DOTNET=%programfiles%\Microsoft Visual Studio\2022\Preview\MSBuild\Current\Bin
set ZIP=%ProgramFiles%\7-Zip
set PATH=%PATH%;%DOTNET%;%ZIP%
set OUTPUTPATH=..\Output
echo Building Extendable Windows Service...
echo ---------------------------------------------------
rem clear OUTPUTPATH
if exist %OUTPUTPATH% rmdir /S /Q %OUTPUTPATH%
mkdir %OUTPUTPATH%
rem BUILD
msbuild ..\WindowsService.sln /p:Configuration=Release /p:Platform="Any CPU" /p:OutDir=%OUTPUTPATH%
xcopy /f /y install.bat %OUTPUTPATH%
xcopy /f /y uninstall.bat %OUTPUTPATH%
rem ZIP
7z a -tzip "%OUTPUTPATH%\ExtendableWindowsService.zip" "%OUTPUTPATH%\*.*" -mx5 -x!*.zip -x!*.pdb
echo ---------------------------------------------------
echo Done.
pause