using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PracBD.Droid;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Dependency(typeof(ISQLite_Droid))]

namespace PracBD.Droid
{
   public class ISQLite_Droid : ISQLite
    {
        public String GetLocalFilePath(string Filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(path, Filename);


        }
    }
}