   M S B A M L   `   `   `  ����G  CTrabajoFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TrabajoFinalTrabajoFinal  5   	   !    TrabajoFinal.NuevaCategoria   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TrabajoFinal     5   	     � Title$  NuevaCategoria��5   	   $	��300��6    $	��300��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $��30(�6   $��Center=�6   $��0��6;   .��6H   Nueva Categoria6Y   � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $	��150��6   .��6$   Cantidad de Producto6:   �� 5      -   5         ��Name$ txbNombreCategoria��5      $	��200��66   6D   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��150��6   .��6$   Nombre del producto69   �� 5      -   5        $ txbNombreProducto��5      $	��200��65   6C   5      �� 5      $ 
Horizontal=�6   .+�5      �� $	��150��6   .��6$   Precio De Compra66   �� 5      -   5        $ txbPrecioCompra��5      $	��200��63   6A   5      �� 5      $ 
Horizontal=�6   .+�5       �� $	��150��6   .��6$   Precio De Venta65   �� 5!      -   5        $ txbPrecioVenta��5!      $	��200��62   6@   5"      5$      � 5%   
   $��2��6   .+�5&      �� -   5         ��Name$ btnNuevo��5&       $��70��6   .��6I   Nuevo6P   �� 5'      -   5        $ 
btnGuardar��5'       $��70��6   .��6M   	Guardar6V   �� 5(      -   5        $ 	btnEditar��5(       $��70��6   .��6K   Editar6S   �� 5)      -   5        $ btnCancelar��5)       $��70��6   .��6O   
Cancelar6Y   �� 5*      -	   5        $ btnEliminar��5*       $��70��6   .��6O   
Eliminar6Y   5+      &   System.Windows.Controls.DataGrid  5,   
   -
   5          Name$ dtgTabla��5,         
IsReadOnly . $��3��67   5.      5/      