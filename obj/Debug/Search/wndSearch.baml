   M S B A M L   `   `   `  ����G  CGroupProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GroupProject.SearchGroupProject.Search  5   	   #    GroupProject.Search.wndSearch   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:GroupProject.Search     5   	     � Title$  	wndSearch��5   	   $	��450��6   $	��800��6(   .��5	      � ���#595959 � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� -   5         ��Name$ clearFilterBTN��5      $��Cancel or Clear Filter��6)   $��Center=�6J   $��0,52,0,0q�6g   $	��Top=�6y   $��37��6�   $	��180��6�   $��2��6�   $��17(�6�   6�   �� 5   
   -   5        $ selectInvoiceBTN��5      $��Select Invoice��6+   $
��Left=�6D   $��	10,52,0,0q�6_   $	��Top=�6r   $��37��6�   $	��122��6�   $��3��6�   $��18(�6�   6�   �� 5   
   -   5         ��Name$ invoiceNumberLBL��5      $��Invoice Number:��6*   $
��Left=�6D   $��	44,22,0,0q�6_   $	��Top=�6r   $	��146��6�   $��22��6�   $��20(�6�   �� 5   
   -   5        $ invoiceDateLBL��5      $��Invoice Date:��6(   $
��Left=�6@   $��	76,54,0,0q�6[   $	��Top=�6n   $��26��6�   $	��114��6�   $��20(�6�   �� 5   
   -   5        $ totalCostsLBL��5      $��Total Costs:��6'   $
��Left=�6>   $��	89,89,0,0q�6Y   $	��Top=�6l   $��27��6�   $	��101��6�   $��20(�6�   �� 5   
   -   5         ��Name$ invoiceNumberCB��5      $��29,28,33,157q�6,   $��1��6B   .@�5      �� $��Test Content 1��6   �� 5      $��Test Content 2��6   �� 5      $��Test Content 3��6   5      �� 5    
   -   5        $ invoiceDateCB��5       $��29,62,33,123q�6*   $��1��6@   .@�5!      �� $��Test Content 1��6   �� 5"      $��Test Content 2��6   �� 5#      $��Test Content 3��6   5$      �� 5%   
   -   5        $ totalCostsCB��5%      $��29,95,33,90q�6)   $��1��6>   .@�5&      �� $��Test Content 1��6   �� 5'      $��Test Content 2��6   �� 5(      $��Test Content 3��6   5)      &   System.Windows.Controls.DataGrid  5*   
   $��	9,47,9,46q�6>   $��1��6Q   $��2��6^   $��1��6r   �� 5+   
   -	   5        $ allInvoicesLBL��5+      $��1��6(   $��All Invoices��68   $��Center=�6O   $��0,10,0,0q�6l   $��1��6~   $	��Top=�6�   $��2��6�   $	��100��6�   $��20(�6�   5-      5.      