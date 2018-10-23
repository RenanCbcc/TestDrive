
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using TestDrive.Droid;
using TestDrive.Media;
using Xamarin.Forms;

// Registring the class.
[assembly: Xamarin.Forms.Dependency(typeof(MainActivity))]
namespace TestDrive.Droid
{
    [Activity(Label = "TestDrive", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, IPhotographable

    {
        static Java.IO.File imageFile;
        public void TackPhotography()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            
            imageFile = takesFileImage();

            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(imageFile));
            Activity activity = Android.App.Application.Context as Activity;
            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File takesFileImage()
        {
            Java.IO.File imageFile;
            Java.IO.File directory = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures),"images");

            if (!directory.Exists())
            {
                directory.Mkdirs();
            }

            imageFile = new Java.IO.File(directory, "myphoto.jpg");
            return imageFile;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            MessagingCenter.Send<Java.IO.File>(imageFile, "takePgoto");
        }
    }
}