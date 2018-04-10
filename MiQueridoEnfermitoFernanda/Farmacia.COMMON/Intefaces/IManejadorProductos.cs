using Farmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Intefaces
{
    public interface IManejadorProductos : IManejadorGenerico<Productos>
	{
		List<Productos> ProductosDeCategoria(string categoria);
	}
}
