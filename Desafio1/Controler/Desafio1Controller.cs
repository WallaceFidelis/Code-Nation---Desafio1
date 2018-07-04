using Desafio1.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1.Controler
{
    class Desafio1Controller
    {
        private RespostaModel resposta;
        private string url;
        public Desafio1Controller(string url, string token, string email, int quantidadeMelhoresAlunos)
        {
            ArquivoEnemModel arquivo = new ArquivoEnemModel(Dao.ArquivoEnemDao.LerCSV(), quantidadeMelhoresAlunos);
            this.resposta = new RespostaModel(token, email, arquivo.alunos);

            this.url = url;
        }

        public async Task<string> postResposta()
        {
            HttpClient client = new HttpClient();

            var content = JsonConvert.SerializeObject(resposta, Formatting.Indented);
            
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(this.url, byteContent);
            string responseString = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK) return responseString;
            return ("Erro: "+response.StatusCode.ToString());
        }
    }
}
