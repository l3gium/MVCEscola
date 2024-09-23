using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEscola
{
    internal class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos; // Máximo de 15 alunos

        public Disciplina(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            this.alunos = new Aluno[15];
        }

        public bool matricularAluno(Aluno aluno)
        {
            // Verifica se o aluno já está matriculado na disciplina
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == aluno)
                {
                    // Aluno já matriculado
                    return false;
                }
            }

            // Verifica se há vagas na disciplina
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == null)
                {
                    alunos[i] = aluno;
                    return true;
                }
            }

            // Disciplina cheia
            return false;
        }

        public bool desmatricularAluno(Aluno aluno)
        {
            for (int i = 0; i < alunos.Length; i++)
            {
                if (alunos[i] == aluno)
                {
                    alunos[i] = null;
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

        public Aluno[] getAlunos()
        {
            return alunos;
        }
    }
}
