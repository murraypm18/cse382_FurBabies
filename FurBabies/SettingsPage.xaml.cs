using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;

namespace FurBabies
{
    public partial class SettingsPage : ContentPage
    {
        public static string getAge;
        public static string getFurColor;
        public static string getChildren;
        public static string getAller;
        public static string getSize;
        public SettingsPage()
        {
            InitializeComponent();
            if (!Preferences.ContainsKey("age"))
                Preferences.Set("age", 0);
            if (!Preferences.ContainsKey("furColor"))
                Preferences.Set("furColor", 0);
            if (!Preferences.ContainsKey("children"))
                Preferences.Set("children", 0);
            if (!Preferences.ContainsKey("aller"))
                Preferences.Set("aller", 1);
            if (!Preferences.ContainsKey("size"))
                Preferences.Set("size", 0);
            age.SelectedIndex = Preferences.Get("age", 0);
            furColor.SelectedIndex = Preferences.Get("furColor", 0);
            children.SelectedIndex = Preferences.Get("children", 0);
            aller.SelectedIndex = Preferences.Get("aller", 1);
            size.SelectedIndex = Preferences.Get("size", 0);
            getAge = age.SelectedItem.ToString();
            getFurColor = furColor.SelectedItem.ToString();
            getChildren = children.SelectedItem.ToString();
            getAller = aller.SelectedItem.ToString();
            string[] toks = size.SelectedItem.ToString().Split(' ');
            getSize = toks[0];
        }

    protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void age_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("age", age.SelectedIndex);
            getAge = age.SelectedItem.ToString();
        }

        void furColor_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("furColor", furColor.SelectedIndex);
            getFurColor = furColor.SelectedItem.ToString();
        }

        void children_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("children", children.SelectedIndex);
            getChildren = children.SelectedItem.ToString();
        }

        void aller_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("aller", aller.SelectedIndex);
            getAller = aller.SelectedItem.ToString();
        }

        void size_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            Preferences.Set("size", size.SelectedIndex);
            string[] toks = size.SelectedItem.ToString().Split(' ');
            getSize = toks[0];
        }
    }
}

