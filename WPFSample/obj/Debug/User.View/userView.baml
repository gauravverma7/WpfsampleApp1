   M S B A M L   `   `   `  ����  	WPFSample    WPFSample.userView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  _this��5   	    � Title$ WPFSample Application��5   	    � WindowState$ 	Maximized=�5   	   $
��1000��5   	   $	��700��5   	    � 	Resources 5	         DataGridStyle1 �� 
TargetType&   System.Windows.Controls.DataGrid �� Property  ColumnHeaderStyle1 �� Value��%�   &	        �� 5   
   "  6'   .�5      ��  �@ ColumnHeaderStyle# �  62   �� 5       � ��$
 Left=�6;   5      5      .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $ 
Horizontal=�6   .+�5      �� $�� ��6   $��0��6    �� 5      $��User Id��5      $��Stretch=�5      $��	10,10,0,0q�5      $��Center=�5      
�������$	��120��5      6   �� 5      -   5        $��Stretch=�5      $��	10,10,0,0q�5      $��Center=�5      $	��120��5      
�������5!      �� 5#      $�� ��6   $��0��6    �� 5$      -   5        $��
detailInfo��5$   g   $��1��6   $	��120��6"   $��Stretch=�6.   $��Center=�6L   $��	10,10,0,0q�5%   	   
�������.��6C   Detailed Information6Y   �� 5&      $��       ��6   $��0��6'   �� 5'      -   5        $��	ComboType��5'      $��Stretch=�5(      $��	10,10,0,0q�5)      $��Center=�5*      $	��120��5+      
�������5-   3   �� 5.      -   5        $��1��5.      $	��100��6"   $��Stretch=�6.   $��Center=�6N   $��	10,10,0,0q�5/   	   
�������.��6G   CopyContents6U   50      � 51   
   $��	0,0,0,-20q�6   .+�52        -   5        $��dgUsers��52         AutoGenerateColumns .  #���   6j   	   CanUserAddRows	 .  
   CanUserReorderColumns
 .   � DataContext 6B   �� *viewModel.users+   Columns 53      0  *System.Windows.Controls.DataGridTextColumn  54      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *userId+,  &System.Windows.Controls.DataGridColumn   Header 55      �� 56      $ 
Horizontal=�6)   .+�57   "   �� $��UserID��6,   $��0��6:   58      5:        5;      $ Id��6*    66   �� *id+  5<       6)   �� *title+ 5=      �� 5>      $ 
Horizontal=�6)   .+�5?   "   �� $��Title��6,   $��0��69   5@      5B        5C         Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6p      
Visibility 6)   �� *	IsVisible+ �� Mode$ OneWay=� 6W   �� *body+ 5D      �� 5E      $ 
Horizontal=�6)   .+�5F   "   �� $��Description��6,   $��0��6?   5G      5I      5L      5O      5P      5X      