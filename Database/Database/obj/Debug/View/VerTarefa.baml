   M S B A M L   `   `   `  ����C  ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View  5   	       Database.View.VerTarefa   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Database.View     5   	   -   5          � Icon$.  (pack://application:,,,/Image/mailBox.ico��5   	    � Title$ Bank MailBox��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��650��5
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
   -   5         ��Name$ Titulo��5g      $��
Ver Tarefa��6    $��Comic Sans MS)�66   $��30(�6Q   $��3��6_   $��4��6o   $��2��6�   $��Center=�6�   $��Center=�6�   �� 5i   
   -   5        $ lbTitulo��5i      $��2��6"   $��10q�62   $��14(�6>   $��2��6L   $��4��6`   $��Titulo:��6m   $��Right=�6   $��Center=�6�   6�   �� 5j   
   -   5         ��Name$ tbTitulo��5j       �� 
IsReadOnly . $��10q�66   $��14(�6B   $��4��6u   $��4��6�   $��3��6�   $
��Left=�6�   $��Center=�6�   ��6P   �� *SelectedTarefa.Nome+6�   �� 5l   
   -   5        $ lbData��5l      $��2��6    $��14(�60   $��10q�6>   $��2��6K   $��5��6_   $��Data:��6l   $��Right=�6|   $��Center=�6�   6�   �� 5m   
   -   5        $ lbCorpo��5m      $��2��6!   $��14(�61   $��10q�6@   $��2��6L   $��6��6`   $��Corpo:��6m   $��Right=�6~   $��Center=�6�   6�   (  "System.Windows.Controls.DatePicker  5o   
   -   5          Name$ tbData��5o      {�.  $��4��67   $��10q�6G   $��3��6S   $��5��6g      FirstDayOfWeek$ Sunday=�6t      SelectedDateFormat$ Short=�6�   $��Center=�6�      SelectedDate 6�   �� *SelectedTarefa.Data+6�   �� 5p   
   -   5        $ tbCorpo��5p       . $��10q�65   $��12(�6g   $��4��6u   $��6��6�   $��3��6�   $��3��6�   $
��Left=�6�   ��6A   �� *SelectedTarefa.Corpo+6�   �� 5r   
   -	   5         ��Name$ 	bttVoltar��5r      $��3��6$   $��14(�64   $��10��6B   $��10q�6P   $��2��6\   $��Voltar��6q   6�   �� 5s   
   -
   5        $ 	bttEditar��5s      $��5��6$   $��14(�64   $��10��6B   $��10q�6P   $��2��6\   $��Editar��6q   6�   5t      5u      