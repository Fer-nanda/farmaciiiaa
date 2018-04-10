using Farmacia.COMMON.Entidades;
using Farmacia.COMMON.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacia.BIZ
{
	public class ManejadorProdutos : IManejadorProductos
	{
		IRepositorio<Productos> repositorio;
		public ManejadorProdutos(IRepositorio<Productos> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Productos> Listar => repositorio.Read;

		public bool Agregar(Productos entidad)
		{
			return repositorio.Create(entidad);
		}

		public Productos BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public bool Modificar(Productos entidad)
		{
			return repositorio.Update(entidad);
		}

		public List<Productos> ProductosDeCategoria(string categoria)
		{
			return Listar.Where(e => e.categoriaa == categoria).ToList();
		}
	}
}
