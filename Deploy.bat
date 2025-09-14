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

REM Copy all application files (excluding config files that will be handled separately)
echo Copying application files...
robocopy "%PUBLISH_PATH%" "%IIS_PATH%" /E /XD bin obj /XF *.pdb /R:3 /W:1
echo ✓ Application files copied successfully

REM Keep existing config files in deploy folder - they are customized
echo ✓ Preserving existing config files in deploy folder (if any)

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
REM Copy web.config from deploy folder (publish path) to production
REM Only copy if web.config doesn't already exist in production
if exist "%PUBLISH_PATH%\web.config" (
    if not exist "%IIS_PATH%\web.config" (
        copy "%PUBLISH_PATH%\web.config" "%IIS_PATH%\web.config"
        echo ✓ web.config copied from deploy folder to production
    ) else (
        echo ⚠ web.config already exists in production - skipping override
    )
) else (
    echo ⚠ web.config not found in deploy folder - using default
)

echo.
echo Step 3.3: Configuring appsettings for Production...
echo ========================================
REM Copy appsettings.Production.json from deploy folder (publish path) to production
REM Only copy if appsettings.Production.json doesn't already exist in production
if exist "%PUBLISH_PATH%\appsettings.Production.json" (
    if not exist "%IIS_PATH%\appsettings.Production.json" (
        copy "%PUBLISH_PATH%\appsettings.Production.json" "%IIS_PATH%\appsettings.Production.json"
        echo ✓ appsettings.Production.json copied from deploy folder to production
    ) else (
        echo ⚠ appsettings.Production.json already exists in production - skipping override
    )
) else (
    echo ⚠ appsettings.Production.json not found in deploy folder - using default
)

if %ERRORLEVEL% geq 8 (
    echo ERROR: Copy operation failed!
    pause
    exit /b 1
)

echo.
echo Step 3.4: Verifying static files accessibility...
echo ========================================
echo Checking if custom files are accessible:
echo - Custom CSS: %IIS_PATH%\wwwroot\swagger-ui\custom.css
echo - Custom JS: %IIS_PATH%\wwwroot\swagger-ui\custom.js

if exist "%IIS_PATH%\wwwroot\swagger-ui\custom.css" (
    echo ✓ Custom CSS file exists in production
) else (
    echo ✗ Custom CSS file missing in production
)

if exist "%IIS_PATH%\wwwroot\swagger-ui\custom.js" (
    echo ✓ Custom JS file exists in production
) else (
    echo ✗ Custom JS file missing in production
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
