﻿
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using TestDrive.Droid;
using TestDrive.Media;
using Xamarin.Forms;
using Plugin.Permissions;
using Android.Runtime;

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
            intent.PutExtra(MediaStore.ExtraOutput,
                Android.Net.Uri.FromFile(imageFile));


            //var activity = Android.App.Application.Context as Activity;
            Activity activity = Forms.Context as Activity;
                       
            activity.StartActivityForResult(intent, 0);
        }

        private static Java.IO.File takesFileImage()
        {
            Java.IO.File imageFile;
            Java.IO.File directory = new Java.IO.File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "Imagens");

            if (!directory.Exists())
            {
                directory.Mkdirs();
            }

            imageFile = new Java.IO.File(directory, "myphoto.jpg");
            return imageFile;
        }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                byte[] bytes;
                using (var stram = new Java.IO.FileInputStream(imageFile))
                {
                    bytes = new byte[imageFile.Length()];
                    stram.Read(bytes);
                }
                MessagingCenter.Send<byte[]>(bytes, "takedPhoto");
            }

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}