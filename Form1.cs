using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordgenerator
{
    public partial class Form1 : Form
    {
        static string PassGenerate(int minlenght, int maxlength)
        {
            Random rand = new Random();
            string numeral = "1234567890";
            string letter = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            int passLength = rand.Next(minlenght, maxlength);
            string passWord = "";
            int numeralCheck = 0;
            // Наполнение пароля рандомными символами
            for (int i = 0; i < passLength; i++)
            {

                // Берем рандомную букву из letter
                int letterSymbolIndex = rand.Next(0, letter.Length);
                char letterSymbol = letter[letterSymbolIndex];
                // Берем рандомную цифру из numeral
                int numeralSymbolIndex = rand.Next(0, numeral.Length);
                char numeralSymbol = numeral[numeralSymbolIndex];
                // Рандомим 0 или 1, если 0 то в пароль добавится буква, если 1 то цифра
                int choice = rand.Next(0, 2);
                if (choice == 0)
                {
                    passWord += letterSymbol;
                }
                else
                {
                    passWord += numeralSymbol;
                }
            }
            // Подсчет цифр в пароле
            for (int i = 0; i < numeral.Length; i++)
            {
                if (passWord.Contains(numeral[i]))
                {
                    numeralCheck++;
                }
            }
            // Количество цифр в пароле должно быть не менее 2 и не больше половины пароля, иначе заново
            if (numeralCheck >= 2 && numeralCheck <= passWord.Length / 2)
            {
                Console.WriteLine("Цифр : " + numeralCheck + "из " + passWord.Length);
                return passWord;
            }
            else
            {
                Console.WriteLine("Цифр : " + numeralCheck + " меньше чем 2 " + " или больше чем  " + passWord.Length / 2);
                Console.WriteLine("Неподходящий пароль:" + passWord + "\n");
                return PassGenerate(minlenght, maxlength);
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.Text = "Генератор паролей";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 4 | numericUpDown2.Value < 4)
            {
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                MessageBox.Show("Кол-во символов не меньше 4");
            }
            else
            {
                string pass = PassGenerate(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));
                textBox1.Text = pass;
                listBox1.Items.Add(pass);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)textBox1.Text);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Hide();
            if (panel1.Visible == false)
            {
                panel1.Show();
            }
            else
            {
                panel1.Hide();
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            if (listBox1.Visible == false)
            {
                listBox1.Show();

            }
            else
            {
                listBox1.Hide();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
