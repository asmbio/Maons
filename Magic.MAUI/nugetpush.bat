
@echo off
CD /D "%~dp0"
: Your script begin here

===================================================================
CD /D "%~dp0"
cd /d bin\Debug

for /f %%a in ('dir /o-d /tc /b *.nupkg') do (
set pkg=%%~na%%~xa
::echo filename: !pkg!, createtime:	%%~ta
goto end
)

:end

nuget push %pkg% -Source http://3s1772q347.zicp.vip:38799/nuget glorysoft_123_EAP
pause
