using Farmacia.COMMON.Entidades;
using Farmacia.COMMON.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacia.BIZ
{
	public class ManejadorClientes : IManejadorCliente
	{
		IRepositorio<Cliente> repositorio;
		public ManejadorClientes(IRepositorio<Cliente> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Cliente> Listar => repositorio.Read;

		public bool Agregar(Cliente entidad)
		{
			return repositorio.Create(entidad);
		}

		public Cliente BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public List<Cliente> ClientePorEmail(string email)
		{
			return Listar.Where(e => e.Email == email).ToList();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public bool Modificar(Cliente entidad)
		{
			return repositorio.Update(entidad);
		}
	}
}
