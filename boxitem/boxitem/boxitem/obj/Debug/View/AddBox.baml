   M S B A M L   `   `   `  ����B  >boxitem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:boxitemboxitem  5   	       boxitem.AddBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:boxitem     5   	     � Title$  Dodaj pudełko��5   	   $��400.341��6   $��250.36��60    � 
ResizeMode$ NoResize=�6?   .��5	      � .+�5
   
   �� -   5         ��Name$ tbNameAddBox��5
       �� TextAlignment$ Center=�6*   $
��Left=�6B   $��27��6]   $��	28,33,0,0q�6i    �� TextWrapping$
 Wrap=�6|   $	��Top=�6�   $	��182��6�   $��16(�6�   $��Arial)�6�   ���	#FF787878��6�   Z� 6�   �� 5   
   -   5        $ tbNumberAddBox��5      $ Center=�6+   $
��Left=�6C   $��27��6^   $��	28,90,0,0q�6j   $
 Wrap=�6}   $	��Top=�6�   $	��182��6�   $��16(�6�   $��Arial)�6�   ���	#FF787878��6�   Z� 6�   �� 5   
   -   5         ��Name$ btnCancelAddIBox��5      $��Anuluj��6+   $
��Left=�6<   $��
74,325,0,0q�6W   $	��Top=�6k   $��96��6�   $��34��6�   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   6�   �� 5   
   -   5        $ btnOkAddBox��5      $��Ok��6&   $
��Left=�63   $��
74,276,0,0q�6N   $	��Top=�6b   $��96��6z   $��34��6�   $��16(�6�   $��Arial)�6�   $
��Bold"�6�   6�   �� 5   
   $��Nazwa:��6   $��	92,5,72,0q�6#   $	��Top=�66   $��15(�6N   $��Arial)�6\   $��28��6o   �� 5   
   $��Kod pudełka:��6   $��
73,61,67,0q�6)   $	��Top=�6=   $��15(�6U   $��Arial)�6c   $��28��6v    J� RenderTransformOrigin$ 0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ -0.321Q�6&   T� 5      5      5      �� 5   
   $��Opis:��6   $��92,126,93,0q�6"   $	��Top=�67   $��15(�6O   $��Arial)�6]   $��28��6p   �� 5   
   -   5        $ tbDescriptionAddBox��5      $ Center=�60   $
��Left=�6H   $��90��6c   $��
28,167,0,0q�6o   $
 Wrap=�6�   $	��Top=�6�   $	��182��6�   $��16(�6�   $��Arial)�6�   ���	#FF787878 �� AcceptsReturn . "	 �� VerticalScrollBarVisibility$	 Visible=�5      ��5   �   Z� 5      5      5      