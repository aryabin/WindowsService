@echo off
set DOTNET=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\
set PATH=%PATH%;%DOTNET%
echo Installing Extendable Windows Service...
echo ---------------------------------------------------
InstallUtil /i WinService.exe
echo ---------------------------------------------------
echo Done.
pause