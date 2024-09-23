using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEscola
{
    internal class Escola
    {
        private Curso[] cursos; 

        public Escola()
        {
            this.cursos = new Curso[5];
        }

        public bool adicionarCurso(Curso curso)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].getId() == curso.getId())
                {
                    return false;
                }
            }

            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] == null)
                {
                    cursos[i] = curso;
                    return true;
                }
            }
            return false;
        }

        public Curso pesquisarCurso(Curso curso)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].getId() == curso.getId())
                {
                    return cursos[i];
                }
            }
            return null;
        }

        public bool removerCurso(Curso curso)
        {
            for (int i = 0; i < cursos.Length; i++)
            {
                if (cursos[i] != null && cursos[i].getId() == curso.getId())
                {
                    Disciplina[] disciplinas = cursos[i].getDisciplinas();
                    for (int j = 0; j < disciplinas.Length; j++)
                    {
                        if (disciplinas[j] != null)
                        {
                            return false;
                        }
                    }
                    cursos[i] = null;
                    return true;
                }
            }
            return false;
        }

        public Curso[] getCursos()
        {
            return cursos;
        }
    }
}
