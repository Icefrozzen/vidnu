using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PessoasWeb.Models
{
    public class Video
    {
        private int videoId;
        private string nome;

        public int VideoId
        {
            get { return VideoId; }
            set { VideoId = value; }
        }

        public string Nome
        {
            get { return Nome; }
            set { Nome = value; }
        }
    }
}