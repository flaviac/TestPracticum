@echo Building TestPraticum_GFT...@echo off
"%ProgramFiles(x86)%\MSBuild\12.0\Bin\MSBuild.exe" TestPraticum.sln /t:Clean;Build /p:OutDir=..\output\ && ".\packages\NUnit.Runners.2.6.4\tools\nunit-console.exe" .\output\TestPraticum.Tests.dll /wait
