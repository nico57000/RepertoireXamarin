using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Repertoire.Modele
{
    public class Contact
    {
        public Contact()
        {
            ImageUrl = "icone.ico";
        }

        [PrimaryKey, AutoIncrement]
        public int Key { get; set; }
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string mail { get; set; }

        public string Tel { get; set; }

        public string ImageUrl { get; set; }
        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
