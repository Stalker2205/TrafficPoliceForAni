   M S B A M L   `   `   `  ����H  DTrafficPolice, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TrafficPoliceTrafficPolice  5      #    TrafficPolice.WorkWithTheAvto   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:TrafficPolice     5        N� Title$  WorkWithTheAvto��5	       N� 
Background
 �����.��5      � -   5         �Name$ 	GridFirst��5       � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $��0.07* �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgCar��5       $��1��6   
�������   
IsReadOnly . $y�Visible=�6S      AutoGenerateColumns .     SelectionUnit$
 Cell=�6�   	   SelectionMode$	 Single=�6�   
   GridLinesVisibility$
 Vertical=�6�   $��Stretch=�6�   $	��Top=�6�      CanUserSortColumns .     MinColumnWidth$ 50Q�6(  $��0,0,7,0q�6<   J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      CellTemplate 5      �� 5      .R�5      o� $��Center=�6#   $��Center=�6>   .@�5   "   m� -   5        ��5   +   �� *CarID+.@�5   &   m�  m�Name$ bt_openInfoWithAvto��6A   -   5        $��Просмотр��5   /   6^   m� 5   &   $ 
bt_OpenCTC��6<   -   5        $��СТС��5   /   6P   m� 5   &   $ 
tb_OpenPTC��6<   -   5        $��ПТС��5   /   6P   m� 5    &   $ bt_OpenInsurance��6B   -   5        $��Страховка��5    /   6\   m� 5!   &   $ tb_OpenInspections��6C   -   5        $��Тех.Осмотр��5!   /   6_   m� 5"   &   $ bt_OpenStatement��6B   -	   5        $��Заявления��5"   /   6\   5#   #   5$      5%      5'        5(      $ Машина��6)      
IsReadOnly .  5)      �� 5*      .R�5+      �� ��6(   �� *VenhicleType+5,      5.        5/      $# Номер двигателя��6)    .  50      �� 51      .R�52      �� ��6(   �� *EngineNumber+53      55        56      $ Цвет��6)    .  57      �� 58      .R�59      �� ��6(   �� *Color+5:      5<        5=      $ Max.Масса��6)    .  5>      �� 5?      .R�5@      �� ��6(   �� *
MaxVeigh+5A      5C        5D      $	 Vin��6)    .  5E      �� 5F      .R�5G      �� ��6(   �� *Vin+5H      5J      5M       � 5N   
   -
   5          �Name$ FrameFromNavigation��5N   1   $��1��6   $y�Hidden=�6   61   � 5O   
   $��0��6   .+�5P      ��  �� Orientation$ 
Horizontal=�6   $	��Top=�62   .+�5R      o� 
������ .@�5S      m� -   5        $ bt_WiewAllCars��5S   <   $*��$Отобразить все авто��6   6T   m� 5T      -   5        $ bt_registredCar��5T   9   $&�� зарегистрировать��6   6R   m� 5U      $��
Найти��6   5V      5W      5X      5Y      5Z      