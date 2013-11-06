using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleInjectorWebApi
{
    public class PrognoseController:ApiController
    {
        private readonly IPrognoseRepository prognoseRepository;

        public PrognoseController(IPrognoseRepository prognoseRepository)
        {
            this.prognoseRepository = prognoseRepository;
        }

        public HttpResponseMessage GetPrognosis()
        {
            return Request.CreateResponse(HttpStatusCode.OK, prognoseRepository.GetPrognoses());
        }
    }
}