﻿using Farmacia.BIZ;
using Farmacia.COMMON.Entidades;
using Farmacia.COMMON.Intefaces;
using Farmacia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Farmacia.GUI.Administrador
{
	/// <summary>
	/// Lógica de interacción para Agregar.xaml
	/// </summary>
	public partial class Agregar : Window
	{
		enum accion
		{
			Nuevo,
			Editar
		}

		IManejadorCategoria manejadorCategorias;
		IManejadorCliente manejadorClientes;
		IManejadorProductos manejadorProducto;
		IManejadorEmpleados manejadorEmpleados;

		accion accionCategoria;
		accion accionClientes;
		accion accionProductos;
		accion accionEmpleados;
		public Agregar()
		{
			InitializeComponent();

			manejadorCategorias = new ManejadorCategoria(new RepositorioCategoria());
			manejadorClientes = new ManejadorClientes(new RepositorioClientes());
			manejadorProducto = new ManejadorProdutos(new RepositorioProductos());
			manejadorEmpleados = new ManejadorEmpleado(new RepositorioEmpleados());

			PonerBotonesCategoriaEnEdicion(false);
			LimpiarCamposDeCategoria();
			ActualizarTablaCategoria();

			PonerBotonesClientesEnEdicion(false);
			LimpiarCamposClientes();
			ActualizarTablaClientes();

			PonerBotonesProductosEnEdicion(false);
			LimpiarCamposDeProductos();
			ActualizarTablaProdutos();

			PonerBotonesDeEmpleadosEnEdicion(false);
			LimpiarCamposDeEmpleados();
			ActualizarTablaEmpleados();

		}

		private void ActualizarTablaEmpleados()
		{
			dtgEmpleado.ItemsSource = null;
			dtgEmpleado.ItemsSource = manejadorEmpleados.Listar;
		}

		private void LimpiarCamposDeEmpleados()
		{
			txbEmpleadoNombre.Clear();
			txbEmpleadoEmail.Clear();
			txbEmpleadoId.Text = "";
			txbEmpleadoDireccion.Clear();
			txbEmpleadoTelefono.Clear();
			txbEmpleadoMatricula.Clear();
			txbEmpleadoRFC.Clear();
			txbEmpleadoPuesto.Clear();
		}

		private void PonerBotonesDeEmpleadosEnEdicion(bool value)
		{
			btnEmpleadoCancelar.IsEnabled = value;
			btnEmpleadoEditar.IsEnabled = !value;
			btnEmpleadoEliminar.IsEnabled = !value;
			btnEmpleadoGuardar.IsEnabled = value;
			btnEmpleadoNuevo.IsEnabled = !value;
		}

		private void ActualizarTablaProdutos()
		{
			dtgProductos.ItemsSource = null;
			dtgProductos.ItemsSource = manejadorProducto.Listar;
		}

		private void LimpiarCamposDeProductos()
		{
			txbProductosNombre.Clear();
			txbProductosCategoria.Clear();
			txbProductoId.Text = "";
			txbProductosDescripcion.Clear();
			txbProductosPrecioCompra.Clear();
			txbProductosPrecioVenta.Clear();
			txbProductosCantidad.Clear();
			txbProductosPresentacion.Clear();

		}

		private void PonerBotonesProductosEnEdicion(bool value)
		{
			btnProductosCancelar.IsEnabled = value;
			btnProductosEditar.IsEnabled = !value;
			btnProductosEliminar.IsEnabled = !value;
			btnProductosGuardar.IsEnabled = value;
			btnProductosNuevo.IsEnabled = !value;
		}

		private void ActualizarTablaClientes()
		{
			dtgCliente.ItemsSource = null;
			dtgCliente.ItemsSource = manejadorClientes.Listar;
		}

		private void LimpiarCamposClientes()
		{
			txbClienteNombre.Clear();
			txbClienteNo.Clear();
			txbClienteId.Text = "";
			txbClienteTelefono.Clear();
			txbClienteDireccion.Clear();
			txbClienteEmail.Clear();
			txbClienterRfc.Clear();
		}

		private void PonerBotonesClientesEnEdicion(bool value)
		{
			btnClienteCancelar.IsEnabled = value;
			btnClienteEditar.IsEnabled = !value;
			btnClienteEliminar.IsEnabled = !value;
			btnClienteGuardar.IsEnabled = value;
			btnClienteNuevo.IsEnabled = !value;
		}

		private void ActualizarTablaCategoria()
		{
			dtgCategoria.ItemsSource = null;
			dtgCategoria.ItemsSource = manejadorCategorias.Listar;
		}

		private void LimpiarCamposDeCategoria()
		{
			txbCategoriaTipoDeCategoria.Clear();
			txbCategoriaId.Text = "";
		}

		private void PonerBotonesCategoriaEnEdicion(bool value)
		{
			btnCategoriaCancelar.IsEnabled = value;
			btnCategoriaEditar.IsEnabled = !value;
			btnCategoriaEliminar.IsEnabled = !value;
			btnCategoriaGuardar.IsEnabled = value;
			btnCategoriaNuevo.IsEnabled = !value;
		}

		private void btnCategoriaNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeCategoria();
			PonerBotonesCategoriaEnEdicion(true);
			accionCategoria = accion.Nuevo;
		}

		private void btnCategoriaEditar_Click(object sender, RoutedEventArgs e)
		{
			Categoria cat = dtgCategoria.SelectedItem as Categoria;
			if (cat != null)
			{
				txbCategoriaId.Text = cat.Id;
				txbCategoriaTipoDeCategoria.Text = cat.TipoCategoria;
				accionCategoria = accion.Editar;
				PonerBotonesCategoriaEnEdicion(true);
			}
		}

		private void btnCategoriaGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionCategoria == accion.Nuevo)
			{
				Categoria cat = new Categoria()
				{
					TipoCategoria = txbCategoriaTipoDeCategoria.Text
				};
				if (manejadorCategorias.Agregar(cat))
				{
					MessageBox.Show("Categoria agregada correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeCategoria();
					ActualizarTablaCategoria();
					PonerBotonesCategoriaEnEdicion(false);
				}
				else
				{
					MessageBox.Show("La Categoria no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Categoria cat = dtgCategoria.SelectedItem as Categoria;
				cat.TipoCategoria = txbCategoriaTipoDeCategoria.Text;
				if (manejadorCategorias.Modificar(cat))
				{
					MessageBox.Show("categoria modificada correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeCategoria();
					ActualizarTablaCategoria();
					PonerBotonesCategoriaEnEdicion(false);
				}
				else
				{
					MessageBox.Show("La Categoria no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

		}

		private void btnCategoriaCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeCategoria();
			PonerBotonesCategoriaEnEdicion(false);
		}

		private void btnCategoriaEliminar_Click(object sender, RoutedEventArgs e)
		{
			Categoria cat = dtgCategoria.SelectedItem as Categoria;
			if (cat != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar esta Categoria?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorCategorias.Eliminar(cat.Id))
					{
						MessageBox.Show("Categoria eliminada", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaCategoria();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar la Categoria", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}


		private void btnProductosNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeProductos();
			PonerBotonesProductosEnEdicion(true);
			accionProductos = accion.Nuevo;
		}

		private void btnProductosEditar_Click(object sender, RoutedEventArgs e)
		{
			Productos emp = dtgProductos.SelectedItem as Productos;
			if (emp != null)
			{
				txbProductoId.Text = emp.Id;
				txbProductosNombre.Text = emp.Nombre;
				txbProductosCategoria.Text = emp.categoriaa;
				txbProductosDescripcion.Text = emp.Descripcion;
				txbProductosPrecioCompra.Text = emp.precioCompra;
				txbProductosPrecioVenta.Text = emp.precioVenta;
				accionProductos = accion.Editar;
				PonerBotonesProductosEnEdicion(true);
			}
		}

		private void btnProductosGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionProductos == accion.Nuevo)
			{
				Productos emp = new Productos()
				{
					Nombre = txbProductosNombre.Text,
					categoriaa = txbProductosCategoria.Text,
					Presentacion = txbProductosPresentacion.Text,
					cantidad = txbProductosCantidad.Text,
					Descripcion = txbProductosDescripcion.Text,
					precioCompra = txbProductosPrecioCompra.Text,
					precioVenta = txbProductosPrecioVenta.Text
				};
				if (manejadorProducto.Agregar(emp))
				{
					MessageBox.Show("Producto agregado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeProductos();
					ActualizarTablaProdutos();
					PonerBotonesProductosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Producto no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Productos emp = dtgCliente.SelectedItem as Productos;
				emp.Nombre = txbProductosNombre.Text;
				emp.categoriaa = txbProductosCategoria.Text;
				emp.Descripcion = txbProductosDescripcion.Text;
				emp.precioCompra = txbProductosPrecioCompra.Text;
				emp.precioVenta = txbProductosPrecioVenta.Text;
				emp.Presentacion = txbProductosPresentacion.Text;
				emp.cantidad = txbProductosCantidad.Text;
				if (manejadorProducto.Modificar(emp))
				{
					MessageBox.Show("El Producto modificado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeProductos();
					ActualizarTablaProdutos();
					PonerBotonesProductosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Peoducto no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}



		}

		private void btnProductosCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeProductos();
			PonerBotonesProductosEnEdicion(false);
		}

		private void btnProductosEliminar_Click(object sender, RoutedEventArgs e)
		{
			Productos emp = dtgProductos.SelectedItem as Productos;
			if (emp != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este productos?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorProducto.Eliminar(emp.Id))
					{
						MessageBox.Show("Producto eliminado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaProdutos();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el producto", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}








		private void btnClienteNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposClientes();
			PonerBotonesClientesEnEdicion(true);
			accionClientes = accion.Nuevo;
		}

		private void btnClienteEditar_Click(object sender, RoutedEventArgs e)
		{
			Cliente emp = dtgCliente.SelectedItem as Cliente;
			if (emp != null)
			{
				txbClienteId.Text = emp.Id;
				txbClienteNo.Text = emp.numCliente;
				txbClienteNombre.Text = emp.Nombre;
				txbClienteDireccion.Text = emp.Direccion;
				txbClienterRfc.Text = emp.Rfc;
				txbClienteTelefono.Text = emp.Telefono;
				txbClienteEmail.Text = emp.Email;
				accionClientes = accion.Editar;
				PonerBotonesClientesEnEdicion(true);
			}
		}

		private void btnClienteGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionClientes == accion.Nuevo)
			{
				Cliente emp = new Cliente()
				{
					numCliente = txbClienteNo.Text,
					Nombre = txbClienteNombre.Text,
					
					Direccion = txbClienteDireccion.Text,
					Rfc = txbClienterRfc.Text,
					Telefono = txbClienteTelefono.Text,
					Email = txbClienteEmail.Text
				};
				if (manejadorClientes.Agregar(emp))
				{
					MessageBox.Show("Cliente agregado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposClientes();
					ActualizarTablaClientes();
					PonerBotonesClientesEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Cliente no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Cliente emp = dtgCliente.SelectedItem as Cliente;
				emp.numCliente = txbClienteNo.Text;
				emp.Nombre = txbClienteNombre.Text;
				
				emp.Direccion = txbClienteDireccion.Text;
				emp.Rfc = txbClienterRfc.Text;
				emp.Telefono = txbClienteTelefono.Text;
				emp.Email = txbClienteEmail.Text;

				if (manejadorClientes.Modificar(emp))
				{
					MessageBox.Show("El Cliente modificado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposClientes();
					ActualizarTablaCategoria();
					PonerBotonesClientesEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Cliente no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

		}

		private void btnClienteCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposClientes();
			PonerBotonesClientesEnEdicion(false);
		}

		private void btnClienteEliminar_Click(object sender, RoutedEventArgs e)
		{
			Cliente emp = dtgCliente.SelectedItem as Cliente;
			if (emp != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este Cliente?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorClientes.Eliminar(emp.Id))
					{
						MessageBox.Show("Cliente eliminado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaClientes();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el Cliente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}





		private void btnEmpleadoNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeEmpleados();
			PonerBotonesDeEmpleadosEnEdicion(true);
			accionEmpleados = accion.Nuevo;
		}

		private void btnEmpleadoEditar_Click(object sender, RoutedEventArgs e)
		{
			empleado emp = dtgEmpleado.SelectedItem as empleado;
			if (emp != null)
			{
				txbEmpleadoId.Text = emp.Id;
				txbEmpleadoNombre.Text = emp.Nombre;
				txbEmpleadoDireccion.Text = emp.Direccion;
				txbEmpleadoRFC.Text = emp.Telefono;
				txbEmpleadoTelefono.Text = emp.Telefono;
				txbEmpleadoEmail.Text = emp.Email;
				txbEmpleadoPuesto.Text = emp.puesto;
				txbEmpleadoMatricula.Text = emp.Matricula;
				accionEmpleados = accion.Editar;
				PonerBotonesDeEmpleadosEnEdicion(true);
			}
		}

		private void btnEmpleadoGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionEmpleados == accion.Nuevo)
			{
				empleado emp = new empleado()
				{
					Nombre = txbEmpleadoNombre.Text,
					
					Direccion = txbEmpleadoDireccion.Text,
					Rfc = txbEmpleadoRFC.Text,
					Telefono = txbEmpleadoTelefono.Text,
					Email = txbEmpleadoEmail.Text,
					puesto = txbEmpleadoPuesto.Text,
					Matricula = txbEmpleadoMatricula.Text
				};
				if (manejadorEmpleados.Agregar(emp))
				{
					MessageBox.Show("Empleado agregado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeEmpleados();
					ActualizarTablaEmpleados();
					PonerBotonesDeEmpleadosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Empleado no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				empleado emp = dtgCliente.SelectedItem as empleado;
				emp.Nombre = txbEmpleadoNombre.Text;
				
				emp.Direccion = txbEmpleadoDireccion.Text;
				emp.Rfc =txbEmpleadoRFC .Text;
				emp.Telefono = txbEmpleadoTelefono.Text;
				emp.Email = txbEmpleadoEmail.Text;
				emp.puesto = txbEmpleadoPuesto.Text;
				emp.Matricula = txbEmpleadoMatricula.Text;

				if (manejadorEmpleados.Modificar(emp))
				{
					MessageBox.Show("El Empleado modificado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeEmpleados();
					ActualizarTablaEmpleados();
					PonerBotonesDeEmpleadosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Empleado no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}


		}

		private void btnEmpleadoCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeEmpleados();
			PonerBotonesDeEmpleadosEnEdicion(false);
		}

		private void btnEmpleadoEliminar_Click(object sender, RoutedEventArgs e)
		{
			empleado emp = dtgEmpleado.SelectedItem as empleado;
			if (emp != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este Empleado?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorEmpleados.Eliminar(emp.Id))
					{
						MessageBox.Show("Empleado eliminado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaEmpleados();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el Empleado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}
	}
}
