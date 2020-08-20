using CadastroDeClientes.Data;
using CadastroDeClientes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroDeClientes.Services
{
    public class ClienteService
    {
        private static string ERRO_CLIENTE_NAO_ENCONTRADO = "Não foi possível executar deleção. Cliente {0} não encontrado!";

        private readonly CadastroDeClientesContext Context;

        public ClienteService(CadastroDeClientesContext Context)
        {
            this.Context = Context;
        }

        public async Task<IEnumerable<Cliente>> ObterClientes()
        {
            return await Context.Cliente.ToListAsync();
        }

        public async Task<Cliente> ObterClientePorId(int id)
        {
            return await Context.Cliente.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task SalvarCliente(Cliente cliente)
        {
            Context.Add(cliente);
            await Context.SaveChangesAsync();
        }

        public async Task EditarCliente(Cliente cliente)
        {
            Context.Entry(cliente).State = EntityState.Modified;
            Context.Update(cliente);
            await Context.SaveChangesAsync();
        }

        public async Task RemoverCliente(int id)
        {
            var cliente = await Context.Cliente.FirstOrDefaultAsync(m => m.Id == id);

            if(cliente != null)
            {
                Context.Remove(cliente);
                await Context.SaveChangesAsync();
            }
            else
            {
                throw new Exception(string.Format(ERRO_CLIENTE_NAO_ENCONTRADO,id));
            }
        }

        public bool VerificarSeClienteExiste(int id)
        {
            return Context.Cliente.Any(c => c.Id == id);
        }
    }
}
