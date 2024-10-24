using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Kotlin.Reflect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e.Droid
{
    [Activity(Theme ="@style/Theme.inicial", MainLauncher =true, NoHistory =true)]
    public class inicial : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(5000);
            StartActivity(typeof(MainActivity));
        }
    }
}