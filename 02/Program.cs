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
            int intCountValidPassWord = 0;
            System.Collections.Generic.List<PasswordVerificatorBE> lstPassword = null;
            
            lstPassword = mGetInputValues();
            intCountValidPassWord = mCountValidPassword(lstPassword);
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

        private static int mCountValidPassword(System.Collections.Generic.List<PasswordVerificatorBE> vlstPassword)
        {
            int intCountValidPassWord = 0;

            foreach(PasswordVerificatorBE objCurrentPasswordVerificatorBE in vlstPassword)
            {
                if(objCurrentPasswordVerificatorBE.PasswordIsValid())
                {
                    intCountValidPassWord++;
                }
            }

            return intCountValidPassWord;
        }
    }

    public class PasswordVerificatorBE
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public char CharToCheck { get; private set; }
        public string Password { get; private set; }

        public PasswordVerificatorBE(string vstrAllInfos)
        {
            string[] strSepareInfos;
            vstrAllInfos = vstrAllInfos.Replace(" ", "-");
            vstrAllInfos = vstrAllInfos.Replace(":", "");

            strSepareInfos = vstrAllInfos.Split('-');

            if(strSepareInfos.GetUpperBound(0) == 3)
            {
                this.Min = Convert.ToInt32(strSepareInfos[0]);
                this.Max = Convert.ToInt32(strSepareInfos[1]);
                this.CharToCheck = Convert.ToChar(strSepareInfos[2]);
                this.Password = strSepareInfos[3];
            }
        }

        public bool PasswordIsValid()
        {
            int intCountCharToCheck = 0;

            intCountCharToCheck = this.Password.Count(c => c == this.CharToCheck);

            return intCountCharToCheck >= this.Min && intCountCharToCheck <= this.Max;
        }
    }
}
