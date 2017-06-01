using GerenciaChimarrao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GerenciaChimarrao.Controllers
{
    public class HomeController : Controller
    {
        private MapeamentoEntidadesContext db = new MapeamentoEntidadesContext();

        public ActionResult Index()
        {
            var gauchos = this.db.Gauchos.Include(a => a.Imagem).Where(b => b.StatusGaucho.Descricao != "Caminhando na rua").ToList();
            return View(gauchos);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult VisualizaRoda()
        {
            var gauchos = db.Gauchos.Include(g => g.Imagem).ToList();
            string conteudo = "";
            foreach (Gaucho g in gauchos)
            {
                conteudo = string.Concat(g.Nome, "\\n", conteudo, "\\n");
            }
            this.montaAlertJavaScript(conteudo);
            return View("Index", gauchos);
        }
        public ActionResult EncontraChimarraoVivente()
        {
            var gauchos = db.Gauchos.Include(i => i.Imagem).Include(s => s.StatusGaucho).ToList();
            string nomeVivente = "";
            foreach (Gaucho g in gauchos)
            {
                if (g.StatusGaucho.Descricao == "Bebendo mate")
                {
                    nomeVivente = "O chimarrão está com: " + g.Nome;
                    break;
                }
            }
            this.montaAlertJavaScript(nomeVivente);
            return View("Index", gauchos);
        }

        public ActionResult PassarParaProximo(int id)
        {
            var gauchosTotal = db.Gauchos.Include(i => i.Imagem).Include(s => s.StatusGaucho).ToList();
            Gaucho gauchoQuerPassar = db.Gauchos.Find(id);
            string mensagem = "";
            if (gauchoQuerPassar.StatusGaucho.Descricao == "Esperando mate")
            {
                mensagem = "Gaudério " + gauchoQuerPassar.Nome + ", você não está com o mate ainda";
                this.montaAlertJavaScript(mensagem);
            }
            else
            {
                Gaucho proximoGaucho = this.db.Gauchos.Where(x => x.ID != id).OrderByDescending(x => x.ID).First();
                proximoGaucho.StatusGaucho.Descricao = "Bebendo mate";
                proximoGaucho.Imagem.Path = "/Imagens/bebendoMate.jpg";

                gauchoQuerPassar.StatusGaucho.Descricao = "Esperando mate";
                gauchoQuerPassar.Imagem.Path = "/Imagens/esperandoMate.jpg";

                db.Entry(proximoGaucho).State = EntityState.Modified;
                db.Entry(gauchoQuerPassar).State = EntityState.Modified;
                db.SaveChanges();
            }
            return View("Index", gauchosTotal);
        }

        public ActionResult SairDaRoda(int id)
        {
            Gaucho gauchoQuerSair = db.Gauchos.Find(id);
            if (gauchoQuerSair.StatusGaucho.Descricao == "Bebendo mate")
            {
                Gaucho proximoGaucho = this.db.Gauchos.Where(x => x.ID != id).OrderByDescending(x => x.ID).First();
                proximoGaucho.StatusGaucho.Descricao = "Bebendo mate";
                proximoGaucho.Imagem.Path = "/Imagens/bebendoMate.jpg";
            }
            gauchoQuerSair.StatusGaucho.Descricao = "Caminhando na rua";
            gauchoQuerSair.Imagem.Path = "/Imagens/esperandoMate.jpg";

            db.Entry(gauchoQuerSair).State = EntityState.Modified;
            db.SaveChanges();
            var gauchosTotal = db.Gauchos.Include(i => i.Imagem).Include(s => s.StatusGaucho).Where(x => x.StatusGaucho.Descricao != "Caminhando na rua").ToList();
            return View("Index", gauchosTotal);
        }

        public void montaAlertJavaScript(string conteudo)
        {
            Response.Write("<script>alert('"+conteudo+"');</script>");
        }
    }
}