using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lentern
{
    class Encoding
    {
        string[] alphabite = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "=", "+", " ", "."};
        string[] code = new string[] { "05", "21", "34", "99", "01", "46", "76", "11", "61", "73", "88", "16", "50", "23", "80",
            "17", "83", "45", "10", "13", "77", "04", "03", "27", "65", "31", "91", "90", "38", "28",
            "93", "08", "98", "09", "30", "74", "75", "29", "53", "15", "42", "32", "71", "55", "49",
            "69", "92", "97", "19", "67", "72", "89", "66", "52", "94", "00", "20", "58", "86", "40",
            "36", "25", "07", "33", "70", "95", "78", "63", "59", "81", "85", "22", "51", "96", "48", "26", "54", "64"};

        public string encode(string value) 
        {
            string res = "";
            for (int i = 0; i < value.Length; i++) 
            {
                for (int j = 0; j < alphabite.Length; j++) 
                {
                    if (value[i].ToString() == alphabite[j]) 
                    {
                        res = res + code[j].ToString();
                    }
                }
            }
            return res;
        }

        public string decode(string value) 
        {
            string res = "";
            for (int i = 0; i < value.Length; i += 2) 
            {
                for (int j = 0; j < code.Length; j++)
                {
                    if ((value[i].ToString() + value[i+1].ToString()) == code[j].ToString())
                    {
                        res = res + alphabite[j].ToString();
                    }
                }
            }
            return res;
        }
    }
}
