   M S B A M L   `   `   `  ����e  aTelerik.Windows.Controls, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7eHclr-namespace:Telerik.Windows.DragDrop;assembly=Telerik.Windows.ControlsTelerik.Windows.DragDrop  5       Reports_IICs   Reports_IICs.App   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      n jTelerik.Windows.Controls.Charting, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a	 ]Telerik.Windows.Data, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p
 lTelerik.Windows.Controls.Navigation, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation   	 
     5      jtelerikDragDropHclr-namespace:Telerik.Windows.DragDrop;assembly=Telerik.Windows.Controls   	 
     5        �� 	Resources  5       �� MergedDictionaries �� Source0   *Telerik.Windows.DragDrop.ListBoxDragVisual �� 
TargetType   DragVisualStyle �� BasedOn �� Property �� Value �� 
TargetType)   #Telerik.Windows.DragDrop.DragVisual'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard �� 
TargetName �� TargetProperty R� KeyTime R� Value  System.Windows.Visibility ��Name �� CornerRadius  DragVisualMultyItemBorder ! DragVisualMultyItemBackground �� RelativeSource �� Mode �� Path   BooleanToVisibilityConverter �� 	Converter �� Padding � ColumnDefinitions � RowDefinitions F�Name  DragVisualEffectImportant  DragVisualEffectNormal �� Orientation  MenuForeground_MouseOver �� Color  MenuBackground_Highlighted  MenuItemTemplate* 
 $Telerik.Windows.Controls.RadMenuItem �Name 	 MenuBackground_MouseOver	 W� To g� Duration ��Name J� Opacity    IconColumnWidth! ��Name"   Icon#   IconTemplateD   >Telerik.Windows.Controls.Primitives.SharedSizeContentPresenter$  Name%   SharedSizeGroupWidth&   InputGestureText 
 MenuIconForeground_Normal' �Name( � HorizontalOffset) � VerticalOffset*   IsSubmenuOpen+ � AllowsTransparency,   DropDownWidth-   DropDownHeight  MenuPopupBorderBrush  MenuPopupBackground. ��Name  MenuScrollViewer9	   3Telerik.Windows.Controls.Primitives.SharedSizeScope/ 	  IsSharedSizeScope  RadMenuItemStyle  MenuItemPadding  SeparatorTemplate&
 
  Telerik.Windows.Controls.RadMenu  RadMenuStyle1  +Telerik.Windows.Controls.GridViewDataColumn  ColumnPreview-  'Telerik.Windows.Controls.GridViewColumn?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter  ContentControlFecha  ContentControlNumero  ContentControlN0  ContentControlN1  ContentControlN2  ContentControlN4  ContentControlN84  .Telerik.Windows.Controls.GridView.GridViewCell  GridViewCellNumeric  GridViewDataColumnNumericN06  0Telerik.Windows.Controls.GridViewBoundColumnBase  GridViewDataColumnNumericN1  GridViewDataColumnNumericN2  GridViewCellDate  GridViewDataColumnDate�� 5   
    5	      �� 5
      $9 3/FirstFloor.ModernUI;component/Assets/ModernUI.xaml?�6%   �� 5      $? 9/FirstFloor.ModernUI;component/Assets/ModernUI.Light.xaml?�6%   �� 5      $O I/Telerik.Windows.Themes.Office_Black;component/Themes/System.Windows.xaml?�6%   �� 5      $Y S/Telerik.Windows.Themes.Office_Black;component/Themes/Telerik.Windows.Controls.xaml?�6%   �� 5      $R L/Telerik.Windows.Themes.Expression_Dark;component/Themes/System.Windows.xaml?�6%   �� 5      $\ V/Telerik.Windows.Themes.Expression_Dark;component/Themes/Telerik.Windows.Controls.xaml?�6%   �� 5      $g a/Telerik.Windows.Themes.Expression_Dark;component/Themes/Telerik.Windows.Controls.Navigation.xaml?�6%   �� 5      $! /Themes/System.Windows.xaml?�6%   �� 5      $+ %/Themes/Telerik.Windows.Controls.xaml?�6%   �� 5      $1 +/Themes/Telerik.Windows.Controls.Input.xaml?�6%   �� 5      $6 0/Themes/Telerik.Windows.Controls.Navigation.xaml?�6%   �� 5      $+ %/Themes/Telerik.ReportViewer.Wpf.xaml?�6%   �� 5      $I Cpack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml?�6%   �� 5      $F @pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml?�6%   �� 5      $G Apack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   %�1  '        7   7  7  7  7  7  7  7  7  7  7  7  &	 �    &	 �    &	     7  7  7  7 	 7  7  7  7  7  7  7 
 7  7  7  '  (    7  7  7  7  7  7  7  7  '
  *    7  &	 �*    &	 j+    &	 �+    &	 E,    7  &	 �,    7  &	 -    7  &	 h-    7  &	 �-    7  &	 *.    &	 u.    &	 �.    &	 '/    &	 �/    &	 �/    �� 5       "  6   8   .�5!      ��  � ��
 �����6/   �� 5"       � ��
 � d �60   �� 5#       � ��
 � � �6/   �� 5$       � �� 5%      �� 5&      "  6*   .R�5'      �  5(   "     5)   &   EffectStates��.	 5*   *     None��.
 5+   .   �� .��5,   2   T� $ 
NoneEffect��6P   $ 
Visibility�6s   ..�5-   6   i� $ 0:0:0��6M    5.   :    5/   >   Visible=�6R   51   7   52   3   53   /   54   +     55   *   Move��.
 56   .   �� .��57   2   T� $ 
MoveEffect��6P   $ 
Visibility�6s   ..�58   6   i� $ 0:0:0��6M    59   :    5:   >   Visible=�6R   5<   7   5=   3   5>   /   5?   +     5@   *   Copy��.
 5A   .   �� .��5B   2   T� $ 
CopyEffect��6P   $ 
Visibility�6s   ..�5C   6   i� $ 0:0:0��6M    5D   :    5E   >   Visible=�6R   5G   7   5H   3   5I   /   5J   +     5K   *   Link��.
 5L   .   �� .��5M   2   T� $ 
LinkEffect��6P   $ 
Visibility�6s   ..�5N   6   i� $ 0:0:0��6M    5O   :    5P   >   Visible=�6R   5R   7   5S   3   5T   /   5U   +     5V   *   
Scroll��.
 5W   .   �� .��5X   2   T� $ ScrollEffect��6P   $ 
Visibility�6u   ..�5Y   6   i� $ 0:0:0��6M    5Z   :    5[   >   Visible=�6R   5]   7   5^   3   5_   /   5`   +   5a   '   .+�5c   "   �� $ SecondItemVisual��6)   $ 2��6�   $��4 4 0 0q�6�   8�� 8�� $��1q�6}  y�6C   ��  �� $ TemplatedParent=�$ IsDraggingMultipleItems�8  6}  �� 5d   "   $ ThirdthItemVisual��6)   $ 2��6�   $��2 2 2 2q�6�   8�� 8�� $��1q�6~  y�6D   ��  �� $ TemplatedParent=�$ IsDraggingMultipleItems�8  6~  �� 5e   "   $ DragBackgroundVisual��6)   $ 2��6G   $��0 0 4 4q�6X   #��z��6i   #��z��6�   #��z��6�   �� 5f   "   $��0 0 4 4q�6)   # z��6:   ._�5g   &   � $��
2, 0, 2, 0q�6+    5h   *   �� 5i   .   $
��Auto �6?   �� 5j   .   $��* �6?    5l   *   �� 5m   .   $��20 �6<   �� 5n   .   $
��Auto �6<   �� 5o   .   $��20 �6<   �� 5p   .   $
��Auto �6<   �� 5q   .   $��20 �6<   .+�5s   *   F� $ 
NoneEffect��6/   $y�	Collapsed=�6C   $��5q�6Z   $��10��6e   $��10��6p   $
��Left=�6|   $	��Top=�6�   ����Ѐ�  z � z �� �@T� @KL �@T�  �m  �m @T� @KL @T� ��2) @T� ��j @KL �@B ��* ��* @KL � �m @B @T� ��* @T� @KL 	8�� $��2��6=  F� 5t   *   $ 
MoveEffect��6/   $y�	Collapsed=�6C   $��5q�6Z   $��10��6e   $��10��6p   $
��Left=�6|   $	��Top=�6�   4����    @KL � z @KL � 	= @B � z @KL � 	= @T� 	8�� $��2��6�   F� 5u   *   $ 
CopyEffect��6/   $y�	Collapsed=�6C   $��5q�6Z   $��10��6e   $��10��6p   $
��Left=�6|   $	��Top=�6�   +����@KL @B �@KL @T� �@B @KL �@T� @KL 	8��	 $��2��6�   F� 5v   *   $ 
LinkEffect��6/   $y�	Collapsed=�6C   $��5 7 4 7q�6Z   $��6��6k   $��11��6v   $
��Left=�6�   $	��Top=�6�   ����� z  � ��n�  � �7�  j �7� ��- Ӡ7� �#C �n� `�S  z `�S �@�d `�S `�S �#C `�S ��- �`�S  j @�d  �  z  � ���-  � Ӏ#C  � `�S  j `�S ��- �`�S �#C �#C `�S ��- `�S � j `�S  � �#C  � ��- � �  j  j  � ��-  � 	8��
 $��1��6�  F� 5w   *   $ ScrollEffect��6/   $y�	Collapsed=�6E   $	��5 4q�6\   $��10��6i   $��12��6t   $
��Left=�6�   $	��Top=�6�   =����    @KL �@KL     р�� @KL �    ��j �@KL  � р�� ��j 	8�� 6�   �� 5x   *   $ 
Horizontal=�65   $��15, 0, 0, 0q�6N   $��0��6c   $��Center=�6p   .+�5y   .   �� $
��Id: ��68   �� 5z   .   $
��Bold"�5{      ��5z   8   �� *
Content.Id+ �� *TemplatedParent+5{      5|   +   �� 5}   *   
�������$��1��6D   $��1��6O   �� 5~   *   $ 
Horizontal=�65   $��15, 0, 0, 0q�6N   $��2��6c   $��Center=�6p   .+�5   .   �� $��Descripcion: ��68   �� 5�   .   $
��Bold"�5�      ��5�   8   �� *Content.Descripcion+ �� *TemplatedParent+5�      5�   +   5�   '   5�   #   5�      5�      5�      5�      �� 5�      $ White��6?   �� 5�      $ #33BCBA��6A   �� 5�      "  67   .R�5�      � $ RootElement��6    5�        5�      CommonStates��.	 5�        SubMenuOpen��.
 5�   "   �� .��5�   &   T� $ Content��6D   $ (TextBlock.Foreground)�6d   ..�5�   *   i� $ 0:0:0��6A   8   6Q   5�   '   T� 5�   &   $ PART_InputGestureText��6D   $ (TextBlock.Foreground)�6r   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   T� 5�   &   $ ExpandIconRight��6D   $
 Fill�6l   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   T� 5�   &   $ HighlightVisual��6D   $
 Fill�6l   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   T� 5�   &   $
 Tick��6D   $
 Fill�6a   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   W� 5�   &   $ 1X�66   $ 0:0:0D�6=   $ HighlightVisual��6N   $ Opacity�6v   5�   #   5�        5�      Highlighted��.
 5�   "   �� .��5�   &   T� $ Content��6D   $ (TextBlock.Foreground)�6d   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   T� 5�   &   $ PART_InputGestureText��6D   $ (TextBlock.Foreground)�6r   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   T� 5�   &   $ ExpandIconRight��6D   $
 Fill�6l   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   T� 5�   &   $
 Tick��6D   $
 Fill�6a   ..�5�   *   i� $ 0:0:0��6A   8  6Q   5�   '   W� 5�   &   $ 1X�66   $ 0:0:0D�6=   $ HighlightVisual��6N   $ Opacity�6v   5�   #   5�        5�      Disabled��.
 5�   "   �� .��5�   &   W� $ Opacity�66   $ ContentGrid��6Z   $
 0.27X�6~   $ 0:0:0D�6�   5�   #   5�        5�      
Normal��6*   5�        5�      FocusStates��.	 5�        	Unfocused��6*     5�      Focused��6*   5�        5�      CheckedStates��.	 5�        Checked��.
 5�   "   �� .��5�   &   T� $
 Tick��6D   $ 
Visibility�6a   $ 0D�6�   ..�5�   *   i� $ 0��6A    5�   .    5�   2   Visible=�6F   5�   +   5�   '   T� 5�   &   $
 Icon��6D   $ 
Visibility�6a   $ 0D�6�   ..�5�   *   i� $ 0��6A    5�   .    5�   2   	Collapsed=�6H   5�   +   5�   '   5�   #   5�        5�      	Unchecked��6*     5�      HideIcon��.
 5�   "   �� .��5�   &   T� $
 Icon��6D   $ 
Visibility�6a   $ 0D�6�   ..�5�   *   i� $ 0��6A    5�   .    5�   2   	Collapsed=�6H   5�   +   5�   '   5�   #   5�      5�        5�      
RoleStates��.	 5�        TopLevelItem��.
 5�   "   �� .��5�   &   T� $ 0:0:0D�6D   $ ContentGrid��6U   $ Margin�6y   ..�5�   *   i� $ 0:0:0��6A    5�   .   u�5�   2   1q�6?   5�   +   5�   '   W� 5�   &   $ 0X�66   $ 0:0:0D�6=   $ 
PART_Popup��6N   $ HorizontalOffset�6q   5�   #   5�        5�      TopLevelHeader��.
 5�   "   �� .��5�   &   T� $ 0:0:0D�6D   $ ContentGrid��6U   $ Margin�6y   ..�5�   *   i� $ 0:0:0��6A    5�   .   u�5�   2   1q�6?   5�   +   5�   '   W� 5�   &   $ 0X�66   $ 0:0:0D�6=   $ 
PART_Popup��6N   $ HorizontalOffset�6q   5�   #   5�        5�      SubmenuItem��6*     5�      SubmenuHeader��.
 5�   "   �� .��5�   &   T� $ 
ExpandIcon��6D   $ 
Visibility�6g   $ 0D�6�   ..�5�   *   i� $ 0��6A    5   .    5  2   Visible=�6F   5  +   5  '   5  #   5       5     	Separator��6*   5       5	     OrientationStates��.	 5
       
Horizontal��6*     5     Vertical��6*   5       5     ChildrenStates��.	 5       HasChildren��6*     5     
NoChildren��6*   5       5     HeaderStates��.	 5       VisibleHeader��6*     5     EmptyHeader��.
 5  "   �� .��5  &   T� $ 0:0:0D�6D   $ IconHost��6U   $ Margin�6v   ..�5  *   i� $ 0:0:0��6A    5  .   u�5  2   0q�6?   5  +   5  '   T� 5  &   $ Content��6D   $ 
Visibility�6d   $ 0D�6�   ..�5  *   i� $ 0��6A    5  .    5  2   	Collapsed=�6H   5!  +   5"  '   5#  #   5$     5%       5&     InputGestureTextStates��.	 5'       EmptyInputGestureText��6*     5(     VisibleInputGestureText��.
 5)  "   �� .��5*  &   T� $ PART_InputGestureText��6D   $ 
Visibility�6r   $ 0D�6�   ..�5+  *   i� $ 0��6A    5,  .    5-  2   Visible=�6F   5/  +   50  '   51  #   52     53     .+�55     �� #��z��6   #��z��6G   #��z��6s   � 56     $ ContentGrid��6    57     �� 58     $
��Auto �6/   �� 59     $��* �6/   �� 5:     $
��Auto �6/   �� 5;     $
��Auto �6/   .+�5=     �� $ HighlightVisual��6$   $��4��6=   $ 0Q�6Q   8��	 6]   � 5?     $ IconHost��6   #��z  61   $��0 0 -2 0q�6[   .+�5@     F� $
 Tick��6#   $��2q�5A     $y�	Collapsed=�5B     $��LeftToRight=�5C     #��z��5D     $��16��5E     $��16��5F     =���� 	= `Vl Ѡ�V  �m �@�p �ڊ � �  �$ рj� �� Ѡco @�� 	5G     �� 5H     $
! Icon��6/   $��2q�6=   #��z" 6H   #��z# 6i   5I     �� 5J     $! Content��6+   $��1��5K     #��z��5L     #��z��5M     #��z��5N     ��. $��Header��5P       5Q     $$ PART_InputGestureText��6=   $��2��6\   $y�	Collapsed=�6l   $% 	IGTColumn��6�   $��40 2 3 2q�6�   #��z& 6�     5R     $��Right=�6=   $% ExpandIconColumn��6Y   $��3��6�   .��5S     � $ 
ExpandIcon��6#   $��0 0 2 0q�67   $��19��6H   $��16��6T   $y�	Collapsed=�6_   .+�5T  "   F� $ ExpandIconRight��6'   8��
 "����        �@KL �%& �    @KL 	$��5��6�   $��6��6�   5U     5V     5W     � 5X     $' 
PART_Popup��6   $( -1��60   $) -1��6F   #��z* 6Z   |�.  + . .��5Y     � #��z, 6   #��z- 6G   .+�5Z     � $ PopupContentElement��6#   .+�5[  "   �� $��1q�6)   8�� 8�� ._�5\  &   � .+�5]  *   �� $. PART_ScrollViewer��67   8�� / . .��5^  .   � .+�5_  2   �� 5`  /   5a  +   5b  '   5c  #   5d     5e     5f     5g     5h     �� 5j     "  6   8   .�5k     ��  � ��
 �����6/   �� 5l      � �� �#48B1B76/   �� 5m      � ��8  6,   �� 5n      � ��8  6-   �� 5o     ! �@ TopLevelHeaderTemplateKey8  6>   �� 5p      �@ TopLevelItemTemplateKey8  6<   �� 5q       �@ SubmenuHeaderTemplateKey8  6=   �� 5r      �@ SubmenuItemTemplateKey8  6;   �� 5s      �@ SeparatorTemplateKey8  69   �� 5t      �@��PanningMode$ VerticalFirst=�6=   5u     �� 5v     " 
 6   8   .�5w     ��  � ��
 �����6/   �� 5x      � �� �#48B1B76/   5y     �� 5{     "  6   .�5|     ��  �@ Width$ * 6*   �� 5}      �@ 
IsReadOnly . 6/   �� 5~      �@ TextWrapping$
 Wrap=�61   �� 5      �@ TextAlignment$ Center=�62   5�     �� 5�     " ��6   .�5�     ��  � ��$ Center=�68   �� 5�      �@��ContentStringFormat$ {0:dd/MM/yyyy}��68   5�     �� 5�     " ��6   .�5�     ��  � ��$ Right=�68   5�     �� 5�     " ��6   8   .�5�     ��  �@��ContentStringFormat$ N0��68   5�     �� 5�     " ��6   8   .�5�     ��  �@��ContentStringFormat$ N1��68   5�     �� 5�     " ��6   8   .�5�     ��  �@��ContentStringFormat$ N2��68   5�     �� 5�     " ��6   8   .�5�     ��  �@��ContentStringFormat$ N4��68   5�     �� 5�     " ��6   8   .�5�     ��  �@��ContentStringFormat$ N8��68   5�     �� 5�     "  6   .�5�     ��  � ��$ Right=�68   5�     �� 5�     "  6   .�5�     ��  �@ DataFormatString$ N0��65   5�     �� 5�     "  6   .�5�     ��  �@ DataFormatString$ N1��65   5�     �� 5�     "  6   .�5�     ��  �@ DataFormatString$ N2��65   5�     �� 5�     "  6   .�5�     ��  � ��$ Center=�68   5�     �� 5�     "  6   .�5�     ��  �@ DataFormatString$ d��65   5�     5�     5�     