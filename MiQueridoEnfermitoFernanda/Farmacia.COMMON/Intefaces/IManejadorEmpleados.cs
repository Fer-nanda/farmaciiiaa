using Farmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Intefaces
{
    public interface IManejadorEmpleados : IManejadorGenerico<empleado>
	{
		List<empleado> EmpleadosPorPuesto(string puesto);
	}
}
