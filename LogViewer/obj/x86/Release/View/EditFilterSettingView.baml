   M S B A M L   `   `   `  ���� D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LogViewer.ServiceLogViewer.Service  ;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  *    $LogViewer.View.EditFilterSettingView   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    1Serviceclr-namespace:LogViewer.Service    1mvvm"clr-namespace:LogViewer.MVVMHelper    ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  :d2http://schemas.microsoft.com/expression/blend/2008  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  3
properties"clr-namespace:LogViewer.Properties  %  LogViewer.Service.DialogService    IsRegisteredView  . $	��400�� � SizeToContent$ Height=� � 
ResizeMode$ NoResize=� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterOwner=� � Icon$( "/LogViewer;component/Images/LV.png�� � Title �� *Title+ � 	Resources -  'LogViewer.MVVMHelper.TranslateConverter   TranslateConverter+   %LogViewer.MVVMHelper.CommandReference  OkCommandReference   Command��%5   &	        &	           �� *	OkCommand+	 J� InputBindings	 �� 

 �� Key$
 Enter�� �� Command# [ .��� $	��470��.+��� $��5q�.+�)  #Microsoft.Windows.Controls.DataGrid  -   $��dtgFilterList��   CanUserAddRows .     AutoGenerateColumns .     
IsReadOnly . $	��200��   CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  ���� *ItemSettingList+)  #LogViewer.MVVMHelper.DatagridHelper   DoubleClickedRow �� *DoubleClickedCandidate+ �� Mode$ TwoWay=�%   LogViewer.MVVMHelper.DataPiping   	DataPipes -   'LogViewer.MVVMHelper.DataPipeCollection  #   LogViewer.MVVMHelper.DataPipe     Source ��  �� RelativeSource ��  �� AncestorType"   �� Path$ SelectedItems�   Target �� $ SelectedItems�$ OneWayToSource=�   Columns 3	  -Microsoft.Windows.Controls.DataGridTextColumn	  $
   LogViewer.Properties.Resources 
  Name/  )Microsoft.Windows.Controls.DataGridColumn   Header# Z    Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$ 2* 4  .Microsoft.Windows.Controls.DataGridBoundColumn   Binding �� $
 Name�	   
  String# Z $ 2*  �� $ StringValue�    	CellStyle  �� ! �� 
TargetType-  'Microsoft.Windows.Controls.DataGridCell"!  .��� " �� Property" � ��# �� Value# �� $ 
Foreground��� " � ��# �� $ 
Background��� *  $LogViewer.MVVMHelper.FontStyleHelper" �@ 	FontStyle# �� $ 	FontStyle�	  $ 
  Item# Z$ $ *  �� $ LogItem�% �� 	Converter#% [  7  1Microsoft.Windows.Controls.DataGridTemplateColumn  & 
  Enable# Z& $ * '   CellTemplate' �� .R��� $��Center=�$��Center=�( d� 	IsChecked( �� $ Enabled�$ TwoWay=�) �� UpdateSourceTrigger$) PropertyChanged=�*   RowStyle* �� ,  &Microsoft.Windows.Controls.DataGridRow"!  .�-   � $��Center=�$��5q�.+��� 
+ 
  Add#��Z+ $��50��$��5q����� *AddItemSettingCommand+�� , 
  	Overwrite#��Z, $��80��$��5q����� *OverwriteItemSettingCommand+�� - 
  Delete#��Z- $��50��$��5q����� *DeleteItemSettingCommand+�� .u��� 
�������$��1q�$��Stretch=�._��� $��Center=�$��5q�.+�� $��Stretch=�. � ColumnDefinitions. �� $
��Auto ��� $��5* �/ � RowDefinitions/ �� �� ��  0 �� Triggers1 P� Property2 P� Value��%�   '��       '_� �     �� "! ��0 P� 1 �@=�HasError2 . . ��� " �@�ToolTip# ��  �� *Self+$2 ,(Validation.Errors).CurrentItem.ErrorContent��� " �@^�InitialShowDelay$# 0���� "! _�.��� " � ��
# �  ��.+��� 3 
  FilterNameColon#��Z3 $��Right=�$��0��$��0��$��0,0,0,5q��� $��0��$��1��$��0,0,0,5q�$	��226������ *Name+$ TwoWay=�4 �� ValidatesOnDataErrors4 . $) PropertyChanged=��� 5 
  FilterStringColon#��Z5 $��Right=�$��1��$��0��$��0,0,0,5q��� $��1��$��1��$��0,0,0,5q�$	��226������ *FilterString+$ TwoWay=�$) PropertyChanged=�4 . ���� *
Foreground+$ TwoWay=����� *
Background+$ TwoWay=�6   	FontStyle6 �� *	FontStyle+�� 7 
  LogItemColon#��Z7 $��Right=�$��2��$��0��$��0,0,0,5q��� $��2��$��1��$��0,0,0,5q�8 �� DisplayMemberPath$8 Display��9 �� SelectedValuePath$9 Value������ *AllLogItems+: �� SelectedValue: �� *	LogItem+$ TwoWay=�$) PropertyChanged=��� $��5q�$��Stretch=�; �� Orientation$; 
Horizontal=�.+��� $��90��$��5q����� *EditForeGroundCommand+.���� < 
  ForeGroundColor#��Z< $
��Wrap=�= �� TextAlignment$= Center=��� $��90��$��5q����� *EditBackGroundCommand+.���� > 
  BackGroundColor#��Z> $
��Wrap=�$= Center=��� ? 
  	FontStyle#��Z? $��90��$��5q����� *EditFontStyleCommand+� $��Center=�.+��� 	@ 
  OK#��Z@ $��5q�$��50������ *	OkCommand+�� A 
  Apply#��ZA $��5q�$��50������ *ApplyCommand+�� B 
  Cancel#��ZB $��5q�$��50��C �� IsCancelC . ���� *CloseCommand+