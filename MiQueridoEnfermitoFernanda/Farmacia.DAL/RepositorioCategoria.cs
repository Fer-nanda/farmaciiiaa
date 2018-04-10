using Farmacia.COMMON.Entidades;
using Farmacia.COMMON.Intefaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Farmacia.DAL
{
	public class RepositorioCategoria : IRepositorio<Categoria>
	{
		private string DBName = "Farmacia.db";
		private string TableName = "Categoria";
		public List<Categoria> Read
		{
			get
			{
				List<Categoria> datos = new List<Categoria>();
				using (var db = new LiteDatabase(DBName))
				{
					datos = db.GetCollection<Categoria>(TableName).FindAll().ToList();
				}
				return datos;
			}
		}

		public bool Create(Categoria entidad)
		{
			entidad.Id = Guid.NewGuid().ToString();
			try
			{
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Categoria>(TableName);
					coleccion.Insert(entidad);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Delete(string id)
		{
			try
			{
				int r;
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Categoria>(TableName);
					r = coleccion.Delete(e => e.Id == id);
				}
				return r > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Update(Categoria entidadModificada)
		{
			try
			{
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Categoria>(TableName);
					coleccion.Update(entidadModificada);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
