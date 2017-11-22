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
                if (v.Nome.Contains(nome))
                {
                    return v;
                }
            }
            return null;
        }

        public void Update(Video e)
        {
            foreach (Video v in videos)
            {
                if (v.VideoId == e.VideoId)
                {
                    v.Nome = e.Nome;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            foreach (Video v in videos)
            {
                if (v.VideoId == id)
                {
                    videos.Remove(v);
                    break;
                }
            }
        }
    }
}