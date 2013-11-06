using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AutofacWebApi
{
    public class PrognoseController:ApiController
    {
        private IPrognoseRepository prognoseRepository;

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