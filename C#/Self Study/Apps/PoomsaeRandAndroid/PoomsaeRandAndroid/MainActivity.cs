using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;

namespace PoomsaeRandAndroid
{
    [Activity(Label = "Red Dragon Taekwondo", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        //Referring text fields
        TextView txtForm;
        TextView txtFocus;
        //Assigning relative arrays
        private string[] colour = new string[] { "Chon Ji Heung", "Taeguk 1", "Taeguk 2", "Taeguk 3", "Taeguk 4", "Taeguk 5", "Taeguk 6", "Taeguk 7", "Taeguk 8", "Palgue 7", "Palgue 8" };
        private string[] black = new string[] { "Koryo", "Keumgang", "Taebaek", "Pyongwon", "Sipjin", "Jitae", "Cheonkwon", "Hansu", "Ilyo" };
        private string[] all = new string[] { "Chon Ji Heung", "Taeguk 1", "Taeguk 2", "Taeguk 3", "Taeguk 4", "Taeguk 5", "Taeguk 6", "Taeguk 7", "Taeguk 8", "Palgue 7", "Palgue 8",
            "Koryo", "Keumgang", "Taebaek", "Pyongwon", "Sipjin", "Jitae", "Cheonkwon", "Hansu", "Ilyo" };
        private string[] focus = new string[] { "Synchronize", "Bopping", "Tempo", "Snap", "Setup", "Body Angle", "Kicks", "Blocks", "Transitions", "Stances" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //txtForm = FindViewById<TextView>(Resource.Id.);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private string getRandom(string[] arr)
        {
            System.Random rand = new System.Random();
            int index = rand.Next(arr.Length);

            return arr[index];
        }
    }
}