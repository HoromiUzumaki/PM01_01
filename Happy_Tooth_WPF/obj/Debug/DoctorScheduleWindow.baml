   M S B A M L   `   `   `  ����J  FHappy_Tooth_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Happy_Tooth_WPFHappy_Tooth_WPF  5   	   *    $Happy_Tooth_WPF.DoctorScheduleWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Happy_Tooth_WPF     5   	     � Title$%  Расписание врача��5   	   $	��450��6"   $	��600��6/    � WindowStartupLocation$ CenterOwner=�5	   	   ���	#FFE6F2FF.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ lblDoctorName��5      $��16(�6'   $
��Bold"�65   ���	#FF0033666G   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��	0,10,0,10q�6;   .+�5      �� -   5         ��Name$ cmbDayOfWeek��5      $	��120��6-   $��0,0,10,0q�69   .@�5      �� $
��пн��6   �� 5      $
��вт��6   �� 5      $
��ср��6   �� 5      $
��чт��6   �� 5      $
��пт��6   �� 5      $
��сб��6   �� 5      $
��вс��6   5      �� 5       $��Начало:��6   $��Center=�6&   �� 5!      -   5         ��Name$ txtStartTime��5!      $��80��6,   $��5,0,10,0q�67   $��09:00��6I   �� 5#      $��Конец:��6   $��Center=�6%   �� 5$      -   5        $ 
txtEndTime��5$      $��80��6*   $��5,0,10,0q�65   $��18:00��6G   �� 5&      -   5        $��Добавить��5&         ActionButtonStyle#��[  6(   6S   5'      &   System.Windows.Controls.DataGrid  5)   
   -   5          Name$ scheduleGrid��5)      $��2��6)      AutoGenerateColumns .  	   Columns	 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn
   Header$
 День недели��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *day_of_week+6Z     5,      $
 Начало��6%   $ * 6T    65   �� *
start_time+6T     5-      $
 
Конец��6%   $ * 6Q    64   �� *
end_time+6Q   4  .System.Windows.Controls.DataGridTemplateColumn  5.      $
 Auto 6)      CellTemplate 5/      �� 50      .R�51      �� -   5        $��Удалить��51   %   #��[  52   %   
 � Tag 54   %   �� *schedule_id+55      57      59      �� 5;   
   -   5        $��3��5;      $��Закрыть��6   $��Right=�60   $	��100��6L   #��[  5<      5=      5>      5?      