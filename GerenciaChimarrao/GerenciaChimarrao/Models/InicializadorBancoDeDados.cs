using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GerenciaChimarrao.Models
{
    //public class InicializadorBancoDeDados : System.Data.Entity.DropCreateDatabaseIfModelChanges<MapeamentoEntidadesContext>
    public class InicializadorBancoDeDados : System.Data.Entity.DropCreateDatabaseAlways<MapeamentoEntidadesContext>
    {
        protected override void Seed(MapeamentoEntidadesContext context)
        {

            var imagens = new List<Imagem>
            {
                new Imagem { Path = "/Imagens/esperandoMate.jpg"},
                new Imagem { Path = "/Imagens/bebendoMate.jpg"},

             };
            imagens.ForEach(s => context.Imagens.Add(s));
            context.SaveChanges();

            var status = new List<StatusGaucho>
            {
                new StatusGaucho { Descricao = "Esperando mate"},
                new StatusGaucho { Descricao = "Bebendo mate"},
                new StatusGaucho { Descricao = "Caminhando na rua"}

             };
            status.ForEach(s => context.StatusGauchos.Add(s));
            context.SaveChanges();

            var gauchos = new List<Gaucho>
            {
                new Gaucho {
                    Nome = "Joao Claudio",
                    ImagemID =  imagens.Single( g => g.Path == "/Imagens/bebendoMate.jpg").ImagemID,
                    StatusGauchoID =  status.Single( g => g.Descricao == "Bebendo mate").StatusGauchoID,
                },
                new Gaucho {
                    Nome = "Roberto Farias",
                    ImagemID =  imagens.Single( g => g.Path == "/Imagens/esperandoMate.jpg").ImagemID,
                    StatusGauchoID =  status.Single( g => g.Descricao == "Esperando mate").StatusGauchoID,
                },
             };
            gauchos.ForEach(s => context.Gauchos.Add(s));
            context.SaveChanges();
        }
    }
}