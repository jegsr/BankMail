   M S B A M L   `   `   `  ����C  ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View  5   	   #    Database.View.AdicionarTarefa   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Database.View     5   	     � Icon$.  (pack://application:,,,/Image/mailBox.ico��5   	    � Title$ Bank MailBox��5   	    � WindowStartupLocation$ CenterScreen=�5	   	   $	��650��5
   	   $
��1150��5   	   .��5      � ��5   
   �� 5       �� EndPoint$	 0,1&�6"    �� 
StartPoint$ 1,0.3&�61    �� Opacity$	 0.7Q�6D   .��5      �  � Color$ DarkGray��6    � Offset$ 0Q�60   � 5      $
 Gray��6   $	 0.2Q�6,   � 5      $ White��6   $ 1Q�6-   5       � ColumnDefinitions 5   
   �� 5      5      �� 5      $��20 �6   5      �� 5      5      �� 5       5"      �� 5#      5%      �� 5&      5(      �� 5*      5-      �� 5/      51      �� 52      $��20 �6   54      �� 55      57      	 � RowDefinitions	 5;   
   �� 5<      5>      �� 5?      $��20 �6   5A      �� 5B      5D      �� 5E      $��20 �6   5G      �� 5H      5J      �� 5K      5M      �� 5N      5P      �� 5Q      5S      �� 5T      5V      �� 5W      $��20 �6   5Y      �� 5Z      5\      �� 5]      $��20 �6   5_      �� 5`      5b      .+�5e   
   �� $��1��6   $��2��6!   $��6��61   $��11��6E   
 �� RadiusX$
 30��6W    �� RadiusY$ 30��6d   
�������$��4��6�   
�������6�   �� 5f   
   -   5         ��Name$ Titulo��5f      $��Adicionar Tarefa��6    $��Comic Sans MS)�6<   $��30(�6W   $��3��6e   $��4��6u   $��2��6�   $��Center=�6�   $��Center=�6�   �� 5h   
   -   5        $ lbTitulo��5h      $��2��6"   $��10q�62   $��2��6?   $��4��6S   $��14(�6`   $��Titulo:��6n   $��Right=�6�   $��Center=�6�   6�   �� 5i   
   -   5         ��Name$ tbTitulo��5i      $��10q�6$   $��4��60   $��4��6@    �� 	MaxLength$ 50��6M   $��3��6\   $��14(�6p   $
��Left=�6~   $��Center=�6�   6�   �� 5k   
   -   5        $ lbData��5k      $��2��6    $��10q�60   $��2��6=   $��14(�6Q   $��5��6_   $��Data:��6l   $��Right=�6|   $��Center=�6�   6�   �� 5l   
   -   5        $ lbCorpo��5l      $��2��6!   $��10q�62   $��2��6>   $��14(�6R   $��6��6`   $��Corpo:��6m   $��Right=�6~   $��Center=�6�   6�   (  "System.Windows.Controls.DatePicker  5p   
   -   5          Name$ tbData��5p      $��4��6%   $��10q�65   $��3��6A   $��5��6U      FirstDayOfWeek$ Sunday=�6�   $��14(�6�      SelectedDateFormat$ Short=�6�   $��Center=�6�      DisplayDateStart 6b   �� *DateTime.Now+6�   �� 5q   
   -   5        $ tbCorpo��5q       �� AcceptsReturn . $��10q�68   $��4��6D   $��6��6T   $��3��6a   $��3��6u   $��12(�6�   $
��Left=�6�   6�   �� 5s   
   -   5         ��Name$ 	bttVoltar��5s      $��3��6$   $��10��64   $��10q�6B   $��2��6N   $��14(�6b   $��Voltar��6q   6�   �� 5t   
   -	   5        $ bttAdicionar��5t      $��5��6'   $��10��67   $��10q�6E   $��2��6Q   $��14(�6f   $��	Adicionar��6t   6�   5u      5v      