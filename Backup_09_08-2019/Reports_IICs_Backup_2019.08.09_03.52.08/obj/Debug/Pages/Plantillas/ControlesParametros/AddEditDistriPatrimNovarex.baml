   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.1.3.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      fCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.MetroMahApps.Metro.Controls.Dialogs  5      H DReports_IICs, Version=1.1.94.0, Culture=neutral, PublicKeyToken=nullu?clr-namespace:Reports_IICs.Pages.Plantillas.ControlesParametros1Reports_IICs.Pages.Plantillas.ControlesParametros 5      R   LReports_IICs.Pages.Plantillas.ControlesParametros.AddEditDistriPatrimNovarex   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      WDialogsCclr-namespace:MahApps.Metro.Controls.Dialogs;assembly=MahApps.Metro     5      Qlocal?clr-namespace:Reports_IICs.Pages.Plantillas.ControlesParametros     5        � Title$5  /Añadir/Editar Distribución Patrimonio Novarex��5
      $	��450��5      $	��250��5      $��0q�5      (   "MahApps.Metro.Controls.MetroWindow   	GlowBrush
 �   � � ShowInTaskbar .     ShowIconOnTitleBar .  .��5      � -   5         �Name$
 grid��5       J� CommandBindings 5   
   )  #System.Windows.Input.CommandBinding  5      -   5           Command$	 New��5      6N    � ColumnDefinitions 5   
   �� 5      $
��125* �6   �� 5      $
��235* �6   �� 5      $	��12* �6   �� 5      $	��71* �6   .+�5   
   �� -   5         ��Name$ ButtonGuardar��5      $��2��6(   $��Guardar��65   $
��Left=�6H   $��
70,125,0,0q�6c   $	��Top=�6w   $��75��6�   $	��New��6�   $��1��6�   �� 5   
   -   5        $ ButtonCancelar��5      $��3��6)   $��Cancelar��66   $
��Left=�6I   $��150,125,0,0q�6d   $	��Top=�6y   $��75��6�   $��1��6�   �� 5   
   -   5        	 ��Name$	 labelDescripcion��5      $��Descripción��6*   $
��Left=�6@   $��26��6[   $	��Top=�6g   $��	14,25,0,0q�6   �� 5   
   -   5        
 ��Name$
 textBoxDescripcion��5      $��0��6.    �� 	MaxLength$ 50��6;   $
��Left=�6J    �� TextWrapping$
 Wrap=�5      $	��Top=�5    U   $	��256��6m   $��44.2,25,0,0q�6y   $��1��6�   $��3��6�   ��5   &   ��  �� UpdateSourceTrigger$ PropertyChanged=� �� Path$ Descripcion� �� ValidatesOnDataErrors .  �� NotifyOnValidationError . 5    �   �� 5"   
   -   5        $	 labelFormula��5"      $��Formula��6&   $
��Left=�68   $��38��6x   $	��Top=�6�   $��	14,72,0,0q�6�   �� 5#   
   -   5        $
 textBoxFormula��5#      $	 150��6*   $��1��6:   $
��Left=�6G    �� 
IsReadOnly . $
 Wrap=�5$      $	��Top=�5%   T   $	��256��6l   $��	44,69,0,0q�6x   $��3��6�   $��1��6�   ��5$   &   �� $ PropertyChanged=�$ Formula� .  . 5%   �   5'      5(      