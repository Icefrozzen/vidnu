using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PessoasWeb.Models
{
    public class VideoModel : ModelBase
    {
        public void Create(Video e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection; // objeto herdado do ModelBase
            cmd.CommandText = @"Exec CadProfessor @estatus, @email, @nome, @sobreNome, @cel, @senha";

            cmd.Parameters.AddWithValue("@nome", e.Nome);

            cmd.ExecuteNonQuery();
        }

        public Video Read(string nome)
        {
            Video e = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"Exec LogarProfessor @email, @senha";

            cmd.Parameters.AddWithValue("@nome", nome);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                e = new Video();
                e.VideoId = (int)reader["idVideo"];
                e.Nome = (string)reader["Nome"];
            }

            return e;
        }

        public List<Video> Read()
        {
            List<Video> lista = new List<Video>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"select * from v_video";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Video e = new Video();
                e.VideoId = (int)reader["idProfessor"];
                e.Nome = (string)reader["Nome"];
                lista.Add(e);
            }

            return lista;
        }
    }
}