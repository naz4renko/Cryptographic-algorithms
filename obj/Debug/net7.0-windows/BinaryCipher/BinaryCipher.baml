   M S B A M L   `   `   `  ����G  CInfoSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:InfoSecurity.BinaryCipherInfoSecurity.BinaryCipher  5      ,    &InfoSecurity.BinaryCipher.BinaryCipher   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:InfoSecurity.BinaryCipher     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $	��350 �6   �� 5      $��1* �6   .+�5   
   �� $��Center=�6   $��Center=�62   $��0��6M   .+�5      �� $'��!Введите сообщение��6   $��20(�61   $��Arial Black)�6?   $
��0,10q�6X   $��Center=�6f   �� 5      -   5         ��Name$ WorkMessage��5      $��30��6+   $	��250��67   $
��0,10q�6C   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� -   5         ��Name$ EncryptMessageButton��5      $��40��67   $	��115��6C   $��Закодировать��6O   $��14(�6f   $��Arial Black)�6t   $��10,10q�6�   6�   �� 5      -   5        $ DecryptMessageButton��5      $��40��67   $	��115��6C   $��Декодировать��6O   $��14(�6f   $��Arial Black)�6t   $��10,10q�6�   6�   5      �� 5      $��Результат��6   $��20(�6)   $��Arial Black)�67   $
��0,10q�6P   $��Center=�6^   �� 5      -   5        $ ResultMessage��5      $��30��6-   $	��250��69   $
��0,10q�6E   �� 5      -   5        $ ReadFileButton��5      $!��Загрузить файл��6-   $��Arial Black)�6F   $��30��6_   $	��200��6k   $	��5,5q�6w   6�   �� 5      -   5        $ SaveFileButton��5      $$��Сохранить в файл��6-   $��Arial Black)�6H   $��30��6a   $	��200��6m   $	��5,5q�6y   6�   �� 5      -   5        $ ClearButton��5      $��Очистить��6*   $��30��6=   $	��100��6I   $
��0,20q�6U   $��Arial Black)�6c   6|   5      �� 5   
   $ Vertical=�6   $��1��6,   $
��0,10q�6<   .+�5      �� $��Center=�6   $��Center=�66   $��1��6Q   .+�5      �� $5��/Промежуточные результаты��6   $��20(�6<   $��Arial Black)�6J   $
��0,10q�6c   $��Center=�6q   �� 5       $
��Auto��6   $
��Auto=�6-   .��5!      &   System.Windows.Controls.DataGrid  -   5          Name$ 	ResultsDG��5!      5"      5#      �� 5%      $��Center=�6   $��Center=�66   $��1��6Q   .+�5&      �� $/��)Зашифрованные символы��6   $��20(�69   $��Arial Black)�6G   $
��0,10q�6`   $��Center=�6n   �� 5'      $
��Auto��6   $
��Auto=�6-   .��5(        -	   5        $ 
Results2DG��5(      5)      5*      5+      5,      5-      