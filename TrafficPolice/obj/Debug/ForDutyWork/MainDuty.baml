   M S B A M L   `   `   `  ����H  DTrafficPolice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TrafficPoliceTrafficPolice  5          TrafficPolice.MainDuty   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:TrafficPolice     5        N� Title$  MainDuty��5	       N� 
Background
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $��0.03* �6   �� 5      �� 5      $��0.03* �6     � RowDefinitions 5   
   �� 5      $��0.05* �6   �� 5      �� 5      $��0.05* �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $��0.08* �6    �� 5      .+�5      o� $��15(�6   $��0��6!   
������ $��Center=�6G   $��Center=�6b   $��Center=�6�   .@�5      m� -   5         m�Name$ 	CreateDtp��5   (   $��Дтп��6   6;   m� 5      -   5        $��Рапорт��5      6+   m� 5      -   5        $ 
bt_Reports��5   +   $��Отчеты��6   6?   m� 5       $��Сотрудники��6   .@�5!      m� -   5        $#��Отобразить всех��5!      68   m� 5"      -   5        $��
Прием��5"      6.   5#      5$      &   System.Windows.Controls.DataGrid  5%      -   5          Name$ dg_MainGrid��5%      $��1��6,   $y�Hidden=�69   $	��400��6M      AutoGenerateColumns .     Columns 5&      4  .System.Windows.Controls.DataGridTemplateColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-   	   CellTemplate	 5(      �� 5)      .R�5*   "   o� $��Center=�6'   $��Center=�6B   .@�5+   &   m� -   5        ��5+   /   �� *	StaffID+.@�5,   *   m� $ bt_viewSertification��6J   -   5        $ ��Удостоверение��5,   3   6h   m� 5-   *   $ bt_YvolStaff��6D   -	   5        $��Уволить��5-   3   6Z   5.   '   5/   #   50      52        53      $ Имя��6-   
   
IsReadOnly
 . 	 54      �� 55      .R�56   "   �� ��6,   �� *	FirstName+57      59        5:      $ Фамилия��6-   
 . 	 5;      �� 5<      .R�5=   "   �� ��6,   �� *
Lastname+5>      5@        5A      $ 
Логин��6-   
 . 	 5B      �� 5C      .R�5D   "   �� ��6,   �� *Login+5E      5G      5J       � 5K      -
   5          �Name$ 	WorkFrame��5K   !   $��1��6   5M      5N      5O      5P      