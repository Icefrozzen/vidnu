using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PessoasWeb.Models;

namespace PessoasWeb.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            Video p1 = new Video();
            p1.VideoId = 1;
            p1.Nome = "Fulano";

            return View();
        }
    }
}