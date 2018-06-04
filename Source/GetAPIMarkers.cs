using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GooglePlayServicesTest.Source
{
    class GetAPIMarkers
    {

        public Array Tags { get; set; }
        public Array Years { get; set; }
        public Array FileName { get; set; }
        public string Attractions { get; set; }
        public string AttractId { get; set; }
        public string Address { get; set; }
        public string Headline { get; set; }
        public string Desscription { get; set; }
        public string Subjects { get; set; }

    }
}