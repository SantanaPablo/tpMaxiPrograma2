using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        [DisplayName("ID")]
        public int id { get; set; }
        [DisplayName("Categoría")]
        public string descripcion { get; set; }

        public override string ToString()
        {
            return descripcion.ToString();
        }
    }
}
