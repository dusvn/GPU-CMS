   M S B A M L   `   `   `  ���� >  :CP1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CP1CP1      CP1.AdminWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:CP1     -     � Title$  AdminWindow��$	��500��$	��800�� � AllowsTransparency$
 True��
������  � WindowStyle$
 None=�.����  �� CornerRadius$ 25��
���   �$��2q� �� Padding$ 6q�����  �� 
StartPoint$	 0,2&� �� EndPoint$	 1,1&�.���  � Color$ 	LightBlue�� � Offset$ 0Q�� $ DarkBlue��$ 3Q�._��� .+��� -   $��ExitAdminWin��$��0 0 5 0q�$��X�����#b01919$	��Top=�$��Right=�$��22��$
��Bold"�	 � 	Resources	 
 �� 
TargetType �� Property �� Value��%:   '��       �� "
 ��.���  �@��CornerRadius$ 25��� $��
20 20 20 0q�$	��350��.+�&   System.Windows.Controls.DataGrid  -     Name$ DataGridGraphicCards��   SelectionMode$ Single=�   AutoGenerateColumns$ False��   CanUserAddRows$ False������ *GraphicCards+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ *    Header$ CheckBox��   CellTemplate �� .R���  ��Name$ CheckBox��-   $��Center=�$��Center=�5  /System.Windows.Controls.DataGridHyperlinkColumn  -   	HyperLink��$
 Name��$	 200 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+   ElementStyle �� .�-     $	 100    
IsReadOnly$
 True�� �� .R��� ���� *Image+0  *System.Windows.Controls.DataGridTextColumn  $ 	Date Time��$ * $
 True�� �� *Time+� $��0 30 0 0q� � ColumnDefinitions �� $��* ��� $��* �.+��� -    ��Name$ Remove��$��REMOVE��$��
80 10 80 0q�$
��Bold"����#dd1717$��Italic$�$��0��$��Center=�
�������	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10���� -   $	 ADD��$	��ADD��$��
80 10 80 0q�$
��Bold"����#0167c1$��Italic$�$��1��$��Center=�
�������	 ��%:   '��       �� "
 ��.���  �@��CornerRadius$ 10��