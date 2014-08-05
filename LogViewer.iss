; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{0A394502-72E0-4697-B145-BF758773DD29}
AppName=LogViewer
AppVersion=1.0
;AppVerName=LogViewer 1.0
DefaultDirName={pf}\LogViewer
DefaultGroupName=LogViewer
AllowNoIcons=yes
OutputDir=C:\Users\thaivm\Desktop\Installer
OutputBaseFilename=LogViewer
SetupIconFile=C:\Users\thaivm\Desktop\LV.ico
Compression=lzma
SolidCompression=yes
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
;Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "D:\LogViewer\LogViewer\bin\Release\LogViewer.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\LogViewer\LogViewer\bin\Release\System.Windows.Controls.DataVisualization.Toolkit.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\LogViewer\LogViewer\bin\Release\System.Windows.Interactivity.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\LogViewer\LogViewer\bin\Release\WPFToolkit.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\LogViewer\LogViewer\bin\Release\EnableNET35.bat"; DestDir: "{app}"; Flags: ignoreversion
;Source: "D:\LogViewer\LogViewer\bin\Release\InstallConfig.bat"; DestDir: "{app}"; Flags: ignoreversion
;Source: "D:\LogViewer\LogViewer\bin\Release\FileConfig"; DestDir: "{app}\FileConfig"; Flags: ignoreversion recursesubdirs createallsubdirs
;Source: "D:\LogViewer\LogViewer\bin\Release\ActionList"; DestDir: "{app}\ActionList"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\LogViewer\LogViewer\bin\Release\FileConfig"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\LogViewer\LogViewer\bin\Release\ActionList"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\LogViewer\LogViewer\bin\Release\Memo"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "D:\LogViewer\LogViewer\Images\*"; DestDir: "{app}\Images"; Flags: ignoreversion recursesubdirs createallsubdirs
[Icons]
Name: "{group}\LogViewer"; Filename: "{app}\LogViewer.exe"
Name: "{group}\{cm:UninstallProgram,LogViewer}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\LogViewer"; Filename: "{app}\LogViewer.exe"; Tasks: desktopicon; IconFilename: "{app}\Images\LV.ico"
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\LogViewer"; Filename: "{app}\LogViewer.exe"; Tasks: quicklaunchicon

[Run]
FileName: "{app}\EnableNET35.bat"; Check: CheckForFramework; Flags: waituntilterminated
;Filename: "D:\LogViewer_new\LogViewer\lib\dotnetfx35SP1"; Parameters: "/q:a /c:""install /l /q"""; Check: CheckForFramework; StatusMsg: Microsoft Framework 3.5 is being installed. Please wait...
FileName: "{app}\InstallConfig.bat"; Flags: waituntilterminated postinstall runhidden
Filename: "{app}\LogViewer.exe"; Description: "{cm:LaunchProgram,LogViewer}"; Flags: nowait postinstall skipifsilent
[Dirs]
Name: "{app}\"; Permissions: everyone-modify
;Name: "{app}\"; Permissions: admins-modify
;Name: "{app}\"; Permissions: users-modify
[UninstallDelete]
Type: filesandordirs; Name: "{app}"
[Code]
procedure CurPageChanged(CurPageID: Integer);
begin
  // you must do this as late as possible, because the RunList is being modified
  // after installation; so this will check if there's at least one item in the
  // RunList and then set to the first item (indexing starts at 0) Enabled state
  // to False
  if (CurPageID = wpFinished) and (WizardForm.RunList.Items.Count > 0) then
    WizardForm.RunList.ItemEnabled[0] := False;
end;
function CreateBatch(): boolean;
var
  fileName : string;
  fromActionList : string;
  toActionList : string;
  fromFileConfig : string;
  toFileConfig : string;
  lines : TArrayOfString;
begin
  Result := true;
  fileName := ExpandConstant('{app}\InstallConfig.bat');
  fromFileConfig := ExpandConstant('{src}\FileConfig');
  toFileConfig := ExpandConstant('{app}\FileConfig');
  fromActionList := ExpandConstant('{src}\ActionList');
  toActionList := ExpandConstant('{app}\ActionList');
  SetArrayLength(lines, 3);
  lines[0] := 'xcopy /s ' + FromFileConfig + ' "' + ToFileConfig + '"';
  lines[1] := 'xcopy /s ' + fromActionList + ' "' + toActionList + '"';
  Result := SaveStringsToFile(filename,lines,true);
  exit;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  if  CurStep=ssPostInstall then
   begin
         CreateBatch();
    end
end;
//  checks for framework 3.5 full
Function CheckForFramework : boolean;
Var
  regresult : cardinal;
Begin
  RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v3.5', 'Install', regresult);
  If regresult = 0 Then
    Begin
      Result := true;
    End
  Else
    Result := false;
End;
//  checks for uninstall when install new version    ////////
Function GetNumber(var temp: String): Integer;
var
  part: String;
  pos1: Integer;
begin
  if Length(temp) = 0 then
  begin
    Result := -1;
    Exit;
  end;
    pos1 := Pos('.', temp);
    if (pos1 = 0) then
    begin
      Result := StrToInt(temp);
    temp := '';
    end
    else
    begin
    part := Copy(temp, 1, pos1 - 1);
      temp := Copy(temp, pos1 + 1, Length(temp));
      Result := StrToInt(part);
    end;
end;

Function CompareInner(var temp1, temp2: String): Integer;
var
  num1, num2: Integer;
begin
    num1 := GetNumber(temp1);
  num2 := GetNumber(temp2);
  if (num1 = -1) or (num2 = -1) then
  begin
    Result := 0;
    Exit;
  end;
      if (num1 > num2) then
      begin
        Result := 1;
      end
      else if (num1 < num2) then
      begin
        Result := -1;
      end
      else
      begin
        Result := CompareInner(temp1, temp2);
      end;
end;

Function CompareVersion(str1, str2: String): Integer;
var
  temp1, temp2: String;
begin
    temp1 := str1;
    temp2 := str2;
    Result := CompareInner(temp1, temp2);
end;

Function InitializeSetup(): Boolean;
var
  oldVersion: String;
  uninstaller: String;
  ErrorCode: Integer;

begin
  if RegKeyExists(HKEY_LOCAL_MACHINE,
    'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0A394502-72E0-4697-B145-BF758773DD29}_is1') then
  begin
    RegQueryStringValue(HKEY_LOCAL_MACHINE,
      'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0A394502-72E0-4697-B145-BF758773DD29}_is1',
      'DisplayVersion', oldVersion);
    if (CompareVersion(oldVersion, '1.0') <= 0) then
      begin
        if MsgBox('Version ' + oldVersion + ' of LogViewer is already installed. Continue to install this new version?',
          mbConfirmation, MB_YESNO) = IDYES then
          begin
            RegQueryStringValue(HKEY_LOCAL_MACHINE,
              'SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{0A394502-72E0-4697-B145-BF758773DD29}_is1',
              'UninstallString', uninstaller);
              ShellExec('runas', uninstaller, '/SILENT', '', SW_HIDE, ewWaitUntilTerminated, ErrorCode);
              Result := True;
          end
        else
          begin
          Result := False;
        end;
      end
    else
      begin
        //MsgBox('Version ' + oldVersion + ' of LogViewer is already installed. This installer will exit.',
          //mbInformation, MB_OK);
        Result := False;
      end;
  end
  else
  begin
    Result := True;
  end;
end;

///////////////////