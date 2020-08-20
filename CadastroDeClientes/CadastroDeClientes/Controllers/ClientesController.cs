using CadastroDeClientes.Business;
using CadastroDeClientes.Data;
using CadastroDeClientes.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CadastroDeClientes.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ClientesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private static string CLIENTE_NAO_ENCONTRADO = "Cliente não encontrado";
        private readonly ClienteBusiness ClienteBusiness;

        public ClientesController(CadastroDeClientesContext context)
        {
            ClienteBusiness = new ClienteBusiness(context);
        }

        //GET api/Clientes/
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await ClienteBusiness.ListarClientes();
        }

        //PUT api/Clientes/{id}
        [Microsoft.AspNetCore.Mvc.HttpPut("{id}")]
        public async Task<HttpStatusCodeResult> PutCliente(int id, Cliente cliente)
         {
            if (id != cliente.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                await ClienteBusiness.EditarCliente(id, cliente);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        //GET api/Clientes/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await ClienteBusiness.ObterCliente(id);

            if (cliente == null)
            {
                return BadRequest(CLIENTE_NAO_ENCONTRADO);
            }
            else
            {
                return cliente;
            }
        }

        //POST api/Clientes
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<HttpStatusCodeResult> PostCliente(Cliente cliente)
        {
            try
            {
                await ClienteBusiness.SalvarCliente(cliente);

            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,e.Message);
            }

            return new HttpStatusCodeResult(HttpStatusCode.Created);
        }

        //DELETE api/Clientes/{id}
        [Microsoft.AspNetCore.Mvc.HttpDelete("{id}")]
        public async Task<HttpStatusCodeResult> DeleteCliente(int id)
        {
            try
            {
                await ClienteBusiness.RemoverCliente(id);
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, e.Message);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}