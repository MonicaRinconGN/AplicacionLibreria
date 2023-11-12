using AccesoDatos.Operaciones;
using AccesoDatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/*
 * la clase LibroController maneja las solicitudes HTTP relacionadas 
 * con la entidad book
 */

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        // creamos una instancia de LibroDAO para manejar las operaciones relacionadas con la entidad book en la base de datos
        private LibroDAO libroDAO = new LibroDAO();

        /**
         * EndPoint para insertar un nuevo libro
         */
        [HttpPost("libro")]
        public bool insertarLibro([FromBody] Book libro)
        {
            return libroDAO.agregar(libro.IdAuthor, libro.Title, libro.Chapters, libro.Pages, libro.Price);
        }


        /**
         * EndPoint para obtener la lista de todos los libros
         */
        [HttpGet("libros")]
        public List<Book> obtenerLibros()
        {
            return libroDAO.obtenerTodos();
        }


        /**
         * EndPoint para obtener un libro específico por su id
         */
        [HttpGet("libro")]
        public Book obtenerLibro(int id)
        {
            return libroDAO.consultar(id);
        }


        /**
         * EndPoint para obtener los datos de los libros (incluyendo el autor)
         */
        [HttpGet("libroAutor")]
        public List<BookAuthor> obtenerLibroAutor()
        {
            return libroDAO.obtenerLibroA();
        }
    }
}
