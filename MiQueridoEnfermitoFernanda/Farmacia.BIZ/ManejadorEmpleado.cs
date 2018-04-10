using Farmacia.COMMON.Entidades;
using Farmacia.COMMON.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacia.BIZ
{
	public class ManejadorEmpleado : IManejadorEmpleados
	{
		IRepositorio<empleado> repositorio;
		public ManejadorEmpleado(IRepositorio<empleado> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<empleado> Listar => repositorio.Read;

		public bool Agregar(empleado entidad)
		{
			return repositorio.Create(entidad);
		}

		public empleado BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public List<empleado> EmpleadosPorPuesto(string puesto)
		{
			return Listar.Where(e => e.puesto == puesto).ToList();
		}

		public bool Modificar(empleado entidad)
		{
			return repositorio.Update(entidad);
		}
	}
}
