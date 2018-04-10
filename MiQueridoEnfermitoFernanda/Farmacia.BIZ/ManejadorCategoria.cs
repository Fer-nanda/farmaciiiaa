using Farmacia.COMMON.Entidades;
using Farmacia.COMMON.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacia.BIZ
{
	public class ManejadorCategoria : IManejadorCategoria
	{
		IRepositorio<Categoria> repositorio;

		public ManejadorCategoria(IRepositorio<Categoria> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Categoria> Listar => repositorio.Read;
	

		public bool Agregar(Categoria entidad)
		{
			return repositorio.Create(entidad);
		}

		public Categoria BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public List<Categoria> categoria(string categoriaaa)
		{
			return Listar.Where(e => e.TipoCategoria == categoriaaa).ToList();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public bool Modificar(Categoria entidad)
		{
			return repositorio.Update(entidad);
		}
	}
}
