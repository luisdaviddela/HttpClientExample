using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using Xamarin.Forms;

using System.Net;
using System.IO;
using System.Collections.ObjectModel;

namespace HttpApp
{
    public partial class MainPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
        List<Employee> ListaEmpleados = new List<Employee>();
        string UrlJson = "http://jsonplaceholder.typicode.com/users";
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Httpclient_Clicked(object sender, EventArgs e)
        {
            var responseString = await client.GetStringAsync(UrlJson);
            string resp = Convert.ToString(responseString);
            var obj = JsonConvert.DeserializeObject<object>(resp);
            string data = Convert.ToString(obj);
            ListaEmpleados= JsonConvert.DeserializeObject<List<Employee>>(data);
            await Application.Current.MainPage.DisplayAlert("Response", data, "Ok");
        }

        private void Httpwebrequest_Clicked(object sender, EventArgs e)
        {
            HttpWebRequest request = WebRequest.Create(UrlJson) as HttpWebRequest;
            string resp;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                resp = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<object>(resp);
                string data = Convert.ToString(obj);
                List<Employee> Observable = JsonConvert.DeserializeObject<List<Employee>>(data);
                ListaEmpleados = JsonConvert.DeserializeObject<List<Employee>>(data);
                Application.Current.MainPage.DisplayAlert("Response", data, "Ok");
            }
        }
    }
}
