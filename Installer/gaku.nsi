!define MAJOR 0
!define MINOR 8
!define REVISION 686
!define VERSION "${MAJOR}.${MINOR}.${REVISION}"
!define APP_NAME "Gaku"
!define COMPANY_NAME "piksel bitworks"
!define PRODUCT_NAME "Gaku"
!define PROGEXE "Gaku.exe"
!define UNINSTALL_FILENAME "uninstall.exe"
!define UPDATE_URL "http://p1k.se/gaku"


  !define MUI_ICON "..\icon.ico"
  SetCompressor /SOLID lzma
  
!define MULTIUSER_INSTALLMODE_INSTDIR "${APP_NAME}"
!define MULTIUSER_INSTALLMODE_INSTALL_REGISTRY_KEY "${APP_NAME}" 
!define MULTIUSER_INSTALLMODE_UNINSTALL_REGISTRY_KEY "${APP_NAME}"
!define MULTIUSER_INSTALLMODE_DEFAULT_REGISTRY_VALUENAME "UninstallString"
!define MULTIUSER_INSTALLMODE_INSTDIR_REGISTRY_VALUENAME "InstallLocation"
!define MULTIUSER_INSTALLMODE_DISPLAYNAME "${APP_NAME}"
!define MULTIUSER_INSTALLMODE_ALLOW_ELEVATION
!define MULTIUSER_INSTALLMODE_DEFAULT_ALLUSERS

; Add plugin directories (DLLs) to the search path
!addplugindir /x86-ansi ".\NsisMultiUser\Plugins\x86-ansi\"
!addplugindir /x86-unicode ".\NsisMultiUser\Plugins\x86-unicode\"

; Include the path to header files
!addincludedir ".\NsisMultiUser\Include\"
!include "NsisMultiUser.nsh" 

;--------------------------------
;Includes

;Modern UI
!define MULTIUSER_MUI
!define MULTIUSER_INSTALLMODE_COMMANDLINE
!include MUI2.nsh

;Utility
!include FileFunc.nsh
!include LogicLib.nsh
!include UAC.nsh
 

;--------------------------------
;General

  Name "Gaku"
  OutFile "gaku-installer.exe"
  Icon "..\icon.ico"

;--------------------------------
; Version

VIAddVersionKey /LANG=0 "ProductName" "Gaku"
VIAddVersionKey /LANG=0 "Comments" "http://p1k.se/gaku"
VIAddVersionKey /LANG=0 "CompanyName" "piksel bitworks"
VIAddVersionKey /LANG=0 "LegalCopyright" "© 2016, piksel bitworks"
VIAddVersionKey /LANG=0 "FileDescription" "Gaku Image Viewer"
VIAddVersionKey /LANG=0 "FileVersion" "${VERSION}"
VIProductVersion ${VERSION}.0
  
;--------------------------------
;Interface Configuration

  !define MUI_HEADERIMAGE
  !define MUI_HEADERIMAGE_BITMAP "header.bmp"
  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_COMPONENTS
  
  !insertmacro MULTIUSER_PAGE_INSTALLMODE
  
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !define MUI_FINISHPAGE_RUN "$INSTDIR\Gaku.exe"
  !insertmacro MUI_PAGE_FINISH

  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Gaku (required)" SecGaku
  SectionIn RO
  SetOutPath "$INSTDIR"
  
  ; Install .NET 4.5 if needed
  Call CheckAndDownloadDotNet45
  
  File "..\bin\Release\Gaku.exe"
  File "..\bin\Release\gaku-document.ico"
  File "..\bin\Release\Imgur.API.dll"
  File "..\bin\Release\Newtonsoft.Json.dll"
  File "..\bin\Release\YamlDotNet.dll"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\Modern UI Test" "" $INSTDIR
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\uninstall.exe"
  
  ; Add registry keys
  !insertmacro MULTIUSER_RegistryAddInstallInfo

SectionEnd

Section "Start Menu Shortcut"
	CreateShortCut "$SMPROGRAMS\${PRODUCT_NAME}.lnk" "$INSTDIR\${PROGEXE}" "" "$INSTDIR\${PROGEXE}" 0
SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecGaku 0 "Gaku main program"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecGaku} $(DESC_SecGaku)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END
 
;--------------------------------
;Uninstaller Section

Section "Uninstall"

  Delete "$INSTDIR\Gaku.exe"
  Delete "$INSTDIR\gaku-document.ico"
  Delete "$INSTDIR\Imgur.API.dll"
  Delete "$INSTDIR\Newtonsoft.Json.dll"
  Delete "$INSTDIR\YamlDotNet.dll"

  Delete "$INSTDIR\Uninstall.exe"

  RMDir "$INSTDIR"

  ; Remove registry keys
  !insertmacro MULTIUSER_RegistryRemoveInstallInfo

SectionEnd

Function .onInit
  !insertmacro MULTIUSER_INIT
FunctionEnd

Function un.onInit
  !insertmacro MULTIUSER_UNINIT
FunctionEnd

 Function CheckAndDownloadDotNet45
	# Let's see if the user has the .NET Framework 4.5 installed on their system or not
	# Remember: you need Vista SP2 or 7 SP1.  It is built in to Windows 8, and not needed
	# In case you're wondering, running this code on Windows 8 will correctly return is_equal
	# or is_greater (maybe Microsoft releases .NET 4.5 SP1 for example)
 
	# Set up our Variables
	Var /GLOBAL dotNET45IsThere
	Var /GLOBAL dotNET_CMD_LINE
	Var /GLOBAL EXIT_CODE
 
        # We are reading a version release DWORD that Microsoft says is the documented
        # way to determine if .NET Framework 4.5 is installed
	ReadRegDWORD $dotNET45IsThere HKLM "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" "Release"
	IntCmp $dotNET45IsThere 378389 is_equal is_less is_greater
 
	is_equal:
		Goto done_compare_not_needed
	is_greater:
		# Useful if, for example, Microsoft releases .NET 4.5 SP1
		# We want to be able to simply skip install since it's not
		# needed on this system
		Goto done_compare_not_needed
	is_less:
		Goto done_compare_needed
 
	done_compare_needed:
		#.NET Framework 4.5 install is *NEEDED*
 
		# Microsoft Download Center EXE:
		# Web Bootstrapper: http://go.microsoft.com/fwlink/?LinkId=225704
		# Full Download: http://go.microsoft.com/fwlink/?LinkId=225702
 
		# Setup looks for components\dotNET45Full.exe relative to the install EXE location
		# This allows the installer to be placed on a USB stick (for computers without internet connections)
		# If the .NET Framework 4.5 installer is *NOT* found, Setup will connect to Microsoft's website
		# and download it for you
 
		# Reboot Required with these Exit Codes:
		# 1641 or 3010
 
		# Command Line Switches:
		# /showrmui /passive /norestart
 
		# Silent Command Line Switches:
		# /q /norestart
 
 
		# Let's see if the user is doing a Silent install or not
		IfSilent is_quiet is_not_quiet
 
		is_quiet:
			StrCpy $dotNET_CMD_LINE "/q /norestart"
			Goto LookForLocalFile
		is_not_quiet:
			StrCpy $dotNET_CMD_LINE "/showrmui /passive /norestart"
			Goto LookForLocalFile
 
		LookForLocalFile:
			# Let's see if the user stored the Full Installer
			IfFileExists "$EXEPATH\components\dotNET45Full.exe" do_local_install do_network_install
 
			do_local_install:
				# .NET Framework found on the local disk.  Use this copy
 
				ExecWait '"$EXEPATH\components\dotNET45Full.exe" $dotNET_CMD_LINE' $EXIT_CODE
				Goto is_reboot_requested
 
			# Now, let's Download the .NET
			do_network_install:
 
				Var /GLOBAL dotNetDidDownload
				NSISdl::download "http://go.microsoft.com/fwlink/?LinkId=225704" "$TEMP\dotNET45Web.exe" $dotNetDidDownload
 
				StrCmp $dotNetDidDownload success fail
				success:
					ExecWait '"$TEMP\dotNET45Web.exe" $dotNET_CMD_LINE' $EXIT_CODE
					Goto is_reboot_requested
 
				fail:
					MessageBox MB_OK|MB_ICONEXCLAMATION "Unable to download .NET Framework.  ${PRODUCT_NAME} will be installed, but will not function without the Framework!"
					Goto done_dotNET_function
 
				# $EXIT_CODE contains the return codes.  1641 and 3010 means a Reboot has been requested
				is_reboot_requested:
					${If} $EXIT_CODE = 1641
					${OrIf} $EXIT_CODE = 3010
						SetRebootFlag true
					${EndIf}
 
	done_compare_not_needed:
		# Done dotNET Install
		Goto done_dotNET_function
 
	#exit the function
	done_dotNET_function:
 
FunctionEnd