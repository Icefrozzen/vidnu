using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PessoasWeb.Models
{
    public class PessoaModel : ModelBase
    {
        public void Create(Pessoa e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection; // objeto herdado do ModelBase
            cmd.CommandText = @"Exec CadPessoa @nome, @email, @senha, @date";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@senha", e.Senha);
            cmd.Parameters.AddWithValue("@date", e.Senha);
            DateTime data = Convert.ToDateTime(e.DataNascimento);
            cmd.Parameters.AddWithValue("@datanasc", data);

            cmd.ExecuteNonQuery();
        }

        public Pessoa Read(string email, string senha)
        {
            Pessoa e = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"Exec LogarPessoa @email, @senha";

            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                e = new Admin();
                e.PessoaId = (int)reader["idPessoa"];
                e.Nome = (string)reader["Nome"];
                e.Email = (string)reader["Email"];
                e.Senha = (string)reader["Senha"];
                DateTime data = (DateTime)reader["Datanasc"];
                //e.DataNascimento = data.ToString(@"yyyy-MM-dd");
            }

            return e;
        }

        public List<Pessoa> Read()
        {
            List<Pessoa> lista = new List<Pessoa>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"select * from v_pessoa";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Pessoa p = new Pessoa();
                p.PessoaId = (int)reader["idPessoa"];
                p.Nome = (string)reader["Nome"];
                p.Email = (string)reader["Email"];
                p.Senha = (string)reader["Senha"];
                p.DataNascimento = (DateTime)reader["Datanasc"];

                lista.Add(p);
            }

            return lista;
        }
    }
}
