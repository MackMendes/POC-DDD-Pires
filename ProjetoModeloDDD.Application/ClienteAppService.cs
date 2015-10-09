﻿using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Application
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            this._clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClienteEspeciais()
        {
            return _clienteService.ObterClienteEspeciais(_clienteService.GetAll());
        }
    }
}