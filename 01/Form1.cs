using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int[] intInputValues= mGetInputValues();
            int intAnswer2 = mGetAnswerWithValues(intInputValues,2);
            int intAnswer3 = mGetAnswerWithValues(intInputValues, 3);

        }

        private int[] mGetInputValues()
        {
            string strInputPath = "";
            string strCurrentLine = "";
            int intCurrentValue = 0;

            System.Collections.Generic.List<int> lstInput = new List<int>();

            strInputPath = System.Windows.Forms.Application.StartupPath + @"\input.txt";

            if(System.IO.File.Exists(strInputPath))
            {
                using (System.IO.StreamReader objStreamReader = new System.IO.StreamReader(strInputPath))
                {
                    while (objStreamReader.Peek() >= 0)
                    {
                        strCurrentLine = objStreamReader.ReadLine();

                        if (int.TryParse(strCurrentLine, out intCurrentValue))
                        {
                            lstInput.Add(intCurrentValue);
                        }
                    }
                }

            }
            return lstInput.ToArray();
        }

        private int mGetAnswerWithValues(int[] intValues, int intNumberOfItems)
        {
           for(int intI = intValues.GetLowerBound(0); intI < intValues.GetUpperBound(0); intI++)
            {
                for (int intJ = intI + 1; intJ < intValues.GetUpperBound(0); intJ++)
                {
                    switch (intNumberOfItems)
                    {
                        case 2:
                            {
                                if (intValues[intI] + intValues[intJ] == 2020)
                                {
                                    return intValues[intI] * intValues[intJ];
                                }
                                break;
                            }

                        case 3:
                            {
                                for (int intK = intJ + 1; intK < intValues.GetUpperBound(0); intK++)
                                {
                                    if (intValues[intI] + intValues[intJ] + intValues[intK]  == 2020)
                                    {
                                        return intValues[intI] * intValues[intJ] * intValues[intK];
                                    }
                                }
                                break;
                            }
                    }
                }
            }

            return -1;
        }
    }
}
