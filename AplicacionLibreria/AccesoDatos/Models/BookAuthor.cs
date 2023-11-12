using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Models
{
    public class BookAuthor
    {
        public string title { get; set; } = null;
        public string nameAuthor { get; set; } = null;
        public int chapters { get; set; }
        public int pages { get; set; }
        public double price { get; set; }

    }
}
