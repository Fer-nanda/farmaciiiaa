using Farmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Intefaces
{
    public interface IManejadorVenta : IManejadorGenerico<Venta>
	{
		List<Venta> VentaPorLiquidar();
		List<Venta> VentaEnIntervalo(DateTime realizada);
	}
}
