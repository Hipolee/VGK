   M S B A M L   `   `   `  ����>  :VGK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModelView.ViewsModelView.Views  5      !    ModelView.Views.AddGameView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:ModelView.Views     5        � 	Resources  5	       �� 
TargetType �� Property �� Value��%�  ']�       '�� t     '��     �� 5
   
   " ]�6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$	 200��6&   �� 5       � ��$ 15q�6'   �� 5       � ��$ 18(�6)   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6&   �� 5       � ��$ 15q�6'   �� 5       � ��$ 18(�6)   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      $��2* �6    � RowDefinitions 5    
   �� 5!      �� 5"      �� 5#      �� 5$      �� 5%      �� 5&      .+�5)   
   ]� $��1��6   .+�5*      �� .��6   Titre6   �� 5,      ��6   �� *AddedJeu.Titre+ �� UpdateSourceTrigger$ PropertyChanged=�5.      ]� 5/   
   $��1��6   $��1��6%   .+�50      �� .��6   	Editeur6   �� 51      ��6   �� *AddedJeu.Editeur+$ PropertyChanged=�52      ]� 53   
   $��1��6   $��2��6%   .+�54      �� .��6   Date6   �� 55      ��6   �� *AddedJeu.Date+   DateToStringConverter �� 	Converter# [  57      ]� 58   
   $��1��6   $��3��6%   .+�59      �� .��6   Prix6   �� 5:      ��6   �� *AddedJeu.Prix+$ PropertyChanged=�5;      �� 5<   
   $��4��6   $��1��6"   .+�5=      �� $	��200��6   $��0q�6    .��6+   Catégorie(s)69   ]� 5>      $��4��6   $��1��6%   .+�5?      �� 
 � Tag$ 
Catégorie��6   $��30��6,   $��10q�68   $
��Left=�6D   $	��120��6_   $��16(�6�   ��6k   �� *LesCategories+	 �� SelectedItem	 6�   �� *AddedJeu.Categorie1+
 �� Mode$
 TwoWay=�6�   �� 5@      $ 
Catégorie��6   $��30��6,   $��10q�68   $
��Left=�6D   $	��120��6_   $��16(�6�   ��6k   �� *LesCategories+	 6�   �� *AddedJeu.Categorie2+$
 TwoWay=�6�   5A      5B      �� 5D   
   $��Center=�6   $��Center=�6/   $��28(�6L   Description6g   �� 5E   
   $��5��6   $��15q�6    $	��200��6,   $��45��68   $��Charger une image��6D   $��16(�6�   ��6`   �� *UploadImageCommand+6�   �� 5F   
   $��1��6   $��4��6!    �� TextWrapping$
 Wrap=�62   $
��auto��6G   ��6T   �� *AddedJeu.Description+]� 5G   
   $��5��6   $��1��6!   .+�5H      �� $��	Appliquer��6   $��10q�6H   $	��160��6T   $��60��6`   $��20(�6l   ��6)   �� *
AddCommand+y�6z   �� *VisibilityAddGame+   BooleanToVisibilityConverter# [ 6�   �� 5I      $��Annuler��6   $��60��6H   $	��120��6U   $��20(�6a   $��Right=�6o   $��10q�6�   ��6'   �� *CloseCommand+6�   5J      5M      5N      