   M S B A M L   `   `   `  ����D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:LogViewer.ServiceLogViewer.Service  5   	   ;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5   	   ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  5   	   *    $LogViewer.View.EditFilterSettingView   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   1Serviceclr-namespace:LogViewer.Service    5   	   1mvvm"clr-namespace:LogViewer.MVVMHelper    5   	   ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5	   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
   	   3
properties"clr-namespace:LogViewer.Properties  5   	   %  LogViewer.Service.DialogService    IsRegisteredView  . $	��400��5   	    � SizeToContent$ Height=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$ 
ToolWindow=�6    � WindowStartupLocation$ CenterOwner=�68    � Icon$( "/LogViewer;component/Images/LV.png��6\    � Title 5   	   �� *Title+ � 	Resources 5      -  'LogViewer.MVVMHelper.TranslateConverter   TranslateConverter+   %LogViewer.MVVMHelper.CommandReference  OkCommandReference   Command��%Q   &	        &	        5   
   6"     5   
    6;   �� *	OkCommand+5      	 J� InputBindings	 5      �� 5   
   

 �� Key$
 Enter��6    �� Command# [ 6!   .��5      � $	��470��6   .+�5   
   �� $��5q�6   .+�5      )  #Microsoft.Windows.Controls.DataGrid  -   5        $��dtgFilterList��5         CanUserAddRows .     AutoGenerateColumns .     
IsReadOnly . $	��200��5         CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  ��6,   �� *ItemSettingList+)  #LogViewer.MVVMHelper.DatagridHelper   DoubleClickedRow 5      �� *DoubleClickedCandidate+ �� Mode$ TwoWay=�%   LogViewer.MVVMHelper.DataPiping   	DataPipes 5      -   'LogViewer.MVVMHelper.DataPipeCollection  #   LogViewer.MVVMHelper.DataPipe  5         Source 6(   ��  �� RelativeSource ��  �� AncestorType"   �� Path$ SelectedItems�   Target 5      �� $ SelectedItems�$ OneWayToSource=�5          Columns 5"      3	  -Microsoft.Windows.Controls.DataGridTextColumn	  5#      $
   LogViewer.Properties.Resources 
  Name/  )Microsoft.Windows.Controls.DataGridColumn   Header# Z 61      Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$ 2* 6_   4  .Microsoft.Windows.Controls.DataGridBoundColumn   Binding 6j   �� $
 Name�	  5$       
  String# Z 61   $ 2* 6a    6l   �� $ StringValue�    	CellStyle  5%      �� 5&      ! �� 
TargetType-  'Microsoft.Windows.Controls.DataGridCell"!  6$   .�5'   "   �� " �� Property" � ��# �� Value# 6?   �� $ 
Foreground��� 5(   "   " � ��# 6?   �� $ 
Background��� 5)   "   *  $LogViewer.MVVMHelper.FontStyleHelper" �@ 	FontStyle# 6S   �� $ 	FontStyle�5*      5,      	  5-      $ 
  Item# Z$ 61   $ * 6_    6i   �� $ LogItem�% �� 	Converter#% [  7  1Microsoft.Windows.Controls.DataGridTemplateColumn  5.      & 
  Enable# Z& 65   $ * 6e   '   CellTemplate' 5/      �� 50      .R�51   "   �� $��Center=�6�   $��Center=�6�   ( d� 	IsChecked( 6+   �� $ Enabled�$ TwoWay=�) �� UpdateSourceTrigger$) PropertyChanged=�6�   52      54      *   RowStyle* 56      �� 57      ,  &Microsoft.Windows.Controls.DataGridRow"!  6   .�58      -   5        5:      5<      � 5>      $��Center=�6   $��5q�65   .+�5?      �� 
+ 
  Add#��Z+ 6   $��50��6G   $��5q�6R   ��6]   �� *AddItemSettingCommand+�� 5@      , 
  	Overwrite#��Z, 6   $��80��6M   $��5q�6X   ��6c   �� *OverwriteItemSettingCommand+�� 5A      - 
  Delete#��Z- 6   $��50��6J   $��5q�6U   ��6`   �� *DeleteItemSettingCommand+5B      �� 5C      .u�5D      �� 
�������$��1q�6(   $��Stretch=�6<   ._�5E      �� $��Center=�6   $��5q�6:   .+�5F      � $��Stretch=�6   . � ColumnDefinitions. 5G      �� 5H      $
��Auto �6/   �� 5I      $��5* �6/   / � RowDefinitions/ 5K      �� 5L      �� 5M      �� 5N       5P      0 �� Triggers1 P� Property2 P� Value��%c  '��       '_�     �� 5Q      "! ��6$   0 5R   "   P� 5S   &   1 �@=�HasError2 . . �5T   *   �� " �@�ToolTip# 6D   ��  �� *Self+$2 ,(Validation.Errors).CurrentItem.ErrorContent��� 5U   *   " �@^�InitialShowDelay$# 0��6\   5V   '   5X      �� 5Y      "! _�6$   .�5Z   "   �� " � ��
# �  ��6?   5[      5\      .+�5]      �� 3 
  FilterNameColon#��Z3 6    $��Right=�6Z   $��0��6}   $��0��6�   $��0,0,0,5q�6�   �� 5^      $��0��6"   $��1��6/   $��0,0,0,5q�6?   $	��226��6�   ��6P   �� *Name+$ TwoWay=�4 �� ValidatesOnDataErrors4 . $) PropertyChanged=�6�   �� 5_      5 
  FilterStringColon#��Z5 6    $��Right=�6\   $��1��6   $��0��6�   $��0,0,0,5q�6�   �� 5`      $��1��6"   $��1��6/   $��0,0,0,5q�5a   "   $	��226��5d   W   ��5a   3   �� *FilterString+$ TwoWay=�$) PropertyChanged=�4 . ��5b   "   �� *
Foreground+$ TwoWay=���5c   "   �� *
Background+$ TwoWay=�6   	FontStyle6 5d   "   �� *	FontStyle+6W   �� 5e      7 
  LogItemColon#��Z7 6    $��Right=�6W   $��2��6z   $��0��6�   $��0,0,0,5q�6�   �� 5f      $��2��6#   $��1��60   $��0,0,0,5q�6@   8 �� DisplayMemberPath$8 Display��5i   #   9 �� SelectedValuePath$9 Value��5j   #   ��5g   #   �� *AllLogItems+: �� SelectedValue: 5h   #   �� *	LogItem+$ TwoWay=�$) PropertyChanged=�5l      5m      �� 5n      $��5q�6!   $��Stretch=�6,   ; �� Orientation$; 
Horizontal=�6J   .+�5o      �� $��90��6!   $��5q�6,   ��67   �� *EditForeGroundCommand+.��5p      �� < 
  ForeGroundColor#��Z< 6(   $
��Wrap=�6_   = �� TextAlignment$= Center=�6s   5q      �� 5r      $��90��6!   $��5q�6,   ��67   �� *EditBackGroundCommand+.��5s      �� > 
  BackGroundColor#��Z> 6(   $
��Wrap=�6_   $= Center=�6s   5t      �� 5u      ? 
  	FontStyle#��Z? 6!   $��90��6~   $��5q�6�   ��6U   �� *EditFontStyleCommand+6�   5v      5w      5x      5y      � 5z      $��Center=�6   .+�5{      �� 	@ 
  OK#��Z@ 6   $��5q�6F   $��50��6Q   ��6\   �� *	OkCommand+�� 5|      A 
  Apply#��ZA 6   $��5q�6J   $��50��6V   ��6a   �� *ApplyCommand+�� 5}      B 
  Cancel#��ZB 6   $��5q�6K   $��50��6V   C �� IsCancelC . ��6q   �� *CloseCommand+5~      5      5�      5�      