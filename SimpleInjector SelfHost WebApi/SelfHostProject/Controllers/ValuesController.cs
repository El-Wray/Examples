using System.Web.Http;
using SelfHostProject.Services;

namespace SelfHostProject.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IValuesService _service;

        public ValuesController(IValuesService service)
        {
            _service = service;
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(_service.GetValues());
        }

        // GET api/values/id
        public IHttpActionResult Get(int id)
        {
            return Ok(_service.GetValue(id));
        }
    }
}