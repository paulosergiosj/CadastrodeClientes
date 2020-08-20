using CadastroDeClientes.Data;
using CadastroDeClientes.Models;
using CadastroDeClientes.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroDeClientes.Business
{
    public class ClienteBusiness
    {
        private static string CLIENTE_NAO_ENCONTRADO = "Cliente não encontrado na base de dados";
        private static string CAMPO_NOME_OBRIGATORIO = "Campo Nome é obrigatório.";
        private static string CAMPO_DATA_OBRIGATORIO = "Campo Data de Nascimento é obrigatório.";
        private static string CAMPO_SEXO_OBRIGATORIO = "Campo Sexo é obrigatório.";

        private readonly ClienteService ClienteService;

        public ClienteBusiness(ClienteService ClienteService)
        {
            this.ClienteService = ClienteService;
        }

        public ClienteBusiness(CadastroDeClientesContext Context)
        {
            ClienteService = new ClienteService(Context);
        }

        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            return await ClienteService.ObterClientes();
        }

        public async Task<Cliente> ObterCliente(int id)
        {
            return await ClienteService.ObterClientePorId(id);
        }

        public async Task EditarCliente(int id, Cliente cliente)
        {
            try
            {
                if (ValidarCliente(cliente))
                    await ClienteService.EditarCliente(cliente);
            }
            catch (Exception e)
            {
                if (!ClienteService.VerificarSeClienteExiste(id))
                {
                    throw new Exception(CLIENTE_NAO_ENCONTRADO);
                }
                else
                {
                    throw e;
                }
            }
        }

        public async Task SalvarCliente(Cliente cliente)
        {
            if (ValidarCliente(cliente))
                await ClienteService.SalvarCliente(cliente);
        }

        public async Task RemoverCliente(int id)
        {
            await ClienteService.RemoverCliente(id);
        }

        private bool ValidarCliente(Cliente cliente)
        {
            var erros = string.Empty;

            if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrWhiteSpace(cliente.Nome))
                erros = string.Format(CAMPO_NOME_OBRIGATORIO, "\n");

            if (cliente.DataDeNascimento == null)
                erros += string.Format(CAMPO_DATA_OBRIGATORIO, "\n");

            if (string.IsNullOrEmpty(cliente.Sexo) || string.IsNullOrWhiteSpace(cliente.Sexo))
                erros += CAMPO_SEXO_OBRIGATORIO;

            if (!string.IsNullOrEmpty(erros))
                throw new Exception(erros);

            return true;
        }
    }
}
