   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5   	   C ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View 5   	       Database.View.NovaMensagem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   jtoolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Database.View     5   	     � Icon$.  (pack://application:,,,/Image/mailBox.ico��5   	    � Title$ Bank MailBox��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   $	��650��5   	   $
��1150��5   	   .��5      � ��5   
   �� 5       �� EndPoint$	 0,1&�6"    �� 
StartPoint$ 1,0.3&�61    �� Opacity$	 0.7Q�6D   .��5      �  � Color$ DarkGray��6    � Offset$ 0Q�60   � 5      $
 Gray��6   $	 0.2Q�6,   � 5      $ White��6   $ 1Q�6-   5       � ColumnDefinitions 5   
   �� 5      5      �� 5      $��20 �6   5      �� 5      5      �� 5!      5#      �� 5$      5&      �� 5'      5)      �� 5+      5.      �� 50      52      �� 53      $��20 �6   55      �� 56      58      	 � RowDefinitions	 5<   
   �� 5=      5?      �� 5@      $��20 �6   5B      �� 5C      5E      �� 5F      $��20 �6   5H      �� 5I      5K      �� 5L      $��20 �6   5N      �� 5O      5Q      �� 5R      5T      �� 5U      5W      �� 5X      5Z      �� 5[      5]      �� 5^      $��20 �6   5`      �� 5a      5c      �� 5d      $��20 �6   5f      �� 5g      5i      .+�5l   
   �� $��1��6   $��2��6!   $��6��61   $��13��6E   
 �� RadiusX$
 30��6W    �� RadiusY$ 30��6d   
�������$��4��6�   
�������6�   �� 5m   
   -   5         ��Name$ Titulo��5m      $��Nova Mensagem��6    $��Comic Sans MS)�68   $��35(�6S   $��3��6a   $��4��6q   $��2��6�   $��Center=�6�   $��Center=�6�   �� 5o   
   -   5        $ lbContactos��5o      $1��+Procurar Contactos para adicionar ao email:��6&   $��2��6\   $��2��6l   $��4��6�   $��10q�6�   $��Center=�6�   $��Right=�6�   -   'System.Windows.Controls.AutoCompleteBox  5p   
   -   5          Name$ autoComplete��5p   "   $��4��68   $��4��6H   $��3��6U   $��10q�6i      ValueMemberPath$ Email��6�   $��Center=�6  $
��Left=�6-     ItemsSource 6u   �� *GetUserContactos+   
ItemFilter 6�   �� *UtilizadorFilter+   ItemTemplate 5q   
   �� 5r      .R�5s      ��  �� Orientation$ 
Horizontal=�6   .+�5t      �� $	��100��65   ��6   �� *Nome+65   �� 5u      $��Italic$�66   
���������6   �� *Email+6I   5v      5w      5y      �� 5{   
   -   5         ��Name$ bttAdicionarDestino��5{      $��10q�6.   $��Adicionar ao Destino��6:   $��7��6Y   $��4��6i   6v   �� 5}   
   -   5        $ lbDestination��5}      $��Para:��6(   $��3��68   $��6��6H   $��10q�6U   $��Center=�6a   $��Right=�6�   �� 5~   
   -   5         ��Name$ 
txtDestino��5~      $��10q�6'   $��4��63   $��3��6C   $��6��6W   $��Center=�6d   �� 5�   
   -   5        $ 	lbAssunto��5�      $��Assunto:��6#   $��3��66   $��7��6F   $��10q�6S   $��Center=�6_   $��Right=�6�   �� 5�   
   -   5        $ 
txtAssunto��5�      $��10q�6&   $��4��62    �� 	MaxLength$ 50��6B   $��3��6Q   $��7��6e   $��Center=�6r   �� 5�   
   -	   5        $ 
lbMensagem��5�      $��	Mensagem:��6$   $��3��68   $��8��6H   $��10q�6U   $��Right=�6c   �� 5�   
   -
   5        $ txtMensagem��5�       �� AcceptsReturn . $��10q�6<   $��4��6H   $��3��6X   $��8��6l   $��3��6y   6�   �� 5�   
   -   5        $ 	bttEnviar��5�      $��10q�6$   $��Enviar��60   $��3��6A   $��12��6Q   $��2��6_   6s   �� 5�   
   -   5        $ bttCancelar��5�      $��10q�6&   $��Cancelar��62   $��5��6E   $��12��6U   $��2��6c   6w   5�      5�      