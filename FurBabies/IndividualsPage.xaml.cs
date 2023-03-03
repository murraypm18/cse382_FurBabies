using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FurBabies
{
    public partial class IndividualsPage : ContentPage
    {
        public IndividualsPage()
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
            ls.ItemsSource = DB.conn2.Table<indBreed>().Where(s => s.name == BreedPage.dog).ToList();
        }
    }
}

