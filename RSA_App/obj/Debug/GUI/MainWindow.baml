   M S B A M L   `   `   `  ����B  >RSA_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:RSA_App.GUIRSA_App.GUI  5   	   H DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu 5   	       RSA_App.GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:RSA_App.GUI     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	     � Title$  RSA Boekhoud App��5	   	    � 
ResizeMode$ 	CanResize=�5
   	    � WindowState$ 	Maximized=�5   	    � Icon$0 */RSA_App;component/Icons/asbestos_icon.ico��5   	   .��5      � 
�������.+�5   
   � $��	50,55,0,0q�6   .+�5       � -   5        $��	MainFrame��5        � NavigationUIVisibility$ Hidden=�5      5      � 5   
   $��55��5      
����·�$	��Top=�5      .+�5!      �� $4��./RSA_App;component/Images/logo_RSA_cropped.png��5"      $
��Left=�5#      �� 5&      $��Bottom=�5'      $
��Left=�5(      $��55��5)      $��	262,0,0,0q�5*      $	��200��5+      
�������.+�5.      �� $��0q�6   $��12��6.   �� 50      $��25��51      $��Boekhoud App��52      $��Gotham Black)�53      
����·�$��14(�55      $��0q�56      $��Right=�57      $��Center=�58      �� 5:      $��20��5;      $-��'Developed By: Natasja Krop © 2018-2019��5<      $��8(�5=      $��Right=�5>      $��Italic$�5?      $��Center=�5@      5B      �� 5E      $��Right=�6   .+�5G      �� -   5        $��lblUser��5H      $��Right=�5I      $��stretch=�5J      $��Gotham)�5K      
�������$��12(�5M      5O      5P      � 5S   
   $��0,55,0,0q�6   .+�5U      !  HamburgerMenu.HamburgerMenu  ���#646464   MenuIconColor
 �����   SelectionIndicatorColor
 �����   MenuItemForeground
 �����$
��Left=�5Z      $	��200��5[         Content 5`      %  HamburgerMenu.HamburgerMenuItem  -   5        	   Text$
	 Home��5a      
   Icon$
 /Icons/home_icon.ico��5b      5c        5f      -   5        $	 Facturen��5g      $
 /Icons/invoice_icon.ico��5h      5i        5l      $	 
Debiteuren��5m      $
 /Icons/users_icon.ico��5n        5q      $	 Balans��5r      $
 /Icons/euro_icon.ico��5s        5v      $		 BTW��5w      $
 /Icons/tax_icon.ico��5x        5{      $	 Overzichten��5|      $
 /Icons/profits_icon.ico��5}      5�      5�      5�      5�      