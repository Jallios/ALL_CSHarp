   M S B A M L   `   `   `  ����G  CPlaneBuilder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PlaneBuilderPlaneBuilder  5   	       PlaneBuilder.Cex   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PlaneBuilder     5   	   -   5          � Title$	  Cex��5   	   $	��450��6   $	��800��6"   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dtgWorkshop��5   U   $��1��6   $��0��6    $��3��60   $��3��6D      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Название цеха ��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *Name_Workshop+  5      $' !Расположение цеха��6%    6@   �� *Location_Workshop+  5      $ Адрес участка��6%    6<   �� *Area.Address_Area+4  .System.Windows.Controls.DataGridTemplateColumn  5         Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)   	   CellTemplate	 5      �� 5      .R�5      �� 
 ��Name$
 btnRed��68   -   5        $��Изменить��5   %   6H   5       5"      5$      �� 5%   
   $��1��6   $��0��6    $��2��6-   $��Окно цеха��6A   $��Center=�6U   $��Center=�6p   $��20(�6�   �� 5&   
   -   5        $
 btnDel��5&   k   $��3��6   $��2��6!   $��Center=�6/   $��20(�6J   $��Удаление��6X   6{   �� 5'   
   -   5        $
 btnAdd��5'   m   $��3��6   $��1��6!   $��Bottom=�6/   $��20(�6J   $��Добавление��6X   6}   �� 5(   
   -   5        $
 btnBack��5(   h   $��3��6   $��4��6!   $��Center=�6/   $��20(�6J   $��
Назад��6X   6y   5)      5*      