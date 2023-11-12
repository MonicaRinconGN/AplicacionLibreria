using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * la clase AutorDAO se encarga de realizar operaciones relacionadas con la entidad author
 */

namespace AccesoDatos.Operaciones
{
    public class AutorDAO
    {
        // creamos un objeto de contexto de base de datos para interactuar con la base de datos
        public LibreriaContext contexto = new LibreriaContext();

        //método para insertar un nuevo autor
        public bool agregar(string name)
        {
            try
            {
                Author autor = new Author();
                autor.Name = name;

                contexto.Authors.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // método para seleccionar todos los autores de la base de datos
        public List<Author> obternerTodos()
        {
            var autores = contexto.Authors.ToList<Author>();
            return autores;
        }
    }
}
