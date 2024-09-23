using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEscola
{
    internal class Aluno
    {
        private int id;
        private string nome;

        public Aluno(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public bool podeMatricular(Curso curso)
        {
            return true;
        }

        public int getId()
        {
            return id;
        }

        public string getNome()
        {
            return nome;
        }
    }
}
