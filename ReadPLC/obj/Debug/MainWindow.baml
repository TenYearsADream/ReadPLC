   M S B A M L   `   `   `  ����B  >ReadPLC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ReadPLCReadPLC  5   	       ReadPLC.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ReadPLC     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��680��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ 
CmdConnect��5
      $��Connect��6%   $
��Left=�67   $��
136,10,0,0q�6R   $	��Top=�6f   $��75��6~   6�   �� 5   
   -   5        $ CmdRead��5      $��Read ��6"   $
��Left=�62   $��
136,34,0,0q�6M   $	��Top=�6a   $��75��6y   {�.  6�   �� 5   
   -   5         ��Name$ LblText��5      $��Label��6!   $
��Left=�61   $��	60,86,0,0q�6L   $	��Top=�6_   $	��106��6w   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   �� 5   
   -   5         ��Name$ TxtIP��5      $
��Left=�6!   $��23��6<   $��	11,10,0,0q�6H    �� TextWrapping$
 Wrap=�6[   $��10.225.178.75��6o   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ CmdDIs��5      $��
Disconnect��6!   $
��Left=�66   $��
216,10,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   $'��!LogData - PLC Transaction Counter��6   $
��Left=�6<   $��	10,65,0,0q�6W   $	��Top=�6j   �� 5   
   -   5         ��Name$ listBox1��5      $
��Left=�6$   $	��226��6?   $��
209,65,0,0q�6L   $	��Top=�6`   $	��444��6x   �� 5   
   $�� ��6   $
��Left=�6   $��
13,235,0,0q�66   $	��Top=�6J   $��56��6b   $	��118��6n   �� 5   
   $��PLC Count = '700'��6   $
��Left=�6,   $��
11,178,0,0q�6G   $	��Top=�6[   �� 5   
   $��Serial = '764'��6   $
��Left=�6)   $��
11,204,0,0q�6D   $	��Top=�6X   �� 5   
   -   5        $ LblText_Copy��5      $��Label��6&   $
��Left=�66   $��
60,122,0,0q�6Q   $	��Top=�6e   $	��106��6}   $
��Bold"�6�   $��Italic$�6�   $��16(�6�   �� 5   
   $��Inter��6   $
��Left=�6    $��
26,126,0,0q�6;   $	��Top=�6O   �� 5   
   $��Inter = '726'��6   $
��Left=�6(   $��
13,158,0,0q�6C   $	��Top=�6W   �� 5   
   -   5        $ 
TxtIP_Copy��5      $
��Left=�6&   $��23��6A   $��	11,33,0,0q�6M   $
 Wrap=�6`   $
��1601��6t   $	��Top=�6�   $	��120��6�   5      5      