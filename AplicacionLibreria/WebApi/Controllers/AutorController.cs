using AccesoDatos.Operaciones;
using AccesoDatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/*
 * la clase AutorController maneja las solicitudes HTTP relacionadas 
 * con la entidad author
 */
namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        // creamos una instancia de AutorDAO para manejar las operaciones relacionadas con la entidad author en la base de datos
        private AutorDAO autorDAO = new AutorDAO();

        /**
         * EndPoint para insertar un nuevo autor
         */
        [HttpPost("autor")]
        public bool insertarAutor([FromBody] Author autor)
        {
            return autorDAO.agregar(autor.Name);
        }


        /**
         * EndPoint para obtener la lista de todos los autores
         */
        [HttpGet("autores")]
        public List<Author> obtenerAutores()
        {
            return autorDAO.obternerTodos();
        }
    }
}
