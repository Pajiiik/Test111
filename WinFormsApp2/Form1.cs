using System.Configuration;
using System.IO;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int vypocitej(int cislo1, char znamenko, int cislo2)
        {
            switch (znamenko)
            {
                case '+':

                    return cislo1 + cislo2;

                    break;

                case '-':

                    return cislo1 - cislo2;

                    break;

                case '*':

                    return cislo1 * cislo2;

                    break;

                case '/':

                    return cislo1 / cislo2;

                    break;
                    default: return 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("matematika.txt");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            int fn = 0, sn=0, swtch=0;
            char znamenko =' ';
            

            string data = sr.ReadToEnd();
            for (int i =0;i != data.Length;i++)
            {
                if (Char.IsNumber(data[i]))
                {
                    if (swtch == 0)
                    {
                        fn = fn * 10 + data[i];
                        MessageBox.Show(fn.ToString());
                    }
                    else
                    {
                        sn = sn * 10 + data[i];
                    }
                }
                else if (Char.IsWhiteSpace(data[i]))
                {
                    swtch++;
                }
                else if (data[i] == '=')
                {
                    MessageBox.Show(vypocitej(fn, znamenko, sn).ToString() + fn.ToString() + znamenko + sn.ToString());

                    swtch = 0;
                    fn = 0;sn = 0;znamenko = ' ';  
                }
                else
                {        
                    znamenko = data[i];
                }
            }


                //for (int i = 0; i < sr.BaseStream.Length; i++)
                //{

                //    sr.BaseStream.Seek(i, SeekOrigin.Begin);
                //}
            }
    }
}