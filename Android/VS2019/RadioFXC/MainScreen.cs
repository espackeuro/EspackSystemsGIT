using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.Design.Internal;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static RadioFXC.Values;
using AccesoDatosNet;

namespace RadioFXC
{
    [Activity(Label = "Repairs Home")]
    public class MainScreen : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            MenuItem1(this).SetTitle((GetString(Resource.String.title_main_1)));
            MenuItem2(this).SetTitle((GetString(Resource.String.title_main_2)));
            MenuItem3(this).SetTitle((GetString(Resource.String.title_main_3)));
            //navigation.NavigationItemSelected += Navigation_NavigationItemSelected;

            navigation.SetOnNavigationItemSelectedListener(this);
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            using (var ft = FragmentManager.BeginTransaction())
            {
                switch (item.ItemId)
                {
                    case Resource.Id.navigation_1:
                        //ft.Replace(Android.Resource.Id.Content, new RepairsFragment());
                        //ft.Commit();
                        return true;

                    case Resource.Id.navigation_2:
                        ft.Replace(Android.Resource.Id.Content, new LoadsFragment());
                        ft.Commit();
                        return true;

                    case Resource.Id.navigation_3:
                        System.Environment.Exit(0);
                        return true;

                }
            }
            return false;
        }
    }

    public static class Loads
    {
        public static string LoadNumber { get; set; }
        public static DateTime LoadDate { get; set; }
        public static int RepairNumber
        {
            get
            {
                using (var lRS = new DynamicRS())
                {
                    lRS.Open("Select num=count(*) from Repairs where LoadNumber='" + LoadNumber + "' and service='" + Values.gService + "'", Values.gDatos);
                    return Convert.ToInt32(lRS["num"]);
                }
            }
        }
        public static string Label
        {
            get
            {
                return LoadNumber + " (" + RepairNumber.ToString() + ")";
            }
        }
    }
    /*
[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
{
    TextView textMessage;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        SetContentView(Resource.Layout.activity_main);

        textMessage = FindViewById<TextView>(Resource.Id.message);
        BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
        navigation.SetOnNavigationItemSelectedListener(this);
    }
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
        Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
    public bool OnNavigationItemSelected(IMenuItem item)
    {
        switch (item.ItemId)
        {
            case Resource.Id.navigation_home:
                textMessage.SetText(Resource.String.title_home);
                return true;
            case Resource.Id.navigation_dashboard:
                textMessage.SetText(Resource.String.title_dashboard);
                return true;
            case Resource.Id.navigation_notifications:
                textMessage.SetText(Resource.String.title_notifications);
                return true;
        }
        return false;
    }
}
*/
}