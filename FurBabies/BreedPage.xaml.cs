using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.Reflection;
using System.IO;

namespace FurBabies
{
    public partial class BreedPage : ContentPage
    {
        public static indBreed holder;
        public static string dog;
        IndividualsPage individualsPage;
        ISimpleAudioPlayer player = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
        public BreedPage()
        {
            InitializeComponent();
            DB.OpenConnection();
            load("yay.mp3");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DB.RepopulateTables();
            ResetListViewSources();
        }
        private void load(string file)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            String ns = "FurBabies";
            Stream audioStream = assembly.GetManifestResourceStream(ns + "." + file);
            player.Load(audioStream);
        }

        private void ResetListViewSources()
        {
            tLabel.Text = BreedListPage.selectedbreed;
            //ls.ItemsSource = DB.conn2.Table<indBreed>().Where(s => s.breedName == BreedListPage.selectedbreed).ToList();
            ls.ItemsSource = DB.conn2.Table<indBreed>().Where(s => s.breedName == BreedListPage.selectedbreed
            && s.age == SettingsPage.getAge
            && s.furColor == SettingsPage.getFurColor
            && s.GWK == SettingsPage.getChildren
            && s.hypoAl == SettingsPage.getAller
            && s.size == SettingsPage.getSize).ToList();
        }

        private async void ls_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            player.Play();
            holder = e.SelectedItem as indBreed;
            dog = holder.name;
            individualsPage = new IndividualsPage();
            await Navigation.PushAsync(individualsPage, true);
            
        }
    }
}

