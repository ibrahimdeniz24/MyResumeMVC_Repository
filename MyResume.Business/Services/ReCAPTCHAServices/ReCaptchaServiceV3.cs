using Microsoft.Extensions.Options;
using MyResume.Domain;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyResume.Business.Services.ReCAPTCHAServices
{
    public class ReCaptchaServiceV3 : IReCAPTCHAService
    {
        private readonly ReCaptchaSettings _settings;
        private readonly HttpClient _httpClient;

        public ReCaptchaServiceV3(IOptions<ReCaptchaSettings> options, HttpClient httpClient)
        {
            _settings = options.Value;
            _httpClient = httpClient;
        }

        public async Task<bool> ValidateCaptchaAsync(string captchaResponse)
        {
            try
            {

                var url = $"https://www.google.com/recaptcha/api/siteverify?secret={Uri.EscapeDataString(_settings.SecretKey)}&response={Uri.EscapeDataString(captchaResponse)}";


                var result = await _httpClient.PostAsync(url, null);
                var jsonResponse = await result.Content.ReadAsStringAsync();
                var captchaResult = JsonConvert.DeserializeObject<ReCaptchaResponse>(jsonResponse);

                return captchaResult.Success;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }
}
