using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Entidades
{
    public class Productos:Base
    {
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public string precioCompra { get; set; }
		public string precioVenta { get; set; }
		public string Presentacion { get; set; }
		public string cantidad { get; set; }
		public string categoriaa { get; set; }
	}
}
