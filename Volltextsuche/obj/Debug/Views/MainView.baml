   M S B A M L   `   `   `  ����H  DVolltextsuche, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:VolltextsucheVolltextsuche  5   	   9!clr-namespace:Volltextsuche.ViewsVolltextsuche.Views  5   	   C&clr-namespace:Volltextsuche.ViewModelsVolltextsuche.ViewModels  5   	   "    Volltextsuche.Views.MainView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Volltextsuche     5   	   3views!clr-namespace:Volltextsuche.Views     5   	   5vm&clr-namespace:Volltextsuche.ViewModels     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   
�������$��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	      MaterialDesignFont#���   5   	    � AllowsTransparency . 
�������$	��450��5   	   $	��800��6    � 
ResizeMode$ CanResizeWithGrip=�6"    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�6A   ��5   	   Z�  � WindowState 5      �� *PWindowState+ � DataContext 5      ,   &Volltextsuche.ViewModels.MainViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $	��200 �6   	 � RowDefinitions	 5   
   �� 5      $��30 �6   �� 5      $��5 �6   �� 5      .+�5!   
   � ���	#FF191A21
 J� Opacity$	
 0.6Q�6&   $��1��64   $��2��6A   � 5"   
   $��2��6   ���	#FF191A21$

 0.99Q�63   	 5#      �� 5$      �� 5%      .+�5'      ]� .+�5(      �� $��Durchsuche Verzeichnis��6   $��
10 10 10 5q�5)      $	��Top=�6,   #  MaterialDesignThemes.Wpf.Card  5*      $
��10 0q�5+   &   $	��Top=�64   $��10q�6I   {�.  $��30��6h   ��5*   &   �� *PSearchPath.PPath+5+   h   �� 5,      $��Suchbegriff��6   $��
10 10 10 5q�5-      $	��Top=�6,   ]� 5.      $
��10 0q�6   $	��Top=�6*   $	��Top=�6?   .+�5/      ��  * &MaterialDesignFloatingActionMiniButton#��[ 6   $��Right=�52      $��	30 0 20 0q�64    � ToolTip$ Starte Volltextsuche��54      3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   IsIndicatorVisible 50      �� *PIsSearching+   IsIndeterminate 51      �� *PIsSearching+��53      �� *	CmdSearch+.��55      '  !MaterialDesignThemes.Wpf.PackIcon  ��56      �� 57   "    �� 
TargetType"  6(   .�58   &   ��  �� Property �@ Kind �� Value$ Search=�6=    �� Triggers 59   &   �� 5:   *    �� Binding 66   �� *PResultsReady+ �� Value True6X   .a�5;   .   ��  �@ Kind$ Check=�6E   5<   +   5>   #   5@      5A      �� 5B       * &MaterialDesignOutlinedTextFieldTextBox#��[ 5C      $��40��5D      ��5B      �� *PSearchKeyword+5D      5E      5F      ]� 5G      $��1��6   .+�5H      �� $��Ergebnis��6   $��
10 10 10 5q�5I      $	��Top=�6,   5J      5K      � 5L   
   $��2��6   $��1��6   ���	#FF191A21$

 0.99Q�6C   	 5M      �� 5N      �� 5O      5Q      )  #MaterialDesignThemes.Wpf.DrawerHost  5R   
   $��2��6$   $��2��61      OverlayBackground
 �   �   IsLeftDrawerOpen 5S   $   �� *PIsMenuOpen+ �� Mode$ TwoWay=�   LeftDrawerContent 5U      ]� 5V      ���	#FF053749$
��Auto��5W      .+�5X      �� .��5Y      ��  � IsSharedSizeScope .   TIC#���  5[   #   ��5Y   '   �� *	PDrives+ � 	Resources 5\       �� DataType4   .Volltextsuche.ViewModels.LogicalDriveViewModel 9� 
IsExpanded ��Name z� SharedSizeGroup d� 	IsChecked��%�  &	       �� 5]   "   "  6;   .R�5^   &   9� $��Stretch=�5_   +   $
��Left=�5`   +   $��5 0 0 -5q�5b   +   ��5^   /   Z�  5a   +   �� *PIsExpanded+��5c   *   �� 5d   .   $ Border��65   $��-15 0 -15 0q�6E   ._�5e   2   �  5f   6   �� 5g   :   $ Checkerz��6K   �� 5h   :   .+�5j   6   �� $	��Top=�6?    5k   ?   �� *PIsSelected+{�5l   ?   �� *
PIsEnabled+�� 5m   6   $��8 0 0 0q�6A   $��1��6R   .+�5n   :   �� $
��Bold"�6[   ��6D   �� *PPath+6[   �� 5o   :   $��Stretch=�6\   ��6D   �� *PCount+6\   5p   7   5q   3   5r   /   ��5t   *   �� 5u   .   $��20 0 0 0q�5v   ;   #���  5w   ;   ��5u   ;   �� *
PSubdrives+5w   ;   5y   '   5z   #   5{      5|      5}      5~      5�      ]� 5�   
   $��2��6   .+�5�      (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��5q�5�      +	  %MaterialDesignThemes.Wpf.ShadowAssist 	  ShadowDepth$ Depth2=�5�          Mode$  PrimaryDark=�5�      $
��Left=�5�      .��5�      ]� .+�5�      d�  ' #MaterialDesignHamburgerToggleButton#��[ 5�   !   $
��Auto��5�   !   $
��Auto��6.    5�   !   �� *PIsMenuOpen+$ TwoWay=�5�   .   �� 5�      $��Right=�5�      $��Right=�5�       & "MaterialDesignIconForegroundButton#��[ 5�      $
��Auto��5�      $
��Auto��6&   ��5�      �� *
CmdClose+.��5�        !   Kind$! WindowClose=�62   $
��Auto��6E   $
��Auto��6R   5�      d� 5�      $��Right=�5�      $��Right=�5�      #��[ 5�      $ Vollbild��5�      $
��Auto��5�      $
��Auto��6&    5�      �� *PIsMaximized+$ TwoWay=�.��5�        $! WindowMaximize=�62   $
��Auto��6H   $
��Auto��6U   5�      �� 5�      $��Right=�5�      $��Right=�5�      #��[ 5�      $ 	Minimiere��5�      $
��Auto��5�      $
��Auto��6&   ��5�      �� *CmdMinimize+.��5�        $! WindowMinimize=�62   $
��Auto��6I   $
��Auto��6V   5�      5�      5�      5�      5�      5�      