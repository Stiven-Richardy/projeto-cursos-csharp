using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace projeto_cursos
{
    internal class Curso
    {
        private int id;
        private string descricao;
        private Disciplina[] disciplinas = new Disciplina[12];

        public int Id { get => id; set => this.id = value; }
        public string Descricao { get => this.descricao; set => this.descricao = value; }
        public Disciplina[] Disciplinas { get => this.disciplinas; }


        public Curso(int id, string descricao)
        {
            this.id = id;
            this.descricao = descricao;
            for (int ii = 0; ii < disciplinas.Length; ii++)
            {
                this.disciplinas[ii] = new Disciplina();
            }
        }

        public Curso(int id) : this(id, "") { }

        public Curso() : this(-1, "") { }

        public bool adicionarDisciplina (Disciplina disciplina)
        {
            bool adicionou = false;
            for (int ii = 0; ii < disciplinas.Length; ii++)
            {
                if (disciplinas[ii].Id == disciplina.Id)
                {
                    break;
                }
                if (disciplinas[ii].Id == -1)
                {
                    disciplinas[ii] = disciplina;
                    adicionou = true;
                    break;
                }
            }
            return adicionou;
        }

        public Disciplina pesquisarDisciplina (Disciplina disciplina)
        {
            Disciplina achou = new Disciplina();
            for (int ii = 0; ii < disciplinas.Length; ii++)
            {
                if (disciplinas[ii].Id == disciplina.Id)
                {
                    achou = disciplinas[ii];
                }
            }
            return achou;
        }

        public bool removerDisciplina (Disciplina disciplina)
        {
            int jj;
            bool podeRemover = (pesquisarDisciplina(disciplina).Id != -1);
            if (podeRemover)
            {
                int ii = 0;
                while (ii < this.disciplinas.Length && this.disciplinas[ii].Id != disciplina.Id)
                {
                    ii++;
                }
                for (jj = ii; jj < this.disciplinas.Length - 1; jj++)
                {
                    this.disciplinas[jj] = this.disciplinas[jj + 1];
                }
                this.disciplinas[jj] = new Disciplina();
            }
            return podeRemover;
        }
    }
}
