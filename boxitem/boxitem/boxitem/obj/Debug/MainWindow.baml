   M S B A M L   `   `   `  ����B  >boxitem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:boxitemboxitem  5   	       boxitem.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:boxitem     5   	     � Title$  	Logowanie��5   	   $	��470��6   $	��470��6(    � SizeToContent$ WidthAndHeight=�64    � 
ResizeMode$ NoResize=�6S   .��5	      �  � ColumnDefinitions 5
   
   �� 5      .+�5   
   �� -   5         ��Name$ btnLoginLogin��5      $��Zaloguj się��6(   $��133,208,155,183q�6>   $��16(�6W   $��Arial)�6e   $
��Bold"�6x   6�   �� 5   
   -   5        $ btnRegisterLogin��5      $��Zarejestruj się��6+   $��133,347,157,46q�6E   $��14(�6]   $��Arial)�6k   $
��Bold"�6~    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$
 0.06Q�6$   �� 5      T� 5       T� X$ -0.002Q�6)   5      5      �� 5   
   -   5        $ 	btnCancel��5      $��Anuluj��6$   $��344,389,22,0q�65   $	��Top=�6K   $��36��6c   $��16(�6o   $��Arial)�6}   $
��Bold"�6�   6�   �� 5   
   -   5         ��Name$ tbLoginLogin��5      $��30��6(   $��
68,67,80,0q�64   	 �� TextWrapping$
	 Wrap=�6H   $	��Top=�6\   $��18(�6t   �� 5   
   -   5        $ tbPasswordLogin��5      $��30��6+   $��68,157,80,0q�67   $
	 Wrap=�6L   $	��Top=�6a   $y�Visible=�6�   ��6y   �� *
Password+
 �� Mode$
 TwoWay=� �� ElementName$ MyPasswordBox��6�   �� 5   
   $��Login:��6   $��191,31,193,0q�6!   $	��Top=�67   $��18(�6O   $��Arial)�6]   �� 5   
   $��Hasło:��6   $��191,124,193,0q�6"   $	��Top=�69   $��18(�6Q   $��Arial)�6_   �� 5   
   -   5        $ btnRemindPasswordLogin��5      $��Przypomnij hasło��61   $��133,279,155,110q�6L   $��14(�6e   $��Arial)�6s   $
��Bold"�6�   6�   G� 5   
   -   5         G�Name$ pbPasswordLogin��5      $y�Hidden=�60    G� PasswordChar$ *��6D   $
��Left=�6U   $��
68,157,0,0q�6p   $	��Top=�6�   $	��314��6�   $��30��6�   5       5!      