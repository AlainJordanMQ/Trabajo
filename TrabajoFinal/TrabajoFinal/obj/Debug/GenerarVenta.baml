   M S B A M L   `   `   `  ����G  CTrabajoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TrabajoFinalTrabajoFinal  5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	       TrabajoFinal.GenerarVenta   5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TrabajoFinal     5   	   Uwinforms@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	     � Title$  GenerarVenta��5
   	   $	��300��6   $	��300��6+   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   .+�5      ��  �� TextAlignment$ Center=�6   $��Italic$�6/   $
��Bold"�6B   $��20(�6T   Nueva Venta6o   �� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� RFC:6"   �� 5      -   5         ��Name$ txtRFC��5   &   $	��113��6   68   �� 5      Tel:6"   �� 5      -   5        $ txtTel��5   &   $	��113��6   68   5      �� 5      $ 
Horizontal=�6   .+�5      �� 
Direccion:6(   �� 5      -   5        $ txtDireccion��5   &   $	��113��6   6>   �� 5      Email:6$   �� 5      -   5        $ txtEmail��5   %   $��70��6   $��24��67   6E   5      �� 5       $ 
Horizontal=�6   .+�5!      �� 	Empleado:6'   �� 5"      -   5         ��Name$ cmbMaterias��5"   '   $��82��6   6>   �� 5#      
Cliente:6&   �� 5$      -   5        $ txtNombreCliente��5$   &   $	��113��6   6B   5%      �� 5&      $ 
Horizontal=�6   $
��0,10q�62   .+�5'      %  Xceed.Wpf.Toolkit.IntegerUpDown  -   5          Name$ nudCantidad��5'   3   $
��10,0q�6%   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 1X�6H      Maximum$	 100X�6T   	   Value$	 1X�6b   �� 5(      -   5        $ cmbProducto��5(   '   $	��150��6   6>   �� 5)      -	   5        
 ��Name$
 
btnAgregar��5)   '   $
��10,0q�6   .��6T   	Agregar6]   5*      5+      7  1System.Windows.Forms.Integration.WindowsFormsHost  5,   
   $��1��6      Child. 5.      '  !System.Windows.Forms.DataGridView  -
   5        dgvProductos��   ColumnCount$ 4��5.   :      AllowUserToDeleteRows .     AllowUserToAddRows .  5/      50      �� 52   
   $��2��6   .+�53      �� -   5         ��Name$ txbTotal��53   .   $ Right=�6   Total de veta: $0.006V   �� 54      $ 
Horizontal=�6   $��Right=�62   .+�55      �� Cantidad proporcionada $66   �� 56      -   5        $ txtCantidad��56   %   $��80��6   6<   57      �� 58      -   5        $
 btnGenerarVenta��58      .��6L   Generar Venta6[   59      5:      5;      