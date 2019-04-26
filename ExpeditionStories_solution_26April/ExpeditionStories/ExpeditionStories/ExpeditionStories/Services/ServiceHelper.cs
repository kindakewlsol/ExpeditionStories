using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ExpeditionStories.AppConstants;
using ExpeditionStories.Helpers;
using ExpeditionStories.Helpers.Renderers;
using ExpeditionStories.Models;
using ExpeditionStories.ViewModels;
using ExpeditionStories.ViewModels.Common;
using ExpeditionStories.ViewModels.Users;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
namespace ExpeditionStories.Services
{
    public class ServiceHelper : BaseViewModel
    {
        /// <summary>
        /// Private Varaibles.
        /// </summary>
        private HttpClient httpClient;
        private Dictionary<string, string> result;

        String ErrorMessage = String.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ExpeditionStories.Services.ServiceHelper"/> class.
        /// </summary>
        public ServiceHelper()
        {
            result = new Dictionary<string, string>();
            httpClient = new HttpClient
            {
                MaxResponseContentBufferSize = 256000 * 100,
                Timeout = TimeSpan.FromSeconds(30 * 1000)
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Posts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <param name="request">Request.</param>
        /// <typeparam name="U">The 1st type parameter.</typeparam>
        public async Task<Dictionary<string, string>> PostAsync<U>(string url, U request)
        {
            //Clear previous saved result
            result.Clear();

            ErrorMessage = Constants.GLOBAL_ERROR;
            //TODO Network Check HERE
            CheckNetwork();

            try
            {
                Debug.WriteLine("URL:   " + url);
                Debug.WriteLine("Request:   " + JsonConvert.SerializeObject(request));

                var response = await httpClient.PostAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

                Debug.WriteLine("Response StatusCode: " + response.StatusCode);

                switch ((int)response.StatusCode)
                {
                    case 400:
                        ErrorMessage = Constants.BAD_REQUEST;
                        break;
                }
                if (response.IsSuccessStatusCode)
                {
                    var StringResponse = response.Content.ReadAsStringAsync().Result;
                    JObject JSONResponse = JObject.Parse(StringResponse);
                    Debug.WriteLine("Success Response:   " + JsonConvert.SerializeObject(JSONResponse));
                    if (JSONResponse["header"] != null)
                    {
                        JObject header = JObject.Parse(JSONResponse["header"].ToString());
                        if (header["error_id"] != null && (Int32.Parse(header["error_id"].ToString()) == 0 || Int32.Parse(header["error_id"].ToString()) == 200))
                        {
                            try
                            {
                                JObject payload = JObject.Parse(JSONResponse["payload"].ToString());
                            }
                            catch (Exception ee)
                            {

                            }

                            result.Add("Success", "True");
                            result.Add("ErrorMessage", header["error_message"].ToString());
                            result.Add("Response", StringResponse);
                            return result;
                        }
                        else
                        {
                            string ErrorMSG = header["error_message"].ToString();
                            if ((header["error_id"].ToString() == "7" && url.Contains("/Authenticate/Login")))
                                ErrorMSG = AppConstants.Constants.PLEASE_ENTER_VALID_credentials;
                            result.Add("ErrorId", header["error_id"].ToString());
                            result.Add("ErrorMessage", ErrorMSG);

                            int error_id = -1;
                            try
                            {
                                error_id = Convert.ToInt16(header["error_id"].ToString());
                            }
                            catch (Exception ee)
                            {

                            }
                            return result;
                        }
                    }
                    else
                    {
                        JObject header = JObject.Parse(JSONResponse.ToString());
                        if (header["error_id"] != null && (Int32.Parse(header["error_id"].ToString()) == 0 || Int32.Parse(header["error_id"].ToString()) == 200))
                        {
                            result.Add("Success", "True");
                            result.Add("ErrorMessage", header["error_message"].ToString());
                            result.Add("Response", StringResponse);
                            return result;
                        }
                        else
                        {
                            result.Add("ErrorId", header["error_id"].ToString());
                            result.Add("ErrorMessage", header["error_message"].ToString());
                            return result;
                        }
                    }
                }
                result.Add("ErrorId", response.StatusCode.ToString());
                result.Add("ErrorMessage", ErrorMessage);
                return result;
            }
            catch (Exception ee)
            {
                //Clear previous saved result
                Debug.WriteLine("Service Exception:   " + ee.Message);
                result.Clear();
                result.Add("ErrorId", "-1");
                result.Add("ErrorMessage", ErrorMessage);
                return result;
            }
        }
    }
}
