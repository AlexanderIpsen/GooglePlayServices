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
        public List<string> years { get; set; }
        public List<string> tags { get; set; }
        public List<object> filesNames { get; set; }
        public string _id { get; set; }
        public string attractId { get; set; }
        public string headline { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int __v { get; set; }

    }
}