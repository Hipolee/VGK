   M S B A M L   `   `   `  ����>  :VGK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VGK.Views	VGK.Views  5      1clr-namespace:ModelView.ViewsModelView.Views  5          VGK.Views.EditView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:VGK.Views     5      2controlsclr-namespace:ModelView.Views     5        � 	Resources  5
         HeaderStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6%   .�5      ��  � �� �	#FF3131316+   �� 5       � ��$ 20(�6)   �� 5       � ��$ 10q�6'   �� 5       � ��$ Center=�62   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��3* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��auto �6    60   �� 5      $	��10* �6    6/   �� 5      $
��auto �6    60   .+�5!      ]� $��0��6   ���	#FF2E2E2E.+�5"      �� 
�������.��6+   	recherche66   �� 5#      $��0��6   $��4q�6'   $��Center=�62   6O   5$      �� 5%      $��0��6   $��1��6'   $��2��64   ���	#CC000000
���������6\   �� *	LesEdit+ �� SelectedItem 6}   �� *SelectedEdit+ �� Mode$ TwoWay=���5&      �� 5'      .R�5(      �� $��18(�69   ��6$   �� *Nom+69   5)      5+      �� 5,      $��2��6    �� Orientation$ 
Horizontal=�6&   $��Center=�6?   $��Center=�6Z   .+�5-      �� $��20��6   $��80��6'   $��30��62   $��5q�6>   ��6I   �� *AddVisibilityCommand+.��6r   	Ajouter6{   �� 5.      $��20��6   $��80��6'   $��30��62   $��5q�6>   ��6I   �� *UpdateVisibilityCommand+.��6u   
Modifier6   �� 5/      $��20��6   $��80��6'   $��30��62   $��5q�6>   ��6I   �� *RemoveCommand+.��6m   	Supprimer6x   50      51      �� 53   
   $��30q�6   $
��Wrap=�6J   
���   �$��1��6q   $��16(�6�   ��6    �� *SelectedEdit.Description+y�6�   �� *VisibilityEditDetails+   BooleanToVisibilityConverter	 �� 	Converter#	 [ �� 56   
   
���   �$��1q�6&   $��2��6:   $��19q�6J   y�6V   �� *VisibilityEditDetails+#	 [ � 59   
   $��2��6   $��20q�6   
�������y�6B   �� *VisibilityEditDetails+#	 [  5:      �� 5;      �� 5<       5>      �� 5?      $��3* �6    �� 5@      �� 5A      �� 5B      �� 5C      .+�5F      �� $��10q�6   ��6    �� *SelectedEdit.ImagePath+�� 5G      $��0��6   $��1��6%   #��[  6W   $
��Wrap=�6|   $��Center=�6�   $��30(�6�   $
��Bold"�6�   $��0q�6�   ��65   �� *SelectedEdit.Nom+6�   5I         VGK.Views.AddEditView  5K   
   $��1��6   $��2��6,   y�6@   �� *	IsVisible+#	 [ 5N      5O      