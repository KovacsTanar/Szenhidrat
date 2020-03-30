using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szenhidrat
{
    class Program
    {
        static List<Elelmiszer> lista = new List<Elelmiszer>();

        static void Beolvas()
        {
            FileStream fs = new FileStream(@"szenhidratok.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            sr.ReadLine(); //hisz a fájl első sora csak egy fejléc, nem tartalmaz számunkra hasznos adatot!!

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                Elelmiszer elelmiszer = new Elelmiszer(sor);
                lista.Add(elelmiszer);
                
            }
        }

        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();
            Feladat8();
            Feladat9();
           
            Console.ReadKey();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. Feladat: Élelmiszerek száma: {0} db",lista.Count);
        }

        static void Feladat4()
        {
            int db = 0;
            foreach (var item in lista)
            {
                if (0.1 > item.Szenhidrat)
                    db++;
            }

            Console.WriteLine("4. Feladat: Találatok száma : {0} db", db) ;
        }

        static void Feladat5()
        {
            Console.WriteLine("5. feladat: A legnagyobb szénhidráttartalom:");

            double max = -1;
            int maxIndex = -1;

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Szenhidrat > max)
                {
                    maxIndex = i;
                    max = lista[i].Szenhidrat;
                }
            }

            Console.WriteLine("5. Feladat: A legnagyobb szénhidráttartalom:");

            Console.WriteLine("\tÉtel neve: {0}",lista[maxIndex].Megnevezes);
            Console.WriteLine("\tMennyiség: {0:0.0} g",max);
        }

        static void Feladat6()
        {
            double osszeg = 0;
            int db = 0;

            for (int i = 0; i < lista.Count; i++)
            {

                if (lista[i].Kategoria == "Édesipari termékek")
                {
                    osszeg += lista[i].Szenhidrat;
                    db++;
                }
            }
            double atlag =(double) osszeg / db;
            Console.WriteLine("6. Feladat: Édesipari termékek átlagos szénhidráttartalma:");
            Console.WriteLine("\tÁtlag: {0} g",atlag);

        }

        static void Feladat7()
        {
            Console.Write("7. feladat: Kérek egy karakterláncot: ");
            string kereses = Console.ReadLine().ToLower();

            int db = 0;

            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i].Megnevezes.ToLower().Contains(kereses))
                {
                    Console.WriteLine("\tNév: {0}",lista[i].Megnevezes);
                    Console.WriteLine("\tKategória: {0}", lista[i].Kategoria);
                    Console.WriteLine("\tSzénhidrát: {0:0.0} g", lista[i].Szenhidrat);
                    db++;
                }
            }

            if (db==0)
                Console.WriteLine("\tNincs találat!"); 
        }

        static void Feladat8()
        {
            Console.WriteLine("8. feladat: Statisztika");

            List<string> kategoriak = new List<string>();
            

            foreach (var item in lista)
            {
                if (!kategoriak.Contains(item.Kategoria))
                    kategoriak.Add(item.Kategoria);
            }
            int[] darabszamok = new int[kategoriak.Count];
           
            for (int i = 0; i < lista.Count; i++)
            {
                int index = kategoriak.IndexOf(lista[i].Kategoria);
                darabszamok[index]++;
            }

            for (int i = 0; i < kategoriak.Count; i++)
            {
                if (darabszamok[i]>29)
                {
                  Console.WriteLine("\t{0}:{1}", kategoriak[i], darabszamok[i]);
                }
            }

        }

        static void Feladat9()
        {
            Console.WriteLine("9. feladat: kenyerfelek.txt");
            FileStream fs = new FileStream("kenyerfelek.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.WriteLine("Nev;Szenhidrat");

            foreach (var item in lista)
            {
                if(item.Kategoria=="Kenyérfélék")
                {
                    sw.WriteLine("{0};{1}", item.Megnevezes, item.Szenhidrat);
                }
            }
            sw.Close();
            fs.Close();
        }
    }
}
