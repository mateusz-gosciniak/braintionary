   M S B A M L   `   `   `  ���� G  Cbraintionary, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null+clr-namespace:braintionarybraintionary      braintionary.AddWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     ,localclr-namespace:braintionary       � Title$  Tworzenie listy słówek�� � WindowStartupLocation$ CenterScreen=�$	��500��$	��300��.��� $��5q� � RowDefinitions �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $��1* � � ColumnDefinitions �� �� �� .+��� $��0��$��0��$��Nazwa listy słówek:��$��5q��� -    ��Name$ tbTitleName��$��0��$��1��$	��100��$��5q��� $��1��$��0��$��	Słówko:��$��5q��� -   $ 
tbOriginal��$��1��$��1��$	��100��$��5q��� $��2��$��0��$��Odpowiednik:��$��5q��� -   $ tbNew��$��2��$��1��$	��100��$��5q��� -    ��Name$
 bAdd��$��3��$��2��$��Dodaj następne��$��5q��� -    ��Name$ cbTurnOffMessageBox��$��4��$��2��$/��)Wyłącz powiadomienia o dodanym słówku�� d� 	IsChecked$
 TrueY�$��5q��� -   $ bSave��$��5��$��2��$��Zapisz��$��5q��� -   $
 bEnd��$��6��$��2��$��Zakończ��$��5q��� -    ��Name$ lvWords��$��8��$��3��	 �� View	 �� .P��� $��Słówko��
 �� Width$

 auto�� �� DisplayMemberBinding �� *name1+�� $��Odpowiednik��$

 auto�� �� *name2+