   M S B A M L   `   `   `  ����H  DReports_IICs, Version=1.1.94.0, Culture=neutral, PublicKeyToken=null�\clr-namespace:Reports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIONReports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIO  5      [2clr-namespace:Reports_IICs.ViewModels.Instrumentos$Reports_IICs.ViewModels.Instrumentos  5      W0clr-namespace:Reports_IICs.ViewModels.Plantillas"Reports_IICs.ViewModels.Plantillas  5	      �    }Reports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIO.RF_ComprasyVentasRealizadasDuranteEjercicio_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      n jTelerik.Windows.Controls.Charting, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
   5      tlocal\clr-namespace:Reports_IICs.Pages.Previews.RFCOMPRAS_Y_VENTAS_REALIZADAS_DURANTE_EL_EJERCICIO    	 
   5      Gmy2clr-namespace:Reports_IICs.ViewModels.Instrumentos    	 
   5      Fmyp0clr-namespace:Reports_IICs.ViewModels.Plantillas    	 
   5	        � Language$  es-ES�5       � 	Resources 5      :   4Reports_IICs.ViewModels.Instrumentos.VM_Instrumentos   VM_Instrumentos:   4Reports_IICs.ViewModels.Plantillas.PlantillasPage_VM  PlantillasPage_VM��%:   &	        &	        5   
   6     5   
   6    5      .��5      �  � DataContext# [  6   .+�5   
   � $��
0,0,-130,0q�6   $��0��6#   .+�5      * 
 $Telerik.Windows.Controls.RadGridView  -   5          Name$ myGrid��5   "   $	��200��62   ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   ShowGroupPanel .     RowIndicatorVisibility$ 	Collapsed=�6X   &   IsLocalizationLanguageRespected .     AutoGenerateColumns .  $��10(�6�      ColumnWidth? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 60  	   SelectionMode$	 Single=�5   "   
   SelectionUnit$
 FullRow=�5   "      Columns 5      5 
 /Telerik.Windows.Controls.GridViewComboBoxColumn  5      -   5         �Name$ 	DeleteRow��5   A   - 
 'Telerik.Windows.Controls.GridViewColumn   Width$	 120 65   6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Acciones��6S      
UniqueName$ 	DeleteRow��6e      SelectedValueMemberPath$
 Name��5   1      DisplayMemberPath$
 Name��5   1      DataMemberBinding 5   |   �� *Name+   ItemsSource 5   1   �� *ActionsOnlyDelete+ �� Source# [    EditorStyle 5      �� 5       �� 
TargetType*	  $Telerik.Windows.Controls.RadComboBox" 	 6$   .�5   "   ��  �� Property �@	 OpenDropDownOnFocus �� Value . 6H   �� 5   "    �@	 	EmptyText$ -Seleccionar-��6>   5          CellTemplate 5#      �� 5%      .R�5&   "   � .+�5'   &   �� $��-Seleccionar-��61    �� TextAlignment$ Center=�6G   $��Center=�6^   6}   5(   #   5)      5-      1
 
 +Telerik.Windows.Controls.GridViewDataColumn
  5.         	IsVisible .   63   �� *Id+6T   
  5/      $ 60 61      
IsSortable .     IsFilterable .  $ Oper.��6d      HeaderTextAlignment$ Center=�6�      TextAlignment$
 Left=�6�       DataFormatString$  {0:dd/MM/yyyy}��6�   !   
IsReadOnly! .  6s   �� *Fecha+6�   
  50      $ 80 61    .   .  $ T.Mov��6d   $ Center=�6�   $
 Left=�6�   ! .  6s   �� *TipoMovimiento+6�   
  51      $	 190 61    .   .  $ Nombre valor��6e   $ Center=�6�   $
 Left=�6�   ! .  6{   �� *DescripcionValor+6�   
  52      $ 60 61    .   .  $ Cant.��6d   $ Center=�6�   $ Right=�6�   $  {0:N0}��6�    6s   �� *
Cantidad+6�   8 
 2Telerik.Windows.Controls.GridViewMaskedInputColumn  53      -   5        "  Name$" Precio��53   9   $ Precio��6I   $ 60 6Y   $ Right=�6d   $ Center=�6z   #   MaskType$# NumericX�54      $   {0:N2}��6[    61   �� $ �� Path$$ Precio� 56      �� 58      4  .Telerik.Windows.Controls.RadMaskedNumericInput"  6$   .�5:   "   �� 1  +Telerik.Windows.Controls.RadMaskedInputBase �@ SelectionOnFocus$ 	SelectAll=�6E   �� 5<   "    �@ FormatString$ N2��6A   �� 5>   "    �@ SpinMode$
 None=�6=   5@      5D      5F      5G      5H      5I      