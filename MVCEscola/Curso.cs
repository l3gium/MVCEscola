using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEscola
{
    internal class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas;

        public Curso(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.disciplinas = new Disciplina[12];
        }

        public bool adicionarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].getId() == disciplina.getId())
                {
                    return false;
                }
            }

            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] == null)
                {
                    disciplinas[i] = disciplina;
                    return true;
                }
            }
            return false;
        }

        public Disciplina pesquisarDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].getId() == disciplina.getId())
                {
                    return disciplinas[i];
                }
            }
            return null;
        }

        public bool removerDisciplina(Disciplina disciplina)
        {
            for (int i = 0; i < disciplinas.Length; i++)
            {
                if (disciplinas[i] != null && disciplinas[i].getId() == disciplina.getId())
                {
                    disciplinas[i] = null;
                    return true;
                }
            }
            return false;
        }

        public int getId()
        {
            return id;
        }

        public string getDescricao()
        {
            return descricao;
        }

        public Disciplina[] getDisciplinas()
        {
            return disciplinas;
        }
    }
}
