   M S B A M L   `   `   `  ���� >  :CP1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CP1CP1      CP1.AdminChangeWin   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     #localclr-namespace:CP1       � Title$  AdminChange��$	��750��$	��600�� � AllowsTransparency$
 True��
������  � WindowStyle$
 None=�.����  �� CornerRadius$ 25��
���   �$��2q� �� Padding$ 6q�����  �� 
StartPoint$	 0,2&� �� EndPoint$	 1,1&�.���  � Color$ 	LightBlue�� � Offset$ 0Q�� $ DarkBlue��$ 3Q�._�� 	 � RowDefinitions	 �� $
��0.5* ��� $
��0.5* ��� $
��0.5* ��� $
��0.5* ��� �� $
��1.5* ��� $
��0.5* ��� $
��0.5* ��� $
��1.5* ��� $
��0.5* �
 � ColumnDefinitions
 �� �� .+��� -   $��AdminChangeExit��$��1��$��0��$��X�����#b01919$
��Bold"�$	��Top=�$��Right=�$��35��$��30�� � 	Resources  �� 
TargetType �� Property �� Value��%:   '��       �� " ��.���  �@��CornerRadius$ 25���� $��1��$��2��$��Center=�$��Center=�
���   �$
��Bold"�$��20(�$��Italic$�.���� $��	Underline{�GPU�� $��2��$��0��$��Center=�$��Center=�
�������$
��Bold"�$��20(�$��Italic$�.��Name of product�� $ 5q�$��1q�
���   �
�������$ 10��$��Center=�$��2��$��1��$��30��$	��290��._��� -    ��Name$ 	GpuNameTb��
��������� $��3��$��Center=�$��Center=�
�������$
��Bold"�$��20(�$��Italic$�.��Price of product�� $ 5q�$��1q�
���   �
�������$ 10��$��Center=�$��3��$��1��$��30��$	��290��._��� -   $ PriceProduct��
��������� $��4��$��0��$��Center=�$��Center=�
�������$
��Bold"�$��20(�$��Italic$�.��	Date time(  "System.Windows.Controls.DatePicker  -     Name$ 
DataPicker��$��4��$��1��$
{�True���� -    ��Name$ BrowseChange��$��Browse Photo��$
��Bold"����#0167c1$��Italic$�$��Center=�$	��150��$��40��$��0��$��5��
������� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10���� -    ��Name$ PictureProduct��$��1��$��5��$	��200��$	��100���� $��6��$��2��$��Center=�$��Center=�
�������$
��Bold"�$��20(�$��Italic$�.���� $��	Underline{�Descriptionc� $	��Top=�$��2q�
���   �$��2��$��7��.@�d� -   $��btnBold��$ ��EditingCommands.ToggleBold��$��Normal$�$��15(�.���� $��/RtBoxImages/Bold.png��$��Uniform=��� d� -   $��
btnnItalic��$"��EditingCommands.ToggleItalic��$��Italic$�$��15(�.���� $��/RtBoxImages/Italic.png��$��Uniform=��� d� -	   $��btnUnderline��$%��EditingCommands.ToggleUnderline��$��15(�.���� $ ��/RtBoxImages/Underline.jpg��$��Uniform=��� �� -
    ��Name$ ComboBoxFontFamily��$	��150���� -   $ ComboBoxFontSize��$��75���� -   $ ComboBoxColor��$��90���� $��22��$��60��$��2q�
���   �.@��� -    ��Name$ 
TBNumWords��$��55��$��15���� -    ��Name$ 
RTBoxTyper��$��8��$��2��$	��150��. �/� .T�J� .*�.*��� $� ���� -   $
 Save��$
��SAVE��$
��Bold"�$��Italic$�$��9��$��2�����#0167c1
�������$	��250��$��35�� ��%:   '��       �� " ��.���  �@��CornerRadius$ 10��