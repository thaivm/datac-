   M S B A M L   `   `   `  ���� D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5clr-namespace:LogViewer.ServiceLogViewer.Service  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 1clr-namespace:LogViewer.ModelLogViewer.Model  ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  .    (LogViewer.View.EditGraphParamSettingView   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    1mvvm"clr-namespace:LogViewer.MVVMHelper    ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  -Serviceclr-namespace:LogViewer.Service  3System&clr-namespace:System;assembly=mscorlib  )modelclr-namespace:LogViewer.Model  3
properties"clr-namespace:LogViewer.Properties  %  LogViewer.Service.DialogService    IsRegisteredView  .  � WindowStartupLocation$ CenterOwner=�$   LogViewer.Properties.Resources   GraphParamSetting � Title# Z  � SizeToContent$ Height=�$	��500�� � Icon$- '/LogViewer;component/Images/graph_e.png�� � WindowStyle$ SingleBorderWindow=� � 
ResizeMode$ NoResize=� � 	Resources 6   0LogViewer.MVVMHelper.ProtobyteToDrawingConverter   ProtobyteToDrawing  dataFromProtobyteEnum	 S� 
MethodName
 S� 
ObjectType  System.Enum S� MethodParameters M� TypeName��%R   &	        &	        S� $	 	GetValues��"
   M� $ model:Prototype��.���  � RowDefinitions �� $��* ��� $��10 ��� $��* ��� $
��Auto �.+�� $��0�� � DataContext �� *ParameterDataGridVM+ �� $
��Auto ��� $��* ��� $
��Auto � � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��0��   	Parameter#��Z )  #Microsoft.Windows.Controls.DataGrid  -   $��1��   CanUserAddRows .     AutoGenerateColumns .  $	��150��   CanUserSortColumns .     CanUserResizeColumns .    CanUserReorderColumns .     CanUserResizeRows .  )  #LogViewer.MVVMHelper.DatagridHelper   RecordToShow �� *
RowForJump+���� *
SourceList+%   LogViewer.MVVMHelper.DataPiping   	DataPipes -   'LogViewer.MVVMHelper.DataPipeCollection  #	   LogViewer.MVVMHelper.DataPipe	   	  Source ��  �� RelativeSource ��  �� AncestorType"   �� Path$ SelectedItems� 	  Target �� $ SelectedItems� �� Mode$ OneWayToSource=�   Columns 7
  1Microsoft.Windows.Controls.DataGridTemplateColumn
    
  CellTemplate  �� .R��� $��40��$��20��! �� SelectedValue! �� *PrototypeValue+���� " �� Source#" [ ���� .R��� $��10��$��10����H� # H� Drawing# �� $ .�$ �� 	Converter#$ [  3  -Microsoft.Windows.Controls.DataGridTextColumn  %   Name/  )Microsoft.Windows.Controls.DataGridColumn&   Header#& Z% '   Width8  2Microsoft.Windows.Controls.DataGridLengthConverter$' * 4  .Microsoft.Windows.Controls.DataGridBoundColumn(   Binding( �� $
 Name�  )   Object#& Z) $' 2* ( �� $ StringValue�
  *   Enable#& Z* $' 60   �� .R��� $��Center=�$��Center=�+ d� 	IsChecked+ �� $ Enabled�$ TwoWay=�, �� UpdateSourceTrigger$, PropertyChanged=��� $��1��$��1��$��Center=�.+��� $��50��$��Center=�$��20,10,20,20q�
-   Add#��Z- ���� *
AddCommand+�� $��50��$��Center=�$��20,20,20,10q�.   Delete#��Z. ���� *DeleteCommand+�� $��2��$��2��
���  ������ *ErrorMessage+� $��2�� �� *EventDataGridVM+ �� $
��Auto ��� $��* ��� $
��Auto � �� $��* ��� $
��Auto �.+��� $��0��/   Event#��Z/   -   $��1�� .   .  $	��150�� .   .   .   �� *
RowForJump+���� *
SourceList+   	   ��  �� "  $ SelectedItems� �� $ SelectedItems�$ OneWayToSource=� 
    �� .R��� $��40��$��20��! �� *PrototypeValue+���� #" [ ���� .R��� $��10��$��10����H� # �� $ .�#$ [    #& Z% $' * ( �� $
 Name�  #& Z) $' 2* ( �� $ StringValue�
  #& Z* $' 60   �� .R��� $��Center=�$��Center=�+ �� $ Enabled�$ TwoWay=�$, PropertyChanged=��� $��1��$��1��$��Center=�.+��� $��50��$��Center=�$��20,10,20,20q�#��Z- ���� *
AddCommand+�� $��50��$��Center=�$��20,20,20,10q�#��Z. ���� *DeleteCommand+�� $��2��$��2��
���  ������ *ErrorMessage+� $��3��.+��� 0 �� Orientation$0 
Horizontal=�$��Center=�.+��� 	1   OK#��Z1 $��50��$��15,10,10,10q����� *	OkCommand+�� 2   Cancel#��Z2 3 �� IsCancel3 . $��50��$��
0,10,20,10q����� *CloseCommand+