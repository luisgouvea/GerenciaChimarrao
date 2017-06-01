using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciaChimarrao.Models
{
    public class Imagem
    {
        [Key]
        public int ImagemID { get; set; }
        public string Path { get; set; }
    }
}