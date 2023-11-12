using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultOurTestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient(); // bir istemci örneği oluşturuyoruz
            var responseMessage = await client.GetAsync("https://localhost:44370/api/Testimonials"); // api urlimizeden verileri alıyoruz.

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); // gelen verileri string formatında okuyoruz
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);


            }

            return View();
        }
    }
}
