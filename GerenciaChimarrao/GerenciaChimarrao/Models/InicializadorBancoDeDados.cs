using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GerenciaChimarrao.Models
{
    public class InicializadorBancoDeDados : System.Data.Entity.DropCreateDatabaseIfModelChanges<MapeamentoEntidadesContext>
    //public class InicializadorBancoDeDados : System.Data.Entity.DropCreateDatabaseAlways<MapeamentoEntidadesContext>
    {
        protected override void Seed(MapeamentoEntidadesContext context)
        {

            var imagens = new List<Imagem>
            {
                new Imagem { Path = "Imagem1"}

             };
            imagens.ForEach(s => context.Imagens.Add(s));
            context.SaveChanges();


            var gauchos = new List<Gaucho>
            {
                new Gaucho {
                    Nome = "Joao",
                    ImagemID =  imagens.Single( g => g.Path == "/Imagens/imagem1.png").ImagemID,
                }
             };
            gauchos.ForEach(s => context.Gauchos.Add(s));
            context.SaveChanges();
        }
    }
}