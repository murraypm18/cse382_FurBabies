using System;
using SQLite;
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using System.Collections.Generic;
using System.Text;

namespace FurBabies
{
    public class DB
    {
        private static string DBName = "breedLoad.db";
        private static string DBName2 = "BreedIndividual.db";
        public static SQLiteConnection conn;
        public static SQLiteConnection conn2;
        public static void OpenConnection()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, DBName);
            string fname2 = System.IO.Path.Combine(libFolder, DBName2);
            conn = new SQLiteConnection(fname);
            conn2 = new SQLiteConnection(fname2);
            conn.CreateTable<Breeds>();
            conn2.CreateTable<indBreed>();
            //var data = conn2.Table<indBreed>();
            //if (data.FirstOrDefault() == null)
            //{
            //    LoadIndBreeds();
            //}
        }
        public static void DeleteTableContents(string tableName)
        {
            int v = conn.Execute("DELETE FROM " + tableName);
        }
        public static void DeleteTableContents2(string tableName)
        {
            int v = conn2.Execute("DELETE FROM " + tableName);
        }
        public static void RepopulateTables()
        {
            LoadBreeds();
            LoadIndBreeds();
        }
        public static void LoadBreeds()
        {
            try
            {
                DeleteTableContents("breeds");
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FurBabies.breedLoad.txt");
                StreamReader input = new StreamReader(stream);
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    Breeds breed = Breeds.ParseCSV(line);
                    conn.Insert(breed);
                }
            }
            catch (Exception e)
            {
            }
        }
        public static void LoadIndBreeds()
        {
            try
            {
                DeleteTableContents2("indBreed");
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("FurBabies.BreedIndividual.txt");
                StreamReader input = new StreamReader(stream);
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    indBreed breed = indBreed.ParseCSV(line);
                    conn2.Insert(breed);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}

