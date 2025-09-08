using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_cursos
{
    internal class Escola
    {
        private Curso[] cursos = new Curso[5];
        public Curso[] Cursos{ get => this.cursos; }

        public Escola()
        {
            for (int ii = 0; ii < cursos.Length; ii++)
            {
                this.cursos[ii] = new Curso();
            }
        }

        public Escola (Curso[] cursos)
        {
            for (int ii = 0; ii < cursos.Length; ii++)
            {
                this.cursos[ii] = new Curso();
            }
        }

        public bool adicionarCurso(Curso curso)
        {
            bool adicionou = false;
            for (int ii = 0; ii < cursos.Length; ii++)
            {
                if (cursos[ii].Id == curso.Id)
                {
                    break;
                }
                if (cursos[ii].Id == -1)
                {
                    cursos[ii] = curso;
                    adicionou = true;
                    break;
                }
            }
            return adicionou;
        }

        public Curso pesquisarCurso(Curso curso)
        {
            Curso achou = new Curso();
            for (int ii = 0; ii < cursos.Length; ii++)
            {
                if (cursos[ii].Id == curso.Id)
                {
                    achou = cursos[ii];
                }
            }
            return achou;
        }

        public bool removerCurso(Curso curso)
        {
            int jj;
            bool podeRemover = (pesquisarCurso(curso).Id != -1);
            if (podeRemover)
            {
                int ii = 0;
                while (ii < this.cursos.Length && this.cursos[ii].Id != curso.Id)
                {
                    ii++;
                }
                for (jj = ii; jj < this.cursos.Length - 1; jj++)
                {
                    this.cursos[jj] = this.cursos[jj + 1];
                }
                this.cursos[jj] = new Curso();
            }
            return podeRemover;
        }
    }
}
