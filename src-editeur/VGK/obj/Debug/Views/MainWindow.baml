   M S B A M L   `   `   `  ����>  :VGK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ModelView.ViewsModelView.Views  5   	   1clr-namespace:ModelView.ViewsModelView.Views  5   	   %clr-namespace:VGK.Views	VGK.Views  5   	        ModelView.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ModelView.Views     5   	   2controlsclr-namespace:ModelView.Views     5   	   -	controls1clr-namespace:VGK.Views     5   	     � Title$  
MainWindow��5
   	   $	��800��6   $
��1600��6)   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $��5* �6   .+�5      !   ModelView.Views.ToolBarView  � 5   
   $��1��6   ]� 5   
   $��1��6   $��2��6!   y�65   �� *VisibilityMain+    BooleanToVisibilityConverter �� 	Converter# [  .+�5         ModelView.Views.MainView  5      ]� 5   
   $��1��6   $��2��6!   y�65   �� *VisibilityJeux+# [  .+�5         ModelView.Views.GameView  5      ]� 5   
   $��1��6   $��2��6!   y�65   �� *VisibilityEdit+# [  .+�5         VGK.Views.EditView  5      5       5!      