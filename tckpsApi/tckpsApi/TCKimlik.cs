using kpsconnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace tckpsApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCKimlik : ControllerBase
    {

        KPSWebServiceClient kpsServiceClient;
        [HttpPost]
        [Route("TcDogrula")]
        public async Task<IActionResult> TcDogrula(Parametters parametters)
        {


            return Ok(await kpsServiceClient.TCKimlikDogrula(parametters));



        }


        public TCKimlik()
        {
            kpsServiceClient = new KPSWebServiceClient();
        }
    }
}

