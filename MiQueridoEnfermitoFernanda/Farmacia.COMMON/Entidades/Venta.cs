using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Entidades
{
    public class Venta:Base
    {
		public DateTime Fecha { get; set; }

		public empleado Solicitante { get; set; }

		public Cliente clien { get; set; }
		public List<Productos> productoss { get; set; }
		public string Cantidad { get; set; }
	}
}
