using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GooglePlayServicesTest
{
    [Activity(Label = "Velkommen til Broager Arkiv: Kort ", MainLauncher = true)]
    public class MainActivity : Android.Support.V4.App.FragmentActivity, IOnMapReadyCallback
    {

        public WebClient Client = new WebClient();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.basic_demo);

            var mapFragment = ((SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map));
            mapFragment.GetMapAsync(this);
           
        }

        public void OnMapReady(GoogleMap map)
        {
            map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(54.89050133, 9.6694534), 12.0f));

            Client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
            Client.Headers.Add("X-Requested-With", "XMLHttpRequest");

            string dataString = @"{""email"":""guestapp"",""password"":""password""}";
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
            byte[] responseBytes = Client.UploadData(new Uri("http://10.176.164.42:3000/login"), dataBytes);
            string responseString = Encoding.UTF8.GetString(responseBytes);
            Console.WriteLine(responseString);

            var json = JsonConvert.DeserializeObject<Source.TokenJedi>(responseString);

            Client.Headers["x-access-token"] = json.token;

            byte[] responseByte = Client.DownloadData(new Uri("http://10.176.164.42:3000/api/attraction"));
            string responseStrings = Encoding.UTF8.GetString(responseByte);

            List<Source.GetAPIMarkers> attractions = JsonConvert.DeserializeObject<List<Source.GetAPIMarkers>>(responseStrings);

            foreach (var attract in attractions)
            {

                Console.WriteLine(attract.headline);
                Console.WriteLine(attract.latitude);
                Console.WriteLine(attract.longitude);
                 map.AddMarker(new MarkerOptions().SetPosition(new LatLng(Double.Parse(attract.longitude), Double.Parse(attract.latitude))).SetTitle(attract.headline));
                
            }



            //map.AddMarker(new MarkerOptions().SetPosition(new LatLng(54.89050133, 9.6694534)).SetTitle("Broager"));
            // GetMarkers(map);
        }

        //public void GetMarkers(GoogleMap map)
        //{
        //    Client.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=utf-8");
        //    Client.Headers.Add("X-Requested-With", "XMLHttpRequest");

        //    string dataString = @"{""email"":""guestapp"",""password"":""password""}";
        //    byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);
        //    byte[] responseBytes = Client.UploadData(new Uri("http://10.176.164.42:3000/login"), dataBytes);
        //    string responseString = Encoding.UTF8.GetString(responseBytes);
        //    Console.WriteLine(responseString);

        //    var json = JsonConvert.DeserializeObject<Source.TokenJedi>(responseString);

        //    Client.Headers["x-access-token"] = json.token;

        //    byte[] responseByte = Client.DownloadData(new Uri("http://10.176.164.42:3000/api/attraction"));
        //    string responseStrings = Encoding.UTF8.GetString(responseByte);

        //    List<Source.GetAPIMarkers> attractions = JsonConvert.DeserializeObject<List<Source.GetAPIMarkers>>(responseStrings);

        //    foreach (var attract in attractions)
        //    {
        //        map.AddMarker(new MarkerOptions().SetPosition(new LatLng(Double.Parse(attract.longitude), Double.Parse(attract.latitude))).SetTitle(attract.headline));
        //    }

        }

    }



