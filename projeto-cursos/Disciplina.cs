using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace projeto_cursos
{
    internal class Disciplina
    {
        private int id;
        private string descricao;
        private Aluno[] alunos = new Aluno[15];

        public int Id { get => id; set => this.id = value; }
        public string Descricao { get => this.descricao; set => this.descricao = value; }
        public Aluno[] Alunos { get => this.alunos; }

        public Disciplina(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            for (int ii = 0; ii < alunos.Length; ii++)
            {
                this.alunos[ii] = new Aluno();
            }
            
        }

        public Disciplina(int id) : this(id, "") { }

        public Disciplina() : this(-1, "") {}

        public bool matricularAluno(Aluno aluno)
        {
            bool matriculou = false;
            for (int ii = 0; ii < alunos.Length; ii++)
            {
                if (alunos[ii].Id == aluno.Id)
                {
                    break;
                }
                if (alunos[ii].Id == -1)
                {
                    alunos[ii] = aluno;
                    matriculou = true;
                    break;
                }
            }
            return matriculou;
        }

        public Aluno pesquisarAluno (Aluno aluno)
        {
            Aluno achou = new Aluno();
            for (int ii = 0; ii < alunos.Length; ii++)
            {
                if (alunos[ii].Id == aluno.Id)
                {
                    achou = alunos[ii];
                }
            }
            return achou;
        }

        public bool desmatricularAluno (Aluno aluno)
        {
            int jj;
            bool podeRemover = (pesquisarAluno(aluno).Id != -1);
            if (podeRemover)
            {
                int ii = 0;
                while (ii < this.alunos.Length && this.alunos[ii].Id != aluno.Id)
                {
                    ii++;
                }
                for (jj = ii; jj < this.alunos.Length - 1; jj++)
                {
                    this.alunos[jj] = this.alunos[jj + 1];
                }
                this.alunos[jj] = new Aluno();
            }
            return podeRemover;
        }
    }
}
