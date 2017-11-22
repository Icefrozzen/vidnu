using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PessoasWeb.Models;

namespace PessoasWeb.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        public ActionResult Index()  //Read
        {
            Pessoa p1 = new Pessoa();
            p1.PessoaId = 1;
            p1.Nome = "Fulano";
            p1.Email = "fulano@email.com";
            p1.Senha = "1234";
            p1.DataNascimento = new DateTime(1996, 10, 13);

            Pessoa p2 = new Pessoa();
            p2.PessoaId = 2;
            p2.Nome = "Ciclano";
            p2.Email = "ciclano@email.com.br";
            p2.Senha = "17 6543211";
            p2.DataNascimento = new DateTime(1996, 1, 10);

            PessoaModel model = new PessoaModel();

            List<Pessoa> pessoas = model.Read();

            if (pessoas.Count == 0)
            {
                model.Create(p1);
                model.Create(p2);
            }

            return View(pessoas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Entrar()
        {
            return View();
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