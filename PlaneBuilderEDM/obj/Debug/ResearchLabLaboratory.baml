   M S B A M L   `   `   `  ����J  FPlaneBuilderEDM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PlaneBuilderEDMPlaneBuilderEDM  5   	   +    %PlaneBuilderEDM.ResearchLabLaboratory   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PlaneBuilderEDM     5   	   -   5          � Title$
  ИС��5   	   $	��450��6   $	��800��6!   $��16(�6-   $��Times New Roman)�6;   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��1��6   $��0��6    $��2��6-   $:��4Окно просмотра исследования��6A   $��Center=�6g   $��Center=�6�   $��18(�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgResearch��5   U   $��0��6   $��1��6#   $��3��60   $��2��6D      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$0 *Название исследования ��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6E   �� *Name_Research+  5      $1 +Результат исследования��6%    6E   �� *Result_Research.Name_Result+  5      $, &Статус исследования ��6%    6C   �� *Status_Research.Name_Status+  5      $ Лаборатория��6%    6:   �� *%#Research_Laboratory.Name_Laboratory+4  .System.Windows.Controls.DataGridTemplateColumn  5         Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)   	   CellTemplate	 5      �� 5       .R�5!      �� 
 ��Name$
 btnRed��68   -   5        $��Изменить��5!   %   6H   5"      5$      5&      �� 5'   
   -   5        $
 btnAdd��5'   ^   $��3��6   $��1��6!   $��Center=�6.   $��Добавить��6J   6n   �� 5(   
   -   5        $
 btnDel��5(   Z   $��3��6   $��2��6!   $	��Top=�6.   $��Удалить��6G   6j   �� 5)   
   -   5        $
 btnBack��5)   [   $��3��6   $��4��6!   $��Center=�6/   $��
Назад��6K   6l   5*      5+      