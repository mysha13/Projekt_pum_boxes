   M S B A M L   `   `   `  ����B  >boxitem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:boxitemboxitem  5   	       boxitem.FindItem   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:boxitem     5   	     � Title$  Znajdź przedmiot��5   	   $��399.045��6"   $	��260��63    � 
ResizeMode$ NoResize=�6?   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��29* �6   �� 5      $	��29* �6   �� 5      $	��14* �6   �� 5      $	��96* �6   �� 5      $	��17* �6   �� 5      $	��27* �6   �� 5      $	��30* �6   .+�5   
   �� -   5         ��Name$ tbNameFindItem��5       �� TextAlignment$ Center=�6,   $��27��6C   $��1,41,2,0q�6O    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��16(�6�   $��Arial)�6�   ���	#FF787878$��1��6�   $��5��6�   ��6�   Z� 6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridBoxesListFindItem��5      $��	0,149,1,0q�66   $	��Top=�6I   $	��152��6a    J� RenderTransformOrigin$ 0.358,0.444&�6n   $��1��6�   $��5��6�      
IsReadOnly . 6�   �� 5   
   -   5        	 ��Name$	 btnCancelFindItem��5      $��Anuluj��6,   $��
65,319,1,0q�6=   $��16(�6Q   $��Arial)�6_   $
��Bold"�6r   $��34��6�   $	��Top=�6�   $��3��6�   $��3��6�   �� 5   
   -   5        $	 btnGotoFindItem��5      $
��Idź��6+   $
��Left=�69   $��	0,319,0,0q�6T   $��83��6g   $��16(�6r   $��Arial)�6�   $
��Bold"�6�   $��34��6�   $	��Top=�6�   $��1��6�   $��3��6�   6�   �� 5   
   -   5        
 ��Name$
 imageAddPhoto��5   $   $y�Hidden=�6   $	��125��6;   $��
10,115,6,0q�6H   $	��Top=�6\    J� OpacityMask
 �   � � UseLayoutRounding .   � Cursor$
 None��6�   $��2��6�   $��3��6�   �� 5   
   $��Nazwa��6   $��21,5,10,327q�6    $��Arial)�65   $��16(�6H   $��3��6V   �� 5   
   -   5        $	 btnSerachFindItem��5      $��Szukaj��6-   $��0,88,3,0q�6>   $��16(�6P   $��Arial)�6^   $
��Bold"�6q   $��34��6�   $	��Top=�6�   $��3��6�   6�   5      5      