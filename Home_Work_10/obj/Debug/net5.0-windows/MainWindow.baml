   M S B A M L   `   `   `  ����I  EHome_Work_10.5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Home_Work_10._5Home_Work_10._5  5   	        Home_Work_10._5.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Home_Work_10._5     5   	     � Title$  TeleBot��5   	   $	��513��6   $	��812��6&   $	��400��5	   	   $	��500��5
   	   $	��700��5   	   $	��850��5   	    � Icon$ /Telegram_logo_PNG2.png��5   	   
�������.��5      �  � ShowGridLines$ False��6    � ColumnDefinitions 5   
   �� 5      $	��55* �6   �� 5      $	��45* �6   .+�5   
   �� -   5         ��Name$ logList��5      $��0��5      $��5,5,5,5q�5      
���������5      �� 5      .R�5      �� 
���   �$��5q�61   $��1q�6<    �� CornerRadius$ 7��6P   ._�5      �� $��9q�6%   .+�5       �� $��0q�6C   $��15(�6N   ��6(   �� *	FirstName+6N   �� 5!      $��0q�6=   $��20(�6H   ��6(   �� *Msg+6H   �� 5"      $
��10 0q�6>   $��10(�6L   
������� �� TextAlignment$ Right=�6l   ��6(   �� *Time+6l   5#      5$      5%      5'      �� 5)   
   $��1��6   $��20(�5*      $)��#Отправка сообщения��5+      $��5,5,5,5q�5,      .��5.      �� .+�5/      �� -   5         ��Name$ 
TargetSend��5/      $y�	Collapsed=�51      $��5q�52      ��50      ��  �� ElementName$ logList��	 �� Path$	 SelectedItem.Id�52      �� 54      -   5        
 ��Name$
 
txtMsgSend��54      $��20(�6.   $��5q�6<   6G   �� 56      -   5         ��Name$ 
btnMsgSend��56      $��20(�6-   $��Отправить��6;   $��5q�6O   6Z   �� 57      -   5        $ btnSave��57      $��20(�6*   $��Сохранить��68   $��5q�6L   6W   �� 58      -   5         ��Name$ lblNotification��58      $�� ��61   $��Center=�59      $��5q�5:      $��18(�5;      5>      5?      5@      5A      