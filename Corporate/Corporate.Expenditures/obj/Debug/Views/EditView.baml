   M S B A M L   `   `   `  ����Q  MCorporate.Expenditures, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Corporate.Expenditures.ViewModels!Corporate.Expenditures.ViewModels  5      +    %Corporate.Expenditures.Views.EditView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F
viewModels/clr-namespace:Corporate.Expenditures.ViewModels     5      $	��350��5      $	��350��6     � 	Resources  5	       �� Source�� 5
   
   $ ../Theme/Theme.xaml?�6   %    .��5      �    MainBackground#��[  6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��30 �6    � ColumnDefinitions 5   
   �� 5      6!   .+�5   
   � $��0��6    5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��0��6   $��28(�6(   $��	ExtraBold"�66   
�������$
��10,5q�6`   	Office:6w   �� 5       $��1��6   $��28(�6(   $��	ExtraBold"�66   
�������$
��10,5q�6`   ��6n   �� *Notification.OfficeLocal+6�   5!      � 5"   
   $��1��6    5#      �� 5$      $��2* �6#   �� 5%      $��3* �6#   .+�5'      �� $��0��6   $��22(�6(   $
��Bold"�66   
�������$
��10,3q�6[   	Category:6t   �� 5(      $��1��6   $
��10,3q�6'   $��22(�65    �� DisplayMemberPath$
 Name��5*       �� SelectedValuePath$ 	Expenseid��5+      ��5)      ��  �� Path$ Notification.Expenses� �� SelectedValue 5,      �� * Notification.SelectedExpenseId+ �� Mode$ TwoWay=�6_   5-      � 5.   
   $��2��6    5/      �� 50      $��2* �6#   �� 51      $��3* �6#   .+�53      �� $��0��6   
�������$��22(�6;   $
��Bold"�6I   $
��10,3q�6[   	Amount:6r   �� 54      $��1��6   $
��10,3q�6&   $��21(�65   ��6C   �� *Notification.Amount+$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� StringFormat$
 f2��6�   55      � 56   
   $��3��6    57      �� 58      $��* �6    �� 59      $��3* �6    .+�5;      �� $��0��6   $��25(�6%   $
��Bold"�63   
�������$
��10,3q�6X   Note:6m   �� 5<      $��1��6   $
��10,0q�6#   ��61   �� *Notification.Note+$ TwoWay=�6c   5=      � 5>   
   $��4��6    5?      �� 5@      $��* �6#   �� 5A      $	��120 �6#   �� 5B      $��75 �6#   �� 5C      $��85 �6#   .+�5E      �� $��2��6   $��5q�6%   ��60   �� *SaveCommand+.��6P   Save6V   �� 5F      $��3��6   $��5q�6%   ��60   �� *CancelCommand+.��6R   Cancel6Z   5G      5H      5I      