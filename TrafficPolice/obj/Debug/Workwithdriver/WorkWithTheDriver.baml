   M S B A M L   `   `   `  ����H  DTrafficPolice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TrafficPoliceTrafficPolice  5      %    TrafficPolice.WorkWithTheDriver   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:TrafficPolice     5        N� Title$  WorkWithTheDriver��5	       N� 
Background
 �����.��5      � -   5         �Name$ 	GridFirst��5       � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $��0.07* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DriverGrid��5   D   $��1��6   
�������   
IsReadOnly . $y�Visible=�6X      AutoGenerateColumns .     SelectionUnit$
 Cell=�6�   	   SelectionMode$	 Single=�6�   
   GridLinesVisibility$
 Vertical=�6�   $��Stretch=�6�   $	��Top=�6�      CanUserSortColumns .     MinColumnWidth$ 50Q�6-  $��0,0,7,0q�6A   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ DriverID��6)      CellTemplate 5      �� 5      .R�5      o� $��Center=�6#   $��Center=�6>   .@�5   "   m� -   5        ��5   +   �� *
DriverID+.@�5   &   m� -   5        $��Просмотр��5   /   6A   m� 5   &   -   5        $��Обновить��5   /   6A   m� 5   &   $��
Права��6/   .@�5    *   m�  m�Name$
 View��6E   -   5        $��Просмотр��5    3   6S   m� 5!   *   $ ViewAll��6O   -   5        $(��"Показать все права��5!   3   6`   m� 5"   *   -   5        $��Выдать��5"   3   6C   5#   '   5$   #   5%      5&      5(        5)      $ 	FirstName��6)      
IsReadOnly .  5*      �� 5+      .R�5,      �� ��6(   �� *	FirstName+5-      5/        50      $ 
Patronymic��6)    .  51      �� 52      .R�53      �� ��6(   �� *
Patronymic+54      56      58       � 59   
   -	   5          �Name$ FrameFromNavigation��59   1   $��1��6   $y�Hidden=�6   61   � 5:   
   $��0��6   .+�5;      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   .+�5=      o� 
������ .@�5?      m� -
   5        $6��0Отобразить всех водителей��5?      6B   m� 5@      -   5        $��Создать��5@      60   m� 5A      -   5        $��
Найти��5A      6.   5B      5C      5D      5E      5F      