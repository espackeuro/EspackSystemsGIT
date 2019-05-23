

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using static RadioFXC.Values;

namespace RadioFXC
{
    [Activity(Label = "Radio REPAIRS - Loads")]
    public class LoadsMain : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        //private string cLoadNumber;
        //public string cRepairCode { get; set; }

        //public MainRepairs(string pUnitNumber, string pRepairCode)
        //{
        //    cUnitNumber = pUnitNumber;
        //    cRepairCode = pRepairCode;
        //}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            SetContentView(Resource.Layout.activity_main);

            this.Title = "Loads - Service " + Values.gService;
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            MenuItem1(this).SetTitle((GetString(Resource.String.title_loads_1)));
            MenuItem2(this).SetTitle((GetString(Resource.String.title_loads_2)));
            MenuItem3(this).SetTitle((GetString(Resource.String.title_loads_3)));
            //navigation.NavigationItemSelected += Navigation_NavigationItemSelected;

            navigation.SetOnNavigationItemSelectedListener(this);
        }


        public bool OnNavigationItemSelected(IMenuItem item)
        {
            using (var ft = FragmentManager.BeginTransaction())
            {
                switch (item.ItemId)
                {
                    case Resource.Id.navigation_1:
                        var intent = new Intent(this, typeof(MainScreen));
                        StartActivityForResult(intent, 2);
                        return true;

                    case Resource.Id.navigation_2:
                        ft.Replace(Android.Resource.Id.Content, new LoadsFragmentRepairs2Loads());
                        ft.Commit();
                        return true;


                    case Resource.Id.navigation_3:
                        ft.Replace(Android.Resource.Id.Content, new LoadsFragmentCloseLoads());
                        ft.Commit();
                        return true;

                }
            }
            return false;
        }
    }

}