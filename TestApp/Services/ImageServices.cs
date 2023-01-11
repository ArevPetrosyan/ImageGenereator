using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestApp.Models;

namespace TestApp.Services
{
    public static class ImageServices
    {
        public static async Task<ImageModel> GetImageData(Guid id)
        {
            ImageModel imageModel = null;
            try
            {
                string url = $"https://mobile.netix.ru/MobileWebResource.asmx/GetTextAndPicture?id={id}";

                using (HttpClient client = new HttpClient())
                {
                     HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        imageModel = JsonConvert.DeserializeObject<ImageModel>(content);
                    }
                }   
            }
            catch
            {
                return null;
            }
            return imageModel;
        }
    }
}
