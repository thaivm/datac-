   M S B A M L   `   `   `  ���� D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  *    $LogViewer.View.LogDisplaySettingView   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    1mvvm"clr-namespace:LogViewer.MVVMHelper    ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  3
properties"clr-namespace:LogViewer.Properties  $   LogViewer.Properties.Resources    LogDisplaySetting � Title# Z  $	��312��$	��533�� � WindowStyle$ 
ToolWindow=� � WindowStartupLocation$ CenterOwner=� � 
ResizeMode$ NoResize=� � 	Resources    	BoolToVis+   %LogViewer.MVVMHelper.CommandReference  OkCommandReference   Command��%5   &	        &	      ��    �� *	OkCommand+ J� InputBindings �� 
 �� Key$ Enter��	 �� Command#	 [ .��� 
 � RowDefinitions
 �� $��19 ��� $
��210* ��� $
��Auto ��� $��44 � � ColumnDefinitions �� $��1* ��� $��1* �.+��� $��2��$��
12,0,243,0q�CCS�� $��1��$��
11,0,-10,0q�CXDI)  #Microsoft.Windows.Controls.DataGrid  -      AutoGenerateColumns .     CanUserAddRows .  $��1��$��
12,6,10,14q�   CanUserReorderColumns .     CanUserResizeRows .     CanUserSortColumns .  ���� *CCSDisplaySettings+ @  :Microsoft.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value-  'Microsoft.Windows.Controls.DataGridCell  DataGridCellCenter��%b   '        &	 '     �� "  .���  � ��$ Center=��� "  .���  � ��$ Center=�   Columns 3  -Microsoft.Windows.Controls.DataGridTextColumn  /  )Microsoft.Windows.Controls.DataGridColumn   Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$ *    Elements   Header# Z 4	  .Microsoft.Windows.Controls.DataGridBoundColumn 	  Binding ��  �� Path$ 
DisplayKey� �� Mode$ OneWay=�7
  1Microsoft.Windows.Controls.DataGridTemplateColumn
  $ 70    Visible# Z  
  CellTemplate �� .R��� $��Center=�$��Center=� d� 	IsChecked �� $ Value�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�  -    .   .  $��1��$��1��$��
10,6,12,14q� .   .   .  ���� *CXDIDisplaySettings+ ��%b   '        &	 '     �� "  .���  � ��$ Center=��� "  .���  � ��$ Center=�   $ * # Z  �� $ 
DisplayKey�$ OneWay=�
  $ 70 # Z  �� .R��� $��Center=�$��Center=� �� $ Value�$ TwoWay=�$ PropertyChanged=��� $��2��$��2��
���  ������ *ErrorMessage+�� 	   OK#��Z $��3��$��
152,0,9,12q����� *	OkCommand+��     Cancel#��Z  $��1��$��3��! �� IsCancel! . $��10,0,160,12q�