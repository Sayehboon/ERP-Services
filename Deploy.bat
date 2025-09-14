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
dotnet publish Presentation\Dinawin.Erp.WebApi\Dinawin.Erp.WebApi.csproj -c Release -o "%PUBLISH_PATH%" --self-contained false -p:GenerateDocumentationFile=true

if %ERRORLEVEL% neq 0 (
    echo ERROR: Build failed!
    pause
    exit /b 1
)

echo.
echo Step 1.1: Verifying XML documentation files...
echo ========================================
if exist "%PUBLISH_PATH%\Dinawin.Erp.WebApi.xml" (
    echo ✓ WebApi XML documentation found
) else (
    echo ✗ WARNING: WebApi XML documentation not found
)

if exist "%PUBLISH_PATH%\Dinawin.Erp.Application.xml" (
    echo ✓ Application XML documentation found
) else (
    echo ✗ WARNING: Application XML documentation not found
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

REM Copy only wwwroot folder for static files
if exist "%PUBLISH_PATH%\wwwroot" (
    echo Copying wwwroot folder...
    robocopy "%PUBLISH_PATH%\wwwroot" "%IIS_PATH%\wwwroot" /E /R:3 /W:1
    echo ✓ wwwroot folder copied successfully
) else (
    echo ✗ WARNING: wwwroot folder not found in publish directory
)

echo.
echo Step 3.1: Verifying Swagger custom files...
echo ========================================
if exist "%IIS_PATH%\wwwroot\swagger-ui\custom.css" (
    echo ✓ Swagger custom CSS found in production
) else (
    echo ✗ WARNING: Swagger custom CSS not found in production
)

if exist "%IIS_PATH%\wwwroot\swagger-ui\custom.js" (
    echo ✓ Swagger custom JS found in production
) else (
    echo ✗ WARNING: Swagger custom JS not found in production
)

echo.
echo Step 3.2: Configuring web.config for Production...
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
