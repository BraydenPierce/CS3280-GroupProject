   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GroupProject.MainGroupProject.Main  5   	       GroupProject.Main.wndMain   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GroupProject.Main     5   	     � Title$  wndMain��5   	   $	��297��6   $	��579��6&   .��5	      � ���#595959.+�5
   
   o� $��0,0,0,0q�6   $
��Left=�6    $	��Top=�6;   .@�5      m� -   5        $��Search��5      6'   m� 5      -   5        $��
Edit Items��5      6+   5      �� 5   
   -   5         ��Name$ lblInvoiceDate��5      $��Invoice Date:��6(   $
��Left=�6@   $��	25,44,0,0q�6[   $	��Top=�6n   �� 5   
   -   5        $ lblInvoiceNum��5      $��Invoice Number:��6'   $
��Left=�6A   $��	25,72,0,0q�6\   $	��Top=�6o   �� 5   
   -   5        $ lblTotalCost��5      $��Total Cost:��6&   $
��Left=�6<   $��
25,103,0,0q�6W   $	��Top=�6k   �� 5   
   -   5        $ lblDateDisplay��5      $��*DATE GOES HERE*��6(   $
��Left=�6C   $��
130,44,0,0q�6^   $	��Top=�6r   �� 5   
   -   5        $ lblCostDisplay��5      $��*COST GOES HERE��6(   $
��Left=�6B   $��130,103,0,0q�6]   $	��Top=�6r   �� 5   
   -   5        $ lblNumDisplay��5      $��*NUM GOES HERE*��6'   $
��Left=�6A   $��
130,72,0,0q�6\   $	��Top=�6p   �� 5   
   -	   5        $ lblItems��5      $��Items: ��6"   $
��Left=�64   $��
25,142,0,0q�6O   $	��Top=�6c   �� 5   
   -
   5        $ lblCost��5      $��Cost:��6!   $
��Left=�61   $��
25,177,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        $ lblInvoiceItems��5      $��Items on Invoice: ��6)   $
��Left=�6F   $��
341,44,0,0q�6a   $	��Top=�6u   �� 5   
   -   5         ��Name$ btnEdit��5      $��Edit Invoice��6"   $
��Left=�69   $��236,226,0,0q�6T   $	��Top=�6i   �� 5   
   -   5        $ btnSave��5      $��Save Invoice��6"   $
��Left=�69   $��341,226,0,0q�6T   $	��Top=�6i   �� 5   
   $
��Left=�6   $��
74,139,0,0q�6.   $	��Top=�6B   $	��120��6Z   �� 5   
   -   5        $ lblItemCost��5      $��*ITEM COST GOES HERE*��6%   $
��Left=�6E   $��
74,177,0,0q�6`   $	��Top=�6t   �� 5   
   -   5        $ 
btnAddItem��5      $��Add Item��6%   $
��Left=�68   $��244,139,0,0q�6S   $	��Top=�6h   �� 5   
   -   5        $ btnRemoveItem��5      $��Remove Item��6(   $��Center=�6>   $��	0,176,0,0q�6[   $	��Top=�6n   �� 5   
   -   5        $ btnAddInvoice��5      $��Add Invoice��6(   $
��Left=�6>   $��130,226,0,0q�6Y   $	��Top=�6n   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ grdInvoiceItems��5      $��341,70,32,83q�6W   5      5       