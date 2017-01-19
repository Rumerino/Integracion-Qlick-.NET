@SETLOCAL ENABLEEXTENSIONS
@cd /d "%~dp0"

@REM Specify your project's '.csproj', '.sln' file paths
SET ORIG=C:\Users\ruben.merino\Desktop\Esmash\eSmash hc
SET PROJECTPATH=C:\Users\ruben.merino\Desktop\Esmash\eSmash hc\eSmasheSmash.csproj
SET SOLUTIONPATH=C:\Users\ruben.merino\Desktop\Esmash\eSmash hc\eSmash.sln
SET OUTPUTPATH=C:\Users\ruben.merino\Desktop\Compilacion

SET NUGETPATH=C:\Users\ruben.merino\Desktop\nuget.exe
SET MSBUILDPATH=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe
SET COMPILATIONMODE=Debug
cls
rd %OUTPUTPATH% /S /Q
%NUGETPATH% restore %SOLUTIONPATH%

%MSBUILDPATH% %PROJECTPATH% /fl /P:Configuration=%COMPILATIONMODE% /P:Platform=AnyCPU /p:CleanWebProjectOutputDir=False /p:WebProjectOutputDir="%OUTPUTPATH%\\" /p:Outdir="%OUTPUTPATH%\bin\\" /T:_WPPCopyWebApplication /T:ResolveReferences /p:VisualStudioVersion=14.0
xcopy /Y /F /E /H "%ORIG%" "%OUTPUTPATH%\*" /S
rem del "%OUTPUTPATH%"