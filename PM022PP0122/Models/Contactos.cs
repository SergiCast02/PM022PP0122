using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM022PP0122.Models
{
    public class Contactos
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String nombre { get; set; }
        public String telefono { get; set; }
    }
}