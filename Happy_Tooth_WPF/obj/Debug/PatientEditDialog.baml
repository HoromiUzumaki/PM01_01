   M S B A M L   `   `   `  ����J  FHappy_Tooth_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Happy_Tooth_WPFHappy_Tooth_WPF  5   	   '    !Happy_Tooth_WPF.PatientEditDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Happy_Tooth_WPF     5   	     � Title$3  -Редактирование пациента��5   	   $	��400��6)   $	��400��66    � WindowStartupLocation$ CenterOwner=�5	   	    � 
ResizeMode$ NoResize=�5
   	   ���	#FFE6F2FF.��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��ФИО:��6   $��0��6   �� 5   
   -   5         ��Name$ txtFullName��5      $��1��6'   $��0,0,0,5q�64   �� 5   
   $��Телефон:��6   $��2��6#   �� 5   
   -   5        $ txtPhone��5      $��3��6$   $��0,0,0,5q�61   �� 5   
   $��Email:��6   $��4��6!   �� 5    
   -   5        $ txtEmail��5       $��5��6$   $��0,0,0,5q�61   �� 5"   
   $ ��Дата рождения:��6   $��6��6)   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ dpBirthDate��5#      $��7��6*   $��0,0,0,20q�67   �� 5%   
   $��8��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�5&      �� -   5        $��Сохранить��5&      $	��100��6)   $��0,0,10,0q�65      ActionButtonStyle#��[  5'      5(      �� 5)      -   5        $��Отмена��5)      $	��100��6&   #��[  5*      5+      5,      5-      5.      