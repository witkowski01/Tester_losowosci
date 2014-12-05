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

        #endregion

        #endregion

        #region Testy statystyczne według FIPS 140-2

        #region Test długiej serii

        #endregion

        #region Test pojedynczych bitów

        #endregion

        #endregion
    }
}
