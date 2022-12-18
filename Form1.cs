using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
namespace _2_курс_интерфейс_матрицы
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static public int n;
        static public double[] a;// кэффициэнты иксов 
        static public bool s1, s2, s3 = false;
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "Ответ:";
                if (s2)
                {
                    for (int i = 0; i < n; i -= -1)
                    {
                        dataGridView1.Columns.Remove("A" + Convert.ToString(i + 1));
                    }
                }
                n = Convert.ToInt16(textBox1.Text);
                for (int i = 0; i < n; i -= -1)
                {
                    dataGridView1.Columns.Add("А" + Convert.ToString(i + 1), "А" + Convert.ToString(i + 1));
                    
                }
                dataGridView1.Rows.Add();
                s2 = true;
            }
            catch
            {
                label3.Text = "Введите число измерений";
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (s2)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    string f = openFileDialog1.FileName;
                    FileStream af = new FileStream(f, FileMode.OpenOrCreate);
                    StreamWriter s = new StreamWriter(af);
                    s.WriteLine(n);
                    for (int z = 0; z < n; z++)
                    {
                        
                        
                            s.Write(dataGridView1[1, z].Value + " ");
                        
                    }
                    s.Close();
                    label3.Text = "Сохранено";
                }

            }
            else
                label3.Text = "Вы не ввели уравнение";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label3.Text =(" ");
            if (s2)
            {
                a = new double[n];
                double x = 0;
                double am;
                for (int z = 0; z < n; z++)
                {
                        a[z] = Convert.ToDouble(dataGridView1[z,0].Value);
                        am = -a[z] * Math.Log(a[z],2);
                        x = x + am;
                }
                label2.Text = label2.Text + Convert.ToString(Math.Ceiling(x))+" Бита";

            }
            else
                label3.Text = ("Заполните матрицу");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ЗагрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int y, z = 0;
                    string a3;
                    try
                    {
                        string filename = openFileDialog1.FileName;
                        StreamReader f = new StreamReader(filename);
                        a3 = f.ReadLine();
                        n = Int32.Parse(a3);
                        try
                        {
                            if (s2)
                            {
                                for (int i = 0; i < n; i -= -1)
                                {
                                    dataGridView1.Columns.Remove("X" + Convert.ToString(i + 1));
                                }
                                dataGridView1.Columns.Remove("B");
                            }
                            for (int i = 0; i < n; i -= -1)
                            {
                                dataGridView1.Columns.Add("X" + Convert.ToString(i + 1), "X" + Convert.ToString(i + 1));
                                dataGridView1.Rows.Add();
                            }
                            dataGridView1.Columns.Add("B", "B");
                        }
                        catch
                        {
                            label3.Text = "Введите Размерность";
                        }

                        string[] str;
                        while (z != n)
                        {
                            a3 = f.ReadLine();
                            str = a3.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                            for (y = 0; y < str.Length - 1; y++)
                            {
                                dataGridView1[y, z].Value = double.Parse(str[y]);
                                a[y] = Convert.ToDouble(dataGridView1[1, y].Value);
                            }
                            dataGridView1[n, z].Value = double.Parse(str[(str.Length) - 1]);
                            z++;
                        }

                        s2 = true;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        label3.Text = "Файл не найден";
                    }
                }
                catch
                {
                    label3.Text = "Файл имеет некоректные данные";
                }
            }
        }
    }
}
