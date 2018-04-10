using Farmacia.COMMON.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Farmacia.COMMON.Intefaces
{
    public interface IManejadorCliente : IManejadorGenerico<Cliente>
	{
		List<Cliente> ClientePorEmail(string email);
	}
}
