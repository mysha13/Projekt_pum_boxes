   M S B A M L   `   `   `  ����B  >boxitem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:boxitemboxitem  5   	       boxitem.Items   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:boxitem     5   	     � Title$  
Przedmioty��5   	   $	��460��6   $��500.5��6)    � 
ResizeMode$ NoResize=�67   .��5	      � $	��460��6   $��0,0,-8,0q�6    � ColumnDefinitions 5
   
   �� 5      $��0* �6   �� 5      $
��223* �6   �� 5      $	��26* �6   �� 5      $
��199* �6   �� 5      $	��12* �6   .+�5   
   �� -   5         ��Name$ btnRefreshItems��5      $��	Odśwież��6*   $��-1,24,152,0q�6<   $	��Top=�6Q   $��35��6i   $��16(�6u   $��Arial)�6�   $
��Bold"�6�   $��2��6�   6�   �� 5   
   -   5        $ btnCancelItems��5      $��Anuluj��6)   $
��Left=�6:   $��103,379,0,0q�6U   $	��Top=�6j   $��96��6�   $��34��6�   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   $��3��6�   6�   �� 5   
   $B��<* Po każdej zmianie proszę nacisnąć przycisk 'Odśwież'��6   $��-1,388,102,7q�6Q   $��Arial)�6g   $��13(�6z   $��4��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridItems��5      $��	-1,65,0,0q�6*   $	��Top=�6=   $	��246��6U   $��2��6b      
IsReadOnly . 6�   �� 5   
   -   5        $ btnAddItems��5      $��Dodaj��6&   $��0,330,130,0q�66   $	��Top=�6K   $��35��6c   $��16(�6o   $��Arial)�6}   $
��Bold"�6�   $��2��6�   6�   �� 5   
   -   5        $ btnDeleteItems��5      $��Usuń��6)   $��134,330,0,0q�68   $	��Top=�6M   $��35��6e   $��16(�6q   $��Arial)�6   $
��Bold"�6�   $��2��6�   6�   �� 5   
   -   5         ��Name$ 
imageItems��5      $
��Left=�6$   $	��161��6?   $��	20,65,0,0q�6L   $	��Top=�6_   $	��164��6w   $��3��6�   �� 5   
   -   5        $ btnAddPhotoItems��5      $��Dodaj��6+   $��2,252,102,0q�6;   $	��Top=�6P   $��35��6h   $��16(�6t   $��Arial)�6�   $
��Bold"�6�   $��3��6�   6�   �� 5   
   -   5        $ btnDeletePhotoItems��5      $��Usuń��6.   $��108,252,10,0q�6=   $	��Top=�6S   $��35��6k   $��16(�6w   $��Arial)�6�   $
��Bold"�6�   $��3��6�   $��2��6�   6�   �� 5   
   -	   5        $ btnMoveItems��5      $��Przenieś przedmiot��6'   $��	2,307,0,0q�6D   $	��Top=�6W   $��45��6o   $��20(�6{   $��Arial)�6�   $
��Bold"�6�   $��3��6�   6�   �� 5   
   $��Podgląd zdjęcia��6   $��37,27,37,364q�6*   $��Arial)�6@   $��16(�6S   $��3��6a   �� 5   
   -
   5         ��Name$ tbFilePathItems��5      $��3��6+   $
��Left=�6;   $��23��6V   $��	0,234,0,0q�6b    �� TextWrapping$
 Wrap=�6u   $	��Top=�6�   $	��200��6�   $��2��6�   $y�Hidden=�6�   �� 5   
   -   5        	 ��Name$	 groupBox��5      $��3��6%   $��2��69   $��Edycja zdjęć��6I   $��Center=�6`   $��64��6}   $��
21,232,0,0q�6�   $	��Top=�6�   $	��216��6�   ���	#FF3B91C56�   5      5      