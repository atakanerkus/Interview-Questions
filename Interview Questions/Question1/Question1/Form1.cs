using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;



//1 - A number will be entered in the 1st textbox and by pressing the button [opposite]! it will find the prime numbers up to that number. It will create the result it finds in a thread and write the result to the its own listbox.

//2- A number will be entered in the 2nd textbox and by pressing the button opposite it will find the prime numbers up to that number. It will create the result it finds in a thread and write the result to the its  own listbox.
namespace Question1
{
    public partial class Form1 : Form
    {
        private List<int> primeList = new List<int>();
        

        public Form1()
        {
            InitializeComponent();
            
        }

        private bool IsPrime(int number)
        {
            if (number < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        private void findPrimes(int number) // Finds all primes till given number
        {
            for (int i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    primeList.Add(i);
                }
            }
        }

        public void button2_Click(object sender, EventArgs e)

        {
            if (int.TryParse(textBox1.Text,out int number))
            {
                Task.Run(() =>
                {
                    findPrimes(number);
                    Invoke(new Action(() =>
                    {
                        listBox1.Items.Clear();
                        foreach (int prime in primeList)
                        {
                            listBox1.Items.Add(prime);
                        }
                    }));
                });

            }
            
            
            
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox2.Text, out int number))
            {
                Task.Run(() =>
                {
                    findPrimes(number);
                    Invoke(new Action(() =>
                    {
                        listBox2.Items.Clear();
                        foreach (int prime in primeList)
                        {
                            listBox2.Items.Add(prime);
                        }
                    }));
                });

            }
        }

        

        
    }
}
