   M S B A M L   `   `   `  ����G  CPlaneBuilder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PlaneBuilderPlaneBuilder  5   	   !    PlaneBuilder.ResearchAddRed   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:PlaneBuilder     5   	     � Title$  ResearchAddRed��5   	   $	��350��6    $	��400��6-   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6"   $��2��62   .+�5      �� $.��(Название иследования:��6   $��Right=�64   $��11(�6P   �� 5      $0��*Результат иследования:��6   $��Right=�65   $��11(�6Q   �� 5      $*��$Статус иследования:��6   $��Right=�62   $��11(�6N   �� 5      $��Лаборатория:��6   $��Right=�6+   $��11(�6G   5      �� 5   
   $��0��6   $��1��6"   $��2��62   .+�5      �� -   5         ��Name$
 Name��5   A   $��25��65   ��6   �� *Name_Research+6A   �� 5      -   5         ��Name$ Result��5   L   $��25��6@    �� DisplayMemberPath$ Name_Result��6\    �� SelectedItem 6   �� *Result_Research+6\   �� 5      -   5        $ Status��5   L   $��25��6@   $ Name_Status��6\    6   �� *Status_Research+6\   �� 5      -   5        $ 
Laboratory��5   P   $��25��6D   $ Name_Laboratory��6d    6   �� *Research_Laboratory+6d   5      �� 5   
   -   5         ��Name$
 Save��5      $��0��6   $��1��6/   $��30��6<   $��Сохранить��6H   $��2��6\   6p   �� 5   
   -   5        $
 Back��5      $��0��6   $��1��6/   $��30��6<   $��
Назад��6H   $��2��6X   $��Bottom=�6l   6�   5       5!      