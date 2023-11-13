using Newtonsoft.Json;
using RestSharp;
using SeguroVeiculos.Web.Integration.Interface;
using SeguroVeiculos.Web.Models;
using System.Net;

namespace SeguroVeiculos.Web.Integration
{
    public class SeguroIntegracao : ISeguroIntegracao
    {
        private readonly string baseUrl;

        public SeguroIntegracao()
        {
            baseUrl = "http://localhost:54274/api/Seguro";
        }

        public void Gravar(SeguroViewModel model)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                         (sender, cert, chain, sslPolicyErrors) => true;

                var client = new RestClient(baseUrl);
                var request = new RestRequest("", Method.Post);
                request.AddJsonBody(model);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {                    
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SeguroViewModel> ListarSegurados(string nomeOudocumento)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                         (sender, cert, chain, sslPolicyErrors) => true;

                var endPoint = string.IsNullOrEmpty(nomeOudocumento) ? "lista" : $"?nomeOuDocumento={nomeOudocumento}";

                var client = new RestClient(baseUrl);
                var request = new RestRequest(endPoint, Method.Get);

                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var segurados = JsonConvert.DeserializeObject<List<SeguroViewModel>>(response.Content);
                    return segurados;
                }
                else
                {
                    return new List<SeguroViewModel>();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
