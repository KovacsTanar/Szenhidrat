using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szenhidrat
{
    class Elelmiszer
    {
        //Az adattagok
        private string megnevezes, kategoria;
        private int kjoule, kcal;
        private double feherje, zsir;
        private double szenhidrat;

        public Elelmiszer(string sor)
        {
            string[] spliteltSor = sor.Split(';');
            this.megnevezes = spliteltSor[0];
            this.kategoria = spliteltSor[1];
            this.kjoule = Convert.ToInt32(spliteltSor[2]);
            this.kcal = Convert.ToInt32(spliteltSor[3]);
            this.feherje = Convert.ToDouble(spliteltSor[4]);
            this.zsir = Convert.ToDouble(spliteltSor[5]);
            this.szenhidrat = Convert.ToDouble(spliteltSor[6]);
        }
        
        public string Megnevezes
        {
            get { return megnevezes; }
        }

        public string Kategoria { get => kategoria;}
        public int Kjoule { get => kjoule;}
        public int Kcal { get => kcal;}
        public double Feherje { get => feherje;}
        public double Zsir { get => zsir;}
        public double Szenhidrat { get => szenhidrat;}
    }
}
