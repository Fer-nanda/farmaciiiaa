using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Entidades
{
    public class Cliente:Base
    {
		public string Nombre { get; set; }
		public string Direccion { get; set; }
		public string Rfc { get; set; }
		public string Telefono { get; set; }
		public string Email { get; set; }
		public string numCliente { get; set; }
	}
}
