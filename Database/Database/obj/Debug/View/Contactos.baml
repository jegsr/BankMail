   M S B A M L   `   `   `  ����p  lSystem.Windows.Controls.Input.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35pTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.ToolkitSystem.Windows.Controls  5   	   C ?Database, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Database.ViewDatabase.View 5   	      Database.View.Contactos   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   htoolkitTclr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Input.Toolkit     5   	   -localclr-namespace:Database.View     5   	   -   5          � Icon$.  (pack://application:,,,/Image/mailBox.ico��5   	    � Title$ Bank MailBox��5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � 
ResizeMode$ CanMinimize=�5   	   .��5      � ��5   
   �� 5       �� EndPoint$	 0,1&�6"    �� 
StartPoint$ 1,0.3&�61    �� Opacity$	 0.7Q�6D   .��5      �  � Color$ DarkGray��6    � Offset$ 0Q�60   � 5      $
 Gray��6   $	 0.2Q�6,   � 5      $ White��6   $ 1Q�6-   5      	 � ColumnDefinitions	 5   
   �� 5      $��20 �6   5      �� 5      5      �� 5      5      �� 5       5"      �� 5#      $��30 �6   5%      �� 5&      $��20 �6   5(      �� 5)      5+      �� 5,      5.      �� 5/      51      �� 52      54      �� 55      57      �� 58      5:      �� 5;      5=      �� 5?      $��20 �6   5A      
 � RowDefinitions
 5C   
   �� 5D      $��20 �6   5F      �� 5G      $��70 �6   5I      �� 5J      $��20 �6   5L      �� 5M      $��30 �6   5O      �� 5P      $��50 �6   5R      �� 5S      $��50 �6   5U      �� 5V      $��50 �6   5X      �� 5Y      $��50 �6   5[      �� 5\      $��50 �6   5^      �� 5_      5a      �� 5b      $��50 �6   5d      �� 5e      $��20 �6   5g      .+�5i   
   �� $��0��6   $��5��6$   $��0��68   $��14��6E   
�������6k   �� 5j   
   $��1��6   $��Contatos��6   $��Comic Sans MS)�61   $��35(�6L   $��Center=�6Z   $��Center=�6~   $��1��6�   $��3��6�   6�   o� 5m   
   
������ $��0��6(   $��5��68   $��10��6L   ��5n      �� 5o      .R�5p      $�  $� Orientation$ Vertical=�6-   5q      .@�5s      m� -   5        $��	20,0,20,0q�5s      $��Voltar��6+   $��50��6;   $��15(�6G   6U   5t      �� 5v   
   $��6��6   $��1��6$   $��7��61   
������� �� RadiusX$ 25��6W    �� RadiusY$ 25��6d   6t   �� 5w   
   -   5         ��Name$ lbContactos��5w      $��Procurar Contatos:��6&   $��6��6C   $��2��6S   $��1��6g   $��10q�6t   $��Center=�6�   $��Right=�6�   -   'System.Windows.Controls.AutoCompleteBox  5x   
   -   5          Name$ autoComplete��5x   "      IsTextCompletionEnabled .     ValueMemberPath$ Email��5y   "   $��8��6c   $��1��6s   $��3��6�   $��23q�5z   "   $��Center=�6   $
��Left=�6�      SelectedItem 5x   8   �� *SelectedUtilizadorAdicionar+ �� Mode$ TwoWay=�   
ItemFilter 5y   :   �� *UtilizadorFilter+   ItemsSource 5z   .   �� *ListUtilizadores+   ItemTemplate 5{      �� 5|      .R�5}      ��  �� Orientation$ 
Horizontal=�6%   .+�5~      �� $	��100��69   ��6    �� *Nome+69   �� 5      $��Italic$�6:   
���������6    �� *Email+6M   5�      5�      5�      �� 5�      -   5         ��Name$ bttAddContato��5�      $��23q�6,   $��Adicionar Contato��68   $��11��6T   $��2��6e   $��1��6y   ��6�   �� *
AddContato+c� 5�   
   $��6��6   $��3��6"   $��7��6/   
�������$��Center=�6[   .@�5�      �� -   5        $ 	btnDelete��5�      $��	20,0,20,0q�6(   $��Apagar Contacto��6;   ��6U   �� *
DelContato+�� 5�      -   5        $ btnVerPerfil��5�      $��	20,0,20,0q�6+   $��
Ver Perfil��6>   ��6S   �� *	SeePerfil+6q   �� 5�      -   5         ��Name$ 	txtSearch��5�      $��	20,0,20,0q�6)   $��20,0,0,0q�6<   
�������$��Center=�6b   $��12(�6�   $	��300��6�   ��6�   �� *PesquisaContactos+ �� UpdateSourceTrigger$ PropertyChanged=�.��6�   ��5�      �� 5�       �� ImageSource$- 'pack://application:,,,/Image/search.ico��6!    j� Stretch$ Uniform=�6W    j� 
AlignmentX$
 Left=�6i   .��5�   &   5�      5�      �� 5�   
   -	   5         ��Name$ ltViewContactos��5�      $��6��6,   $��7��6<   $��4��6P   $��7��6]   ��6n   �� *ContactosAdicionados+ �� IsAsync .   �� SelectedItem  6�   �� *SelectedContacto+��5�      �� 5�      ! �� 
TargetType"! ��6   .�5�      -
   5        5�      " �� View" 5�      �� 5�      -   5        	gvMembers��# �� AllowsColumnReorder# .  .P�5�      �� $��Username��6%   $ �� Width$	$ 180��67   % �� DisplayMemberBinding% 6C   �� *
Username+6o   �� 5�      $
��Nome��6%   $	$ 180��63   % 6?   �� *Nome+6g   �� 5�      $��Email��6%   $	$ 150��64   % 6@   �� *Email+6i   �� 5�      $��	Telemovel��6%   $
$ auto��68   % 6E   �� *	Telemovel+6r   �� 5�      $��Data de Registo��6%   $
$ auto��6>   % 6K   �� *DataRegisto+6z   5�      5�      5�      5�      