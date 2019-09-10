using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pathrise_NumberArray_Practice
{
    public partial class Number_Array_Practice : Form
    {
        public Number_Array_Practice()
        {
            InitializeComponent();
            listBox1.Items.Add("hello");
            listBox1.Items.Add("second line");
 //The method ShowResults() calls the method 
  //GenerateNumberArray() which in turn calls SearchForDuplicates()
          ShowResults();
        }

        public void ShowResults()
        {
            Queue<List<int>> Duplicates = SearchForDuplicates();
            foreach (var item in Duplicates)
            {
                listBox1.Items.Add($"Positions {item[0] + 1}" +
                    $" and {item[1] + 1} share a duplicate " +
                    $"value of {item[2]}");
            }
        }

        public Queue<List<int>> SearchForDuplicates()
        {
            int[] NumberArray = GenerateNumberArray();
            Queue<List<int>> Duplicates = new Queue<List<int>>();
            for (int a = 0; a < NumberArray.Length; a++)
            {
                for (int b = a + 1; b < NumberArray.Length; b++)
                {
                    if (NumberArray[a] == NumberArray[b])
                    {
                        List<int> LocationAndValue = new List<int>(3);
                        LocationAndValue.Add(a);
                        LocationAndValue.Add(b);
                        LocationAndValue.Add(NumberArray[a]);
                        Duplicates.Enqueue(LocationAndValue);
                    }
                }
            }
            return Duplicates;
        }

        public int[] GenerateNumberArray()
        {
            int[] NumberArray = new int[10];
            Random rand = new Random();
            for (int i = 0; i < NumberArray.Length; i++)
            {
                NumberArray[i] = rand.Next(9);
            }
            return NumberArray;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
