   M S B A M L   `   `   `  ����B  >PocTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:PocTaskPocTask  5   	       PocTask.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:PocTask     5   	   -   5          �Name$
  This��5   5    � Title$ 
MainWindow��6	   $	��450��6   $	��800��6)    � DataContext 5	        PocTask.ContextMain  5
   
   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      6   .+�5   
   �� $��0��6    �� DisplayMemberPath$
 Name��6E   ��6    �� *ProcessTests+ �� SelectedValue 6^   �� *SelectProcess+6�   �� 5   
   $��1��6   ��6&   �� *SelectProcess.Data+6O   5      5      