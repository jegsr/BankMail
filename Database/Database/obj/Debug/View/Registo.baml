   M S B A M L   `   `   `  ����C  ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View  5   	       Database.View.Registo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Database.View     5   	   -   5          � Icon$,  &pack://application:,,,/Image/login.ico��5   	    � Title$ Registo��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ CanMinimize=�5
   	   $	��800��5   	   $	��600��5   	   .��5      � ��5   
   �� 5       �� EndPoint$	 0,1&�6"    �� 
StartPoint$ 1,0.3&�61    �� Opacity$	 0.7Q�6D   .��5      �  � Color$ DarkGray��6    � Offset$ 0Q�60   � 5      $
 Gray��6   $	 0.2Q�6,   � 5      $ White��6   $ 1Q�6-   5      	 � ColumnDefinitions	 5   
   �� 5      5      �� 5      $��20 �6   5      �� 5      5!      �� 5"      5$      �� 5%      5'      �� 5(      5*      �� 5,      5/      �� 51      53      �� 54      56      �� 58      $��20 �6#   5:      �� 5;      5=      
 � RowDefinitions
 5A   
   �� 5B      5D      �� 5E      $��20 �6   5G      �� 5H      5J      �� 5K      $��20 �6   5M      �� 5N      5P      �� 5Q      5S      �� 5T      5V      �� 5W      5Y      �� 5Z      5\      �� 5]      $��20 �6   5_      �� 5`      5b      �� 5c      $��20 �6   5e      �� 5f      5h      .+�5k   
   �� $��1��6   $��2��6!   $��8��61   $��11��6E    �� RadiusX$ 30��6W    �� RadiusY$ 30��6d   
�������$��4��6�   
�������6�   �� 5m   
   -   5         ��Name$ 	lbRegisto��5m      $��Registo��6#   $��3��65   $��5��6E   $��2��6Z   $��Center=�6g   $��Comic Sans MS)�6�   $��35(�6�   $��Center=�6�   6�   �� 5q   
   -   5        $ 
lbUsername��5q      $��3��6$   $��2��65   $��4��6I   $��12q�6V   $��15(�6b   $��	Username:��6p   $��Center=�6�   $��Right=�6�   �� 5r   
   -   5        $ 
lbPassword��5r      $��3��6$   $��2��65   $��5��6I   $��12q�6V   $��15(�6b   $��	Password:��6p   $��Center=�6�   $��Right=�6�   �� 5s   
   -   5        $ lbNome��5s      $��3��6    $��2��61   $��6��6E   $��12q�6R   $��15(�6^   $��Nome:��6l   $��Center=�6|   $��Right=�6�   �� 5t   
   -   5        $ lbTelemovel��5t      $��3��6%   $��2��66   $��7��6J   $��12q�6W   $��15(�6c   $��Telemóvel:��6q   $��Center=�6�   $��Right=�6�   �� 5u   
   -   5        $ lbMorada��5u      $��3��6"   $��2��63   $��8��6G   $��12q�6T   $��15(�6`   $��Morada:��6n   $��Center=�6�   $��Right=�6�   �� 5w   
   -   5         ��Name$ 
tbUsername��5w      $��5��6&   $��4��66    �� 	MaxLength$ 25��6C   $��3��6R   $��15q�6f   $��12(�6r   $��Center=�6�   G� 5x   
   -	   5         G�Name$ 
tbPassword��5x      $��5��6*   $��5��6:   $��3��6G   $��15q�6[   $��12(�6g   $��Center=�6u   �� 5y   
   -
   5        $ tbNome��5y      $��5��6"   $��6��62   $��3��6?   $��15q�6S   $��12(�6_   $��Center=�6m   �� 5z   
   -   5        $ tbTelemovel��5z      $��5��6'   $��7��67   $��3��6D   $��15q�6X   $��12(�6d   $��Center=�6r   �� 5{   
   -   5        $ tbMorada��5{      $��5��6$   $��8��64   $��3��6A   $��15q�6U   $��12(�6a   $��Center=�6o   �� 5}   
   -   5         ��Name$ 
bttRegisto��5}      $��6��6%   $��10��65   $��2��6C   $��15(�6X   $��	5,10,5,10q�6f   $��Registar��6z   6�   �� 5~   
   -   5        $ bttCancelar��5~      $��3��6&   $��10��66   $��2��6D   $��15(�6Y   $��	5,10,5,10q�6g   $��Cancelar��6z   6�   5      5�      