using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ExpeditionStories.Helpers.Interfaces;
using ExpeditionStories.Models;
using Xamarin.Forms;
using ExpeditionStories.ViewModels;

namespace ExpeditionStories.Services
{
    public class APIHelper
    {

        private ServiceHelper _ServiceHelper = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ExpeditionStories.Services.APIHelper"/> class.
        /// </summary>
        public APIHelper()
        {
            _ServiceHelper = new ServiceHelper();
        }

        /// <summary>
        /// Logins the APIA sync.
        /// </summary>
        /// <returns>The APIA sync.</returns>
        /// <param name="url">URL.</param>
        /// <param name="request">Request.</param>
        /// <typeparam name="U">The 1st type parameter.</typeparam>
        public async Task<Dictionary<string, string>> LoginAsync<U>(string url, U request)
        {
            return await _ServiceHelper.PostAsync(url, request);
        }

        /// <summary>
        /// Logins the APIA sync.
        /// </summary>
        /// <returns>The APIA sync.</returns>
        /// <param name="url">URL.</param>
        /// <param name="request">Request.</param>
        /// <typeparam name="U">The 1st type parameter.</typeparam>
        public async Task<Dictionary<string, string>> LogoutAsync<U>(string url, U request)
        {
            return await _ServiceHelper.PostAsync(url, request);
        }

        /// <summary>
        /// Saves the action item.
        /// </summary>
        /// <returns>The action item.</returns>
        /// <param name="request">Request.</param>
        /// <typeparam name="U">The 1st type parameter.</typeparam>
        //public async Task<Dictionary<string, string>> SaveActionItem<U>(U request)
        //{
        //    SaveItemRequest requestPayload = new SaveItemRequest
        //    {
        //        header = new RequestHeader(),
        //        payload = request as SaveItemRequestPayload
        //    };
        //    return await _ServiceHelper.PostAsync(ServiceURL.URL_SaveActionItem, requestPayload);
        //}

        //public async Task<Dictionary<string, string>> UpdateContactNumber<U>(U request)
        //{
        //    UpdateContactRequest requestPayload = new UpdateContactRequest
        //    {
        //        header = new RequestHeader(),
        //        payload = request as UpdateContactRequestPayload
        //    };
        //    return await _ServiceHelper.PostAsync(ServiceURL.URL_UpdatingEmployeeContact, requestPayload);
        //}
    }
}
