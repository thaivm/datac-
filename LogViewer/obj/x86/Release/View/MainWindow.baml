   M S B A M L   `   `   `  ���� D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:LogViewer.ViewLogViewer.View  ;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5clr-namespace:LogViewer.ServiceLogViewer.Service  /clr-namespace:LogViewer.UtilLogViewer.Util  ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  c _System.Windows.Interactivity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     LogViewer.View.MainWindow   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    +viewclr-namespace:LogViewer.View    1mvvm"clr-namespace:LogViewer.MVVMHelper    1Serviceclr-namespace:LogViewer.Service    +Utilclr-namespace:LogViewer.Util    7
properties"clr-namespace:LogViewer.Properties    \iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity    3my&clr-namespace:System;assembly=mscorlib    >d2http://schemas.microsoft.com/expression/blend/2008    Hmc;http://schemas.openxmlformats.org/markup-compatibility/2006    ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  %  LogViewer.Service.DialogService    IsRegisteredView  . $   LogViewer.Properties.Resources   	LogViewer � Title# Z $��11(�$
��1200��$	��720�� � WindowStartupLocation$ CenterScreen=� � Icon$( "/LogViewer;component/Images/LV.png�� � WindowState$ 	Maximized=� � 	Resources    TBCCSToolTip �� RelativeSource �� Mode	 �� AncestorType
 �� Path  TBCXDIToolTip  	BoolToVis,   &LogViewer.MVVMHelper.FontSizeConverter  FontSizeConverter+   %LogViewer.MVVMHelper.CommandReference  ExpandCommandReference   Command  ShrinkCommandReference ! SearchKeywordCommandReference  
MenuButton �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value  LogsMenuButton �� BasedOn 	 MenuToggleButton 
 LogsNarrowFilterButton  ReadOnlyCellTextBoxStyle,   &LogViewer.MVVMHelper.RichTextBoxHelper'   !LogViewer.MVVMHelper.BindingProxy  MainViewProxy   Data��%  &	        &	 m     &	 �     &	 �     &	 �     &	     &	 $    &	 K    &	 �    7  &		     &	
 �    7 	 &	 �    &	 p    �� 
���  ������  �� $ FindAncestor=�"	 ��$2
 ,(Validation.Errors).CurrentItem.ErrorContent��� 
���  ������  �� $ FindAncestor=�"	 ��$2
 ,(Validation.Errors).CurrentItem.ErrorContent���      �� *ExpandCommand+   �� *ShrinkCommand+   �� *SearchKeywordCommand+�� " ��.���  � ��$ 30����  � ��$ 30�� P�  � {� . . ���  � ��
 �����P�  � {� .  . ���  � ��
 ������� " ��8   .���  � {� �� *HasLogsData+�� " d�.���  � ��$ 30����  � ��$ 30�� P�  � {� . . ���  � ��
 �����P�  � {� .  . ���  � ��
 ������� " d�8   .���  � {� �� *IsEnableButtonFilter+�� " ��.���  �@��
IsReadOnly . ��  � ��$ 0q���  �@ FilterToShow �� *FilterSetting+   ��  J� InputBindings �� 
 �� Key$ F�� �� 	Modifiers$
 Ctrlf� �� Command# [ �� $ Oemplus��$
 Ctrlf�# [ �� $ OemMinus��$
 Ctrlf�# [ d� ,  &LogViewer.MVVMHelper.MouseWheelGesture   CtrlDown d� Gesture# Z # [ d�    CtrlUp# Z # [ .���  � RowDefinitions �� $��20 ��� $��* �.+�o� $	��Top=�$��0��
�������.@�m�    _File#��Z .@�m�    _OpenEtc#��Z .@�m�    
CCSLogFile#��Z  m� Command �� *CCSMainVM.LoadLogFileCommand+m�     CCSMemoLogFile#��Z   �� *" CCSMainVM.LoadMemoLogFileCommand+m� !   CXDILogFile#��Z!  �� *CXDIMainVM.LoadLogFileCommand+m� "   CXDIMemoLogFile#��Z"  �� *#!CXDIMainVM.LoadMemoLogFileCommand+m� #   
_ExportEtc#��Z# .@�m� #��Z   �� *$"CCSMainVM.ExportMemoLogFileCommand+m� #��Z"  �� *%#CXDIMainVM.ExportMemoLogFileCommand+#   LogViewer.Util.RecentFileList  -   $  Name$$ RecentFileList��%   
RecentFile% �� *RecentFileAction+m� -   &   _Quit#��Z& m� '   _Edit#��Z' .@�m� (   _SetLogParameter#��Z(  �� *SetLogParameterCommand+m� -   )   _ResetBookmarks#��Z)  �� *ResetBookmarkCommand+m� -   *   _ResetComments#��Z*  �� *ResetCommentCommand+m� +   _ResetFilters#��Z+  �� *ResetFilterCommand+m� ,   _ResetColorFilters#��Z,  �� * ClearColorFilterSettingCommand+m� -   _ClearAnalyzedResult#��Z-  �� *ClearAnalyzeCommand+m� .   	_ClearAll#��Z.  �� *ClearAllCommand+m� /   _Option#��Z/ .@�m� -   $��Search��0   _Search#��Z0  �� *SearchKeywordCommand+� $��Stretch=�$��Stretch=�$��1�� �� $��* �1 � ColumnDefinitions1 �� $��1* ��� $
��Auto ��� $��1* �.+��� 
�������$��1q�$��Stretch=�$��Stretch=�$��0��$��0��2 � DataContext2 �� *	CCSMainVM+   	MainProxy��%   &	          �� ._��  �� $��30 ��� $��30 ��� $��90 ��� $��* ��� $
��Auto ��� $��* �.+�� -   $��CCS_Title_Panel��$��Stretch=�$	��Top=�$��0��1 �� $��1* ��� $��6* �.+��� -   $��CCSTitleLabel��$��0��$��0��$	��CCS��$��5,0,0,0q��� 
���  ��$��Center=�$��1��$	��800��$��WrapWithOverflow=�$��CharacterEllipsis=����� *CurrentLogFileName+3 � ToolTip3 �� $	��400��$
��Wrap=����� *CurrentLogFileName+� 4 � Orientation$4 
Horizontal=�  WrapPanelShortcut#��[ $��1��.+�� $4 
Horizontal=�#��[ .+��� $3 	Open file��#��[ ���� *LoadLogFileCommand+.���� 5 �� Orientation$5 
Horizontal=�.+��� $.��(/LogViewer;component/Images/openfile.png���� $3 	Clear All��#��[ ���� *ClearAllCommand+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� -   $3 Clear Analyzed Result��#��[ ���� *ClearAnalyzeCommand+.���� $5 
Horizontal=�.+��� $-��'/LogViewer;component/Images/refresh.png���� $3 Expand��#��[ ���� *ExpandCommand+.���� $5 
Horizontal=�.+��� $+��%/LogViewer;component/Images/add_e.png��$3 Expand���� $3 Shrink��#��[ ���� *ShirnkCommand+.���� $5 
Horizontal=�.+��� $.��(/LogViewer;component/Images/delete_e.png��� $4 
Horizontal=�#��[ .+��� $3 	Go to Top��#��[ ���� *GoToTopCommand+.���� $5 
Horizontal=�.+��� $/��)/LogViewer;component/Images/gototop_e.png���� $3 Go to Bottom��#��[ ���� *GoToBotCommand+.���� $5 
Horizontal=�.+��� $/��)/LogViewer;component/Images/gotobot_e.png���� $3 Move to line��#��[ ���� *JumpToLineCommand+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/gotoline_e.png���� $3 Move to time��#��[ ���� *JumpToTimeCommand+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/gotodate_e.png��� $4 
Horizontal=�#��[ .+��� $3 Calculate Process Time��#��[ ���� *ProcessTimeCommand+.���� $5 
Horizontal=�.+��� $*��$/LogViewer;component/Images/time.png���� $3 Error action��#��[ ���� *ErrorActionCommand+.���� $5 
Horizontal=�.+��� $+��%/LogViewer;component/Images/Error.png���� $3 User action��#��[ ���� *UserActionCommand+.���� $5 
Horizontal=�.+��� $,��&/LogViewer;component/Images/user_e.png���� $3 Pattern Analyzing��#��[ ���� *PatternAnalyserCommand+.���� $5 
Horizontal=�.+��� $1��+/LogViewer;component/Images/analyzing_e.png���� $3 Count Keyword��#��[ ���� *CountKeywordCommand+.���� $5 
Horizontal=�.+��� $.��(/LogViewer;component/Images/countkey.png���� $3 Set Pattern��#��[ ���� *EditPatternSettingCommand+.���� $5 
Horizontal=�.+��� $-��'/LogViewer;component/Images/pattern.png���� $3 Set Keyword��#��[ ���� * EditKeywordCountSettingCommand+.���� $5 
Horizontal=�.+��� $)��#/LogViewer;component/Images/key.png���� $3 
Set Filter��#��[ ���� *EditFilterSettingCommand+.���� $5 
Horizontal=�.+��� $,��&/LogViewer;component/Images/filter.png���   WrapPanelFilter#��[ $��2��.+�� $��5,0,0,0q�.+��� -	   $��FilterCCSLabel��$��Center=�6   FilterColon#��Z6 �� .u��� -
   $��FilterCCSTextBox��$	��200��$��Center=����� *StringFilter+7 �� Mode$7 TwoWay=�8 �� UpdateSourceTrigger$8 PropertyChanged=�9 �� ValidatesOnDataErrors9 . .����1&clr-namespace:System;assembly=mscorlibSystem �� 0sys&clr-namespace:System;assembly=mscorlib  " ��: �� 	Resources:   CueBannerBrush; j� 
AlignmentX< j� 
AlignmentY= j� Stretch> !� Visual?   PleaseInputFilterString��%M   &	       !� $
; Left=�$< Center=�$
= None=�> �� #��Z? 
������� P�  � ��@ �� Empty# Z@ . ���  � ��# [ P�  � �� Z� . ���  � ��# [ P�  �@J�IsKeyboardFocused . . ���  � ��
 �����P�  �@=�HasError . . ���  �@�ToolTip# [ ��  �@^�InitialShowDelay$ 0��.���� -   $��ContentCCSComboBox��A �� DisplayMemberPath$A Display��B �� SelectedValuePath$B Value��$��Center=�C �� SelectedValueC �� *	LogItem+$7 TwoWay=�9 . $8 PropertyChanged=����� *LogItemList+d� -   $!��tbtnCCSNarrowFilterNonColor��$3 Refine Filtering��#��[
 D d� 	IsCheckedD �� *IsOnNarrowNonColorFilter+$7 TwoWay=����� *NarrowNonColorFilterCommand+.���� $5 
Horizontal=�.+��� $1��+/LogViewer;component/Images/refinecolor.png��d� -   $��tbtnCCSNarrowFilterColor��$3 Color Filtering��#��[
 D �� *IsOnNarrowColorFilter+$7 TwoWay=����� *NarrowColorFilterCommand+.���� $5 
Horizontal=�.+��� $1��+/LogViewer;component/Images/filtercolor.png��� $��5,5,0,0q�.+�� E � 	StaysOpenE .  F � AllowsTransparencyF . ���� *IsOpenPopup+.����   BorderColorFilterArena#��[ ._��� $5 Vertical=�.+���   BorderColorFilterRow#��[ ._�� $
��Left=�.+���   ButtonCollapseColorFilter#��[ $��5������ *ClosePopupCommand+�� #��[ ._��� $��Center=�$��5q�.+�%	   LogViewer.View.FilterButtonArea	  %
   LogViewer.View.FilterButtonAreaG 
  ButtonClicked$G RefreshCCSLogsList��H 	  ItemsSourceRemainH �� *FilterSettingList+�� #��[ ._�� $��Center=�.+��   WrapColorButtonBottom#��[ .+��� -   I   	SelectAll#��ZI ���� *SelectAllFilterSettingCommand+�� 
J   Add#��ZJ ���� *EditFilterSettingCommand+�� -   K   Clear#��ZK ���� * ClearColorFilterSettingCommand+�   WrapColorFilter_NF#��[ .+��� #��[ $��4������ *OpenPopupCommand+� -   $��CSSColorButtonArenaNF��  WrapColorButtonFilter#��[ .+�	  $G RefreshCCSLogsList��L 	  ItemsSourceSummaryL �� *FilterSettingList+� $y�Visible=�$��3��.+�� 2 �� *LogsDisplayVM+ �� $��* ��� $��30 �.+�)  #Microsoft.Windows.Controls.DataGrid  -   $��DataLogCCSDisplay��M   EnableRowVirtualizationM . !N   EnableColumnVirtualizationN .  O   AutoGenerateColumnsO .  P   CanUserAddRowsP .  $��0��$	��430��Q   CanUserReorderColumnsQ .  R   CanUserSortColumnsR .  S   CanUserResizeRowsS .  T J� 	AllowDropT . $	��5,0q�)  #LogViewer.MVVMHelper.DatagridHelperU   
ClickedRowU �� *ClickedRecord+$7 OneWayToSource=����� *FontOfDataGrid+V �� 	Converter#V [ ���� *BaseRecordVMList+$7 TwoWay=�W   RecordToShowW �� *RecordForJump+X   RecordToFollowX �� *RecordForFollow+Y   RefreshDataY �� *RefreshData+  	 proxy  AddMoreBookmarkReferenceZ �� Source��%R   &	       &	      7     ��    �� *Data.AddMoreBookmark+8Z    �� $ Space��# [ [   RowStyle[ �� ,  &Microsoft.Windows.Controls.DataGridRow"  .�-   .  (System.Windows.Interactivity.Interaction\   	Behaviors\ 3   -LogViewer.MVVMHelper.DataGridDragDropBehavior  ]   AllowedEffects$	] All=�^   Command^ �� *Data.DragDropCommand+#Z [ _ � ContextMenu_ �� $��Center=�.@�m� `   Copy#��Z`  �� *Data.CopyCommand+#Z [ �� a   
FollowMode#��Za D �� *Data.IsOnFollowModeCCS+#Z [ %   LogViewer.MVVMHelper.DataPipingb   	DataPipesb -   'LogViewer.MVVMHelper.DataPipeCollection  #   LogViewer.MVVMHelper.DataPipe  c   Sourcec ��  �� "	  $
 SelectedItems�d   Targetd �� $
 SelectedItems�$7 OneWayToSource=�e   Columnse 7  1Microsoft.Windows.Controls.DataGridTemplateColumn  /  )Microsoft.Windows.Controls.DataGridColumnf   
Visibilityf �� *Data.IsDisplayBookmark+#V [ #Z [ g   CellTemplateg �� .R��� $��Center=�$��Center=�D �� $
 IsBookmarked�$7 TwoWay=�$8 PropertyChanged=����� $
 BookmarkCommand�����   h   Linei   Header#i Zh j   Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$j 50 k   MinWidth$k 50Q�f �� *Data.IsDisplayLine+#V [ #Z [ g �� .R��� $
��Line��#��[ $��50��l   DocumentXamll �� $

 Line�$7 OneWay=�m   LineOfContentm �� $

 Line�$7 OneWay=� �� $ Space��# [   n   Date#i Zn $j 75 $k 75Q�f �� *Data.IsDisplayDate+#V [ #Z [ g �� .R��� $
��Date��#��[ $��75��l �� $

 Date�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   o   Time#i Zo $j 75 $k 75Q�f �� *Data.IsDisplayTime+#V [ #Z [ g �� .R��� $
��Time��#��[ $��75��l �� $

 Time�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   p   HostName#i Zp $	j 150 $	k 150Q�f �� *Data.IsDisplayHostName+#V [ #Z [ g �� .R��� $��HostName��#��[ $	��150��l �� $
 HostName�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   q   ThreadId#i Zq $j 75 $k 75Q�f �� *Data.IsDisplayThreadID+#V [ #Z [ g �� .R��� $��ThreadId��#��[ $��75��l �� $
 ThreadId�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   r   Type#i Zr $j 60 $k 60Q�f �� *Data.IsDisplayType+#V [ #Z [ g �� .R��� $��LogType��#��[ $��60��l �� $

 Type�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   	s   Id#i Zs $	j 100 $	k 100Q�f �� *Data.IsDisplayID+#V [ #Z [ g �� .R��� $��LogId��#��[ $	��100��l �� $
 Id�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   t   Content#i Zt $
j 1000 $
k 1000Q�f �� *Data.IsDisplayContent+#V [ #Z [ g �� .R��� $��Content��#��[ $
��1000��l �� $
 Content�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   u   AdditionalInfo#i Zu $	j 400 $	k 400Q�f �� *Data.IsDisplayAdditionalInfo+#V [ #Z [ g �� .R��� $��AdditionalInfo��#��[ $	��400��l �� $
 AdditionalInfo�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   v   PersonalInfo#i Zv $	j 400 $	k 400Q�f �� *Data.IsDisplayPersonalInfo+#V [ #Z [ g �� .R��� $��PersonalInfo��#��[ $	��400��l �� $
 PersonalInfo�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   w   	ClassName#i Zw $	j 400 $	k 400Q�f �� *Data.IsDisplayClassName+#V [ #Z [ g �� .R��� $��	ClassName��#��[ $	��400��l �� $
 	ClassName�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   x   Comment#i Zx $	j 200 $	k 200Q�f �� *Data.IsDisplayComment+#V [ #Z [ g �� .R��� ���� $
 Comment�$7 TwoWay=�$8 PropertyChanged=�� $4 
Horizontal=�$��Bottom=�$��1��.+��� -   $��CCSProcessLabel��y   ProcessTimeColon#��Zy �� -   $��CCSProcessFileLabel��
���  ������ *ProcessTime+�� $��Stretch=�$��Bottom=�$��4��z �� ResizeBehavior$z PreviousAndNext=�$��3�����	#FFBCBCBC]�   DockPanelLogReport#��[ $��Stretch=�$��Stretch=�$��5��$��5,0,0,0q�.+��� -   $��TabControlCCS��$
��Auto��  TabControlLogReport#��[ T .  2 �� *BaseAnalyzeAreaVM+.@��� {   	Bookmarks#��Z{ $��2q�| �� 
IsSelected| �� *IsShowTabBookmark+2 �� *LogBookmarkTabVM+.��� .+�� .+�  -   O .  $��Stretch=�P .  Q .  S .  R .  }   CanUserDeleteRows} . ~   DoubleClickedRow~ �� *DoubleClickedRecord+$7 OneWayToSource=����� *LogRecordList+ @  :Microsoft.Windows.Controls.Primitives.DataGridColumnHeader-  'Microsoft.Windows.Controls.DataGridCell  DataGridCellCenter��%x   '        &	 %     &	 L     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�   �� b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItems�$7 OneWayToSource=�_ �� .@�m� #��Z`  �� *Data.CopyCommand+#Z [ [ �� "  .�-   e 3  -Microsoft.Windows.Controls.DataGridTextColumn  $j 50 $k 50Q�#i Zh 4  .Microsoft.Windows.Controls.DataGridBoundColumn   Binding �� $

 Line�$7 OneWay=�  $j 75 $k 75Q�#i Zn  �� $

 Date�$7 OneWay=�  $j 75 $k 75Q�#i Zo  �� $

 Time�$7 OneWay=�  $j 60 $k 60Q�#i Zr  �� $

 Type�$7 OneWay=�  #i Zt $
j 1000  �� $
 Content�$7 OneWay=��� $��2q��   Error#��Z� | �� *IsShowTabError+2 �� *ErrorActionTabVM+.��� .+�� .+�  -   O .  P .  M . N . $��5��$��0��$��Stretch=�Q .  S .  R .  ~ �� *DoubleClickedRecord+$7 OneWayToSource=����� *ErrorActionList+ ��%x   '        &	 %     &	 L     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�   �� _ �� .@�m� #��Z`  �� *Data.CopyCommand+#Z [ b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItems�$7 OneWayToSource=�[ �� "  .�-   e   $j 50 $k 50Q�#i Zh  �� $

 Line�$7 OneWay=�  $j 75 $k 75Q�#i Zn  �� $

 Date�$7 OneWay=�  $j 75 $k 75Q�#i Zo  �� $

 Time�$7 OneWay=�  $j 60 $k 60Q��   LogType#i Z�  �� $
 LogType�$7 OneWay=�  $j 80 $k 80Q��   	ErrorCode#i Z�  �� $
 	ErrorCode�$7 OneWay=�  $	j 270 $	k 200Q��   Message#i Z�  �� $
 Message�$7 OneWay=�  $i Recipe��$	j 800  �� $
 Recipe�$7 OneWay=�� 1 �� �� �� .+�� $��1��1 �� �� .+�� $��Right=�� � IsIndeterminate� . $��80��$��20��y��� *IsLoadingData+#V [ �� $��1��$��0q�$��20��$��20��$��Stretch=�$
��Left=�y��� *IsLoadingData+#V [ ���� *CancelError+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� $��2q��   
UserAction#��Z� | �� *IsShowTabUserAction+2 �� *UserActionTabVM+.��� .+�� .+�  -   O .  P .  $��Stretch=�M . N . $��5��$��0��Q .  �   CanUserResizeColumns� . S .  R .  ~ �� *DoubleClickedRecord+$7 OneWayToSource=����� *UserActionList+ ��%x   '        &	 %     &	 L     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�   �� _ �� .@�m� #��Z`  �� *Data.CopyCommand+#Z [ b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItems�$7 OneWayToSource=�[ �� "  .�-   e   $j 50 $k 50Q�#i Zh  �� $

 Line�$7 OneWay=�  $j 75 $k 75Q�#i Zn  �� $

 Date�$7 OneWay=�  $j 75 $k 75Q�#i Zo  �� $

 Time�$7 OneWay=�  $j * #i Z�  �� $
 
UserAction�$7 OneWay=�� 1 �� �� �� .+�� $��1��1 �� �� .+�� $��Right=�� . $��80��$��20��y��� *IsLoadingData+#V [ �� $��1��$��0q�$��20��$��20��$��Stretch=�$
��Left=�y��� *IsLoadingData+#V [ ���� *CancelUserAction+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� $��2q��   PatternAnalyzed#��Z� $	��100��| �� *IsShowTabPattern+2 �� *LogPatternTabVM+.��� .+�� 1 �� $��1* ��� $��1* �.+�  -   O .  P .  $��Stretch=�$��0��$��0,0,10,0q�Q .  � .  S .  R .  �   SelectionMode$� Single=�~ �� * DoubleClickedPatternResultItem+$7 OneWayToSource=����� *PatternRecordList+ ��%`   '        &	 %     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�e   $j * �   Name#i Z�  �� $

 Name�$7 OneWay=�  $j 90 $k 90Q��   Count#i Z�  �� $
 Count�$7 OneWay=�[ �� "  .�-     -   O .  P .  $�   HorizontalScrollBarVisibility$
� Auto=�$��Stretch=�$��1��$��10,0,0,0q�Q .  � .  S .  R .  $� Single=�~ �� *DoubleClickedRecord+$7 OneWayToSource=����� *CurrentPatternItem.LogRecords+ ��%`   '        &	 %     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�e   $j 90 $k 90Q�#i Zh  �� $

 Line�$7 OneWay=�  $j * #i Zt k �� *ActualWidth+ �� $
 Self=� �� $
 Content�$7 OneWay=�[ �� "  .�-   � 1 �� �� �� .+�� $��1��1 �� �� .+�� $��Right=�� . $��80��$��20��y��� *IsLoadingData+#V [ �� $��1��$��0q�$��20��$��20��$��Stretch=�$
��Left=�y��� *IsLoadingData+#V [ ���� *CancelPatternAnalyzed+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� $��2q��   KeywordCount#��Z� $	��100��| �� *IsShowTabKeyword+2 �� *CountKeywordTabVM+.��� .+�� .+�  -    O .  P .  $��5��$��0��$��Stretch=�Q .  � .  S .  R .  ���� *AnalyzeCountKeywordItems+ ��%`   '        &	 %     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�e   $j * #i Z�  �� $

 Name�$7 OneWay=�  $j * #i Z�  �� $
 Count�$7 OneWay=�� 1 �� �� �� .+�� $��1��1 �� �� .+�� $��Right=�� . $��80��$��20��y��� *IsLoadingData+#V [ �� $��1��$��0q�$��20��$��20��$��Stretch=�$
��Left=�y��� *IsLoadingData+#V [ ���� *CancelCountKeyword+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� $��Right=�$��Stretch=�$��1��$��0��$z PreviousAndNext=�$��3�����	#FFBCBCBC�� 
�������$��1q�$��Stretch=�$��Stretch=�$��2��$��0��2 �� *
CXDIMainVM+ ��%   &	          �� ._��  �� $��30 ��� $��30 ��� $��90 ��� $��* ��� $
��Auto ��� $��* �.+�� -!   $��CXDI_Title_Panel��$��Stretch=�$	��Top=�$��0��1 �� $��1* ��� $��6* �.+��� -"   $��CXDITitleLabel��$
��CXDI��$��5,0,0,0q��� -#   $��CXDITitleFileLabel��$��Center=�$��1��$��WrapWithOverflow=�
���  ��$��CharacterEllipsis=����� *CurrentLogFileName+3 �� $	��400��$
��Wrap=����� *CurrentLogFileName+� #��[ $��1��.+�� #��[ .+��� $3 	Open file��#��[ ���� *LoadLogFileCommand+.���� $5 
Horizontal=�.+��� $.��(/LogViewer;component/Images/openfile.png���� $3 	Clear All��#��[ ���� *ClearAllCommand+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� -$   $3 Clear Analyzed Result��#��[ ���� *ClearAnalyzeCommand+.���� $5 
Horizontal=�.+��� $-��'/LogViewer;component/Images/refresh.png���� $3 Expand��#��[ ���� *ExpandCommand+.���� $5 
Horizontal=�.+��� $+��%/LogViewer;component/Images/add_e.png���� $3 Shrink��#��[ ���� *ShirnkCommand+.���� $5 
Horizontal=�.+��� $.��(/LogViewer;component/Images/delete_e.png��� #��[ .+��� $3 	Go to Top��#��[ ���� *GoToTopCommand+.���� $5 
Horizontal=�.+��� $/��)/LogViewer;component/Images/gototop_e.png���� $3 Go to Bottom��#��[ ���� *GoToBotCommand+.���� $5 
Horizontal=�.+��� $/��)/LogViewer;component/Images/gotobot_e.png���� $3 Move to line��#��[ ���� *JumpToLineCommand+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/gotoline_e.png���� $3 Move to time��#��[ ���� *JumpToTimeCommand+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/gotodate_e.png��� #��[ .+��� $3 Calculate Process Time��#��[ ���� *ProcessTimeCommand+.���� $5 
Horizontal=�.+��� $*��$/LogViewer;component/Images/time.png���� $3 Show Graph View��#��[ ���� *ShowGraphCommand+.���� $5 
Horizontal=�.+��� $-��'/LogViewer;component/Images/graph_e.png���� $3 Pattern Analyzing��#��[ ���� *PatternAnalyserCommand+.���� $5 
Horizontal=�.+��� $/��)/LogViewer;component/Images/analyzing.png���� $3 Count Keyword��#��[ ���� *CountKeywordCommand+.���� $5 
Horizontal=�.+��� $.��(/LogViewer;component/Images/countkey.png���� $3 Set Pattern��#��[ ���� *EditPatternSettingCommand+.���� $5 
Horizontal=�.+��� $-��'/LogViewer;component/Images/pattern.png���� $3 Set Keyword��#��[ ���� * EditKeywordCountSettingCommand+.���� $5 
Horizontal=�.+��� $)��#/LogViewer;component/Images/key.png���� $3 
Set Filter��#��[ ���� *EditFilterSettingCommand+.���� $5 
Horizontal=�.+��� $,��&/LogViewer;component/Images/filter.png��� #��[ $��2��.+�� $��5,0,0,0q�.+��� -%   $��FilterCXDILabel��$��Center=�#��Z6 �� .u��� -&   $��FilterCXDITextBox��$	��200��$��Center=����� *StringFilter+$7 TwoWay=�$8 PropertyChanged=�9 . .����1&clr-namespace:System;assembly=mscorlibSystem �� 0sys&clr-namespace:System;assembly=mscorlib  " ��: ��%M   &	       !� $
; Left=�$< Center=�$
= None=�> �� #��Z? 
������� P�  � ��# Z@ . ���  � ��# [ P�  � �� Z� . ���  � ��# [ P�  �@J�IsKeyboardFocused . . ���  � ��
 �����P�  �@=�HasError . . ���  �@�ToolTip# [ ��  �@^�InitialShowDelay$ 0��.���� -'   $��ContentCXDIComboBox��$A Display��$B Value��$��Center=�C �� *	LogItem+$7 TwoWay=�$8 PropertyChanged=����� *LogItemList+d� -(   $"��tbtnCXDINarrowFilterNonColor��$3 Refine Filtering��#��[
 ���� *NarrowNonColorFilterCommand+D �� *IsOnNarrowNonColorFilter+$7 TwoWay=�.���� $5 
Horizontal=�.+��� $1��+/LogViewer;component/Images/refinecolor.png��$3 Refine Filtering��d� -)   $��tbtnCXDINarrowFilterColor��$3 Color Filtering��#��[
 ���� *NarrowColorFilterCommand+D �� *IsOnNarrowColorFilter+$7 TwoWay=�.���� $5 
Horizontal=�.+��� $1��+/LogViewer;component/Images/filtercolor.png��$3 Color Filtering��� $��5,5,0,0q�.+�� E .  F . ���� *IsOpenPopup+.���� -*   $��CXDIColorButtonArena��#��[ ._��� $5 Vertical=�.+��� #��[ ._�� $
��Left=�.+��� #��[ $��5������ *ClosePopupCommand+�� #��[ ._��� $��Center=�$��5q�.+�	  $G RefreshCXDILogsList��H �� *FilterSettingList+�� #��[ ._�� $��Center=�.+�� #��[ .+��� -+   #��ZI ���� *SelectAllFilterSettingCommand+�� #��ZJ ���� *EditFilterSettingCommand+�� -,   #��ZK ���� * ClearColorFilterSettingCommand+� #��[ .+��� #��[ $��4������ *OpenPopupCommand+� --   $��CXDIColorButtonArenaNF��#��[ .+�	  $G RefreshCXDILogsList��L �� *FilterSettingList+� $y�Visible=�$��3��.+�� 2 �� *LogsDisplayVM+ �� $��* ��� $��30 �.+�  -.   $��DataLogCXDI��$��0��M . N .  O .  P .  $	��430��Q .  S .  R .  T . $��5,0,0,0q�U �� *ClickedRecord+$7 OneWayToSource=����� *FontOfDataGrid+#V [ ���� *BaseRecordVMList+$7 TwoWay=�W �� *RecordForJump+X �� *RecordForFollow+Y �� *RefreshData+
� � Tag� �� *DataContext+� �� ElementName$� DataLogCCSDisplay�� ��%R   &	       &	      7     ��    �� *Data.AddMoreBookmark+8Z    �� $ Space��# [ _ �� .@�m� #��Z`  �� *CopyCommand+�� #��Za D �� *Data.IsOnFollowModeCXDI+#Z [ [ �� "  .�-/   \   $	] All=�^ �� *Data.DragDropCommand+#Z [ b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItems�$7 OneWayToSource=�e   f �� *Data.IsDisplayBookmark+#V [ #Z [ g �� .R��� $��Center=�$��Center=�D �� $
 IsBookmarked�$7 TwoWay=�$8 PropertyChanged=����� $
 BookmarkCommand�����   #i Zh $j 50 $k 50Q�f �� *Data.IsDisplayLine+#V [ #Z [ g �� .R��� $
��Line��#��[ $��50��l �� $

 Line�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   #i Zn $j 75 $k 75Q�f �� *Data.IsDisplayDate+#V [ #Z [ g �� .R��� $
��Date��#��[ $��75��l �� $

 Date�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   #i Zo $j 75 $k 75Q�f �� *Data.IsDisplayTime+#V [ #Z [ g �� .R��� $
��Time��#��[ $��75��l �� $

 Time�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   �   Module#i Z� $	j 100 $	k 100Q�f �� *Data.IsDisplayModule+#V [ #Z [ g �� .R��� $��Module��#��[ $	��100��l �� $
 Module�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   #i Z� $
j 1000 $
k 1000Q�f �� *Data.IsDisplayMessage+#V [ #Z [ g �� .R��� $��Message��#��[ $
��1000��l �� $
 Message�$7 OneWay=�m �� $

 Line�$7 OneWay=� �� $ Space��# [   #i Zx $	j 200 $	k 200Q�f �� *Data.IsDisplayComment+#V [ #Z [ g �� .R��� ���� $
 Comment�$7 TwoWay=�$8 PropertyChanged=�� $4 
Horizontal=�$��Bottom=�$��1��.+��� -0   $��CXDIProcessLabel��#��Zy �� -1   $��CXDIProcessFileLabel��
���  ������ *ProcessTime+�� $��Stretch=�$��Bottom=�$��4��$z PreviousAndNext=�$��3�����	#FFBCBCBC]� #��[ $��Stretch=�$��Stretch=�$��5��$��5,0,0,0q�.+��� -2   $��TabControlCXDI��$
��Auto��#��[ 2 �� *BaseAnalyzeAreaVM+.@��� $��2q�#��Z{ | �� *IsShowTabBookmark+2 �� *LogBookmarkTabVM+.��� .+�� .+�  -3   O .  P .  $��5��$��0��$��Stretch=�Q .  S .  R .  ~ �� *DoubleClickedRecord+$7 OneWayToSource=����� *LogRecordList+ ��%x   '        &	 %     &	 L     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�   �� b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItems�$7 OneWayToSource=�_ �� .@�m� #��Z`  �� *Data.CopyCommand+#Z [ [ �� "  .�-4   e   $j 50 $k 50Q�#i Zh  �� $

 Line�$7 OneWay=�  $j 75 $k 75Q�#i Zn  �� $

 Date�$7 OneWay=�  $j 75 $k 75Q�#i Zo  �� $

 Time�$7 OneWay=�  $j 90 $k 90Q�#i Z�  �� $
 Module�$7 OneWay=�  $i Message��$
j 1000  �� $
 Message�$7 OneWay=��� $��2q�#��Z� $	��100��| �� *IsShowTabPattern+2 �� *LogPatternTabVM+.��� .+�� 1 �� $��1* ��� $��1* �.+�  -5   O .  P .  $��Stretch=�$��0��$��0,0,10,0q�Q .  � .  S .  R .  $� Single=�~ �� * DoubleClickedPatternResultItem+$7 OneWayToSource=����� *PatternRecordList+ ��%`   '        &	 %     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�e   $j * #i Z�  �� $

 Name�$7 OneWay=�  $j 90 $k 90Q�#i Z�  �� $
 Count�$7 OneWay=�[ �� "  .�-6     -7   O .  P .  $��Stretch=�$��1��$��10,0,0,0q�Q .  � .  S .  R .  $� Single=�~ �� *DoubleClickedRecord+$7 OneWayToSource=����� *CurrentPatternItem.LogRecords+ ��%`   '        &	 %     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�e   $j 90 $k 90Q�#i Zh  �� $

 Line�$7 OneWay=�  $j * #i Z� k �� *ActualWidth+ �� $
 Self=� �� $
 Message�$7 OneWay=�[ �� "  .�-8   � 1 �� �� �� .+�� $��1��1 �� �� .+�� $��Right=�� . $��80��$��20��y��� *IsLoadingData+#V [ �� $��1��$��0q�$��20��$��20��$��Stretch=�$
��Left=�y��� *IsLoadingData+#V [ ���� *CancelPatternAnalyzed+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� $��2q�#��Z� $	��100��| �� *IsShowTabKeyword+2 �� *CountKeywordTabVM+.��� .+�� .+�  -9   O .  P .  $��5��$��0��$��Stretch=�Q .  � .  S .  R .  ���� *AnalyzeCountKeywordItems+ ��%`   '        &	 %     �� "  .���  � ��$
 Left=��� "  .���  � ��$ Center=�e   $j * #i Z�  �� $

 Name�$7 OneWay=�  $j * #i Z�  �� $
 Count�$7 OneWay=�� 1 �� �� �� .+�� $��1��1 �� �� .+�� $��Right=�� . $��80��$��20��y��� *IsLoadingData+#V [ �� $��1��$��0q�$��20��$��20��$��Stretch=�$
��Left=�y��� *IsLoadingData+#V [ ���� *CancelCountKeyword+.���� $5 
Horizontal=�.+��� $0��*/LogViewer;component/Images/clearall_e.png���� �   Firmware#��Z� $��2q�$	��100��2 �� *FirmwareInfoTabVM+.���� -:   $
��Auto=�.��� 1 ��  �� $��23 ��� $��* ��� $��23 ��� $��* ��� $��23 �.+��� 
�������$��Stretch=�$��0��._��� �   CounterParameter#��Z� $��Center=�$��Center=�  -;   �   HeadersVisibility$
� None=�O .  $��Disabled=�P .  $��1��{�. ���� *CXDIFirmware.Counter+ ��%z   '        &	 '     &	 N     �� "  .���  � ��$ Center=��� "  .���  � ��$ Center=�   �� _ �� .@�m� #��Z`  �� *Data.CopyCommand+#Z [ b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItemsCounter�$7 OneWayToSource=�e   $j * $i Count�� �� $
 	parameter�$7 OneWay=�  $j * $i Value�� �� $
 value�$7 OneWay=��� 
�������$��Stretch=�$��2��._��� �   SaveParameter#��Z� $��Center=�$��Center=�  -<   $
� None=�O .  $��Disabled=�P .  $��3��{�. ���� *CXDIFirmware.Saved+ ��%z   '        &	 '     &	 N     �� "  .���  � ��$ Center=��� "  .���  � ��$ Center=�   �� _ �� .@�m� #��Z`  �� *Data.CopyCommand+#Z [ b     c ��  �� "	  $
 SelectedItems�d �� $
 SelectedItemsSaved�$7 OneWayToSource=�e   $j * $i Count�� �� $
 	parameter�$7 OneWay=�  $j * $i Value�� �� $
 value�$7 OneWay=�