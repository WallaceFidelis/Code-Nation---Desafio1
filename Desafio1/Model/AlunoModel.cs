using System;

namespace Desafio1.Model
{
    class AlunoModel
    {
        //Número de inscrição do aluno
        public string NU_INSCRICAO { get; set; }
        //Nota de Ciências da natureza
        private double NU_NOTA_CN { get; set; }
        //Nota de Ciências Humanas
        private double NU_NOTA_CH { get; set; }
        //Nota de Linguagens e códigos
        private double NU_NOTA_LC { get; set; }
        //Nota de Matemática
        private double NU_NOTA_MT { get; set; }
        //Nota de Redação
        private double NU_NOTA_REDACAO { get; set; }
        //Soma total das notas com a aplicação dos pesos de cada matéria       
        public double NOTA_FINAL
        {
            get
            {
                //return Math.Round(((NU_NOTA_MT * 3 + NU_NOTA_CH * 2 + NU_NOTA_LC * 1.5 + NU_NOTA_CH + NU_NOTA_REDACAO * 3) / 10.5), 1);
                return Math.Round(((NU_NOTA_MT * 3.0 + NU_NOTA_CN * 2.0 + NU_NOTA_LC * 1.5 + NU_NOTA_CH + NU_NOTA_REDACAO * 3.0) / 10.5),2);
            }
        }

        /// <summary>
        /// Método construtor que recebe um array com as informações de um aluno
        /// </summary>
        /// <param name="informacaoAluno"></param>
        public AlunoModel(string[] informacaoAluno)
        {
            NU_INSCRICAO = informacaoAluno[1];
            NU_NOTA_CN = (informacaoAluno[97] == "") ? 0 : Double.Parse(informacaoAluno[97].Replace('.', ','));
            NU_NOTA_CH = (informacaoAluno[98] == "") ? 0 : Double.Parse(informacaoAluno[98].Replace('.', ','));
            NU_NOTA_LC = (informacaoAluno[99] == "") ? 0 : Double.Parse(informacaoAluno[99].Replace('.', ','));
            NU_NOTA_MT = (informacaoAluno[100] == "") ? 0 : Double.Parse(informacaoAluno[100].Replace('.', ','));
            NU_NOTA_REDACAO = (informacaoAluno[116] == "") ? 0 : Double.Parse(informacaoAluno[116].Replace('.', ','));
        }
    }

    public class AlunoComparer : System.Collections.IComparer
    {
        public int Compare(object a, object b)
        {
            AlunoModel pa = a as AlunoModel;
            AlunoModel pb = b as AlunoModel;
            if (pa.NOTA_FINAL == pb.NOTA_FINAL) return 0;
            if (pa == null) return -1;
            if (pb == null) return 1;
            return pb.NOTA_FINAL.CompareTo(pa.NOTA_FINAL);
        }
    }
}
