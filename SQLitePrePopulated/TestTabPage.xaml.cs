using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;

namespace SQLitePrePopulated
{
	public partial class TestTabPage : ContentPage
	{
		public TestTabPage()
		{
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			List<TestTab> pplList = await App.TestTabRepo.GetAllItems();

			var testItems = from getString in pplList
							select new TestTab
							{
								Id = getString.Id,
								Name = getString.Name,
								Info = getString.Info,
								Image = getString.Image,
								ImgLarge = "large_" + getString.Image,
								URL = getString.URL
							};

			Debug.WriteLine("ItemsGot");

			ObservableCollection<TestTab> pplCollection = new ObservableCollection<TestTab>(testItems);
			listView.ItemsSource = pplCollection;

			Debug.WriteLine("ItemsInList");

			var testtab_data = from queryA in pplList
							   select queryA;

			foreach (var testtab_tieto in testtab_data)
			{
				Debug.WriteLine("ITEM");
				Debug.WriteLine(testtab_tieto.Id);
				Debug.WriteLine(testtab_tieto.Name);
			}

		}

		void OnItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}
			var vSelItem = (TestTab)e.SelectedItem;
			Navigation.PushAsync(new TestItemPage(vSelItem));
		}
	}
}
