   M S B A M L   `   `   `  ����D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5   	   ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  5   	   *    $LogViewer.View.LogDisplaySettingView   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   1mvvm"clr-namespace:LogViewer.MVVMHelper    5   	   ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   3
properties"clr-namespace:LogViewer.Properties  5   	   $   LogViewer.Properties.Resources    LogDisplaySetting � Title# Z  5   	   $	��312��6C   $	��533��6P    � WindowStyle$ 
ToolWindow=�6\    � WindowStartupLocation$ CenterOwner=�6u    � 
ResizeMode$ NoResize=�6�    � 	Resources 5         	BoolToVis+   %LogViewer.MVVMHelper.CommandReference  OkCommandReference   Command��%Q   &	        &	      �� 5	   
   6'     5
   
    6;   �� *	OkCommand+5       J� InputBindings 5      �� 5   
   
 �� Key$ Enter��6   	 �� Command#	 [ 6!   .��5      � 
 � RowDefinitions
 5   
   �� 5      $��19 �6   �� 5      $
��210* �6   �� 5      $
��Auto �6   �� 5      $��44 �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��2��6   $��
12,0,243,0q�6(   CCS6A   �� 5   
   $��1��6   $��
11,0,-10,0q�6$   CXDI6>   )  #Microsoft.Windows.Controls.DataGrid  5   
   -   5           AutoGenerateColumns .     CanUserAddRows .  $��1��5      $��
12,6,10,14q�6(      CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  ��5      �� *CCSDisplaySettings+ 5      @  :Microsoft.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value-  'Microsoft.Windows.Controls.DataGridCell  DataGridCellCenter��%�   '        &	 Q     �� 5       "  6   .�5!      ��  � ��$ Center=�6C   6T   5"      �� 5#      "  6   .�5$      ��  � ��$ Center=�6<   6M   5%      5&         Columns 5'      3  -Microsoft.Windows.Controls.DataGridTextColumn  5(      /  )Microsoft.Windows.Controls.DataGridColumn   Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$ * 6-      Elements   Header# Z 67   4	  .Microsoft.Windows.Controls.DataGridBoundColumn 	  Binding 6i   ��  �� Path$ 
DisplayKey� �� Mode$ OneWay=�7
  1Microsoft.Windows.Controls.DataGridTemplateColumn
  5)      $ 70 61      Visible# Z 6<    
  CellTemplate 5*      �� 5+      .R�5,      �� $��Center=�6z   $��Center=�6�    d� 	IsChecked 6'   �� $ Value�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5-      5.      50      52        54   
   -   5         .   .  $��1��55   c   $��1��6s   $��
10,6,12,14q�6�    .   .   .  ��67   �� *CXDIDisplaySettings+ 56      ��%�   '        &	 Q     �� 57      "  6   .�58      ��  � ��$ Center=�6C   6T   59      �� 5:      "  6   .�5;      ��  � ��$ Center=�6<   6M   5<      5=       5>        5?      $ * 6-   # Z 67    6i   �� $ 
DisplayKey�$ OneWay=�
  5@      $ 70 61   # Z 6<    5A      �� 5B      .R�5C      �� $��Center=�6z   $��Center=�6�    6'   �� $ Value�$ TwoWay=�$ PropertyChanged=�5D      5E      5G      5I      �� 5J   
   $��2��6   $��2��6!   
���  ����65   �� *ErrorMessage+6S   �� 5K   
   	   OK#��Z 6   $��3��6>   $��
152,0,9,12q�6i   ��6K   �� *	OkCommand+6   �� 5L   
       Cancel#��Z  6   $��1��6B   $��3��6R   ! �� IsCancel! . $��10,0,160,12q�6o   6�   5M      5N      