   M S B A M L   `   `   `  ����H  DReports_IICs, Version=1.1.94.0, Culture=neutral, PublicKeyToken=nulls>clr-namespace:Reports_IICs.Pages.Previews.Changes.UserControls0Reports_IICs.Pages.Previews.Changes.UserControls  5      H    BReports_IICs.Pages.Previews.Changes.UserControls.RentaVariable_CHN   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      n jTelerik.Windows.Controls.Charting, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Chart, Version=2019.2.618.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7p	 lTelerik.Windows.Controls.Navigation, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n
 jTelerik.Windows.Controls.GridView, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2015.3.930.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Ktelerik1http://schemas.telerik.com/2008/xaml/presentation    	 
   5      Pmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 
   5      Fd2http://schemas.microsoft.com/expression/blend/2008    	 
   5      Vlocal>clr-namespace:Reports_IICs.Pages.Previews.Changes.UserControls    	 
   5      .��5
      � .+�5   
   * 
 $Telerik.Windows.Controls.RadGridView  -   5           Name$  RadGridView1��5      ; 
 5Telerik.Windows.Controls.GridView.GridViewDataControl   	RowHeight$ 20Q�5   	   8 
 2Telerik.Windows.Controls.GridView.BaseItemsControl   GroupRenderMode$
 Flat=�5         SelectionMode$ Extended=�5   	      RowIndicatorVisibility$ 	Collapsed=�5   	      CanUserFreezeColumns .     AutoGenerateColumns .     AutoExpandGroups .    ShowGroupPanel .  	   CanUserDeleteRows	 . $��Visible=�5   7   
   Columns
 5      3 
 -Telerik.Windows.Controls.GridViewSelectColumn  5      1 
 +Telerik.Windows.Controls.GridViewDataColumn  5      - 
 'Telerik.Windows.Controls.GridViewColumn   Width? 
 9Telerik.Windows.Controls.GridView.GridViewLengthConverter$	 120 6-   6 
 0Telerik.Windows.Controls.GridViewBoundColumnBase   Header$ Fecha Informe��6d      GridViewDataColumnDate#��[  6{     GridViewCellDate   	CellStyle# [ 6�      DataMemberBinding 69   �� *FechaInforme+6�     5         
IsSortable .     IsFilterable .  $ Descripción��6U      HeaderTextAlignment$
 Left=�6�      TextAlignment$
 Left=�6�      
IsReadOnly .  6j   �� *Descripcion+6�     5      $	 100 6-   $ Grupo Nuevo��6b     GridViewDataColumnNumericN0#��[ 6w     GridViewCellNumeric# [ 6�    69   �� *
GrupoNuevo+6�     5      $	 100 6-   $ Grupo��6]   #��[ 6l   # [ 6�    69   �� *Grupo+6�     5      $	 100 6-   $ Títulos��6e   #��[ 6v   # [ 6�    69   �� *NumeroTitulos+6�     5      $	 100 6-   $ 	PrecioIni��6a     GridViewDataColumnNumericN2#��[ 6t   # [ 6�    69   �� *	PrecioIni+6�     5       $	 100 6-   $ TipoCambioIni��6e   #��[ 6|   # [ 6�    69   �� *TipoCambioIni+6�     5!      $	 100 6-   $ 	PrecioFin��6a   #��[ 6u   # [ 6�    69   �� *	PrecioFin+6�     5"      $	 100 6-   $ TipoCambioFin��6e   #��[ 6}   # [ 6�    69   �� *TipoCambioFin+6�     5#      $	 100 6-   $ PrecioAjustado��6f   #��[ 6   # [ 6�    69   �� *PrecioAjustado+6�   5%      5&      5'      