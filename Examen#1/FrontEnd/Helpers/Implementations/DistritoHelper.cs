using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class DistritoHelper : IDistritoHelper
    {
        IServiceRepository ServiceRepository;

        public DistritoHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public DistritoViewModel AddDistrito(DistritoViewModel distrito)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Distrito", Convertir(distrito));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  distritoAPI = JsonConvert.DeserializeObject<Distrito>(content);
            }

            return distrito;
        }


        Distrito Convertir(DistritoViewModel distrito)
        {
            return new Distrito
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre,
            };
        }

        DistritoViewModel Convertir(Distrito distrito)
        {
            return new DistritoViewModel
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre,
            };
        }


        public DistritoViewModel DeleteDistrito(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Distrito/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new DistritoViewModel();
        }

        public List<DistritoViewModel> GetDistritos()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/distrito");
            List<Distrito> resultado = new List<Distrito>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Distrito>>(content);
            }
            List<DistritoViewModel> lista = new List<DistritoViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public DistritoViewModel GetDistrito(int id)
        {
            DistritoViewModel distrito = new DistritoViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Distrito/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                distrito = Convertir(JsonConvert.DeserializeObject<Distrito>(content));
            }

            return distrito;
        }

        public DistritoViewModel UpdateDistrito(DistritoViewModel distrito)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Distrito", Convertir(distrito));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  distritoAPI = JsonConvert.DeserializeObject<Distrito>(content);
            }

            return distrito;
        }
    }
}