   M S B A M L   `   `   `  ����D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5   	   ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  5   	       LogViewer.View.MoveToLine   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   1mvvm"clr-namespace:LogViewer.MVVMHelper    5   	   7
properties"clr-namespace:LogViewer.Properties    5   	   $   LogViewer.Properties.Resources    
MoveToLine � Title# Z  5   	   $	��140��6<   $	��238��6I    � WindowStyle$ 
ToolWindow=�6U    � 
ResizeMode$ NoResize=�6n    � WindowStartupLocation$ CenterOwner=�6�    � 	Resources 5      +   %LogViewer.MVVMHelper.CommandReference   JumpToLineCommandReference   Command��%<   &	          5   
    6C   �� *JumpToLineCommand+5	       J� InputBindings 5
      �� 5   
   
 �� Key$ Enter��6   	 �� Command#	 [  6!   .��5      � $	��106��6   $	��216��6   .+�5   
   �� .+�5      � $��Center=�6   $��5q�65   .+�5      �� -   5        $!��MoveToLine_LineNumber_Title��5   M   
   
LineNumber#��Z
 6   6M   �� 5      -   5        $#��MoveToLine_LineNumber_Textbox��5      $	��100��6?   ��6�   �� *Line+ �� UpdateSourceTrigger$ PropertyChanged=�6  5      �� 5      -   5        $��MoveToLine_Warning_Lable��5   M   $��Center=�60   
���  ����6   �� *	Message+6m   � 5      $��Center=�6   $��5q�65   .+�5      �� -   5        $��MoveToLine_Button_JumpTo��5   J      JumpTo#��Z 6   $	��Top=�6�   $��75��6�   $��2,2,12,2q�6�   ��6j   �� *JumpToLineCommand+6�   �� 5      -   5        $��MoveToLine_Button_Cancel��5   J      Cancel#��Z 6   $	��Top=�6j   $��75��6�    �� IsCancel . $��12,2,2,2q�6�   5      5      5      5      