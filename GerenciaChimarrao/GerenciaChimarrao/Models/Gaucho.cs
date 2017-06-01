using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciaChimarrao.Models
{
    public class Gaucho
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }

        public int ImagemID { get; set; }
        public virtual Imagem Imagem { get; set; }

        public int StatusGauchoID { get; set; }
        public virtual StatusGaucho StatusGaucho { get; set; }
    }
}