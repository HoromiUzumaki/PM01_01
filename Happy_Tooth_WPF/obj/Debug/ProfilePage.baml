   M S B A M L   `   `   `  ����J  FHappy_Tooth_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Happy_Tooth_WPFHappy_Tooth_WPF  5      !    Happy_Tooth_WPF.ProfilePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Happy_Tooth_WPF     5        N� Title$  ProfilePage��5	       N� 
Background �	#FFE6F2FF.��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $1��+Профиль администратора��6   $��18(�5      $
��Bold"�5      ���	#FF003366$��10q�5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $.��(Текущий пользователь:��6   $	��170��64   �� 5      -   5         ��Name$ lblUsername��5      $
��Bold"�6)   5      �� 5!   
   $��2��6   $ 
Horizontal=�6"   $��10q�6;   .+�5"      �� $��Новый логин:��6   $	��150��6+   �� 5#      -   5         ��Name$ txtNewUsername��5#      $	��200��6.   5$      �� 5&   
   $��3��6   $ 
Horizontal=�6"   $��10q�6;   .+�5'      �� $��Новый пароль:��6   $	��150��6,   G� 5(      -   5         G�Name$ txtNewPassword��5(      $	��200��62   5)      �� 5+   
   $��4��6   $ 
Horizontal=�6"   $��10q�6;   .+�5,      �� $0��*Подтверждение 
пароля:��6   $	��150��6>   G� 5-      -   5        $ txtConfirmPassword��5-      $	��200��66   5.      �� 50   
   $��5��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�51      �� -   5        $+��%Сохранить изменения��51         ActionButtonStyle#��[  52      $	��151��53   /   54      55      56      