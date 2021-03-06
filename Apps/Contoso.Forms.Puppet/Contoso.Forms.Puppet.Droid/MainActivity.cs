﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Azure.Mobile;

namespace Contoso.Forms.Puppet.Droid
{
    [Activity(Label = "MCFPuppet", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //MobileCenter.Configure("cc09fb5d-86e9-4dd7-8cdd-4da63ad13677");
            MobileCenter.Configure("44cd8722-bfe0-4748-ac14-7692e031a8a5");

            LoadApplication(new App());
        }
    }
}
