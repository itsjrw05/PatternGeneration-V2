using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatternGeneration_V2
{
    public partial class Form1 : Form
    {
        Random randomNumber = new Random();
        
        int xSize;
        int ySize;

        int colors;

        int previous;
        int current;

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            xSize = Int32.Parse(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ySize = Int32.Parse(textBox2.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            colors = Int32.Parse(textBox3.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void Generate()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            for (int x = 0; x < xSize; x++)
            {
                dataGridView1.Columns.Add("Column" + x, "Column" + x);
            }

            for (int y = 0; y < ySize - 1; y++)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    previous = current;

                    if (current == previous)
                    {
                        current = randomNumber.Next(colors);
                    }
                    else
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[i];
                        dataGridView1.CurrentCell.Value = current;
                    }
                }
            }

            //Verify();
        }

        private void Verify()
        {
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[i];

                    if (dataGridView1.Rows[Math.Max(0, j + 1)].Cells[i].Value != dataGridView1.CurrentCell.Value)
                    {
                        if (dataGridView1.Rows[Math.Max(0, j - 1)].Cells[i].Value != dataGridView1.CurrentCell.Value)
                        {
                            if (dataGridView1.Rows[j].Cells[Math.Max(0, i + 1)].Value != dataGridView1.CurrentCell.Value)
                            {
                                if (dataGridView1.Rows[j].Cells[Math.Max(0, i - 1)].Value != dataGridView1.CurrentCell.Value)
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Joshua f***** up at " + i + ", " + j);
                                    Generate();
                                }
                            }
                            else
                            {
                                Console.WriteLine("Joshua f***** up at " + i + ", " + j);
                                Generate();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Joshua f***** up at " + i + ", " + j);
                            Generate();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Joshua f***** up at " + i + ", " + j);
                        Generate();
                    }
                }
            }
        }
    }
}
