   M S B A M L   `   `   `  ����>  :VGK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:VGK.Views	VGK.Views  5          VGK.Views.AddEditView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:VGK.Views     5        � 	Resources  5	       �� 
TargetType �� Property �� Value��%�  ']�       '�� t     '��     �� 5
   
   " ]�6   .�5      ��  � ��$ Center=�6,   �� 5       � ��$ Center=�6*   5      �� 5      " ��6   .�5   
   ��  � ��$	 200��6"   �� 5   
    � ��$ 15q�6#   �� 5   
    � ��$ 18(�6%   5      �� 5      " ��6   .�5   
   ��  � ��$	 100��6"   �� 5   
    � ��$ 15q�6#   �� 5   
    � ��$ 18(�6%   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6    � RowDefinitions 5    
   �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      .+�5)   
   ]� $��1��6   .+�5*      �� .��6   Nom6   �� 5,      ��6   �� *AddedEdit.Nom+ �� UpdateSourceTrigger$ PropertyChanged=�5.      ]� 5/   
   $��1��6   $��2��6%   .+�50      �� .��6   Date6   �� 51      ��6   �� *AddedEdit.DateCreation+   DateToStringConverter �� 	Converter# [  52      �� 54   
   $��Center=�6   $��Center=�6/   $��28(�6L   Description6g   �� 55   
   $��5��6   $��15q�6    $	��200��6,   $��45��68   $��Charger une image��6D   $��16(�6�   ��6`   �� *UploadImageCommand+6�   �� 56   
   $��1��6   $��4��6!    �� TextWrapping$
 Wrap=�62   $
��auto��6G   ��6T   �� *AddedEdit.Description+]� 57   
   $��5��6   $��1��6!   .+�58      �� $��	Appliquer��6   $��10q�6H   $	��160��6T   $��60��6`   $��20(�6l   ��6)   �� *
AddCommand+y�6z   �� *VisibilityAddEdit+   BooleanToVisibilityConverter# [ 6�   �� 59      $��Annuler��6   $��60��6H   $	��120��6U   $��20(�6a   $��Right=�6o   $��10q�6�   ��6'   �� *CloseCommand+6�   5:      5=      5?      