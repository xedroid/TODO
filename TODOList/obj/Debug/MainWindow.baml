   M S B A M L   `   `   `  ����C  ?TODOList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TODOListTODOList  5   	       TODOList.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:TODOList     5   	     � 
ResizeMode$  NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � Title$ Task manager��5
   	   $	��600��6   $	��840��6+   .��5      ]� $��10q�6   .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5        $��	_Settings��5       m� Icon 5      �� 5      $��20��6    $��20��6+   $��Images/settings.png��67   5      5      5      �� 5   
   $��1q�6   
���   �._�5   
   �� $��Right=�6   $��10,0,0,0q�6,   $	��300��6>    � 	Resources 5       �� 
TargetType �� Property �� Value��%X   '��       �� 5      " ��6   .�5      ��  � ��$ 0,0,0,10q�6/   5      5      .+�5      �� $
��Bold"�6   $��Center=�6*   $��0,0,0,10q�6G   Task6_   �� 5      $��Title��6   �� 5      -   5        $��txtTitle��5      �� 5       $��Description��6   �� 5!      -   5        $��txtDescription��5!   ?    �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�6+   
 �� MinLines$
 2��6U   �� 5"      $
��Date��6   (  "System.Windows.Controls.DatePicker  5#      -   5        $��dpExecutionDate��5#      $��0,0,0,10q�60   � 5$       � ColumnDefinitions 5%      �� 5&      $��* �6+   �� 5'      $��* �6+   .+�5)      �� -   5        $��
btnAddTask��5)   -   $��0��6   $	��100��6X   .��6d   Create task6q   �� 5*      -   5        $��	btnCancel��5*   -   $��1��6   $y�Hidden=�6V   $	��100��6j   .��6w   Cancel6   5+      5-      5.      �� 5/   
   .+�50      �� $��10q�6    �� Orientation$ 
Horizontal=�6%   .+�51      �� -   5        $��lbDate��51      $
��Date��6&   $
��Bold"�65     52      -   5        $��dpDate��52      6,   53      �� 55      -	   5        $��lvTasks��55   #   $��10q�6    �� View 56      �� 57      .P�58      �� $��Title��6%    �� Width$	 100��64    �� CellTemplate 59      �� 5:      .R�5;   "   �� $
��Wrap=�6,   ��6@   �� *Title+5<      5>      �� 5?      $��Description��6%   $	 220��6:    5@      �� 5A      .R�5B   "   �� $
��Wrap=�6,   ��6@   �� *ShortDescription+5C      5E      �� 5F      $
��Date��6%   $	 100��63    5G      �� 5H      .R�5I   "   �� ��6,   �� *ExecutionDate+ �� StringFormat$ d��5J      5L      �� 5M      $�� ��6%   $ 40��6/    5N      �� 5O      .R�5P   "   �� -
   5        
�������
������� � ToolTip$! Removing the selected item.��5P   P   $��Center=�6�   $��Center=�6�   .��5Q   &   �� .+�5R   *   �� $��Images/delete.png��60   5S   '   5T   #   5U      5W      5X      5Z      5[      5\      5_      