   M S B A M L   `   `   `  ����G  CInfoSecurity, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:InfoSecurityInfoSecurity  5   	       InfoSecurity.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:InfoSecurity     5   	   c _MaterialDesignThemes.MahApps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5   	     � Title$;  5Информационная безопасность��5	   	   $	��600��6-   $��1000 ��6:   .��5
      � ���	#FFADABAB � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��1* �6   .+�5   
   >� -   5         >�Name$ UserController��5      $��1��6.   � 5   
   $��0��6   $��2��6   ���	#FF32323260   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5      �� -   5         ��Name$ CaesarButton��5      $��Шифр Цезаря��6.   
������ 
�������$��Arial Black)�6p   $��20(�6�   $
��10,0q�6�   6�   �� 5      -   5        $ SymmetricButton��5      $��Симм.Шифр��6.   
������ 
�������$��Arial Black)�6p   $��20(�6�   $
��10,0q�6�   6�   �� 5      -   5        $ BinaryButton��5      $��Побитовое��6.   
������ 
�������$��Arial Black)�6p   $��20(�6�   $
��10,0q�6�   6�   �� 5      -   5        $ EuclidButton��5      $��Евклид��6.   
������ 
�������$��Arial Black)�6p   $��20(�6�   $
��10,0q�6�   6�   �� 5      -   5        $ LemhannButton��5      $��Простые��6/   
������ 
�������$��Arial Black)�6r   $��20(�6�   $
��10,0q�6�   6�   �� 5      -   5        $ KnackpackButton��5      $��Ассиметр��61   
������ 
�������$��Arial Black)�6u   $��20(�6�   $
��10,0q�6�   6�   �� 5      -   5        $ GeneratorButton��5      $��ПСП��61   
������ 
�������$��Arial Black)�6p   $��20(�6�   $
��10,0q�6�   6�   5      5      5      