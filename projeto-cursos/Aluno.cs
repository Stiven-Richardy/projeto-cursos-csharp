using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace projeto_cursos
{
    internal class Aluno
    {
        private int id;
        private string nome;

        public int Id { get => this.id; set => this.id = value; }
        public string Nome { get => this.nome; set => this.nome = value; }

        public Aluno(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public Aluno(int id):this(id, "") {}
        public Aluno() : this(-1, "") {}

        
        public bool podeMatricular (Curso curso)
        {
            bool pode = true;
            int numMatriculas = 0;
            foreach(Disciplina d in curso.Disciplinas)
            {
                if (d.pesquisarAluno(this).Id != -1)
                {
                    numMatriculas++;
                }
                if (numMatriculas == 6)
                {
                    pode = false;
                    break;
                }
            }
            return pode;
        }
        
    }
}
