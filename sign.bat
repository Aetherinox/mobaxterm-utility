@ECHO 	    OFF
TITLE 	    Aetherx - Signtool
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

    TITLE Aetherx - Signtool Missing [Error]

    %echo%   Press any key to acknowledge error and try anyway  ...
    PAUSE >nul
    cls
)

:: -----------------------------------------------------------------------------------------------------
::  remove trailing slash
:: -----------------------------------------------------------------------------------------------------

IF %dir_home:~-1%==\ SET dir_home=%dir_home:~0,-1%

:: -----------------------------------------------------------------------------------------------------
:: func:    NEXT
::          continue script
:: -----------------------------------------------------------------------------------------------------

:NEXT

    %echo%   Select an option:
    %echo%          1     Sign EXE              /Bin/Release
    %echo%          2     Sign EXE + DLL        Current folder
    %echo%. 
    %echo%.
    set /P v_input_cs_type="     Enter Choice: "
    %echo%.

    if [!v_input_cs_type!]==[] (
        %echo%   No choice provided, defaulting to OPTION
        %echo%.
        GOTO SIGN_EXE_SUBFOLDERS
    )

    if /I "%v_input_cs_type%" EQU "1" (
        GOTO SIGN_EXE_SUBFOLDERS
    )

    if /I "%v_input_cs_type%" EQU "2" (
        GOTO SIGN_EXE_DLL_CUROLDER
    ) else (
        %echo%.
        %echo%   Unrecognized Option !v_input_cs_type!
        %echo%.

        goto NEXT
    )

:: -----------------------------------------------------------------------------------------------------
:: func:    SIGN > EXE ONLY > SUBFOLDER
::          sign exe subfolders
:: -----------------------------------------------------------------------------------------------------

:SIGN_EXE_SUBFOLDERS

    for /R "bin/Release/" %%f in ( *.exe ) do (
        call signtool sign /sha1 "%CERT_THUMBPRINT%" /fd SHA256 /d "Aetherx" /du "https://github.com/Aetherinox" /t http://timestamp.comodoca.com/authenticode "%%f"
    )

    goto FINISH

:: -----------------------------------------------------------------------------------------------------
:: func:    SIGN > EXE + DLL > CURRENT FOLDER
::          sign exe, dll current folder
:: -----------------------------------------------------------------------------------------------------

:SIGN_EXE_DLL_CUROLDER

    :: -----------------------------------------------------------------------------------------------------
    ::  sign DLL
    :: -----------------------------------------------------------------------------------------------------

    for %%f in ( *.dll )  do (
        call signtool sign /sha1 "%CERT_THUMBPRINT%" /fd SHA256 /d "Aetherx" /du "https://github.com/Aetherinox" /t http://timestamp.comodoca.com/authenticode "%%f"
    )

    :: -----------------------------------------------------------------------------------------------------
    ::  sign EXE
    :: -----------------------------------------------------------------------------------------------------

    for %%f in ( *.exe )  do (
        call signtool sign /sha1 "%CERT_THUMBPRINT%" /fd SHA256 /d "Aetherx" /du "https://github.com/Aetherinox" /t http://timestamp.comodoca.com/authenticode "%%f"
    )

    goto FINISH

:: -----------------------------------------------------------------------------------------------------
::  finish
:: -----------------------------------------------------------------------------------------------------

:FINISH

    %echo%.
    %echo%.

    timeout /t 1 /nobreak >nul
    TITLE Aetherx - Signtool (Complete)
    %echo%.
    %echo%.
    %echo%   Press any key to close utility
    PAUSE >nul
    
Exit /B 0