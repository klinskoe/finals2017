   M S B A M L   `   `   `  ����H  DSearchService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:SearchServiceSearchService  5   	       SearchService.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:SearchService     5   	     � Title$  Search Demo��5   	   $	��350��6   $	��525��6*   .��5	      � $��5q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5        $��textBoxDirectory��5      $	��0 5q�6*   $��0��67   .��6D   ../..6K   �� 5   
   -   5        $��buttonIndex��5      $��1��6$   $	��150��64   $��5q�6Z   .��6e   Index6l   �� 5   
   -   5         ��Name$ word_textbox��5      $��1��6   .��65   68   �� 5   
   -   5         ��Name$ Search_button��5      $��1��6(   $��1��65   $	��150��6E   .��6f   Search6n   �� 5   
   -   5         ��Name$ Result_listbox��5      $��2��6*   $��2��67   6M   5      5      