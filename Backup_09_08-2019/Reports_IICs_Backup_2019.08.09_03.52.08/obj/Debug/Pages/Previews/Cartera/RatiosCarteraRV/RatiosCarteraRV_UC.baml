   M S B A M L   `   `   `  ����H  DReports_IICs, Version=1.1.94.0, Culture=neutral, PublicKeyToken=nullyAclr-namespace:Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV3Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV  5      yAclr-namespace:Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV3Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV  5      L    FReports_IICs.Pages.Previews.Cartera.RatiosCarteraRV.RatiosCarteraRV_UC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      n jTelerik.Windows.Controls.Charting, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
   5      YlocalAclr-namespace:Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV    	 
   5      VcbAclr-namespace:Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV    	 
   5        � Language$  es-ES�5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��90* �6   �� 5      $	��10* �6   .+�5   
   � $��
0,0,-130,0q�6   $��0��6#    � 	Resources 5   
   N  HReports_IICs.Pages.Previews.Cartera.RatiosCarteraRV.RatiosCarteraRV_Calc   ratiosCarteraRV_Calc��%   &	          5      6H   5      .+�5   
   * 
 $Telerik.Windows.Controls.RadGridView  -   5          Name$ myGrid��5      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   ShowGroupPanel .  &   IsLocalizationLanguageRespected .     AutoGenerateColumns .     ShowColumnFooters . $��8(�6�      GroupDescriptors 5      *  $Telerik.Windows.Data.GroupDescriptor  5      	   Member$	 Sector��6*   .  (Telerik.Windows.Data.GroupDescriptorBase
   SortDirection$
 	AscendingX�6:      ColumnGroups 5      2 
 ,Telerik.Windows.Controls.GridViewColumnGroup  5         Name$ VariacionValor��6.      Header$ Variación Valor��6D     5       $ VariacionBeneficiosBPA��6.   $ Beneficios BPA��6L     5!      $ RentDividendo��6.   $ Rent. Dividendo��6C     5"      $	 PER��6.   $	 PER��69      Columns 5$      1 
 +Telerik.Windows.Controls.GridViewDataColumn  5%      - 
 'Telerik.Windows.Controls.GridViewColumn   	IsVisible .  6	 
 0Telerik.Windows.Controls.GridViewBoundColumnBase 	  DataMemberBinding 6-   �� *Id+6N     5&         Width?
 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 160
 6-      
IsSortable .     IsFilterable .   	  Header$  ��6a      
IsReadOnly .  6k   �� *DescripcionInstrumento+6�     5'      $ 60
 6-    .   .  $ Precio��6`      HeaderTextAlignment$ Center=�6�      TextAlignment$ Right=�6�    .  6p   �� *Precio+6�     5(      $ 75
 6g   $ Right=�6r    6-   �� *CapitalizacionBursatilEuros+ 5)      �� 5*      $%��Capitalización bursátil (€)��6$   $
��Wrap=�6G   5,        5-      $ 50
 6-    .   .  $ 	% Cartera��6`   $ Right=�6�   $ Center=�6�      FooterTextAlignment$ Right=�6�    	  DataFormatString$ {0:N2}��6�    6s   �� *PorcentajeCartera+   AggregateFunctions 5.      &   Telerik.Windows.Data.SumFunction  5/      ,  &Telerik.Windows.Data.AggregateFunction   Caption$ % Cartera: ��6.      ResultFormatString$ {0:N1}��6D   51        52      $ 50
 6-    .   .  $ % Sector��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�   $ {0:N2}��6�    6`   �� *PorcentajeSector+ 53        54      $  ��6.   56        57      $ 40
 6-    .   .     ColumnGroupName$ VariacionValor��6`   $ Right=�6�   $ Center=�6�    .  6�   �� *ValorAñoInforme+ 58      �� 59      .+�5:      �� -   5         ��Name$ labelValorAño��5:   $   
�������$��Center=�6N   5;      5=        5>      $ 40
 6-    .   .  $ VariacionValor��6`   $
 Adq.��6�   $ Right=�6�   $ Center=�6�    .  6�   �� *ValorAdquisicion+6�     5?      $ 40
 6-    .   .  $ VariacionBeneficiosBPA��6`   $ Right=�6�   $ Center=�6�    .  6�   �� *	BpaAño+ 5@      �� 5A      .+�5B      �� -   5        $ labelBpaAño��5B   $   
�������$��Center=�6L   5C      5E        5F      $ 40
 6-    .   .  $ VariacionBeneficiosBPA��6`   $ Right=�6�   $ Center=�6�    .  6�   �� *BpaPrevision+ 5G      �� 5H      .+�5I      �� -   5        $ labelBpaPrevision��5I   $   
�������$��Center=�6R   5J      5L        5M      $ 40
 6-    .   .  $ RentDividendo��6`   $ Right=�6�   $ Center=�6�    .  6�   �� *RentabilidadDividendoAño+ 5N      �� 5O      .+�5P      �� -   5        $$ labelRentabilidadDividendoAño��5P   $   
�������$��Center=�6^   5Q      5S        5T      $ 40
 6-    .   .  $ RentDividendo��6`   $ Right=�6�   $ Center=�6�    .  6�   �� * RentabilidadDividendoPrevision+ 5U      �� 5V      .+�5W      �� -   5        $) #labelRentabilidadDividendoPrevision��5W   $   
�������$��Center=�6d   5X      5Z        5[      $ 40
 6-    .   .  $	 PER��6`   $ Right=�6�   $ Center=�6�    .  6v   �� *	PerAño+ 5\      �� 5]      .+�5^      �� -   5        $ labelPerAño��5^   $   
�������$��Center=�6L   5_      5a        5b      $ 40
 6-    .   .  $	 PER��6`   $ Right=�6�   $ Center=�6�    .  6v   �� *PerPrevision+ 5c      �� 5d      .+�5e      �� -   5        $ labelPerPrevision��5e   $   
�������$��Center=�6R   5f      5h        5i      $ 60
 6-    .   .  $ Right=�6�   $ Center=�6�    .  6a   �� *	DeudaNeta+ 5j      �� 5k      $"��Deuda Neta / Capitalización��6$   $
��Wrap=�6G   5m        5n      $ 40
 6-    .   .  $ Right=�6�   $ Center=�6�    .  6a   �� *
PrecioVc+ 5o      �� 5p      $��Precio / VC��6$   $
��Wrap=�67   5r        5s      $ 60
 6-    .   .  $ Right=�6�   $ Center=�6�    .  6a   �� *ValorFundamental+ 5t      �� 5u      $��Valor Fundamental��6$   $
��Wrap=�6=   5w        5x      $ 50
 6-    .   .  $ Center=�6�   $ Center=�6�    .  6a   �� *GvcBloomberg+ 5y      �� 5z      $��GVC / Bloomberg��6$   $
��Wrap=�6;   5|        5}      $ 60
 6-    .   .  $ Right=�6�   $ Center=�6�    .  6a   �� *DescuentoFundamental+ 5~      �� 5      $��Descuento Fundamental��6$   $
��Wrap=�6A   5�      5�      5�      �� 5�   
   -	   5        $��ErrorPrices��5�      $��1��6)   $y�	Collapsed=�66   .+�5�      �  5�      �� 5�      $	��10* �6$   �� 5�      $	��90* �6$   .+�5�      �� $��0��6   $��12q�6)   $#��Diferencia Fechas Cotización��65    �� TextAlignment$ Center=�6Y   $
��Wrap=�6p     5�      -
   5        $ myErrorGrid��5�   3   $��1��6&   $	��100��6J   $	��320��6Y    .  $��8(�6�       SelectionMode$  Single=�5�   &   !   SelectionUnit$! FullRow=�5�   &   "   
IsReadOnly" . #   CanUserFreezeColumns# .  $   RowIndicatorVisibility$$ 	Collapsed=�5�   &    .  %   ColumnWidth$% *
 5�   &    5�        5�      $ 60
 65    .  .   .  $
 Isin��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�    6z   �� *Isin+5�        5�      $ 99
 65    .  .   .  $ Descripción��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�    6z   �� *DescripcionInstrumento+5�        5�      $ 65
 65    .  .   .  $ Fecha Cotizacion��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�   $ {0:d}��6   6z   �� *FechaCotizacion+5�        5�      $ *
 65    .  .   .  $ Fecha Report��6�   $ Right=�6�   $ Center=�6�   $ Right=�6�   $ {0:d}��6   6y   �� *FechaReport+5�      5�      5�      5�      5�      5�      