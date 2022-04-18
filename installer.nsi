;-------------------------------------------------------------------------------
; Includes
!include "MUI2.nsh"
!include "LogicLib.nsh"
!include "WinVer.nsh"
!include "x64.nsh"
!include "FileFunc.nsh"

;-------------------------------------------------------------------------------
; Constants
!define PRODUCT_NAME "Address Book"
!define PRODUCT_DESCRIPTION "Address Book for Windows"
!define COPYRIGHT "Copyright © 2022 Maximilian Schwaerzler"
!define PRODUCT_VERSION "1.0.0.0"
!define SETUP_VERSION 1.0.0.0
!define ARP "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"

;-------------------------------------------------------------------------------
; Attributes
Name "Address Book"
OutFile "Installer.exe"
InstallDir "$LOCALAPPDATA\Address Book"
InstallDirRegKey HKCU "Software\Max\Address Book" ""
RequestExecutionLevel admin ; user|highest|admin

;-------------------------------------------------------------------------------
; Version Info
VIProductVersion "${PRODUCT_VERSION}"
VIAddVersionKey "ProductName" "${PRODUCT_NAME}"
VIAddVersionKey "CompanyName" "Maximilian Schwaerzler"
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
!define MUI_FINISHPAGE_RUN "$INSTDIR\Address Book.exe"
!define MUI_FINISHPAGE_NOAUTOCLOSE

;-------------------------------------------------------------------------------
; Installer Pages
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "LICENSE"
;!insertmacro MUI_PAGE_COMPONENTS
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
Section "Install"
	SetOutPath $INSTDIR
	File /r "bin\Release\net6.0-windows\publish\win-x64\"
	CreateShortCut "$SMPROGRAMS\Address Book.lnk" "$INSTDIR\Address Book.exe"
	WriteUninstaller "$INSTDIR\Uninstall.exe"
	WriteRegStr HKLM "${ARP}" "DisplayName" "Address Book"
	WriteRegStr HKLM "${ARP}" "UninstallString" "$\"$INSTDIR\Uninstall.exe$\""

	${GetSize} "$INSTDIR" "/S=0K" $0 $1 $2
 	IntFmt $0 "0x%08X" $0
 	WriteRegDWORD HKLM "${ARP}" "EstimatedSize" "$0"
SectionEnd

;-------------------------------------------------------------------------------
; Uninstaller Sections
Section "Uninstall"
	Delete "$SMPROGRAMS\Address Book.lnk"
	RMDir /r "$INSTDIR"
	DeleteRegKey HKLM "${ARP}"
	Delete "$INSTDIR\Uninstall.exe"
SectionEnd

