using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester_losowości.Model
{
    class Test
    {


        public bool[] sample;

        public Test(string s)
        {
            StringToBool(s);
        }

        public void StringToBool(string s)
        {
            sample = new bool[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                sample[i] = s[i] == '1' ? true : false;
            }
        }





        #region Podstawowe testy statystyczne
        #region Test autokorelacji

        public double Test_Autokorelacji()
        {
            const int s = 5;
            return (double) (2*liczba_bitowA(s) - sample.Length + s)/Math.Sqrt((double) (sample.Length - s));
        }

        public int liczba_bitowA(int s)
        {
            int wyjscie = 0;
            for (int i = 0; i < sample.Length - s; i++)
            {
                wyjscie += sample[i] ^ sample[i + s] ? 1 : 0;
            }
            return wyjscie;
        }

        #endregion
        
        #region Test par bitów

        private int n0 = 0, n1 = 0, n00 = 0, n01 = 0, n10 = 0, n11 = 0;

        public void liczbaJedynek_Zer()
        {
            for (int i = 0; i < sample.Length; i++)
            {
                if (sample[i])
                {
                    n1++;
                }
            }
            n0 = 20000 - n1;
        }

        public void liczbaPar()
        {
            for (int i = 0; i < ((sample.Length)/2); )
            {
                if (sample[i]==true &&sample[i+1]==true)
                {
                    n11++;
                }
                else if (sample[i] == false && sample[i + 1] == false)
                {
                    n00++;
                }
                else if (sample[i] == false && sample[i + 1] == true)
                {
                    n01++;
                }
                else if (sample[i] == true && sample[i + 1] == false)
                {
                    n10++;
                }

                i += 2;
            }
        }

        public double TestParBitow()
        {
            liczbaJedynek_Zer();
            liczbaPar();
            return ((4/(sample.Length/-1))*
                    ((Math.Pow(n00, 2)) + (Math.Pow(n01, 2)) + (Math.Pow(n10, 2)) + (Math.Pow(n11, 2))) -
                    (2/sample.Length)*((Math.Pow(n0, 2)) + (Math.Pow(n1, 2))) + 1);
        }
        #endregion

        #endregion

        #region Testy statystyczne według FIPS 140-2
        
        #region Test długiej serii

        public bool TestDlugiejSerii()
        {
            bool wyjscie = true;
            List<bool> lista = new List<bool>();
            for (int i = 0; i < sample.Length - 26; i++)
            {
                if (sprawdz_serie(i))
                {
                    wyjscie = false;
                    break;
                }
                lista.Add(sprawdz_serie(i));
            }
            return wyjscie;  // jeśli wyjście większe od 0 to test zakończył się porażką
        }

        public bool sprawdz_serie(int iterator)
        {
            bool wyjscie = true;
            for (int i = 0; i < 26; i++)
            {
                if (sample[iterator + i])
                {
                    wyjscie = false;
                    break;
                }
            }
            if (!wyjscie)
            {
                wyjscie = true;
                for (int i = 0; i < 26; i++)
                {
                    if (!sample[iterator + i])
                    {
                        wyjscie = false;
                        break;
                    }
                }
            }
            return wyjscie;
        }

        #endregion

        #region Test pojedynczych bitów

        public bool TestPojedynczychBitow()
        {
            bool wyjscie = true;
            int liczbaJedynek = 0;
            for (int i = 0; i < sample.Length; i++)
            {
                if (sample[i])
                {
                    liczbaJedynek++;
                }
            }
            if (9725<liczbaJedynek && liczbaJedynek<10275)
            {
                wyjscie = true;
            }
            else
            {
                wyjscie = false;
            }
            return wyjscie;
        }
        #endregion

        #endregion
    }
}
