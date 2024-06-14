using Microsoft.AspNetCore.Mvc;
using PrimeraApiRest.Models;

namespace PrimeraApiRest.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public dynamic listarCliente()
        {

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente {
                    nombre = "Fabian",
                    edad = "20"
                },
                new Cliente {
                    nombre = "Roler",
                    edad = "44"
                },
                new Cliente {
                    nombre = "Christopher",
                    edad = "23"
                }
            };

            return clientes;
        }

        [HttpGet]
        [Route("id")]
        public dynamic listarClientexId(string _name)
        {
            return new Cliente
            {
                nombre = "Fabian",
                edad = "20"
            };
        }

        [HttpPost]
        [Route("")]
        public dynamic guardarCliente(Cliente cliente)
        {
            return new
            {
                success = true,
                message = "Cliente registrado",
                result = cliente
            };
        }

        [HttpDelete]
        [Route("")]
        public dynamic eliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

            if(token != "fabian123.")
            {
                return Unauthorized(new
                {
                    success = false,
                    message = "Token no valido",
                    result = ""
                });
            }

            return new
            {
                success = true,
                message = "Cliente eliminado",
                result = cliente
            };
        }
    }
}
