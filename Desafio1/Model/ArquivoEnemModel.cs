using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1.Model
{
    class ArquivoEnemModel
    {
        public string[] cabecalho { get; set; }
        public ArrayList alunos { get; set; }

        public ArquivoEnemModel(ArrayList linhas, int quantidadeMelhoresAlunos)
        {
            this.cabecalho = linhas[0].ToString().Split(',');
            linhas.Remove(linhas[0]);

            ArrayList alunos = new ArrayList();
            foreach (var linha in linhas)
            {
                alunos.Add(new AlunoModel(((string[])linha)[0].Split(',')));
                alunos.Sort(new AlunoComparer());
                if(alunos.Count > quantidadeMelhoresAlunos)
                {
                    alunos.RemoveAt(alunos.Count - 1);
                }
            }
            this.alunos = alunos;
        }
    }
}
