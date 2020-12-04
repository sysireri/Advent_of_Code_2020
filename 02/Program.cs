using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List<PasswordVerificator> lstPassword = null;
            lstPassword = mGetInputValues();
        }

        static private System.Collections.Generic.List<PasswordVerificator> mGetInputValues()
        {
            string strInputPath = "";
            string strCurrentLine = "";
            PasswordVerificator objPasswordVerificator = null;

            System.Collections.Generic.List<PasswordVerificator> lstInput = new List<PasswordVerificator>();

            strInputPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\input.txt";

            if (System.IO.File.Exists(strInputPath))
            {
                using (System.IO.StreamReader objStreamReader = new System.IO.StreamReader(strInputPath))
                {
                    while (!objStreamReader.EndOfStream)
                    {
                        strCurrentLine = objStreamReader.ReadLine();
                        objPasswordVerificator = new PasswordVerificator(strCurrentLine);
                        lstInput.Add(objPasswordVerificator);
                    }
                }

            }
            return lstInput;
        }

    }

    public class PasswordVerificator
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public char CharToCheck { get; set; }
        public string Password { get; set; }

        public PasswordVerificator(string vstrAllInfos)
        {
            string[] strSepareInfos;
            vstrAllInfos = vstrAllInfos.Replace(" ", "-");
            vstrAllInfos = vstrAllInfos.Replace(":", "");

            strSepareInfos = vstrAllInfos.Split('-');

            this.Min = Convert.ToInt32(strSepareInfos[0]);
            this.Max = Convert.ToInt32(strSepareInfos[1]);
            this.CharToCheck = Convert.ToChar(strSepareInfos[2]);
            this.Password = strSepareInfos[3];
        }

        public bool PasswordIsValid()
        {
            bool bolValid = false;

            return bolValid;
        }

    }
}
