   M S B A M L   `   `   `  ����C  ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View  5   	       Database.View.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Database.View     5   	     � Title$  Login��5   	    � Icon$, &pack://application:,,,/Image/login.ico��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   $	��800��5   	   $	��600��5   	   .��5      � ��5   
   �� 5       �� EndPoint$	 0,1&�6"    �� 
StartPoint$ 1,0.3&�61    �� Opacity$	 0.7Q�6D   .��5      �  � Color$ DarkGray��6    � Offset$ 0Q�60   � 5      $
 Gray��6   $	 0.2Q�6,   � 5      $ White��6   $ 1Q�6-   5      	 � ColumnDefinitions	 5   
   �� 5      5      �� 5      $��20 �6   5      �� 5      5       �� 5"      5$      �� 5%      5'      �� 5(      5*      �� 5,      5/      �� 51      53      �� 54      $��20 �6   56      �� 57      59      
 � RowDefinitions
 5=   
   �� 5>      5@      �� 5A      $��20 �6   5C      �� 5D      5F      �� 5G      $��20 �6   5I      �� 5J      5L      �� 5M      5O      �� 5P      $��20 �6   5R      �� 5S      5U      �� 5V      $��20 �6   5X      �� 5Y      5[      .+�5^   
   �� $��1��6   $��2��6!   $��6��61   $��8��6E    �� RadiusX$ 30��6V    �� RadiusY$ 30��6c   
�������$��4��6�   
�������6�   �� 5`   
   $1��+pack://application:,,,/Image/imageLogin.png��6   $��5��6E   $��2��6U   $��30��6b   $��Right=�6n   6�   �� 5a   
   $��Login��6   $��4��6    $��2��60   $��2��6D   $��Center=�6Q   $��Comic Sans MS)�6v   $��35(�6�   $��Center=�6�   �� 5c   
   -   5         ��Name$ 
lbUsername��5c      $��2��6$   $��2��64   $��4��6H   $��	Username:��6U   $��15(�6i   $��Right=�6w   $��Center=�6�   �� 5d   
   -   5        $ 
lbPassword��5d      $��2��6$   $��2��65   $��5��6I   $��	Password:��6V   $��15(�6j   $��Right=�6x   $��Center=�6�   �� 5f   
   -   5         ��Name$ 
tbUsername��5f      $��15(�6&   $��4��64   $��4��6D   $��3��6Q   $��15q�6e   $
��Left=�6q   $��Center=�6�   G� 5g   
   -   5         G�Name$ 
tbPassword��5g      $��15(�6F   $��4��6U   $��5��6e   $��3��6r   $��15q�6�   $
��Left=�6�   $��Center=�6�   �� 5j   
   -   5         ��Name$ bttLogin��5j      $��5��6#   $��7��63   $��2��6@   $��15(�6T   $��	5,10,5,10q�6c   $��Login��6v   6�   �� 5k   
   -   5        $ 	bttRegist��5k      $��3��6$   $��7��64   $��2��6A   $��15(�6U   $��	5,10,5,10q�6c   $��Registar��6v   6�   5o      5p      