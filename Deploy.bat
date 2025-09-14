@echo off
echo ========================================
echo    Dinawin ERP Deployment Script
echo ========================================
echo.

echo Step 0: Pulling latest changes from Git...
echo ========================================
cd /d "%~dp0.."
git pull

if %ERRORLEVEL% neq 0 (
    echo WARNING: Git pull failed or no changes to pull!
    echo Continuing with deployment...
)

echo.
echo Returning to BackEnd directory...
cd /d "%~dp0"

REM Set variables
set SOLUTION_PATH=%~dp0
set PUBLISH_PATH=C:\inetpub\wwwroot\ERP\SourceCode\BackEnd\Publish
set IIS_PATH=C:\inetpub\wwwroot\ERP\BackEnd
set APP_NAME=ERPServices
set POOL_NAME=ERPServices

echo Step 1: Compiling and Publishing Solution...
echo ========================================
cd /d "%SOLUTION_PATH%"
dotnet publish Presentation\Dinawin.Erp.WebApi\Dinawin.Erp.WebApi.csproj -c Release -o "%PUBLISH_PATH%" --self-contained false

if %ERRORLEVEL% neq 0 (
    echo ERROR: Build failed!
    pause
    exit /b 1
)

echo.
echo Step 2: Stopping IIS Application and Application Pool...
echo ========================================
echo Stopping application: %APP_NAME%
appcmd stop app "%APP_NAME%"

echo Stopping application pool: %POOL_NAME%
appcmd stop apppool "%POOL_NAME%"

echo.
echo Step 3: Copying files to IIS folder...
echo ========================================
echo Copying from: %PUBLISH_PATH%
echo Copying to: %IIS_PATH%

REM Create destination directory if it doesn't exist
if not exist "%IIS_PATH%" (
    echo Creating directory: %IIS_PATH%
    mkdir "%IIS_PATH%"
)

REM Copy files (excluding some unnecessary files)
robocopy "%PUBLISH_PATH%" "%IIS_PATH%" /E /XD bin obj /XF *.pdb *.xml /R:3 /W:1

echo.
echo Step 3.1: Configuring web.config for Production...
echo ========================================
REM Copy production web.config
if exist "web.Production.config" (
    copy "web.Production.config" "%IIS_PATH%\web.config" /Y
    echo Production web.config applied successfully
) else (
    echo WARNING: web.Production.config not found, using default web.config
)

if %ERRORLEVEL% geq 8 (
    echo ERROR: Copy operation failed!
    pause
    exit /b 1
)

echo.
echo Step 4: Starting IIS Application...
echo ========================================
echo Starting application pool: %POOL_NAME%
appcmd start apppool "%POOL_NAME%"

echo Starting application: %APP_NAME%
appcmd start app "%APP_NAME%"

echo.
echo ========================================
echo    Deployment Completed Successfully!
echo ========================================
echo.
echo Application: %APP_NAME%
echo Pool: %POOL_NAME%
echo Published to: %IIS_PATH%
echo.
pause
