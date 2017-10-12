using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ViewModels
{
    public abstract class ApiControllerHttpClientBase
    {
        public const string WebApiRootUrlAppSettingName = "WebApiRootUrl";
        /// <summary>
        /// Gets or sets the root path.
        /// </summary>
        /// <value>
        /// The root path.
        /// </value>
        ///
        string RootPath { get; set; }

        public abstract string ControllerName { get; }

        protected static HttpClient Client = new HttpClient();

        public ApiControllerHttpClientBase(string rootPath)
        {
            this.RootPath = rootPath;
        }

        public string GetHttpRequestUrl(string actionName, Dictionary<string, string> parameters)
        {
            List<string> parametersInList = new List<string>();
            foreach (var kvPair in parameters)
            {
                parametersInList.Add(string.Format("{0}={1}", kvPair.Key, kvPair.Value));
            }
            string parametersInString = String.Join("&", parametersInList);

            return GetHttpRequestUrl(RootPath, ControllerName, actionName, parametersInString);
        }

        //public string GetHttpRequestUrl(string actionName, string parameters)
        //{
        //    return GetHttpRequestUrl(RootPath, ControllerName, actionName, parameters);
        //}

        public string GetHttpRequestUrl(string actionName)
        {
            return GetHttpRequestUrl(RootPath, ControllerName, actionName, null);
        }

        public static string GetHttpRequestUrl(string rootPath, string controllerName, string actionName, string parameters)
        {
            StringBuilder retval = new StringBuilder(rootPath.TrimEnd('/'));
            if (!string.IsNullOrWhiteSpace(controllerName))
            {
                retval.Append('/');
                retval.Append(controllerName.TrimStart('/').TrimEnd('/'));
            }
            if (!string.IsNullOrWhiteSpace(actionName))
            {
                retval.Append('/');
                retval.Append(actionName.TrimStart('/').TrimEnd('/'));
            }
            if (!string.IsNullOrWhiteSpace(parameters))
            {
                retval.Append('?');
                retval.Append(parameters.TrimStart('?').TrimEnd('/'));
            }
            return retval.ToString();
        }

        public async Task<TResponse> Get<TResponse>(string url)
            where TResponse: class, new()
        {
            var response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(content);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<TViewModel> GetItemViewModel<TViewModel>(string url)
            where TViewModel : class, Framework.ViewModels.IViewModelItemBase, new()
        {
            var response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TViewModel>(content);
                return result;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = new TViewModel();
                result.StatusOfResult = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                result.StatusMessageOfResult = content;
                return result;
            }
        }

        public async Task<TViewModel> GetEntityRelated<TViewModel>(string url)
            where TViewModel : class, Framework.ViewModels.IViewModelEntityRelatedBase, new()
        {
            var response = await Client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TViewModel>(content);
                return result;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = new TViewModel();
                result.StatusOfMasterEntity = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                result.StatusMessageOfMasterEntity = content;
                return result;
            }
        }

        public async Task<TViewModel> Post<TViewModel>(string url, TViewModel vm)
            where TViewModel : class, Framework.ViewModels.IViewModelBase, new()
        {
            string requestJSON = JsonConvert.SerializeObject(vm, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await Client.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TViewModel>(content);
                    return result;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    vm.StatusOfResult = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    vm.StatusMessageOfResult = content;
                    return vm;
                }
            }
            catch(Exception ex)
            {
                vm.StatusOfResult = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                vm.StatusMessageOfResult = ex.Message;
                return vm;
            }
        }

        public async Task<TViewModel> PostIViewModelEntityRelatedBase<TViewModel>(string url, TViewModel vm)
            where TViewModel : class, Framework.ViewModels.IViewModelEntityRelatedBase, new()
        {
            string requestJSON = JsonConvert.SerializeObject(vm, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");

            try
            {
                var response = await Client.PostAsync(url, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TViewModel>(content);
                    return result;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    vm.StatusOfMasterEntity = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                    vm.StatusMessageOfMasterEntity = content;
                    return vm;
                }
            }
            catch (Exception ex)
            {
                vm.StatusOfMasterEntity = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                vm.StatusMessageOfMasterEntity = ex.Message;
                return vm;
            }
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request)
            where TResponse : class, Framework.CommonBLLEntities.IBusinessLogicLayerResponseMessageBase, new()
        {
            string requestJSON = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(content);
                return result;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var retval = new TResponse();
                retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                retval.ServerErrorMessage = content;
                return retval;
            }
        }

        public async Task<TResponse> Put<TRequest, TResponse>(string url, TRequest request)
            where TResponse : class, Framework.CommonBLLEntities.IBusinessLogicLayerResponseMessageBase, new()
        {
            string requestJSON = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(requestJSON, System.Text.Encoding.UTF8, "application/json");

            var response = await Client.PutAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(content);
                return result;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var retval = new TResponse();
                retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                retval.ServerErrorMessage = content;
                return retval;
            }
        }

        public async Task<TResponse> Delete<TResponse>(string url)
            where TResponse : class, Framework.CommonBLLEntities.IBusinessLogicLayerResponseMessageBase, new()
        {
            var response = await Client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(content);
                return result;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                var retval = new TResponse();
                retval.BusinessLogicLayerResponseStatus = Framework.CommonBLLEntities.BusinessLogicLayerResponseStatus.MessageErrorDetected;
                retval.ServerErrorMessage = content;
                return retval;
            }
        }
    }
}

