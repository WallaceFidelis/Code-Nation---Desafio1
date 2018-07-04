using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1.Dao
{
    class ArquivoEnemDao
    {
        public static ArrayList LerCSV()
        {
            //Declaro o StreamReader para o caminho onde se encontra o arquivo 
            System.IO.StreamReader rd = new System.IO.StreamReader(@"Data\train.csv");

            //Declaro uma string que será utilizada para receber a linha completa do arquivo 
            string linha = null;

            //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado 
            ArrayList linhaseparada = new ArrayList();

            //realizo o while para ler o conteudo da linha 
            while ((linha = rd.ReadLine()) != null)
            {
                //com o split adiciono a string 'quebrada' dentro do array 
                linhaseparada.Add(linha.Split(';'));
            }
            rd.Close();
            return linhaseparada;
        }
    }
}
