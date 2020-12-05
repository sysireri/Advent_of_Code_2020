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
            int intdPassWordAValid = 0;
            int intdPassWordBValid = 0;
            System.Collections.Generic.List<PasswordVerificatorBE> lstPassword = null;
            
            lstPassword = mGetInputValues();
            (intdPassWordAValid, intdPassWordBValid) = mCountValidPassword(lstPassword);

        }

        static private System.Collections.Generic.List<PasswordVerificatorBE> mGetInputValues()
        {
            string strInputPath = "";
            string strCurrentLine = "";
            PasswordVerificatorBE objPasswordVerificatorBE = null;

            System.Collections.Generic.List<PasswordVerificatorBE> lstInput = new List<PasswordVerificatorBE>();

            strInputPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\input.txt";

            if (System.IO.File.Exists(strInputPath))
            {
                using (System.IO.StreamReader objStreamReader = new System.IO.StreamReader(strInputPath))
                {
                    while (!objStreamReader.EndOfStream)
                    {
                        strCurrentLine = objStreamReader.ReadLine();
                        objPasswordVerificatorBE = new PasswordVerificatorBE(strCurrentLine);
                        lstInput.Add(objPasswordVerificatorBE);
                    }
                }
            }
            return lstInput;
        }

        private static (int,int) mCountValidPassword(System.Collections.Generic.List<PasswordVerificatorBE> vlstPassword)
        {
            int intdPassWordAValid = 0;
            int intdPassWordBValid = 0;

            foreach (PasswordVerificatorBE objCurrentPasswordVerificatorBE in vlstPassword)
            {
                if(objCurrentPasswordVerificatorBE.PasswordAIsValid())
                {
                    intdPassWordAValid++;
                }
                if (objCurrentPasswordVerificatorBE.PasswordBIsValid())
                {
                    intdPassWordBValid++;
                }
            }

            return (intdPassWordAValid, intdPassWordBValid);
        }
    }

    public class PasswordVerificatorBE
    {
        public int MinA { get; private set; }
        public int MaxA { get; private set; }
        public char CharToCheck { get; private set; }
        public string Password { get; private set; }

        public int FirtsB { get; private set; }
        public int SecondB { get; private set; }

        public PasswordVerificatorBE(string vstrAllInfos)
        {
            string[] strSepareInfos;
            vstrAllInfos = vstrAllInfos.Replace(" ", "-");
            vstrAllInfos = vstrAllInfos.Replace(":", "");

            strSepareInfos = vstrAllInfos.Split('-');

            if(strSepareInfos.GetUpperBound(0) == 3)
            {
                this.MinA = Convert.ToInt32(strSepareInfos[0]);
                this.MaxA = Convert.ToInt32(strSepareInfos[1]);
                this.CharToCheck = Convert.ToChar(strSepareInfos[2]);
                this.Password = strSepareInfos[3];

                this.FirtsB = Convert.ToInt32(strSepareInfos[0]) - 1;
                this.SecondB  = Convert.ToInt32(strSepareInfos[1]) -1;
            }
        }

        public bool PasswordAIsValid()
        {
            int intCountCharToCheck = 0;

            intCountCharToCheck = this.Password.Count(c => c == this.CharToCheck);

            return intCountCharToCheck >= this.MinA && intCountCharToCheck <= this.MaxA;
        }
        public bool PasswordBIsValid()
        {
            bool bolPassWordBIsValid = false;

            if(this.Password.Length - 1 >= this.SecondB )
            {
                if (this.Password[this.FirtsB] == this.CharToCheck && this.Password[this.SecondB] != this.CharToCheck ||
                    this.Password[this.SecondB] == this.CharToCheck && this.Password[this.FirtsB] != this.CharToCheck)
                {
                    bolPassWordBIsValid = true;
                }
            }

            return bolPassWordBIsValid;
        }
    }
}
