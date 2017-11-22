using PessoasWeb.Models;
using PessoasWeb.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PessoasWeb.Controllers
{
    public class PessoaController : Controller
    {
        
        // GET: Pessoa
        public ActionResult Index()  //Read
        {

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            string Nome = form["Nome"];
            string Email = form["Email"];
            string Senha = form["Senha"];
            DateTime DataNascimento = DateTime.Parse(form["DataNascimento"]);

            Pessoa p = new Pessoa();
            p.Nome = Nome;
            p.Email = Email;
            p.Senha = Senha;
            p.DataNascimento = DataNascimento;

            PessoaModel model = new PessoaModel();
            model.Create(p);

            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public ActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Entrar(FormCollection form)
        {
            string email = form["Email"];
            string senha = form["Senha"];

            using (PessoaModel model = new PessoaModel())
            {
                Pessoa pessoa = model.Read(email, senha);

                if (pessoa == null)
                {
                    // nao autenticado
                    return RedirectToAction("Login");
                }
                else
                {

                    //Criar uma sessão (mantida durante toda a aplicação)
                    Session["user"] = pessoa;
                    //usuario valido
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpGet]
        public ActionResult cadMedico()
        {
            return View();
        }

        [HttpGet]
        public ActionResult VerPerfil()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Suportt()
        {
            return View();
        }

        //Chamando apenas por formulário com método igual a POST.
        

        public ActionResult Delete(int id)
        {
            PessoaModel model = new PessoaModel();
            model.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            PessoaModel model = new PessoaModel();
            Pessoa p = model.Read(id);
            
            return View(p);
        }

        [HttpPost]
        public ActionResult Update(FormCollection form)
        {
            PessoaModel model = new PessoaModel();
            int Id = int.Parse(form["PessoaId"]);
            string Nome = form["Nome"];
            string Email = form["Email"];
            string Senha = form["Senha"];
            DateTime DataNascimento = DateTime.Parse(form["DataNascimento"]);

            Pessoa p = model.Read(Id);

            p.Nome = Nome;
            p.Email = Email;
            p.Senha = Senha;
            p.DataNascimento = DataNascimento;

            return RedirectToAction("Index");
        }
    }
}