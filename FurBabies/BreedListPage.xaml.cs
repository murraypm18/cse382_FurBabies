using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FurBabies
{
    public partial class BreedListPage : ContentPage
    {
        BreedPage breedPage;
        public string selected;
        private bool currentOrientation;
        private View portraitLayout;
        private View landscapeLayout;
        public BreedListPage()
        {
            InitializeComponent();
            DB.OpenConnection();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DB.RepopulateTables();
            ResetListViewSources();
        }

        private void ResetListViewSources()
        {
            ls.ItemsSource = DB.conn.Table<Breeds>().ToList();

        }

        public static string selectedbreed = "hello";
        private async void ls_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
                selectedbreed = e.SelectedItem.ToString();
                breedPage = new BreedPage();
                await Navigation.PushAsync(breedPage, true);
        }
    }
}

