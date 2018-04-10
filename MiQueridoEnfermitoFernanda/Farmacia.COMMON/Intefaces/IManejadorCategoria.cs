using Farmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Intefaces
{
    public interface IManejadorCategoria : IManejadorGenerico<Categoria>
	{
		List<Categoria> categoria (string categoriaaa);
	}
}
