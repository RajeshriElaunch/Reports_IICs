   M S B A M L   `   `   `  ����H  DReports_IICs, Version=1.1.94.0, Culture=neutral, PublicKeyToken=null�Hclr-namespace:Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados:Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados  5      �Hclr-namespace:Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados:Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados  5      T    NReports_IICs.Pages.Previews.Evolución.Evolución_Mercados.EvolucionMercado_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      n jTelerik.Windows.Controls.Charting, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
   5      `localHclr-namespace:Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados    	 
   5      ]myHclr-namespace:Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados    	 
   5        � 	Resources  5      [  UReports_IICs.Pages.Previews.Evolución.Evolución_Mercados.EvolucionMercadosConverter   myConverterR   LReports_IICs.Pages.Previews.Evolución.Evolución_Mercados.EvolucionMercados  EvolucionMercados��%:   &	        &	        5   
   6+     5   
   6   5      .��5      �  � DataContext# [ 6    � RowDefinitions 5   
   �� 5      $	��90* �6   �� 5      $	��10* �6   .+�5   
   � $��
0,0,-130,0q�6   $��0��6#   .+�5      * 
 $Telerik.Windows.Controls.RadGridView  -   5        $��myGrid��5   "   $��0��60   ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .  $��10(�6�      IsFilteringAllowed .     ShowGroupPanel .     RowIndicatorVisibility$ 	Collapsed=�6�      ColumnWidth? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ * 6�      Columns 5      1 
 +Telerik.Windows.Controls.GridViewDataColumn  5      - 
 'Telerik.Windows.Controls.GridViewColumn	   	IsVisible	 .  6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase
   DataMemberBinding
 61   �� *Id+6R     5         Width$	 280 61      
IsSortable .     IsFilterable .     Header$ Descripción��6e      
IsReadOnly . 
 6z   �� *Descripcion+6�     5      $ 80 61    .   .     HeaderTextAlignment$ Right=�6�      TextAlignment$ Right=�6�      DataFormatString$ {0:N2}��6�   
 6d   �� *CotizaDivDesde+6�     5      $ 80 61    .   .  $ Right=�6�   $ Right=�6�   $ {0:N2}��6�   
 6d   �� *CotizaDivHasta+6�     5      $ 80 61    .   .  $
 VAR%��6d   $ Right=�6�   $ Right=�6�   $ {0:N2}��6�    . 
 6r   �� *VarCotizaDivisa+6�     5      $ 80 61    .   .  $ VAR% EUR��6d   $ Right=�6�   $ Right=�6�   $ {0:N2}��6�    . 
 6v   �� *VarCotizaEuros+6�   5!      5$      �� 5%   
   -   5        $��ErrorPrices��5%      $��1��6)   $y�	Collapsed=�66   .+�5&      � $��Center=�6    5'      �� 5(      $	��10* �6$   �� 5)      $	��90* �6$   .+�5,      �� $��0��6   $��12q�6)   $#��Diferencia Fechas Cotización��65    �� TextAlignment$ Center=�6Y   $
��Wrap=�6p     5.      -   5          Name$ myErrorGrid��5.   P   $��Center=�6&   $��1��6C   $	��100��6g   $	��360��6v    .  $��10(�6�      SelectionMode$ Single=�5/   &      SelectionUnit$ FullRow=�50   &      
IsReadOnly .    CanUserFreezeColumns .  $ 	Collapsed=�53   &    .  $ * 56   &    58        5:      $ 60 65    .  .   .  $
 Isin��6�   $ Right=�6�   $ Center=�6�      FooterTextAlignment$ Right=�6�   
 6z   �� *Isin+5<        5=      $ 99 65    .  .   .  $ Descripción��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�   
 6z   �� *DescripcionInstrumento+5?        5@      $ 65 65    .  .   .  $ Fecha Desde��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�   $ {0:dd/MM/yyyy}��6  
 6z   �� *FechaCotizacion+5B        5C      $ * 65    .  .   .  $ Fecha Hasta��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�   $ {0:dd/MM/yyyy}��6  
 6y   �� *FechaReport+5E      5H      5J      5K      5L      5M      