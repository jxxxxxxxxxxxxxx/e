using System;
using System.Collections.Generic;
using e.Servico;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using e.Locais;
using Xamarin.Forms;
using e.Modelo;
using System.Net;

namespace e.Servico
{
    public class Servico
    {
        private static string URLEstado =
            "https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome&quot";
        private static string URLMunicipio =
            "https://servicodados.ibge.gov.br/api/v1/localidades/estados/{0}/municipios";

        public static List<Estado> GetEstados()
        {
            WebClient WC = new WebClient();
            string conteudo = WC.DownloadString(URLEstado);
            return JsonConvert.DeserializeObject<List<Estado>>(conteudo);
        }

        public static List<Municipio> GetMunicipio(int estado)
        {
            string NewURL = string.Format(URLMunicipio, estado);
            WebClient WC = new WebClient();
            string conteudo = WC.DownloadString(NewURL);
            return JsonConvert.DeserializeObject<List<Municipio>>(conteudo);
        }
    }
}