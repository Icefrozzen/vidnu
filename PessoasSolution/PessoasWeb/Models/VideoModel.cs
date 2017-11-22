using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace PessoasWeb.Models
{
    public class VideoModel
    {
        private static List<Video> videos = new List<Video>();

        public void Create(Video e)
        {
            videos.Add(e);
        }

        public List<Video> Read()
        {
            return videos;
        }

        public Video Read(int id)
        {
            foreach (Video v in videos)
            {
                if (v.VideoId == id)
                {
                    return v;
                }
            }
            return null;
        }

        public Video Read(string nome)
        {
            foreach (Video v in videos)
            {
                if (p.Nome.Contains(nome))
                {
                    return p;
                }
            }
            return null;
        }

        public void Update(Pessoa e)
        {
            foreach (Pessoa p in pessoas)
            {
                if (p.PessoaId == e.PessoaId)
                {
                    p.Nome = e.Nome;
                    p.Email = e.Email;
                    p.Senha = e.Senha;
                    p.DataNascimento = e.DataNascimento;

                    break;
                }
            }
        }

        public void Delete(int id)
        {
            foreach (Pessoa p in pessoas)
            {
                if (p.PessoaId == id)
                {
                    pessoas.Remove(p);
                    break;
                }
            }
        }
    }
}