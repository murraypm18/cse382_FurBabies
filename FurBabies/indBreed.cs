using System;
using SQLite;

namespace FurBabies
{
	public class indBreed
	{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string breedName { get; set; }
        public string name { get; set; }
        public string pic { get; set; }
        public string age { get; set; }
        public string furColor { get; set; }
        public string GWK { get; set; }
        public string hypoAl { get; set; }
        public string size { get; set; }
        public string web { get; set; }
        public override string ToString()
        {
            return string.Format("{0}", breedName);
        }
        public static indBreed ParseCSV(string line)
        {
            string[] toks = line.Split(',');
            indBreed indBreed = new indBreed
            {
                breedName = toks[0],
                name = toks[1],
                pic = toks[2],
                age = toks[3],
                furColor = toks[4],
                GWK = toks[5],
                hypoAl = toks[6],
                size = toks[7],
                web = toks[8]

            };
            return indBreed;
        }
    }
}

