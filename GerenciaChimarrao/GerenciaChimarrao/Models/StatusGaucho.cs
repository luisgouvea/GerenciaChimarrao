using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GerenciaChimarrao.Models
{
    public class StatusGaucho
    {
        [Key]
        public int StatusGauchoID { get; set; }
        public string Descricao { get; set; }
    }
}