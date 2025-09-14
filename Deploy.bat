@echo off
setlocal enabledelayedexpansion

echo ========================================
echo    Dinawin ERP Deployment Script
echo ========================================
echo.

REM ========================================
REM Configuration Variables
REM ========================================
set SOLUTION_PATH=%~dp0
set PUBLISH_PATH=C:\inetpub\wwwroot\ERP\SourceCode\BackEnd\Publish
set IIS_PATH=C:\inetpub\wwwroot\ERP\BackEnd
set APP_NAME=ERPServices
set POOL_NAME=ERPServices

REM ========================================
REM Step 0: Git Pull
REM ========================================
echo Step 0: Pulling latest changes from Git...
echo ========================================
cd /d "%~dp0.."
git pull
if %ERRORLEVEL% neq 0 (
    echo WARNING: Git pull failed or no changes to pull!
    echo Continuing with deployment...
)
cd /d "%~dp0"

REM ========================================
REM Step 1: Build and Publish
REM ========================================
echo.
echo Step 1: Compiling and Publishing Solution...
echo ========================================
cd /d "%SOLUTION_PATH%"
dotnet publish Presentation\Dinawin.Erp.WebApi\Dinawin.Erp.WebApi.csproj -c Release -o "%PUBLISH_PATH%" --self-contained false -p:GenerateDocumentationFile=true

if %ERRORLEVEL% neq 0 (
    echo ERROR: Build failed!
    pause
    exit /b 1
)

REM Verify XML documentation
echo.
echo Step 1.1: Verifying XML documentation files...
echo ========================================
call :CheckFile "%PUBLISH_PATH%\Dinawin.Erp.WebApi.xml" "WebApi XML documentation"
call :CheckFile "%PUBLISH_PATH%\Dinawin.Erp.Application.xml" "Application XML documentation"

REM ========================================
REM Step 2: Stop IIS Services
REM ========================================
echo.
echo Step 2: Stopping IIS Application and Application Pool...
echo ========================================
echo Stopping application pool: %POOL_NAME%
appcmd stop apppool "%POOL_NAME%"

echo Stopping application: %APP_NAME%
appcmd stop app /app.name:"%APP_NAME%"

REM ========================================
REM Step 3: Deploy Files
REM ========================================
echo.
echo Step 3: Deploying Application Files...
echo ========================================
echo Copying from: %PUBLISH_PATH%
echo Copying to: %IIS_PATH%

REM Create destination directory if it doesn't exist
if not exist "%IIS_PATH%" (
    echo Creating directory: %IIS_PATH%
    mkdir "%IIS_PATH%"
)

REM Copy application files
echo Copying application files...
robocopy "%PUBLISH_PATH%" "%IIS_PATH%" /E /XD bin obj /XF *.pdb /R:3 /W:1 /NFL /NDL
if %ERRORLEVEL% geq 8 (
    echo ERROR: Copy operation failed!
    pause
    exit /b 1
)
echo ✓ Application files copied successfully

REM ========================================
REM Step 4: Configure Production Settings
REM ========================================
echo.
echo Step 4: Configuring Production Settings...
echo ========================================

REM Configure web.config
call :CopyConfigFile "%PUBLISH_PATH%\web.config" "%IIS_PATH%\web.config" "web.config"

REM Configure appsettings
call :CopyConfigFile "%PUBLISH_PATH%\appsettings.Production.json" "%IIS_PATH%\appsettings.Production.json" "appsettings.Production.json"

REM ========================================
REM Step 5: Verify Deployment
REM ========================================
echo.
echo Step 5: Verifying Deployment...
echo ========================================

REM Verify Swagger custom files
call :CheckFile "%IIS_PATH%\wwwroot\swagger-ui\custom.css" "Swagger custom CSS"
call :CheckFile "%IIS_PATH%\wwwroot\swagger-ui\custom.js" "Swagger custom JS"

REM ========================================
REM Step 6: Start IIS Services
REM ========================================
echo.
echo Step 6: Starting IIS Application...
echo ========================================

REM Set permissions
echo Setting permissions for IIS_IUSRS on application folder...
icacls "%IIS_PATH%" /grant "IIS_IUSRS:(OI)(CI)F" /T /Q >nul 2>&1

REM Start application pool
echo Starting application pool: %POOL_NAME%
appcmd start apppool "%POOL_NAME%"
if %ERRORLEVEL% neq 0 (
    echo WARNING: Failed to start application pool, trying to restart...
    appcmd stop apppool "%POOL_NAME%"
    timeout /t 2 /nobreak >nul
    appcmd start apppool "%POOL_NAME%"
)

REM Start application
echo Starting application: %APP_NAME%
appcmd start app /app.name:"%APP_NAME%"
if %ERRORLEVEL% neq 0 (
    echo WARNING: Failed to start application, checking status...
    appcmd list app "%APP_NAME%"
)

REM ========================================
REM Deployment Complete
REM ========================================
echo.
echo ========================================
echo    Deployment Completed Successfully!
echo ========================================
echo.
echo Application: %APP_NAME%
echo Pool: %POOL_NAME%
echo Published to: %IIS_PATH%
echo.
echo You can now access your application at:
echo https://ErpServices.baaz.ir/swagger
echo.
pause
exit /b 0

REM ========================================
REM Helper Functions
REM ========================================

:CheckFile
set "file_path=%~1"
set "file_desc=%~2"
if exist "%file_path%" (
    echo ✓ %file_desc% found
) else (
    echo ✗ WARNING: %file_desc% not found
)
goto :eof

:CopyConfigFile
set "source_file=%~1"
set "dest_file=%~2"
set "file_desc=%~3"
if exist "%source_file%" (
    if not exist "%dest_file%" (
        copy "%source_file%" "%dest_file%" >nul 2>&1
        echo ✓ %file_desc% copied to production
    ) else (
        echo ⚠ %file_desc% already exists in production - skipping override
    )
) else (
    echo ⚠ %file_desc% not found in source - using default
)
goto :eof