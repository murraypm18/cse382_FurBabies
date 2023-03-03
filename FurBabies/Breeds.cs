using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
namespace FurBabies
{
    public class Breeds
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string breedName { get; set; }
        public string pic { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", breedName);
        }
        public static Breeds ParseCSV(string line)
        {
            string[] toks = line.Split(',');
            Breeds breed = new Breeds
            {
                breedName = toks[0],
                pic = toks[1]

            };
            return breed;
        }
    }
}

