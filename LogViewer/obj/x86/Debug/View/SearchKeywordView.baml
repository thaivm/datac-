   M S B A M L   `   `   `  ����D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5   	   5clr-namespace:LogViewer.ServiceLogViewer.Service  5   	   ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  5   	   &     LogViewer.View.SearchKeywordView   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   1mvvm"clr-namespace:LogViewer.MVVMHelper    5   	   1Serviceclr-namespace:LogViewer.Service    5   	   7
properties"clr-namespace:LogViewer.Properties    5   	   ;toolkit-http://schemas.microsoft.com/wpf/2008/toolkit  5   	   %  LogViewer.Service.DialogService    IsRegisteredView  .  � Title$ Search Keyword��5	   	    � SizeToContent$ Height=�6    $	��400��67    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$ 
ToolWindow=�6    � WindowStartupLocation$ CenterOwner=�5   	    � 	Resources 5         	BoolToVis+   %LogViewer.MVVMHelper.CommandReference  SearchCommandReference   Command��%U   &	        &	      �� 5   
   6'     5   
    6?   �� *SearchCommand+5       J� InputBindings 5      �� 5   
   
	 �� Key$	 Enter��6   
 �� Command#
 [ 6!   .��5      �� $��5q�6   .+�5   
   �� $   LogViewer.Properties.Resources   InputKeywordColon#��Z 6   �� 5   
    �� 	MaxLength$ 50��6   $��0,5,0,5q�6!   ��62   �� *SearchString+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
      LogTypeColon#��Z 6   �� 5   
   $��0,5,0,5q�6   $��23��6$    �� DisplayMemberPath$ Display��5       �� SelectedValuePath$ Value��5       �� SelectedValue 5      �� *SelectedLogKindTarget+��5      �� *LogKindTargetList+5      �� 5   
   ��6   �� *SearchResultVMList+ �� SelectedItem 5      �� *SelectedSearchResultVM+ �� ContentTemplate 5      �� 5       .R�5!      �� .+�5"      ��    LogItemColon#��Z 6$   �� 5#      $��0,5,0,5q�6#   $��23��64   $ Display��5%   #   $ Value��5&   #   ��5#   @   �� *LogItemList+ 5$   #   �� *SelectedLogItem+5&   #   � 5'      $��0,5,0,0q�6    � ColumnDefinitions 5(      �� 5)   "   $��2* �63   �� 5*   "   $��3* �63   .+�5,      ��    ResultColon#��Z 6(   $��0��6[   �� 5-      $��1��6b   $��Right=�6r   
���  ����6(   �� *ResultCount+ �� StringFormat$ Total: {0} hits��6�   5.      )  #Microsoft.Windows.Controls.DataGrid  5/      -   5        $��0,5,0,5q�5/   M      AutoGenerateColumns .  $	��300��6z      CanUserAddRows .     CanUserSortColumns .     CanUserResizeRows .     CanUserDeleteRows .     CanUserReorderColumns .  )  #LogViewer.MVVMHelper.DatagridHelper   DoubleClickedRow 50   +   �� *DoubleClickedRecord+ �� Mode$ OneWayToSource=���51   +   �� *LogResultList+ 53      '   !LogViewer.MVVMHelper.BindingProxy 	 proxy    Data��%&   &	         54   "     6B   �� 55      !   Columns! 56      3  -Microsoft.Windows.Controls.DataGridTextColumn  57   "   /  )Microsoft.Windows.Controls.DataGridColumn"   Width8	  2Microsoft.Windows.Controls.DataGridLengthConverter$" 90	 6=   #   MinWidth$# 90Q�6H   $   Header$
$ Line��6V   4
  .Microsoft.Windows.Controls.DataGridBoundColumn% 
  Binding% 6d   �� & �� Path$
& Line�$ OneWay=�  58   "   $" 90	 6=   $# 90Q�6H   $
$ Date��6V   % 6d   �� $
& Date�$ OneWay=�  59   "   $" 90	 6=   $# 90Q�6H   $
$ Time��6V   % 6d   �� $
& Time�$ OneWay=�  5:   "   $$ Content��6=   $
" 1000	 6N   $
# 1000Q�6[   '   
Visibility' 5;   =   �� *
Data.IsCCS+( �� Source#( [ ) �� 	Converter#) [  % 5<   =   �� $& Content�$ OneWay=�  5=   "   $$ Message��6=   $	" 800	 6N   $	# 800Q�6Z   ' 5>   =   �� *Data.IsCXDI+#( [ #) [  % 5?   =   �� $& Message�$ OneWay=�*   RowStyle* 5A      �� 5B   "   + �� 
TargetType,  &Microsoft.Windows.Controls.DataGridRow"+  6(   .�5C   &   -   5        5G   #   5I      5J      5K      ��5M      �� 5N      .R�5O      �� ��6    �� *Name+5P      ��5R      �� 5S      "+ ��6   .�5T      �� , �� Property, � y�- �� Value- 63   �� *	IsShowTab+#) [  5U      5W      � 5Y   
   $��Center=�6   $��5q�6,    5Z      �� 5[      �� 5\      .+�5^      �� .   Search#��Z. 6   $��70��6F   $��Right=�5_      $��0,0,5,0q�5`   7   ��6   �� *SearchCommand+67   �� 5a      $��1��6   	/   OK#��Z/ 6%   $
��Left=�5b      $��70��5c      $��5,0,0,0q�6A   ��6    �� *CloseCommand+6A   5d      5e      5f      