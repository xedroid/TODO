   M S B A M L   `   `   `  ���� C  ?TODOList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TODOListTODOList      TODOList.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:TODOList       � 
ResizeMode$  NoResize=� � WindowStartupLocation$ CenterScreen=� � Title$ Task manager��$	��600��$	��840��.��]� $��10q�.+�o� $	��Top=�.@�m� $��_File��.@�m� -   $��	_Settings�� m� Icon �� $��20��$��20��$��Images/settings.png���� $��1q�
���   �._��� $��Right=�$��10,0,0,0q�$	��300�� � 	Resources  �� 
TargetType �� Property �� Value��%3   '��       �� " ��.���  � ��$ 0,0,0,10q�.+��� $
��Bold"�$��Center=�$��0,0,0,10q�Task�� $��Title���� -   $��txtTitle���� $��Description���� -   $��txtDescription�� �� AcceptsReturn . 	 �� TextWrapping$
	 Wrap=�
 �� MinLines$
 2���� $
��Date��(  "System.Windows.Controls.DatePicker  -   $��dpExecutionDate��$��0,0,0,10q��  � ColumnDefinitions �� $��* ��� $��* �.+��� -   $��
btnAddTask��$��0��$	��100��.��Create task�� -   $��	btnCancel��$��1��$y�Hidden=�$	��100��.��Cancel�� .+��� $��10q� �� Orientation$ 
Horizontal=�.+��� -   $��lbDate��$
��Date��$
��Bold"�  -   $��dpDate���� -	   $��lvTasks��$��10q� �� View �� .P��� $��Title�� �� Width$	 100�� �� CellTemplate �� .R��� $
��Wrap=����� *Title+�� $��Description��$	 220�� �� .R��� $
��Wrap=����� *ShortDescription+�� $
��Date��$	 100�� �� .R��� ���� *ExecutionDate+ �� StringFormat$ d���� $�� ��$ 40�� �� .R��� -
   
�������
������� � ToolTip$! Removing the selected item.��$��Center=�$��Center=�.���� .+��� $��Images/delete.png��