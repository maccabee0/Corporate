   M S B A M L   `   `   `  ����Q  MCorporate.Expenditures, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Corporate.Expenditures.ViewModels!Corporate.Expenditures.ViewModels  5      3    -Corporate.Expenditures.Views.CategoryListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      F
viewModels/clr-namespace:Corporate.Expenditures.ViewModels     5      $	��300��5      $	��300��6     � 	Resources  5       �� Source�� 5   
   $ ../Theme/Theme.xaml?�6   %    .��5      �    MainBackground#��[  6+    � DataContext 6   �� *	Content+ � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   .+�5      �� $��0��6   
�������$��	ExtraBold"�6;   $��29(�6R   $��5q�6`   	Office:6t   �� 5      $��1��6   
�������$��DemiBold"�6;   $��29(�6Q   $��5q�6_   ��6j   �� *Office+6�   5      � 5   
   $��1��6    5      �� 5       $��2* �6#   �� 5!      $��3* �6#   .+�5#      �� $��0��6   
�������$��	ExtraBold"�6;   $��24(�6R   $��5q�6`   	Category:6v   �� 5$      $��1��6   
�������$��DemiBold"�6;   $��24(�6Q   $��5q�6_   ��6j   �� *
Category+6�   5%      �� 5&   
   $��2��6   ��6    �� *Logs+ �� View 5'      �� 5(      .P�5)      �� $
��Date��6%    �� DisplayMemberBinding 63   �� *	InputDate+ �� StringFormat$ 
dd/MM/yyyy���� 5*      $��Amount��6%    65   �� *Amount+$ C��5+      5-      � 55   
   $��3��6    56      �� 57      $��* �6#   �� 58      $��90 �6#   .+�5:      �� -   5        $��1��5:      $��5q�6:   .��6E   Close6L   5;      5<      5=      