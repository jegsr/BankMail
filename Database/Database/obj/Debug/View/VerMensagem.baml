   M S B A M L   `   `   `  ����C  ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View  5   	       Database.View.VerMensagem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Database.View     5   	   -   5          � Icon$.  (pack://application:,,,/Image/mailBox.ico��5   	    � Title$ Bank MailBox��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��650��5
   	   $
��1150��5   	   .��5      � ��5   
   �� 5       �� EndPoint$	 0,1&�6"    �� 
StartPoint$ 1,0.3&�61    �� Opacity$	 0.7Q�6D   .��5      �  � Color$ DarkGray��6    � Offset$ 0Q�60   � 5      $
 Gray��6   $	 0.2Q�6,   � 5      $ White��6   $ 1Q�6-   5       � ColumnDefinitions 5   
   �� 5      5      �� 5      $��20 �6   5      �� 5      5      �� 5!      5#      �� 5$      5&      �� 5'      5)      �� 5+      5.      �� 50      52      �� 53      $��20 �6   55      �� 56      58      	 � RowDefinitions	 5<   
   �� 5=      5?      �� 5@      $��20 �6   5B      �� 5C      5E      �� 5F      $��20 �6   5H      �� 5I      5K      �� 5L      5N      �� 5O      5Q      �� 5R      5T      �� 5U      5W      �� 5X      $��20 �6   5Z      �� 5[      5]      �� 5^      $��20 �6   5`      �� 5a      5c      .+�5f   
   �� $��1��6   $��2��6!   $��6��61   $��11��6E   
 �� RadiusX$
 30��6W    �� RadiusY$ 30��6d   
�������$��4��6�   
�������6�   �� 5g   
   -   5         ��Name$ Titulo��5g      $��Ver Mensagem��6    $��Comic Sans MS)�67   $��35(�6R   $��3��6`   $��4��6p   $��2��6�   $��Center=�6�   $��Center=�6�   �� 5i   
   -   5        $ lbDestination��5i      $��Para:��6(   $��14(�68   $��3��6F   $��4��6V   $��10q�6c   $��Center=�6o   $��Right=�6�   �� 5j   
   -   5         ��Name$ 
txtDestino��5j       �� 
IsReadOnly . $��14(�69   $��10q�6q   $��4��6}   $��3��6�   $��4��6�   $��Center=�6�   ��6G   �� *SelectedMail.UserDestino+6�   �� 5l   
   -   5        $ 	lbAssunto��5l      $��Assunto:��6#   $��14(�66   $��3��6D   $��5��6T   $��10q�6a   $��Center=�6m   $��Right=�6�   �� 5m   
   -   5        $ 
txtAssunto��5m       . $��14(�68   $��10q�6k   $��4��6w    �� 	MaxLength$ 50��6�   $��3��6�   $��5��6�   $��Center=�6�   ��6F   �� *SelectedMail.Titulo+6�   �� 5o   
   -   5        $ 
lbMensagem��5o      $��	Mensagem:��6$   $��14(�68   $��3��6F   $��6��6V   $��10q�6c   $��Right=�6q   �� 5p   
   -   5        $ txtMensagem��5p       . $��12(�69    �� AcceptsReturn . $��10q�6�   $��4��6�   $��3��6�   $��6��6�   $��3��6�   ��6G   �� *SelectedMail.Corpo+6�   �� 5r   
   -	   5         ��Name$ bttResponder��5r      $��10q�6'   $��	Responder��63   $��3��6G   $��14(�6W   $��10��6e   $��2��6s   6�   �� 5s   
   -
   5        $ 	bttVoltar��5s      $��10q�6$   $��Voltar��60   $��5��6B   $��14(�6R   $��10��6`   $��2��6n   6�   5t      5u      