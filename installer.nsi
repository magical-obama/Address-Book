;-------------------------------------------------------------------------------
; Includes
!include "MUI2.nsh"
!include "LogicLib.nsh"
!include "WinVer.nsh"
!include "x64.nsh"

;-------------------------------------------------------------------------------
; Constants
!define PRODUCT_NAME "Address Book"
!define PRODUCT_DESCRIPTION "Address Book for Windows"
!define COPYRIGHT "Copyright © 2022 Maximilian Schwärzler"
!define PRODUCT_VERSION "1.0.0.0"
!define SETUP_VERSION 1.0.0.0

;-------------------------------------------------------------------------------
; Attributes
Name "Address Book"
OutFile "install.exe"
InstallDir "$LOCALAPPDATA\Address Book"
;InstallDirRegKey HKCU "Software\My Company\My Application" ""
RequestExecutionLevel user ; user|highest|admin

;-------------------------------------------------------------------------------
; Version Info
VIProductVersion "${PRODUCT_VERSION}"
VIAddVersionKey "ProductName" "${PRODUCT_NAME}"
VIAddVersionKey "ProductVersion" "${PRODUCT_VERSION}"
VIAddVersionKey "FileDescription" "${PRODUCT_DESCRIPTION}"
VIAddVersionKey "LegalCopyright" "${COPYRIGHT}"
VIAddVersionKey "FileVersion" "${SETUP_VERSION}"

;-------------------------------------------------------------------------------
; Modern UI Appearance
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Header\orange.bmp"
!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange.bmp"
!define MUI_FINISHPAGE_NOAUTOCLOSE

;-------------------------------------------------------------------------------
; Installer Pages
!insertmacro MUI_PAGE_WELCOME
;!insertmacro MUI_PAGE_LICENSE "LICENCE"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH

;-------------------------------------------------------------------------------
; Uninstaller Pages
!insertmacro MUI_UNPAGE_WELCOME
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

;-------------------------------------------------------------------------------
; Languages
!insertmacro MUI_LANGUAGE "English"

;-------------------------------------------------------------------------------
; Installer Sections
Section "My Application" MyApp
	SetOutPath $INSTDIR
	File /r "bin\Release\net6.0-windows\publish\win-x64\"
	CreateShortCut "$SMPROGRAMS\Address Book.lnk" "$INSTDIR\Address Book.exe"
	WriteUninstaller "$INSTDIR\Uninstall.exe"
SectionEnd

;-------------------------------------------------------------------------------
; Uninstaller Sections
Section "Uninstall"
	Delete "$INSTDIR\Uninstall.exe"
	Delete "$SMPROGRAMS\Address Book.lnk"
	RMDir /r "$INSTDIR"
	;DeleteRegKey /ifempty HKCU "Software\Modern UI Test"
SectionEnd

