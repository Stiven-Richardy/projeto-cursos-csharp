/*
| Instituto Federal de São Paulo - Campus Cubatão
| Nome: Guilherme Mendes de Sousa - CB3030857
| Nome: Stiven Richardy Silva Rodrigues - CB3030202
| Turma: ADS 471
| 
| Opções no seletor:
| 0. Sair
| 1. Adicionar curso
| 2. Pesquisar curso (mostrar inclusive as disciplinas associadas)
| 3. Remover curso (não pode ter nenhuma disciplina associada)
| 4. Adicionar disciplina no curso
| 5. Pesquisar disciplina (mostrar inclusive os alunos matriculados)
| 6. Remover disciplina do curso (não pode ter nenhum aluno matriculado)
| 7. Matricular aluno na disciplina
| 8. Remover aluno da disciplina
| 9. Pesquisar aluno (informar seu nome e em quais disciplinas ele está matriculado) 
|
| Requisitos:
| Uma escola oferece 5 cursos de tecnologia, cada um contendo 12 disciplinas.
| Os alunos se inscrevem para as disciplinas, que podem ter, no máximo, 15 alunos inscritos.
| Cada aluno só pode estar matriculado em um único curso e estar inscrito simultaneamente em, no máximo 6 disciplinas.
*/

using System.Runtime.ConstrainedExecution;
using System;
using System.Net.NetworkInformation;

namespace projeto_cursos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Escola escola = new Escola();
            Curso curso = new Curso();
            Disciplina disciplina = new Disciplina();

            int seletor = -1;
            int id;

            while (seletor != 0)
            {
                Console.Clear();
                Utils.Titulo("PAINEL PRINCIPAL");
                Console.WriteLine(" 0 - Sair");
                Console.WriteLine(" 1 - Adicionar curso");
                Console.WriteLine(" 2 - Pesquisar curso");
                Console.WriteLine(" 3 - Remover curso");
                Console.WriteLine(" 4 - Adicionar disciplina no curso");
                Console.WriteLine(" 5 - Pesquisar disciplina");
                Console.WriteLine(" 6 - Remover disciplina do curso");
                Console.WriteLine(" 7 - Matricular aluno na disciplina");
                Console.WriteLine(" 8 - Remover aluno da disciplina");
                Console.WriteLine(" 9 - Pesquisar aluno");
                Console.WriteLine("--------------------------------------------");
                Console.Write(" Escolha uma opção: ");
                seletor = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro número: ");

                switch (seletor)
                {
                    case 0:
                        Console.WriteLine(" Programa finalizado!");
                        break;
                    case 1:
                        adicionarCurso(escola);
                        break;
                    case 2:
                        pesquisarCurso(escola);
                        break;
                    case 3:
                        removerCurso(escola);
                        break;
                    case 4:
                        adicionarDisciplina(escola, curso);
                        break;
                    case 5:
                        pesquisarDisciplina(escola, curso);
                        break;
                    case 6:
                        removerDisciplina(escola, curso);
                        break;
                    case 7:
                        matricularAluno(escola, curso, disciplina);
                        break;
                    case 8:
                        removerAluno(escola, curso, disciplina);
                        break;
                    case 9:
                        pesquisarAluno(escola, curso, disciplina);
                        break;
                    default:
                        Utils.MensagemErro("Digite um número de 0-9!");
                        break;
                }
            }
        }

        public static void adicionarCurso(Escola escola)
        {
            Utils.Titulo("ADICIONAR CURSO");
            Console.Write(" Digite o ID do Curso: ");
            int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro ID: ");
            Console.Write(" Digite o Nome do Curso: ");
            string descricao = Console.ReadLine();
            if (!String.IsNullOrEmpty(descricao))
            {
                if (escola.adicionarCurso(new Curso(id, descricao)))
                    Utils.MensagemSucesso("Curso adicionado");
                else
                    Utils.MensagemErro("ID já adicionado ou máximo de cursos atingido.");
            }
            else
            {
                Utils.MensagemErro("Ocorreu um erro ao adicionar um curso.\n Tente novamente.");
            }
        }

        public static void pesquisarCurso(Escola escola)
        {
            Utils.Titulo("PESQUISAR CURSO");
            Console.Write(" Digite o ID do Curso: ");
            int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            Curso pesquisaCurso = new Curso(id);
            Curso cursoAchado = escola.pesquisarCurso(pesquisaCurso);
            bool temDisciplina = false;
            if (cursoAchado.Id != -1)
            {
                Console.WriteLine($" ID: {cursoAchado.Id}\n Curso: {cursoAchado.Descricao}"); 
                Console.WriteLine("\n Disciplinas associadas:");
                foreach (Disciplina d in cursoAchado.Disciplinas)
                {
                    if (d.Id != -1)
                    {
                        Console.WriteLine($" ID Disciplina: {d.Id}\n Descrição Disciplina: {d.Descricao}");
                        temDisciplina = true;
                    }
                }
                if (!temDisciplina) {
                    Console.WriteLine(" Nenhuma disciplina encontrada.");
                }
                Utils.MensagemSucesso("Curso encontrado.");
            }
            else
            {
                Utils.MensagemErro("Curso não encontrado.");
            }
        }

        public static void removerCurso(Escola escola)
        {
            Utils.Titulo("REMOVER CURSO");
            Console.Write(" Digite o ID do Curso: ");
            int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            Curso removeCurso = new Curso(id);
            Curso cursoAchado = escola.pesquisarCurso(removeCurso);
            bool temDisciplina = false;
            if (cursoAchado.Id != -1)
            {
                foreach (Disciplina d in cursoAchado.Disciplinas)
                {
                    if (d.Id != -1)
                    {
                        temDisciplina = true;
                        break;
                    }
                }
                if (!temDisciplina)
                {
                    escola.removerCurso(cursoAchado);
                    Utils.MensagemSucesso($"ID: {cursoAchado.Id}\n Curso: {cursoAchado.Descricao}\n Curso removido!");
                }
                else
                {
                    Utils.MensagemErro("O curso possui disciplinas associadas.");
                }
            }
            else
                Utils.MensagemErro("Curso não encontrado.");
        }
        public static void adicionarDisciplina(Escola escola, Curso curso)
        {
            Utils.Titulo("ADICIONAR DISCIPLINA");
            Console.Write(" Digite o ID do Curso: ");
            int idCurso = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro ID: ");
            Curso pesquisaCurso = new Curso(idCurso);
            Curso cursoAchado = escola.pesquisarCurso(pesquisaCurso);
            if (cursoAchado.Id != -1)
            {
                Console.Write(" Digite o ID da Disciplina: ");
                int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro ID: ");
                Console.Write(" Digite o Nome da Disciplina: ");
                string descricao = Console.ReadLine();
                if (!String.IsNullOrEmpty(descricao))
                {
                    if (cursoAchado.adicionarDisciplina(new Disciplina(id, descricao)))
                    {
                        Utils.MensagemSucesso("Disciplina adicionada");
                    }
                    else
                        Utils.MensagemErro("ID já adicionado ou máximo de Disciplinas atingido.");
                }
                else
                {
                    Utils.MensagemErro("Ocorreu um erro ao adicionar uma Disciplina.\n Tente novamente.");
                }
            }
            else
                Utils.MensagemErro("ID do Curso não encontrado");
            
            
        }

        public static void pesquisarDisciplina(Escola escola, Curso curso)
        {
            Utils.Titulo("PESQUISAR DISCIPLINA");
            Console.Write(" Digite o ID do Curso: ");
            int idCurso = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro ID: ");
            Curso pesquisaCurso = new Curso(idCurso);
            Curso cursoAchado = escola.pesquisarCurso(pesquisaCurso);
            if (cursoAchado.Id != -1)
            {
                Console.Write(" Digite o ID da Disciplina: ");
                int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
                Disciplina pesquisaDisciplina = new Disciplina(id);
                Disciplina disciplinaAchada = cursoAchado.pesquisarDisciplina(pesquisaDisciplina);
                bool temAluno = false;
                if (disciplinaAchada.Id != -1)
                {
                    Console.WriteLine($" ID: {disciplinaAchada.Id}\n Curso: {disciplinaAchada.Descricao}");
                    Console.WriteLine("\n Alunos matriculados:");
                    foreach (Aluno a in disciplinaAchada.Alunos)
                    {
                        if (a.Id != -1)
                        {
                            Console.WriteLine($" ID Aluno: {a.Id}\n Nome Aluno: {a.Nome}");
                            temAluno = true;
                        }
                    }
                    if (!temAluno)
                    {
                        Console.WriteLine(" Nenhum aluno matriculado.");
                    }
                    Utils.MensagemSucesso("Disciplina encontrada.");
                }
                else
                {
                    Utils.MensagemErro("Disciplina não encontrada.");
                }
            }
            else
                Utils.MensagemErro("ID do Curso não encontrado");
        }

        public static void removerDisciplina(Escola escola, Curso curso)
        {
            Utils.Titulo("REMOVER DISCIPLINA");
            Console.Write(" Digite o ID do Curso: ");
            int idCurso = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida!\n Informe outro ID: ");
            Curso pesquisaCurso = new Curso(idCurso);
            Curso cursoAchado = escola.pesquisarCurso(pesquisaCurso);
            if (cursoAchado.Id != -1)
            {
                Console.Write(" Digite o ID da Disciplina: ");
                int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
                Disciplina pesquisarDisciplina = new Disciplina(id);
                Disciplina disciplinaAchada = new Disciplina();
                bool achouDisciplina = false;
                bool temAluno = false;
                foreach (Disciplina d in cursoAchado.Disciplinas)
                {
                    if (d.Id == pesquisarDisciplina.Id)
                    {
                        disciplinaAchada = d;
                        achouDisciplina = true;
                        break;
                    }

                }
                if (achouDisciplina)
                {
                    foreach (Aluno a in disciplinaAchada.Alunos)
                    {
                        if (a.Id != -1)
                        {
                            temAluno = true;
                            break;
                        }
                    }
                }
                if (!temAluno)
                {
                    cursoAchado.removerDisciplina(disciplinaAchada);
                    Utils.MensagemSucesso("Disciplina removida.");
                }
                else
                {
                    if (disciplinaAchada.Id == -1)
                    {
                        Utils.MensagemErro("Disciplina não encontrada.");
                    } else
                    {
                        Utils.MensagemErro("Existem alunos matriculados na disciplina.");
                    }
                }
            }
            else
                Utils.MensagemErro("ID do Curso não encontrado");
        }

        public static void matricularAluno(Escola escola, Curso curso, Disciplina disciplina)
        {
            Utils.Titulo("MATRICULAR ALUNO");
            Console.Write(" Digite o ID do aluno: ");
            int idAluno = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            int idCursoMatriculado = -1;
            int idDisciplinaMatriculado = -1;
            Aluno aluno = new Aluno();
            foreach (Curso c in escola.Cursos)
            {
                foreach (Disciplina d in c.Disciplinas)
                {
                    if (d.pesquisarAluno(new Aluno(idAluno)).Id != -1)
                    {
                        idCursoMatriculado = c.Id;
                        idDisciplinaMatriculado = d.Id;
                        break;
                    }
                }
            }
            if (idCursoMatriculado == -1)
            {
                Console.Write(" Digite o nome do aluno: ");
                string nome = Console.ReadLine();
                aluno = new Aluno(idAluno, nome);
            }
            else
            {
                aluno = escola.pesquisarCurso(new Curso(idCursoMatriculado))
                    .pesquisarDisciplina(new Disciplina(idDisciplinaMatriculado))
                    .pesquisarAluno(new Aluno(idAluno));
            }
            Console.Write(" Digite o ID do curso: ");
            int idCurso = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            if (escola.pesquisarCurso(new Curso(idCurso)).Id != -1)
            {
                curso = escola.pesquisarCurso(new Curso(idCurso));
                if (idCursoMatriculado != -1 && idCursoMatriculado != curso.Id)
                {
                    Utils.MensagemErro("Aluno já matriculado em outro curso.");
                }
                else if (!aluno.podeMatricular(curso))
                {
                    Utils.MensagemErro("Aluno alcançou o limite de disciplinas matriculadas.");
                }
                else
                {
                    Console.Write(" Digite o ID da disciplina: ");
                    int idDisciplina = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
                    disciplina = curso.pesquisarDisciplina(new Disciplina(idDisciplina));
                    bool matriculou;
                    if (disciplina.Id != -1)
                    {
                        matriculou = escola.pesquisarCurso(curso)
                            .pesquisarDisciplina(disciplina).matricularAluno(aluno);
                        if (matriculou)
                        {
                            Utils.MensagemSucesso("Aluno matriculado com sucesso.");
                        }
                        else
                        {
                            Utils.MensagemErro("Não foi possível realizar a matrícula.");
                        }
                    }
                    else
                        Utils.MensagemErro("Disciplina não encontrada.");
                }
            }
            else
                Utils.MensagemErro("Curso não encontrado.");

        }

        public static void pesquisarAluno(Escola escola, Curso curso, Disciplina disciplina)
        {
            Utils.Titulo("PESQUISAR ALUNO");
            Console.Write(" Digite o ID do Aluno: ");
            int id = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            Aluno pesquisaAluno = new Aluno(id);
            bool encontrou = false;
            foreach (Curso c in escola.Cursos)
            {
                foreach (Disciplina d in c.Disciplinas)
                {
                    if (encontrou)
                        break;
                    if (d.pesquisarAluno(pesquisaAluno).Id != -1)
                    {
                        pesquisaAluno = d.pesquisarAluno(pesquisaAluno);
                        Console.WriteLine($" ID: {pesquisaAluno.Id}\n Nome: {pesquisaAluno.Nome}");
                        Console.WriteLine("\n Disciplinas matriculadas:");
                        encontrou = true;
                        foreach (Disciplina dis in c.Disciplinas)
                        {
                            if (dis.pesquisarAluno(pesquisaAluno).Id != -1)
                            {
                                Console.WriteLine($" ID: {dis.Id}\n Disciplina: {dis.Descricao}\n");
                            }
                        }
                        break;
                    }
                }
            }
            if (encontrou)
            {
                Utils.MensagemSucesso("Aluno encontrado.");
            }
            else
                Utils.MensagemErro("Aluno não encontrado.");

        }

        public static void removerAluno(Escola escola, Curso curso, Disciplina disciplina)
        {
            Utils.Titulo("REMOVER ALUNO");
            Console.Write(" Digite o ID do Aluno: ");
            int idAluno = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            Aluno aluno = new Aluno();
            bool alunoMatriculado = false;
            foreach (Curso c in escola.Cursos)
            {
                if (alunoMatriculado)
                    break;
                foreach (Disciplina d in c.Disciplinas)
                {
                    if (d.pesquisarAluno(new Aluno(idAluno)).Id != -1)
                    {
                        aluno = d.pesquisarAluno(new Aluno(idAluno));
                        curso = c;
                        alunoMatriculado = true;
                        break;
                    }
                }
            }
            Console.Write(" Digite o ID da Disciplina: ");
            int idDisciplina = Utils.lerInt(Console.ReadLine(), 0, " Entrada inválida.\n Informe outro ID: ");
            Disciplina pesquisaDisciplina = curso.pesquisarDisciplina(new Disciplina(idDisciplina));
            bool removeu;
            if (pesquisaDisciplina.Id != -1)
            {
                disciplina = pesquisaDisciplina;
                removeu = escola.pesquisarCurso(curso)
                    .pesquisarDisciplina(disciplina).desmatricularAluno(aluno);
                if (removeu)
                {
                    Utils.MensagemSucesso("Aluno desmatriculado.");
                }
                else
                    Utils.MensagemErro("Aluno não encontrado.");
            }
            else
            {
                Utils.MensagemErro("Disciplina não encontrada.");
            }
        }
            
    }
}