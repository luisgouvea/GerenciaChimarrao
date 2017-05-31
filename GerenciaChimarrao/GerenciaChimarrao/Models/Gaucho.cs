using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GerenciaChimarrao.Models
{
    public class Gaucho
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public int ImagemID { get; set; }
        public virtual Imagem Imagem { get; set; }
    }
}