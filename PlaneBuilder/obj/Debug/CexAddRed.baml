   M S B A M L   `   `   `  ����G  CPlaneBuilder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PlaneBuilderPlaneBuilder  5   	       PlaneBuilder.CexAddRed   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PlaneBuilder     5   	   -   5          � Title$  	CexAddRed��5   	   $	��350��6   $	��400��6(   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6"   $��2��62   .+�5      �� $ ��Название цеха:��6   $��Right=�6-   $��11(�6I   �� 5      $��Адресс:��6   $��Right=�6&   $��11(�6B   �� 5      $��Участок:��6   $��Right=�6'   $��11(�6C   5      �� 5   
   $��0��6   $��1��6"   $��2��62   .+�5      �� -   5         ��Name$ Surname��5   A   $��25��65   ��6   �� *Name_Workshop+6A   �� 5      -   5        $
 Name��5   E   $��25��69   ��6   �� *Location_Workshop+6E   �� 5      -   5         ��Name$
 Area��5   A   $��25��65    �� DisplayMemberPath$ Address_Area��6O    �� SelectedItem 6   �� *Area+6O   5      �� 5   
   -   5         ��Name$
 Save��5      $��0��6   $��1��6/   $��30��6<   $��Сохранить��6H   $��2��6\   6p   �� 5   
   -   5        $
 Back��5      $��0��6   $��1��6/   $��30��6<   $��
Назад��6H   $��2��6X   $��Bottom=�6l   6�   5      5      