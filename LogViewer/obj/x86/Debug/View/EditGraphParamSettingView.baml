   M S B A M L   `   `   `  ����D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5   	   5clr-namespace:LogViewer.ServiceLogViewer.Service  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	   	   1clr-namespace:LogViewer.ModelLogViewer.Model  5
   	   ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  5   	   .    (LogViewer.View.EditGraphParamSettingView   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   1mvvm"clr-namespace:LogViewer.MVVMHelper    5   	   ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   -Serviceclr-namespace:LogViewer.Service  5   	   3System&clr-namespace:System;assembly=mscorlib  5	   	   )modelclr-namespace:LogViewer.Model  5
   	   3
properties"clr-namespace:LogViewer.Properties  5   	   %  LogViewer.Service.DialogService    IsRegisteredView  .  � WindowStartupLocation$ CenterOwner=�5   	   $   LogViewer.Properties.Resources   GraphParamSetting � Title# Z 5   	    � SizeToContent$ Height=�6C   $	��500��5   	    � Icon$- '/LogViewer;component/Images/graph_e.png��6    � WindowStyle$ SingleBorderWindow=�6D    � 
ResizeMode$ NoResize=�6e    � 	Resources 5      6   0LogViewer.MVVMHelper.ProtobyteToDrawingConverter   ProtobyteToDrawing  dataFromProtobyteEnum	 S� 
MethodName
 S� 
ObjectType  System.Enum S� MethodParameters M� TypeName��%�   &	        &	        5   
   6+   S� 5   
   $	 	GetValues��6;   "
  5       5      M� 5      $ model:Prototype��6   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��10 �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � DataContext 6   �� *ParameterDataGridVM+ 5      �� 5       $
��Auto �6    �� 5!      $��* �6    �� 5"      $
��Auto �6     � ColumnDefinitions 5$      �� 5%      $��* �6#   �� 5&      $
��Auto �6#   .+�5(      �� $��0��6      	Parameter#��Z 6%   )  #Microsoft.Windows.Controls.DataGrid  5)      -   5        $��1��5)         CanUserAddRows .     AutoGenerateColumns .  $	��150��5,         CanUserSortColumns .     CanUserResizeColumns .    CanUserReorderColumns .     CanUserResizeRows .  )  #LogViewer.MVVMHelper.DatagridHelper   RecordToShow 5*      �� *
RowForJump+��5,   *   �� *
SourceList+%   LogViewer.MVVMHelper.DataPiping   	DataPipes 5.      -   'LogViewer.MVVMHelper.DataPipeCollection  #	   LogViewer.MVVMHelper.DataPipe	  5/       	  Source 6(   ��  �� RelativeSource ��  �� AncestorType"   �� Path$ SelectedItems� 	  Target 50      �� $ SelectedItems� �� Mode$ OneWayToSource=�51         Columns 53      7
  1Microsoft.Windows.Controls.DataGridTemplateColumn
  54        
  CellTemplate  55      �� 56      .R�57   "   �� $��40��6+   $��20��69   ! �� SelectedValue! 6H   �� *PrototypeValue+��58   +   �� " �� Source#" [ ��59   &   �� 5:   *   .R�5;   .   �� $��10��64   $��10��6?   ��5<   2   H� 5=   6   # H� Drawing# 6C   �� $ .�$ �� 	Converter#$ [  5>   7   5@   /   5A   +   5C   #   5D      5F      3  -Microsoft.Windows.Controls.DataGridTextColumn  5G      %   Name/  )Microsoft.Windows.Controls.DataGridColumn&   Header#& Z% 61   '   Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$' * 6_   4  .Microsoft.Windows.Controls.DataGridBoundColumn(   Binding( 6i   �� $
 Name�  5H      )   Object#& Z) 61   $' 2* 6a   ( 6l   �� $ StringValue�
  5I      *   Enable#& Z* 65   $' 60 6e     5J      �� 5K      .R�5L   "   �� $��Center=�6�   $��Center=�6�   + d� 	IsChecked+ 6+   �� $ Enabled�$ TwoWay=�, �� UpdateSourceTrigger$, PropertyChanged=�6�   5M      5O      5Q      �� 5R      $��1��6   $��1��6)   $��Center=�66   .+�5S      �� $��50��6   $��Center=�6B   $��20,10,20,20q�6_   
-   Add#��Z- 6t   ��6#   �� *
AddCommand+6t   �� 5T      $��50��6   $��Center=�6E   $��20,20,20,10q�6b   .   Delete#��Z. 6w   ��6#   �� *DeleteCommand+6w   5U      �� 5V      $��2��6    $��2��6-   
���  ����6A   �� *ErrorMessage+6_   5W      � 5X   
   $��2��6    6   �� *EventDataGridVM+ 5Y      �� 5Z      $
��Auto �6    �� 5[      $��* �6    �� 5\      $
��Auto �6     5^      �� 5_      $��* �6#   �� 5`      $
��Auto �6#   .+�5b      �� $��0��6   /   Event#��Z/ 6%     5c      -   5        $��1��5c       .   .  $	��150��5f       .   .   .   5e      �� *
RowForJump+��5f   *   �� *
SourceList+ 5h        	  5i       6(   ��  �� "  $ SelectedItems� 5j      �� $ SelectedItems�$ OneWayToSource=�5k       5m      
  5n        5o      �� 5p      .R�5q   "   �� $��40��6+   $��20��69   ! 6H   �� *PrototypeValue+��6r   �� #" [ ��5r   &   �� 5s   *   .R�5t   .   �� $��10��64   $��10��6?   ��5u   2   H� 5v   6   # 6C   �� $ .�#$ [  5w   7   5y   /   5z   +   5|   #   5}      5        5�      #& Z% 61   $' * 6_   ( 6i   �� $
 Name�  5�      #& Z) 61   $' 2* 6a   ( 6l   �� $ StringValue�
  5�      #& Z* 65   $' 60 6e     5�      �� 5�      .R�5�   "   �� $��Center=�6�   $��Center=�6�   + 6+   �� $ Enabled�$ TwoWay=�$, PropertyChanged=�6�   5�      5�      5�      �� 5�      $��1��6   $��1��6)   $��Center=�66   .+�5�      �� $��50��6   $��Center=�6B   $��20,10,20,20q�6_   #��Z- 6t   ��6#   �� *
AddCommand+6t   �� 5�      $��50��6   $��Center=�6E   $��20,20,20,10q�6b   #��Z. 6w   ��6#   �� *DeleteCommand+6w   5�      �� 5�      $��2��6   $��2��6)   
���  ����6=   �� *ErrorMessage+6[   5�      � 5�   
   $��3��6   .+�5�      �� 0 �� Orientation$0 
Horizontal=�6   $��Center=�62   .+�5�      �� 	1   OK#��Z1 6   $��50��6d   $��15,10,10,10q�6r   ��6F   �� *	OkCommand+6r   �� 5�      2   Cancel#��Z2 6   3 �� IsCancel3 . $��50��6{   $��
0,10,20,10q�6�   ��6J   �� *CloseCommand+6�   5�      5�      5�      5�      