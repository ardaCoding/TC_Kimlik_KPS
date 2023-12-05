using System.Text;
using tckpsApi;

namespace kpsconnect
{
    public class KPSWebServiceClient
    {


        private readonly HttpClient _httpClient;
        private readonly string _serviceUrl = "https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx?op=TCKimlikNoDogrula";

        public KPSWebServiceClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> TCKimlikDogrula(Parametters parametters)
        {
            bool result = false;

            string soapRequest = $@"<?xml version=""1.0"" encoding=""utf-8""?>
        <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
            <soap:Body>
                <TCKimlikNoDogrula xmlns=""http://tckimlik.nvi.gov.tr/WS"">
                    <TCKimlikNo>{parametters.TCKimlikNo}</TCKimlikNo>
                    <Ad>{parametters.Ad}</Ad>
                    <Soyad>{parametters.Soyad}</Soyad>
                    <DogumYili>{parametters.DogumYili}</DogumYili>
                </TCKimlikNoDogrula>
            </soap:Body>
        </soap:Envelope>";


            var content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");
            var response = await _httpClient.PostAsync(_serviceUrl, content);

            if (response.IsSuccessStatusCode)
            {

                var responseContent = await response.Content.ReadAsStringAsync();
                result = responseContent.Contains("<TCKimlikNoDogrulaResult>true</TCKimlikNoDogrulaResult>");
            }

            return result;
        }


        // xmli modele deserilze edip true mu false mı bakmak


    }
}

