   M S B A M L   `   `   `  ����U  QFarmacia.GUI.Administrador, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Farmacia.GUI.AdministradorFarmacia.GUI.Administrador  5   	   '    !Farmacia.GUI.Administrador.Ventas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Farmacia.GUI.Administrador     5   	     � Title$  Ventas��5   	   $��566.667��6   $	��646��6)   .��5	      �  � ColumnDefinitions 5
      �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	dtgGrupos��5      $��0��6    $��0��60   $��2��6=   �� 5      $��0��6   $��2��6    �� Orientation$ 
Horizontal=�6,   .+�5      �� .��6   	Agregar6   �� 5      .��6   Editar6   �� 5      .��6   
Eliminar6   5      �� 5      $��1��6   $��0��6   .+�5      �� .��6   	Guardar6   �� 5      $ 
Horizontal=�6   .+�5      �� $	��120��6   .��6   Fecha6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ pkrFechaNacimiento��5      $	��200��6   6;   5      �� 5      $ 
Horizontal=�6   .+�5       �� $	��120��6   .��6   
Empleado6"   �� 5!      -   5         ��Name$ cmbEmpleado��5!      $	��200��6   62   5"      �� 5#      $ 
Horizontal=�6   .+�5$      �� $	��120��6   .��6   	Cliente6!   �� 5%      -   5        $ 
cmbCliente��5%      $	��200��6   61   5&      �� 5'      $ 
Horizontal=�6   .+�5(      �� $	��120��6   .��6   	Productos6#   �� 5)      -   5        $ cmbproductos��5)      $	��200��6   63   5*      �� 5+      $ 
Horizontal=�6   .+�5,      �� $	��120��6   .��6   
Cantidad6"   �� 5-      -   5         ��Name$ txbCantidad��5-      $	��200��6   61   5.      5/        50      -   5        $ dtgCompañeros��50   *   $��1��6   $��1��6   6C   �� 51      $��1��6   $��2��6   $ 
Horizontal=�6,   .+�52      �� .��6   	Agregar6   �� 53      .��6   
Eliminar6   54      55      56      