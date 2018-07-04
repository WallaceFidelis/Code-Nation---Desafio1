using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1.Model
{
    class RespostaModel
    {
        public string token { get; set; }
        public string email { get; set; }
        public ArrayList answer { get; set; }

        public RespostaModel(string token, string email, ArrayList alunos)
        {
            this.token = token;
            this.email = email;
            this.answer = alunos;
        }

        public static object toJson(RespostaModel resposta)
        {
            var json = JsonConvert.SerializeObject(resposta);
            return json;
        }
    }
}
