using System;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

using Android.OS;

namespace GooglePlayServicesTest
{
    [Activity(Label = "Velkommen til Broager Arkiv: Kort ", MainLauncher = true)]
    public class MainActivity : Android.Support.V4.App.FragmentActivity, IOnMapReadyCallback
    {
        /**
     * Note that this may be null if the Google Play services APK is not available.
     */
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            GetMarkers();
            
            SetContentView(Resource.Layout.basic_demo);

            var mapFragment = ((SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map));
            mapFragment.GetMapAsync(this);
        }

        /**
     * This is where we can add markers or lines, add listeners or move the camera. In this case, we
     * just add a marker near Africa.
     */
        public void OnMapReady(GoogleMap map)
        {
            map.MoveCamera(CameraUpdateFactory.NewLatLngZoom(new LatLng(54.89050133, 9.6694534), 12.0f));
            map.AddMarker(new MarkerOptions().SetPosition(new LatLng(54.89050133, 9.6694534)).SetTitle("Broager"));

        }

        public void GetMarkers()
        {
            
            // get email & password


            //    using (var webClient = new System.Net.WebClient())
            //{
            //    var json = webClient.DownloadString("10.176.164.33:3000");
               
            //}
        }

    }
}

