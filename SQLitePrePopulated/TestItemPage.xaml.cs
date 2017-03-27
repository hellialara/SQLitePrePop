using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SQLitePrePopulated
{
	public partial class TestItemPage : ContentPage
	{
		TestTab mSelItem;
		public TestItemPage(TestTab aSelectedItem)
		{
			InitializeComponent();
			mSelItem = aSelectedItem;
			BindingContext = mSelItem;
		}
	}
}
