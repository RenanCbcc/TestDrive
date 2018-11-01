using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SchedulingsListView : ContentPage
	{
		public SchedulingsListView ()
		{
			InitializeComponent ();
            LsitViewSchedulings.ItemsSource = new List<Scheduling>();
           // BindingContext = new SchedulingsListViewModel();
        }
	}
}