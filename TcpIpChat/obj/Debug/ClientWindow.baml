   M S B A M L   `   `   `  ����D  @TcpIpChat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TcpIpChat	TcpIpChat  5   	       TcpIpChat.ClientWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TcpIpChat     5   	   -   5          � Title$*  $Сетевой чат клиента��5   	   $	��450��6%   $	��700��62   $	��200��6>   $	��500��6N   ���	#FF1F1F1F.��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      .+�5   
   �� $��Пользователи��6      
HeaderText#��[  6'   $��Center=�6K   �� 5   
   -   5         ��Name$ UsersListBox��5      $��1��6(   � 5   
   $��1��6   $��2��6    5      �� 5      �� 5      $
��auto �6    .+�5      �� -   5         ��Name$ ChatTextBox��5        ChatTextBox#��[ 6+   � 5      $��1��6    5      �� 5      $
��auto �6'   �� 5      �� 5      $
��auto �6'   .+�5       �� -   5         ��Name$ DiscconectButton��5       $��
Выйти��63   $��70��6C   6N   �� 5!      -   5        $ MessageTextBox��5!      $��1��63   �� 5"      -   5        $ 
SendButton��5"      $��Отправить��6-   $��2��6A   $	��100��6Q   6]   5#      5%      5&      5'      