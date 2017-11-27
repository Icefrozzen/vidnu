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
        public void Create(Video v)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection; // objeto herdado do ModelBase
            cmd.CommandText = "INSERT INTO tb_video (nome_video) VALUES (@nome) ";

            cmd.Parameters.AddWithValue("@nome", v.Nome);

            cmd.ExecuteNonQuery();
        }

        public Video Read(int idVideo)
        {
            Video v = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"select * from v_video where Codigo = @IdVideo";

            cmd.Parameters.AddWithValue("@IdVideo", idVideo);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                v = new Video();
                v.VideoId = (int)reader["idVideo"];
                v.Nome = (string)reader["Nome_video"];
            }

            return v;
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
                Video v = new Video();
                v.VideoId = (int)reader["IdVideo"];
                v.Nome = (string)reader["Nome_video"];

                lista.Add(v);
            }

            return lista;
        }

        public void UpdateVideo(int idVideo, string video)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE videos set nome_video = @nome where id = @idVideo";
            cmd.Parameters.AddWithValue("@idEvento", idVideo);
            cmd.Parameters.AddWithValue("@imagem", video);

            cmd.ExecuteNonQuery();
        }

    }
}