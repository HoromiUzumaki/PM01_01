   M S B A M L   `   `   `  ����J  FHappy_Tooth_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Happy_Tooth_WPFHappy_Tooth_WPF  5           Happy_Tooth_WPF.VisitsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Happy_Tooth_WPF     5        N� Title$  
VisitsPage��5	       N� 
Background �	#FFE6F2FF.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $6��0История визитов пациентов��6   $��18(�5      $
��Bold"�5      ���	#FF003366$��10q�5      �� 5   
   $��1��6   
������� �� CornerRadius$ 5��61    �� Padding$ 10q�6B   $��10q�6O   ._�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ cmbPatientFilter��5      $	��200��65   $��5q�6A    �� DisplayMemberPath$ 	full_name��6L      ComboBoxStyle#��[  5      �� 5      -   5        $ cmbDoctorFilter��5      $	��200��64   $��5q�6@   $ 	full_name��6K   #��[  5       (  "System.Windows.Controls.DatePicker  5!      -   5          Name$ 
dpFromDate��5!      $	��150��61   $��5q�6=   	   SelectedDateFormat$	 Short=�6H     DatePickerStyle#��[ 5"        5#      -   5        $ dpToDate��5#      $	��150��6/   $��5q�6;   $	 Short=�6F   #��[ 5$      �� 5%      -   5        $��Фильтровать��5%        ActionButtonStyle#��[ 6/   6Z   �� 5&      -   5        $��Сбросить��5&      #��[ 6,   6W   5'      5(      &   System.Windows.Controls.DataGrid  5*   
   -   5        
  Name$
 
visitsGrid��5*      $��2��5+         AutoGenerateColumns .     Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
visit_id+6N     50      $ Пациент��6%   $ * 6j    66   �� *!appointments.patients.full_name+6j     51      $ Врач��6%   $ * 6f    63   �� * appointments.doctors.full_name+6f     52      $ Дата приема��6%   $	 120 6�    6:   �� *appointments.appointment_time+ �� StringFormat$ 
dd.MM.yyyy��6�     53      $ Диагноз��6%   $ * 6T    66   �� *	diagnosis+6T     54      $ Стоимость��6%   $	 120 6p    68   �� *total_price+$ {0:C}��6p   56      �� 59   
   -   5         ��Name$ visitDetailsPanel��59   [   $��3��6   
�������$ 5��61   $ 10q�6B   $��10q�6O   ._�5:      �  5;      �� 5<      $
��Auto �6$   �� 5=      $
��Auto �6$   �� 5>      $
��Auto �6$   �� 5?      $��* �6$    � ColumnDefinitions 5A      �� 5B      $
��Auto �6'   �� 5C      $��* �6'   .+�5F      �� $��Диагноз:��6   $��0��6+   $��0��68     
LabelStyle#��[ 5G      �� 5H      -	   5         ��Name$ txtDiagnosis��5H      $��0��60   $��1��6=   $��5q�6M    �� 
IsReadOnly . 6X   �� 5J      $��Лечение:��6   $��1��6+   $��0��68   #��[ 5K      �� 5L      -
   5        $ txtTreatment��5L      $��1��60   $��1��6=   $��5q�6M    . 6X   �� 5N      $&�� Оказанные услуги:��6   $��2��64   $��0��6A   $��2��6Q   #��[ 5O        5P      -   5        $
 servicesGrid��5P      $��3��61   $��0��6>   $��2��6N   $��5q�6b    .     
IsReadOnly .  5R        5S      $ Услуга��6-   $ * 6_    6=   �� *services.name+6_     5T      $ Количество��6-   $
 Auto 6^    6A   �� *
quantity+6^     5U      $ Цена��6-   $
 Auto 6v    6;   �� *services.price+$ {0:C}��6v   5W      5X      5Y      5Z      5[      