   M S B A M L   `   `   `  ����D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  5   	   ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties  5   	       LogViewer.View.MoveToTime   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   1mvvm"clr-namespace:LogViewer.MVVMHelper    5   	   7
properties"clr-namespace:LogViewer.Properties    5   	   -   5        $   LogViewer.Properties.Resources    
MoveToTime � Title# Z  5   	   $	��350��5   	    � WindowStyle$ 
ToolWindow=�6    � 
ResizeMode$ NoResize=�6.    � SizeToContent$ Height=�5   	    � WindowStartupLocation$ CenterOwner=�5	   	    � 	Resources 5
      +   %LogViewer.MVVMHelper.CommandReference   JumpToLineCommandReference   Command��%<   &	          5   
    6C   �� *JumpToLineCommand+5       J� InputBindings 5      �� 5   
   
	 �� Key$	 Enter��6   
 �� Command#
 [  6!   .��5      � .+�5   
   �� $��Center=�6   $��	0,0,-9,12q�62   .+�5      �� .+�5      � $
��Left=�6   $��0,15,0,0q�67   .+�5      �� -   5        $��MoveToTime_Date_Title��5   P      	DateColon#��Z 6   6P   �� 5      -   5        $��MoveToTime_Year_ComboBox��5   8   $��60��6   $��60��6*   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6X   �� *
ListYear+ �� SelectedValue 6y   �� *Year+6�   �� 5      -   5        $��label2��5   L      Slash#��Z 6   6L   �� 5      -   5        $��MoveToTime_Month_ComboBox��5   *   $��45��6   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6K   �� *	ListMonth+ 6m   �� *Month+6�   �� 5      -   5        $��label3��5   L   #��Z 6   6L   �� 5      -   5        $��MoveToTime_Day_ComboBox��5   *   $��45��6   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6I   �� *	ListDay+ 6i   �� *Day+6�   5      � 5      $
��Left=�6   $��0,5,0,0q�67   .+�5      �� -   5        $��MoveToTime_Time_Title��5   P      	TimeColon#��Z 6   6P   �� 5      -	   5        $��MoveToTime_Hour_ComboBox��5   8   $��60��6   $��60��6*   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6X   �� *
ListHour+ 6y   �� *Hour+6�   �� 5      -
   5        $��label5��5   L      Colon#��Z 6   $��14��6Z   �� 5      -   5        $ ��MoveToTime_Minute_ComboBox��5   *   $��45��6   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6L   �� *
ListMinute+ 6o   �� *Minute+6�   �� 5       -   5        $��label6��5    L   #��Z 6   $��14��6Z   �� 5!      -   5        $ ��MoveToTime_Second_ComboBox��5!   *   $��45��6   $��Center=�6�   $��Center=�6�   $��Center=�6�   $��Center=�6�   ��6L   �� *
ListSecond+ 6o   �� *Second+6�   �� 5"      -   5        $��label4��5"   L   #��Z 6   6L   �� 5#      -   5        $$��MoveToTime_Millisecond_TextBox��5#   )   $��45��6    �� 	MaxLength$ 3��6�   ��6�   �� *
MiliSecond+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5$      � 5%      $��Center=�6   .+�5&      �� $
��Left=�6!   .+�5'      �� -   5        $��MoveToTime_Warning1��5'       
���  ����6;   �� *
Message1+6X   �� 5(      -   5        $��MoveToTime_Warning2��5(       
���  ����6;   �� *
Message2+6X   5)      5*      � 5,      $��Center=�6   $��0,0,0,5q�69   .+�5-      �� -   5        $��MoveToTime_Button_JumpTo��5-   k   $��80��6   $��0,0,20,0q�6(      JumpTo#��Z 6:   ��6�   �� *JumpToLineCommand+�� 5.      -   5        $��MoveToTime_Button_Cancel��5.   k   $��80��6   $��20,0,0,0q�6(      Cancel#��Z 6:    �� IsCancel . 6�   5/      50      52      53      54      