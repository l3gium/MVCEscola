using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCEscola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            Aluno[] alunos = new Aluno[100];
            int totalAlunos = 0;

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nSelecione uma opção:");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar curso");
                Console.WriteLine("2. Pesquisar curso (mostrar inclusive as disciplinas associadas)");
                Console.WriteLine("3. Remover curso (não pode ter nenhuma disciplina associada)");
                Console.WriteLine("4. Adicionar disciplina no curso");
                Console.WriteLine("5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)");
                Console.WriteLine("6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)");
                Console.WriteLine("7. Matricular aluno na disciplina");
                Console.WriteLine("8. Remover aluno da disciplina");
                Console.WriteLine("9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado)");
                Console.Write("Opção: ");
                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 0:
                        running = false;
                        break;
                    case 1:
                        Console.WriteLine("\nAdicionar curso\n");
                        Console.Write("ID do curso: ");
                        int idCurso = int.Parse(Console.ReadLine());

                        Console.Write("Descrição do curso: ");
                        string descricaoCurso = Console.ReadLine();

                        Curso novoCurso = new Curso(idCurso, descricaoCurso);
                        bool adicionado = escola.adicionarCurso(novoCurso);

                        if (adicionado)
                        {
                            Console.WriteLine("Curso adicionado com sucesso.\n");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível adicionar o curso (pode ser que já exista ou não haja espaço).\n");
                        }
                        break;

                    case 2:
                        Console.WriteLine("\nPesquisar curso\n");
                        Console.Write("ID do curso: ");
                        int idPesquisaCurso = int.Parse(Console.ReadLine());

                        Curso cursoPesquisa = new Curso(idPesquisaCurso, "");
                        Curso cursoEncontrado = escola.pesquisarCurso(cursoPesquisa);

                        if (cursoEncontrado != null)
                        {
                            Console.WriteLine("Curso encontrado:");
                            Console.WriteLine("ID: " + cursoEncontrado.getId());
                            Console.WriteLine("Descrição: " + cursoEncontrado.getDescricao());
                            Console.WriteLine("Disciplinas associadas:");
                            Disciplina[] disciplinas = cursoEncontrado.getDisciplinas();
                            for (int i = 0; i < disciplinas.Length; i++)
                            {
                                if (disciplinas[i] != null)
                                {
                                    Console.WriteLine(" - ID: " + disciplinas[i].getId() + ", Descrição: " + disciplinas[i].getDescricao());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Curso não encontrado.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\nRemover curso\n");
                        Console.Write("ID do curso: ");
                        int idRemoverCurso = int.Parse(Console.ReadLine());

                        Curso cursoRemover = new Curso(idRemoverCurso, "");
                        bool removido = escola.removerCurso(cursoRemover);

                        if (removido)
                        {
                            Console.WriteLine("Curso removido com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Não foi possível remover o curso (pode ser que não exista ou tenha disciplinas associadas).");
                        }
                        break;

                    case 4:
                        
                        Console.WriteLine("\nAdicionar disciplina no curso\n");
                        Console.Write("ID do curso: ");
                        int idCursoAdicionarDisciplina = int.Parse(Console.ReadLine());

                        Curso cursoParaAdicionarDisciplina = escola.pesquisarCurso(new Curso(idCursoAdicionarDisciplina, ""));

                        if (cursoParaAdicionarDisciplina != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int idDisciplina = int.Parse(Console.ReadLine());

                            Console.Write("Descrição da disciplina: ");
                            string descricaoDisciplina = Console.ReadLine();

                            Disciplina novaDisciplina = new Disciplina(idDisciplina, descricaoDisciplina);
                            bool disciplinaAdicionada = cursoParaAdicionarDisciplina.adicionarDisciplina(novaDisciplina);

                            if (disciplinaAdicionada)
                            {
                                Console.WriteLine("Disciplina adicionada ao curso com sucesso.");
                            }
                            else
                            {
                                Console.WriteLine("Não foi possível adicionar a disciplina (pode ser que já exista ou não haja espaço).");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Curso não encontrado.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("\nPesquisar disciplina\n");

                        Console.Write("ID do Curso: ");
                        int idCursoPesquisa = int.Parse(Console.ReadLine());

                        Console.Write("ID da disciplina: ");
                        int idDisciplinaPesquisa = int.Parse(Console.ReadLine());

                        Disciplina disciplinaEncontrada = null;
                        Curso[] cursos = escola.getCursos();

                        for (int i = 0; i < cursos.Length; i++)
                        {
                            if (cursos[i] != null)
                            {
                                if (cursos[i].getId() == idCursoPesquisa)
                                {
                                    Disciplina[] disciplinas = cursos[i].getDisciplinas();
                                    for (int j = 0; j < disciplinas.Length; j++)
                                    {
                                        if (disciplinas[j] != null && disciplinas[j].getId() == idDisciplinaPesquisa)
                                        {
                                            disciplinaEncontrada = disciplinas[j];
                                            break;
                                        }
                                    }
                                    if (disciplinaEncontrada != null)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        if (disciplinaEncontrada != null)
                        {
                            Console.WriteLine("Disciplina encontrada:");
                            Console.WriteLine("ID: " + disciplinaEncontrada.getId());
                            Console.WriteLine("Descrição: " + disciplinaEncontrada.getDescricao());
                            Console.WriteLine("Alunos matriculados:");
                            Aluno[] alunosDisciplina = disciplinaEncontrada.getAlunos();
                            for (int i = 0; i < alunosDisciplina.Length; i++)
                            {
                                if (alunosDisciplina[i] != null)
                                {
                                    Console.WriteLine(" - ID: " + alunosDisciplina[i].getId() + ", Nome: " + alunosDisciplina[i].getNome());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Disciplina ou Curso não encontrada(o).");
                        }
                        break;

                    case 6:
                        Console.WriteLine("\nRemover disciplina do curso\n");
                        Console.Write("ID do curso: ");

                        int idCursoRemoverDisciplina = int.Parse(Console.ReadLine());
                        Curso cursoRemoverDisciplina = escola.pesquisarCurso(new Curso(idCursoRemoverDisciplina, ""));

                        if (cursoRemoverDisciplina != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int idDisciplinaRemover = int.Parse(Console.ReadLine());

                            Disciplina disciplinaRemover = cursoRemoverDisciplina.pesquisarDisciplina(new Disciplina(idDisciplinaRemover, ""));

                            if (disciplinaRemover != null)
                            {
                                Aluno[] alunosDisciplina = disciplinaRemover.getAlunos();
                                bool hasAlunos = false;
                                for (int i = 0; i < alunosDisciplina.Length; i++)
                                {
                                    if (alunosDisciplina[i] != null)
                                    {
                                        hasAlunos = true;
                                        break;
                                    }
                                }
                                if (!hasAlunos)
                                {
                                    bool disciplinaRemovida = cursoRemoverDisciplina.removerDisciplina(disciplinaRemover);
                                    if (disciplinaRemovida)
                                    {
                                        Console.WriteLine("Disciplina removida do curso com sucesso.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Não foi possível remover a disciplina.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Não é possível remover a disciplina, existem alunos matriculados.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Disciplina não encontrada no curso.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Curso não encontrado.");
                        }
                        break;

                    case 7:
                        Console.WriteLine("\nMatricular aluno na disciplina\n");

                        Console.Write("ID do aluno: ");
                        int idAlunoMatricular = int.Parse(Console.ReadLine());

                        Aluno alunoMatricular = null;

                        for (int i = 0; i < totalAlunos; i++)
                        {
                            if (alunos[i].getId() == idAlunoMatricular)
                            {
                                alunoMatricular = alunos[i];
                                break;
                            }
                        }
                        if (alunoMatricular == null)
                        {
                            Console.Write("Nome do aluno: ");
                            string nomeAluno = Console.ReadLine();

                            alunoMatricular = new Aluno(idAlunoMatricular, nomeAluno);

                            if (totalAlunos < alunos.Length)
                            {
                                alunos[totalAlunos] = alunoMatricular;
                                totalAlunos++;
                            }
                            else
                            {
                                Console.WriteLine("Limite de alunos atingido.");
                                break;
                            }
                        }
                        Console.Write("ID do curso: ");
                        int cursoId = int.Parse(Console.ReadLine());

                        Curso[] cursosMatricular = escola.getCursos();
                        Curso cursoDaDisciplina = null;

                        for (int p = 0; p < cursosMatricular.Length; p++)
                        {
                            if (cursosMatricular[p] != null)
                            {
                                if (cursosMatricular[p].getId() == cursoId)
                                {
                                    Console.Write("ID da disciplina: ");
                                    int idDisciplinaMatricular = int.Parse(Console.ReadLine());

                                    Disciplina disciplinaMatricular = null;


                                    for (int i = 0; i < cursosMatricular.Length; i++)
                                    {
                                        if (cursosMatricular[i] != null)
                                        {
                                            Disciplina[] disciplinas = cursosMatricular[i].getDisciplinas();
                                            for (int j = 0; j < disciplinas.Length; j++)
                                            {
                                                if (disciplinas[j] != null && disciplinas[j].getId() == idDisciplinaMatricular)
                                                {
                                                    disciplinaMatricular = disciplinas[j];
                                                    cursoDaDisciplina = cursosMatricular[i];
                                                    break;
                                                }
                                            }
                                            if (disciplinaMatricular != null)
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    if (disciplinaMatricular != null)
                                    {
                                        if (alunoMatricular.podeMatricular(cursoDaDisciplina))
                                        {
                                            bool matriculadoOutroCurso = false;
                                            for (int i = 0; i < cursosMatricular.Length; i++)
                                            {
                                                if (cursosMatricular[i] != null && cursosMatricular[i] != cursoDaDisciplina)
                                                {
                                                    Disciplina[] disciplinas = cursosMatricular[i].getDisciplinas();
                                                    for (int j = 0; j < disciplinas.Length; j++)
                                                    {
                                                        if (disciplinas[j] != null)
                                                        {
                                                            Aluno[] alunosDisciplina = disciplinas[j].getAlunos();
                                                            for (int k = 0; k < alunosDisciplina.Length; k++)
                                                            {
                                                                if (alunosDisciplina[k] == alunoMatricular)
                                                                {
                                                                    matriculadoOutroCurso = true;
                                                                    break;
                                                                }
                                                            }
                                                            if (matriculadoOutroCurso)
                                                            {
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                if (matriculadoOutroCurso)
                                                {
                                                    break;
                                                }
                                            }

                                            if (!matriculadoOutroCurso)
                                            {
                                                int disciplinasAluno = 0;
                                                for (int i = 0; i < cursosMatricular.Length; i++)
                                                {
                                                    if (cursosMatricular[i] != null)
                                                    {
                                                        Disciplina[] disciplinas = cursosMatricular[i].getDisciplinas();
                                                        for (int j = 0; j < disciplinas.Length; j++)
                                                        {
                                                            if (disciplinas[j] != null)
                                                            {
                                                                Aluno[] alunosDisciplina = disciplinas[j].getAlunos();
                                                                for (int k = 0; k < alunosDisciplina.Length; k++)
                                                                {
                                                                    if (alunosDisciplina[k] == alunoMatricular)
                                                                    {
                                                                        disciplinasAluno++;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (disciplinasAluno < 6)
                                                {
                                                    bool matriculado = disciplinaMatricular.matricularAluno(alunoMatricular);
                                                    if (matriculado)
                                                    {
                                                        Console.WriteLine("Aluno matriculado na disciplina com sucesso.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Não foi possível matricular o aluno na disciplina (disciplina cheia ou aluno já matriculado).");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Aluno já está matriculado em 6 disciplinas.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Aluno já está matriculado em outro curso.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Aluno não pode se matricular neste curso.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Disciplina não encontrada.");
                                    }
                                }
                            }
                        }

                        
                        break;

                    case 8:
                        Console.WriteLine("\nRemover aluno da disciplina\n");
                        Console.Write("ID do aluno: ");
                        int idAlunoRemover = int.Parse(Console.ReadLine());

                        Aluno alunoRemover = null;

                        for (int i = 0; i < totalAlunos; i++)
                        {
                            if (alunos[i].getId() == idAlunoRemover)
                            {
                                alunoRemover = alunos[i];
                                break;
                            }
                        }

                        if (alunoRemover != null)
                        {
                            Console.Write("ID da disciplina: ");
                            int idDisciplinaRemoverAluno = int.Parse(Console.ReadLine());

                            Disciplina disciplinaRemoverAluno = null;
                            Curso[] cursosRemoverAluno = escola.getCursos();

                            for (int i = 0; i < cursosRemoverAluno.Length; i++)
                            {
                                if (cursosRemoverAluno[i] != null)
                                {
                                    Disciplina[] disciplinas = cursosRemoverAluno[i].getDisciplinas();
                                    for (int j = 0; j < disciplinas.Length; j++)
                                    {
                                        if (disciplinas[j] != null && disciplinas[j].getId() == idDisciplinaRemoverAluno)
                                        {
                                            disciplinaRemoverAluno = disciplinas[j];
                                            break;
                                        }
                                    }
                                    if (disciplinaRemoverAluno != null)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (disciplinaRemoverAluno != null)
                            {
                                bool desmatriculado = disciplinaRemoverAluno.desmatricularAluno(alunoRemover);
                                if (desmatriculado)
                                {
                                    Console.WriteLine("Aluno removido da disciplina com sucesso.");
                                }
                                else
                                {
                                    Console.WriteLine("Aluno não está matriculado nesta disciplina.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Disciplina não encontrada.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado.");
                        }
                        break;

                    case 9:
                        Console.WriteLine("\nPesquisar aluno\n");
                        Console.Write("ID do Curso: ");
                        int idcurso = int.Parse(Console.ReadLine());

                        Console.Write("ID do aluno: ");
                        int idAlunoPesquisar = int.Parse(Console.ReadLine());
                        Aluno alunoPesquisar = null;
                        for (int i = 0; i < totalAlunos; i++)
                        {
                            if (alunos[i].getId() == idAlunoPesquisar)
                            {
                                alunoPesquisar = alunos[i];
                                break;
                            }
                        }
                        if (alunoPesquisar != null)
                        {
                            Console.WriteLine("Aluno encontrado:");
                            Console.WriteLine("ID: " + alunoPesquisar.getId());
                            Console.WriteLine("Nome: " + alunoPesquisar.getNome());
                            Console.WriteLine("Disciplinas matriculadas:");

                            Curso[] cursosPesquisar = escola.getCursos();
                            for (int i = 0; i < cursosPesquisar.Length; i++)
                            {
                                if (cursosPesquisar[i] != null)
                                {
                                    if (cursosPesquisar[i].getId() == idcurso)
                                    {
                                        Disciplina[] disciplinas = cursosPesquisar[i].getDisciplinas();
                                        for (int j = 0; j < disciplinas.Length; j++)
                                        {
                                            if (disciplinas[j] != null)
                                            {
                                                Aluno[] alunosDisciplina = disciplinas[j].getAlunos();
                                                for (int k = 0; k < alunosDisciplina.Length; k++)
                                                {
                                                    if (alunosDisciplina[k] == alunoPesquisar)
                                                    {
                                                        Console.WriteLine(" - ID da disciplina: " + disciplinas[j].getId() + ", Descrição: " + disciplinas[j].getDescricao());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
