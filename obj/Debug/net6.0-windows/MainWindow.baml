   M S B A M L   `   `   `  ????  ContactAppWPF    ContactAppWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5      ?  ? ColumnDefinitions 5	   
   ?? 5
      $??* ?6   ?? 5      $??2* ?6   .+?5   
   ?? -   5         ??Name$ listContacts??5       ?? View 5      ?? 5      .P?5      ?? $
??Name??6%    ?? DisplayMemberBinding 63   ?? *	firstName+?? 5      $??Surname??6%    66   ?? *
lastName+5      5      ?? 5   
   $??1??6   $??10q?6%   .+?5      ?? $??Contact Details??6   $??0 0 0 10q?6/   ?? 5       ?? Orientation$ 
Horizontal=?6   $??0 0 0 10q?62   .+?5      ?? $??First Name:??6   $	??100??6/   ?? 5      -   5        $??firstNameTextBlock??5      5      ?? 5      $ 
Horizontal=?6   $??0 0 0 10q?62   .+?5      ?? $??
Last Name:??6   $	??100??6.   ?? 5      -   5        $??lastNameTextBlock??5      5       ?? 5!      $ 
Horizontal=?6   $??0 0 0 10q?62   .+?5"      ?? $??Birth Date:??6   $	??100??6/   ?? 5#      -   5        $??birthDateTextBlock??5#      5$      ?? 5%      $ 
Horizontal=?6   $??0 0 0 10q?62   .+?5&      ?? $??Gender:??6   $	??100??6+   ?? 5'      -   5        $??genderTextBlock??5'      5(      ?? 5)      $ 
Horizontal=?6   $??0 0 0 10q?62   .+?5*      ?? $??Email:??6   $	??100??6*   ?? 5+      -   5        $??emailTextBlock??5+      5,      ?? 5-      $ 
Horizontal=?6   $??0 0 0 10q?62   .+?5.      ?? $??Phone:??6   $	??100??6*   ?? 5/      -   5        $??numberTextBlock??5/      50      51      ?? 52   
   $??1??6   $ 
Horizontal=?6%   $??Right=?6>   $
??10 0q?6Z   $	??Top=?6h   .+?53      ?? -   5         ??Name$ btnAdd??53      $	??Add??6%   $??0 0 10 0q?63   6E   ?? 54      -	   5        $ btnEdit??54      $
??Edit??6&   $??0 0 10 0q?65   6G   ?? 55      -
   5        $ 	btnDelete??55      $??Delete??6(   69   56      57      58      