using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PessoasWeb.Models
{
    public class PessoaModel
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();

        public void Create(Pessoa e)
        {
            pessoas.Add(e);
        }

        public List<Pessoa> Read()
        {
            return pessoas;
        }

        public Pessoa Read( int id)
        {
            foreach(Pessoa p in pessoas)
            {
                if(p.PessoaId == id)
                {
                    return p;
                }
            }
            return null;
        }

        public Pessoa Read(string nome)
        {
            foreach (Pessoa p in pessoas)
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
            foreach(Pessoa p in pessoas)
            {
                if(p.PessoaId == id)
                {
                    pessoas.Remove(p);
                    break;
                }
            }
        }
    }
}
