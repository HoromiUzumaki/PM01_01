   M S B A M L   `   `   `  ����J  FHappy_Tooth_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Happy_Tooth_WPFHappy_Tooth_WPF  5      "    Happy_Tooth_WPF.PatientsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Happy_Tooth_WPF     5        N� Title$  PatientsPage��5	       N� 
Background �	#FFE6F2FF.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $/��)Управление пациентами��6   $��18(�5      $
��Bold"�5      ���	#FF003366$��10q�5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ patientsGrid��5      $��1��5         AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
patient_id+6P     5      $ ФИО��6%   $ * 6P    62   �� *	full_name+6P     5       $ Телефон��6%   $	 150 6P    66   �� *phone+6P     5!      $ Email��6%   $	 200 6N    64   �� *email+6N     5"      $ Дата рождения��6%   $	 120 6z    6<   �� *
birth_date+	 �� StringFormat$	 {0:dd.MM.yyyy}��6z   5$      �� 5&   
   $��2��6   
 �� Orientation$
 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5'      �� -   5        $��Добавить��5'         ActionButtonStyle#��[  6(   6S   �� 5(      -   5        $ ��Редактировать��5(      #��[  6-   6X   �� 5)      -   5        $��Удалить��5)      #��[  6'   6R   5*      5+      5,      