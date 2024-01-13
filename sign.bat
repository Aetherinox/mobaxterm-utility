@ECHO 	    OFF
TITLE 	    Aetherx - Signtool)
SETLOCAL 	ENABLEDELAYEDEXPANSION
MODE        con:cols=125 lines=30
MODE        125,30
GOTO 		comment_end

-----------------------------------------------------------------------------------------------------

Aetherx - Signtool

Signs an exe or dll dragged onto the executable.

-----------------------------------------------------------------------------------------------------

:comment_end

ECHO.

SET dir_home=%~dp0
SET dir_lib=.lib
SET CERT_THUMBPRINT=58a1539d6988d76f44bae27c27ed5645d3b1222a
SET echo=ECHO

:: -----------------------------------------------------------------------------------------------------
::  define:     libraries
::              DO NOT EDIT
:: -----------------------------------------------------------------------------------------------------


:: -----------------------------------------------------------------------------------------------------
::  define:     gpg library
:: -----------------------------------------------------------------------------------------------------

SET signtool=signtool

:: -----------------------------------------------------------------------------------------------------
::  config file
:: -----------------------------------------------------------------------------------------------------

for /F "tokens=*" %%I in ( %file_cfg% ) do set %%I

:: -----------------------------------------------------------------------------------------------------
::  define:     signtool
::              attempt to locate signtool via where command
:: -----------------------------------------------------------------------------------------------------

WHERE /Q %signtool%

IF !ERRORLEVEL! NEQ 0 (
    cls
    %echo%   ERROR
    %echo%   This script has detected that the command %signtool% is not accessible.
    %echo%.

    TITLE Signtool Missing [Error]

    %echo%   Press any key to acknowledge error and try anyway  ...
    PAUSE >nul
    cls
)

:: -----------------------------------------------------------------------------------------------------
::  remove trailing slash
:: -----------------------------------------------------------------------------------------------------

IF %dir_home:~-1%==\ SET dir_home=%dir_home:~0,-1%

:: -----------------------------------------------------------------------------------------------------
::  sign each file
:: -----------------------------------------------------------------------------------------------------

for /R "bin/Release/" %%f in (*.exe) do (
    call signtool sign /sha1 "%CERT_THUMBPRINT%" /fd SHA256 /t http://timestamp.comodoca.com/authenticode "%%f"
)

:: -----------------------------------------------------------------------------------------------------
::  finish
:: -----------------------------------------------------------------------------------------------------

%echo%.
%echo%.

timeout /t 1 /nobreak >nul
TITLE Aetherx - Sign (Complete)

%echo%   Press any key to close utility
PAUSE >nul
Exit /B 0