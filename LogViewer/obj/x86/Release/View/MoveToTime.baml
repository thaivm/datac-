   M S B A M L   `   `   `  ���� D  @LogViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogViewer.MVVMHelperLogViewer.MVVMHelper  ;"clr-namespace:LogViewer.PropertiesLogViewer.Properties      LogViewer.View.MoveToTime   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     8x,http://schemas.microsoft.com/winfx/2006/xaml    1mvvm"clr-namespace:LogViewer.MVVMHelper    7
properties"clr-namespace:LogViewer.Properties    -   $   LogViewer.Properties.Resources    
MoveToTime � Title# Z  $	��350�� � WindowStyle$ 
ToolWindow=� � 
ResizeMode$ NoResize=� � SizeToContent$ Height=� � WindowStartupLocation$ CenterOwner=� � 	Resources +   %LogViewer.MVVMHelper.CommandReference   JumpToLineCommandReference   Command��%.   &	           �� *JumpToLineCommand+ J� InputBindings �� 
	 �� Key$	 Enter��
 �� Command#
 [  .��� .+��� $��Center=�$��	0,0,-9,12q�.+��� .+�� $
��Left=�$��0,15,0,0q�.+��� -   $��MoveToTime_Date_Title��   	DateColon#��Z �� -   $��MoveToTime_Year_ComboBox��$��60��$��60��$��Center=�$��Center=�$��Center=�$��Center=����� *
ListYear+ �� SelectedValue �� *Year+�� -   $��label2��   Slash#��Z �� -   $��MoveToTime_Month_ComboBox��$��45��$��Center=�$��Center=�$��Center=�$��Center=����� *	ListMonth+ �� *Month+�� -   $��label3��#��Z �� -   $��MoveToTime_Day_ComboBox��$��45��$��Center=�$��Center=�$��Center=�$��Center=����� *	ListDay+ �� *Day+� $
��Left=�$��0,5,0,0q�.+��� -   $��MoveToTime_Time_Title��   	TimeColon#��Z �� -	   $��MoveToTime_Hour_ComboBox��$��60��$��60��$��Center=�$��Center=�$��Center=�$��Center=����� *
ListHour+ �� *Hour+�� -
   $��label5��   Colon#��Z $��14���� -   $ ��MoveToTime_Minute_ComboBox��$��45��$��Center=�$��Center=�$��Center=�$��Center=����� *
ListMinute+ �� *Minute+�� -   $��label6��#��Z $��14���� -   $ ��MoveToTime_Second_ComboBox��$��45��$��Center=�$��Center=�$��Center=�$��Center=����� *
ListSecond+ �� *Second+�� -   $��label4��#��Z �� -   $$��MoveToTime_Millisecond_TextBox��$��45�� �� 	MaxLength$ 3������ *
MiliSecond+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�� $��Center=�.+��� $
��Left=�.+��� -   $��MoveToTime_Warning1��
���  ������ *
Message1+�� -   $��MoveToTime_Warning2��
���  ������ *
Message2+� $��Center=�$��0,0,0,5q�.+��� -   $��MoveToTime_Button_JumpTo��$��80��$��0,0,20,0q�   JumpTo#��Z ���� *JumpToLineCommand+�� -   $��MoveToTime_Button_Cancel��$��80��$��20,0,0,0q�   Cancel#��Z  �� IsCancel . 