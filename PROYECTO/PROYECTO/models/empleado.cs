using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;

namespace PROYECTO.models
{
    public class empleado
    {
        [PrimaryKey, AutoIncrement]

        public int codigo { get; set; }

        [MaxLength(100)]

        public string nombre { get; set; }

        [MaxLength(100)]

        public string pais { get; set; }

        [MaxLength(100)]

        public string departamento { get; set; }

        [MaxLength(100)]

        public string municipio { get; set; }

        [MaxLength(100)]

        public string residencia { get; set; }

    }
}
