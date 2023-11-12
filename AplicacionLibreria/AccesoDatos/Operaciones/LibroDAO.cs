using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * la clase LibroDAO se encarga de realizar operaciones relacionadas con la entidad book
 */

namespace AccesoDatos.Operaciones
{
    public class LibroDAO
    {
        // creamos un objeto de contexto de base de datos para interactuar con la base de datos
        public LibreriaContext contexto = new LibreriaContext();

        //método para insertar un nuevo libro
        public bool agregar(int id_author, string title, int chapters, int pages, double price)
        {
            try
            {
                Book libro = new Book();
                libro.IdAuthor = id_author;
                libro.Title = title;
                libro.Chapters = chapters;
                libro.Pages = pages;
                libro.Price = price;

                contexto.Books.Add(libro);
                contexto.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        // método para seleccionar todos los libros de la base de datos
        public List<Book> obtenerTodos()
        {
            var libros = contexto.Books.ToList<Book>();
            return libros;
        }


        // método para seleccionar un libro específico en base a su id
        public Book consultar(int id)
        {
            var libro = contexto.Books.Where(b => b.Id == id).FirstOrDefault();
            return libro;
        }


        //método para mostrar los datos de los libros (incluyendo el autor)
        public List<BookAuthor> obtenerLibroA()
        {
            var query = from libro in contexto.Books
                        join autor in contexto.Authors on libro.IdAuthor
                        equals autor.Id
                        select new BookAuthor
                        {
                            title = libro.Title,
                            nameAuthor = autor.Name,
                            chapters = libro.Chapters,
                            pages = libro.Pages,
                            price = libro.Price
                        };
            return query.ToList();
        }
    }
}
