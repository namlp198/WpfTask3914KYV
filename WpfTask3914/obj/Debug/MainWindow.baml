   M S B A M L   `   `   `  ����F  BWpfTask3914, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfTask3914WpfTask3914  5   	   =#clr-namespace:WpfTask3914.ConverterWpfTask3914.Converter  5   	   3clr-namespace:WpfTask3914.ViewWpfTask3914.View  5   	       WpfTask3914.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfTask3914     5   	   :
localcolor#clr-namespace:WpfTask3914.Converter     5   	   4	localviewclr-namespace:WpfTask3914.View     5   	   -   5          � Title$  
MainWindow��5
   	   $	��300��5   	   $	��650��5   	    � 
ResizeMode$ NoResize=�5   	    � 	Resources 5      5   /WpfTask3914.Converter.ConverterBoolToForeground   ConverterBoolToForeground��%   &	          5   
   6/   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��12* �6   �� 5      $��1 �6   �� 5      $��4* �6   �� 5      $��1 �6   �� 5      $��3* �6   .+�5   
   �� 
����d� �� Orientation$ 
Horizontal=�5      .+�5      �� -   5        $��lbStateCheck��5$      $��Center=�5      $��Center=�5      $��5 0 0 10q�5      $��38(�5       
�������$��SemiBold"�5"      $��Expanded&�5#      ��5      �� *
StateCheck+ �� UpdateSourceTrigger$ PropertyChanged=�5$      *   $WpfTask3914.View.CircularProgressBar  5&      $��10 0 0 0q�6,   5'      � 5)   
   $��2��6    � ColumnDefinitions 5*      �� 5+      $
��3.2* �6#   �� 5,      $��1 �6#   �� 5-      $��7* �6#   .+�5/      � ���	#FF0C3EB9.+�50      �� -   5        $��lbStateResult��5:      $��Center=�51      $��Center=�52      $��Center=�53      $��Center=�54      $��20(�55      $��Expanded&�56      $��
ExtraLight"�57      
�������$��5 0 0 0q�59      ��50      �� *StateResult+$ PropertyChanged=�5:      5<      � 5=      $��2��6   ���	#FF0C3EB9.+�5?      �� $ 
Horizontal=�6   .+�5@      �� $��20 0 5 0q�6    $��20(�5A       $��Expanded&�5B       $��
ExtraLight"�5C       
�������$��RESULT: ��5E       $��Center=�5F       $��Center=�5G       �� 5H      -   5         ��Name$ tbXmlCheckResult��5I       $��5 3 0 0q�5H       $��16(�5J       $��SemiExpanded&�5K       $��
ExtraLight"�5L       $��Center=�5O       $��Center=�5P       ��5M       �� *IsXmlCheckResult+ �� 	Converter# [  ��5N       �� *
JudgeXml+$ PropertyChanged=�5P       �� 5Q      -   5        $ tbIniCheckResult��5R       $��10 3 0 0q�5Q       $��16(�5S       $��SemiExpanded&�5T       $��
ExtraLight"�5U       $��Center=�5X       $��Center=�5Y       ��5V       �� *IsIniCheckResult+# [  ��5W       �� *
JudgeIni+$ PropertyChanged=�5Y       �� 5Z      -   5        $ tbJsonCheckResult��5[       $��10 3 0 0q�5Z       $��16(�5\       $��SemiExpanded&�5]       $��
ExtraLight"�5^       $��Center=�5a       $��Center=�5b       ��5_       �� *IsJsonCheckResult+# [  ��5`       �� *	JudgeJson+$ PropertyChanged=�5b       5c      5d      5e      �� 5f   
   $��4��6   
���2͚�.@�5g      �� -   5        $
��lbP1��5k      $��2 0 0 0q�5h      $��12(�5i      $��SemiExpanded&�5j      ��5g      �� *StP1+$ PropertyChanged=�5k      �� 5l      �� 5m      -   5        $
��lbP2��5q      $��2 0 0 0q�5n      $��12(�5o      $��SemiExpanded&�5p      ��5m      �� *StP2+$ PropertyChanged=�5q      �� 5r      �� 5s      -	   5        $
��lbP3��5w      $��2 0 0 0q�5t      $��12(�5u      $��SemiExpanded&�5v      ��5s      �� *StP3+$ PropertyChanged=�5w      5x      5y      5z      