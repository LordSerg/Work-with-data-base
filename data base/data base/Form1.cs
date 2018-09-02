using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using oledb = System.Data.OleDb;

namespace data_base
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        bool b;
        DataTable t;
        DataSet s;
        XmlTextReader read;
        DataView dv1;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        void read_faculty()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\Faculty.xml");
            read.Read();
            for (int i = 0; i < 9; i++)
            {
                read.ReadToFollowing("Код");
                //read.MoveToNextAttribute();
                comboBox1.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Назва_x0020_факультету");
                comboBox2.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Назва_x0020_університету_x002C__x0020_до_x0020_якого_x0020_належить");
                comboBox3.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Кількість_x0020_кафедр");
                comboBox4.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Кафедра_x0020_з_x0020_найбільшою_x0020_кількістю_x0020_студентів_x0020_при_x0020_факультеті");
                comboBox5.Items.Add(read.ReadElementContentAsString());
            }
        }
        void read_university()
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\University.xml");
            read.Read();
            for (int i = 0; i < 5; i++)
            {
                read.ReadToFollowing("Код");
                //read.MoveToNextAttribute();
                comboBox1.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Назва_x0020_університету");
                comboBox2.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Кількість_x0020_факультетів");
                comboBox3.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Дата_x0020_першого_x0020_випуску");
                comboBox4.Items.Add(read.ReadElementContentAsString());
                read.ReadToFollowing("Чи_x0020_є_x0020_в_x0020_університеті_x0020_академіки");
                comboBox5.Items.Add(read.ReadElementContentAsString());
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            code = 1;
            textBox1.Text = code.ToString();
            comboBox1.Text = code.ToString();
            b = true;
            comboBox1.Text = ("Код");
            comboBox2.Text = ("Назва університету");
            comboBox3.Text = ("Кількість факультетів");
            comboBox4.Text = ("Дата першого випуску");
            comboBox5.Text = ("Чи є в університеті академіки");
            label6.Text = ("Фото університета");
            read_university();
            string st1,st2,st3,st4,st5;
            read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\University.xml");
            read.Read();            
            t = new DataTable();
            s = new DataSet();
            t.Columns.Add("Код");
            t.Columns.Add("Назва університету");
            t.Columns.Add("Кількість факультетів");
            t.Columns.Add("Дата першого випуску");
            t.Columns.Add("Чи є в університеті академіки");
            
            for (int i = 0; i < 5; i++)
            {
                //read.ReadToFollowing("Код");
                read.MoveToNextAttribute();
                //if (n == Convert.ToInt32(read.Value))
                
                    read.ReadToFollowing("Код");
                    st1 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Назва_x0020_університету");
                    st2 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Кількість_x0020_факультетів");
                    st3 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Дата_x0020_першого_x0020_випуску");
                    st4 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Чи_x0020_є_x0020_в_x0020_університеті_x0020_академіки");
                    st5 = (read.ReadElementContentAsString());
                    t.Rows.Add(new String[] { st1, st2, st3, st4, st5 });
                
            }
            dataGridView1.DataSource = t;
            //code = Convert.ToInt32(comboBox1.Text);
            textBox1.Text = code.ToString();
            label1.Text = dataGridView1.Rows[code - 1].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[code - 1].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[code - 1].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[code - 1].Cells[3].Value.ToString();
            label5.Text = dataGridView1.Rows[code - 1].Cells[4].Value.ToString();
            if (b == false)
            {
                pictureBox1.BackgroundImage = new Bitmap(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\" + code.ToString() + "_D.jpg");
            }
            else
            {
                pictureBox1.BackgroundImage = new Bitmap(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\" + code.ToString() + "_U.jpg");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            code = Convert.ToInt32(comboBox1.Text);
            textBox1.Text = code.ToString();
            label1.Text = dataGridView1.Rows[code - 1].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[code - 1].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[code - 1].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[code - 1].Cells[3].Value.ToString();
            label5.Text = dataGridView1.Rows[code - 1].Cells[4].Value.ToString();
            if (b == false)
            {
                pictureBox1.BackgroundImage = new Bitmap(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\" + code.ToString() + "_D.jpg");
            }
            else
            {
                pictureBox1.BackgroundImage = new Bitmap(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\" + code.ToString() + "_U.jpg");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            code = 1;
            textBox1.Text = code.ToString();
            comboBox1.Text = code.ToString();
            b = false;
            comboBox1.Text = ("Код");
            comboBox2.Text = ("Назва факультету");
            comboBox3.Text = ("Назва університету, до якого належить");
            comboBox4.Text = ("Кількість кафедр");
            comboBox5.Text = ("Кафедра з найбільшою кількістю студентів при факультеті");
            label6.Text = ("Фото декана");
            read_faculty();
            XmlTextReader read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\Faculty.xml");
            read.Read();
            string st1, st2, st3, st4, st5;
            read.Read();
            t = new DataTable();
            s = new DataSet();
            t.Columns.Add("Код");
            t.Columns.Add("Назва факультету");
            t.Columns.Add("Назва університету, до якого належить");
            t.Columns.Add("Кількість кафедр");
            t.Columns.Add("Кафедра з найбільшою кількістю студентів при факультеті");

            for (int i = 0; i < 9; i++)
            {
                //read.ReadToFollowing("Код");
                read.MoveToNextAttribute();
                //if (n == Convert.ToInt32(read.Value))
                {
                    read.ReadToFollowing("Код");
                    st1 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Назва_x0020_факультету");
                    st2 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Назва_x0020_університету_x002C__x0020_до_x0020_якого_x0020_належить");
                    st3 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Кількість_x0020_кафедр");
                    st4 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Кафедра_x0020_з_x0020_найбільшою_x0020_кількістю_x0020_студентів_x0020_при_x0020_факультеті");
                    st5 = (read.ReadElementContentAsString());
                    t.Rows.Add(new String[] { st1, st2, st3, st4 ,st5 });
                }
            }
            dataGridView1.DataSource = t;
            //code = Convert.ToInt32(comboBox1.Text);
            textBox1.Text = code.ToString();
            label1.Text = dataGridView1.Rows[code - 1].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[code - 1].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[code - 1].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[code - 1].Cells[3].Value.ToString();
            label5.Text = dataGridView1.Rows[code - 1].Cells[4].Value.ToString();
            if (b == false)
            {
                pictureBox1.BackgroundImage = new Bitmap(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\" + code.ToString() + "_D.jpg");
            }
            else
            {
                pictureBox1.BackgroundImage = new Bitmap(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\" + code.ToString() + "_U.jpg");
            }
        }

        private void виведенняТаблицьНаЕкранToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hide_all();
            checkBox1.Visible = true;
            checkBox1.Checked = false;
            button1.Visible = true;
            button2.Visible = true;
            dataGridView1.Location = new Point(12,102);
            dataGridView1.Size = new Size(787, 446);
            dataGridView1.Visible = true;
            //
            button1.Text = "Показати зміст головної (першої) таблиці";
            button2.Text = "Показати зміст підлеглої (другої) таблиці";
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            if (checkBox1.Checked == true)
            {
                dataGridView1.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                comboBox5.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                pictureBox1.Visible = true;
                label6.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                dataGridView1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                comboBox3.Visible = false;
                comboBox4.Visible = false;
                comboBox5.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                pictureBox1.Visible = false;
                label6.Visible = false;
                textBox1.Visible = false;
            }
            code = 1;
            label1.Text = dataGridView1.Rows[code - 1].Cells[0].Value.ToString();
            label2.Text = dataGridView1.Rows[code - 1].Cells[1].Value.ToString();
            label3.Text = dataGridView1.Rows[code - 1].Cells[2].Value.ToString();
            label4.Text = dataGridView1.Rows[code - 1].Cells[3].Value.ToString();
            label5.Text = dataGridView1.Rows[code - 1].Cells[4].Value.ToString();
        }

        int code;
        private void button4_Click(object sender, EventArgs e)
        {
            if(code < dataGridView1.RowCount-1)
            {
                code++;
                textBox1.Text = code.ToString();
                comboBox1.Text = code.ToString();
            }
            //++
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (code > 1)
            {
                code--;
                textBox1.Text = code.ToString();
                comboBox1.Text = code.ToString();
            }
            //--
        }    

        private void button6_Click(object sender, EventArgs e)
        {
            code = 1;
            textBox1.Text = code.ToString();
            comboBox1.Text = code.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            code = dataGridView1.RowCount-1;
            textBox1.Text = code.ToString();
            comboBox1.Text = code.ToString();
        }

        private void додаванняТаСтиранняЗаписуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hide_all();
            button7.Visible = true;
            button8.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //add
            dataGridView1.Location = new Point(186,50);
            dataGridView1.Size = new Size(this.Width-186,this.Height-50);

            if(radioButton1.Checked!=radioButton2.Checked)
            {
                if (radioButton1.Checked == true)
                {
                    button1_Click(sender, e);
                    string a1 = (dataGridView1.RowCount).ToString();
                    string a2 = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву університету");
                    string a3 = Microsoft.VisualBasic.Interaction.InputBox("Введіть кількість факультетів");
                    string a4 = Microsoft.VisualBasic.Interaction.InputBox("Введіть дату першого випуску");
                    string a5 = Microsoft.VisualBasic.Interaction.InputBox("Чи є в університеті академіки('1' - так '0' - ні)");
                    t.Rows.Add(new String[] { a1, a2, a3, a4, a5 });
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = t;
                }
                else
                {
                    button2_Click(sender, e);
                    string a1 = (dataGridView1.RowCount).ToString();
                    string a2 = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву факультету");
                    string a3 = Microsoft.VisualBasic.Interaction.InputBox("Введіть назву університету, до якого належить");
                    string a4 = Microsoft.VisualBasic.Interaction.InputBox("Введіть кількість кафедр");
                    string a5 = Microsoft.VisualBasic.Interaction.InputBox("Кафедра з найбільшою кількістю студентів при факультеті");
                    t.Rows.Add(new String[] { a1, a2, a3, a4, a5 });
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = t;
                }
            }
            else
                MessageBox.Show("Виберіть таблицю, де будете додавати запис");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //del
            if (radioButton1.Checked != radioButton2.Checked)
            {
                int i = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(i);
            }
            else
                MessageBox.Show("Виберіть таблицю, де будете видаляти запис");
        }



        private void фільтруватиЗаписиТаблиці2ЗаПолемКількістьКафедрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hide_all();
            dataGridView1.Location = new Point(12, 102);
            dataGridView1.Size = new Size(787, 446);
            dataGridView1.Visible = true;
            dataGridView1.Refresh();
            label7.Visible = true;
            groupBox1.Visible = true;
            //radioButton3.Checked = true;
            //dataGridView1.Refresh();
            //XmlTextReader read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\Faculty.xml");
            //read.Read();
            //string st1, st2, st3, st4, st5;
            //read.Read();
            //t = new DataTable();
            //s = new DataSet();
            //t.Columns.Add("Код");
            //t.Columns.Add("Назва факультету");
            //t.Columns.Add("Назва університету, до якого належить");
            //t.Columns.Add("Кількість кафедр");
            //t.Columns.Add("Кафедра з найбільшою кількістю студентів при факультеті");

            //for (int i = 0; i < 9; i++)
            //{
            //    //read.ReadToFollowing("Код");
            //    read.MoveToNextAttribute();
            //    //if ()

            //    read.ReadToFollowing("Код");
            //    st1 = (read.ReadElementContentAsString());
            //    read.ReadToFollowing("Назва_x0020_факультету");
            //    st2 = (read.ReadElementContentAsString());
            //    read.ReadToFollowing("Назва_x0020_університету_x002C__x0020_до_x0020_якого_x0020_належить");
            //    st3 = (read.ReadElementContentAsString());
            //    read.ReadToFollowing("Кількість_x0020_кафедр");
            //    st4 = (read.ReadElementContentAsString());
            //    read.ReadToFollowing("Кафедра_x0020_з_x0020_найбільшою_x0020_кількістю_x0020_студентів_x0020_при_x0020_факультеті");
            //    st5 = (read.ReadElementContentAsString());
            //    if (radioButton3.Checked == true)
            //    {
            //        if (Convert.ToInt32(st4) > 10)
            //            t.Rows.Add(new String[] { st1, st2, st3, st4, st5 });
            //    }
            //    else if (radioButton4.Checked == true)
            //    {
            //        if (Convert.ToInt32(st4) < 10)
            //            t.Rows.Add(new String[] { st1, st2, st3, st4, st5 });
            //    }
            //    else if (radioButton5.Checked == true)
            //    {
            //        if (Convert.ToInt32(st4) == 10)
            //            t.Rows.Add(new String[] { st1, st2, st3, st4, st5 });
            //    }

            //}
            //dataGridView1.DataSource = t;
            XmlTextReader read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\Faculty.xml");
            read.Read();
            string st1, st2, st3, st4, st5;
            read.Read();
            t = new DataTable();
            //s = new DataSet();
            t.Columns.Add("Код");
            t.Columns.Add("Назва факультету");
            t.Columns.Add("Назва університету, до якого належить");
            t.Columns.Add("Кількістькафедр");
            t.Columns.Add("Кафедра з найбільшою кількістю студентів при факультеті");

            for (int i = 0; i < 9; i++)
            {
                //read.ReadToFollowing("Код");
                read.MoveToNextAttribute();
                //if (n == Convert.ToInt32(read.Value))
                {
                    read.ReadToFollowing("Код");
                    st1 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Назва_x0020_факультету");
                    st2 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Назва_x0020_університету_x002C__x0020_до_x0020_якого_x0020_належить");
                    st3 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Кількість_x0020_кафедр");
                    st4 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Кафедра_x0020_з_x0020_найбільшою_x0020_кількістю_x0020_студентів_x0020_при_x0020_факультеті");
                    st5 = (read.ReadElementContentAsString());
                    t.Rows.Add(new String[] { st1, st2, st3, st4, st5 });
                }
            }
            DataView dv1 = new DataView(t);
            //dv1.Sort = "Кількість кафедр";
            if (radioButton3.Checked == true)
            {
                dv1.RowFilter = "Кількістькафедр > 10";
                dataGridView1.DataSource = dv1;

            }
            if (radioButton4.Checked == true)
            {
                dv1.RowFilter = "Кількістькафедр < 10";
                dataGridView1.DataSource = dv1;
            }
            if (radioButton5.Checked == true)
            {
                dv1.RowFilter = "Кількістькафедр = 10";
                dataGridView1.DataSource = dv1;
            }
            
        }

        private void відсортуватиТаблицю1ЗаЗменшеннямУПоліДатаПершогоВипускуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            t = new DataTable();
            s = new DataSet();
            t.Columns.Add("Код");
            t.Columns.Add("Назва університету");
            t.Columns.Add("Кількість факультетів");
            t.Columns.Add("Дата першого випуску");
            t.Columns.Add("Чи є в університеті академіки");
            string st1, st2, st3, st4, st5;
            read = new XmlTextReader(@"D:\10 клас\Учеба\Компютерный проект\!!!\!!!\data base\data base\University.xml");
            read.Read();
            for (int i = 0; i < 5; i++)
            {
                //read.ReadToFollowing("Код");
                read.MoveToNextAttribute();
                //if (n == Convert.ToInt32(read.Value))
                {
                    read.ReadToFollowing("Код");
                    st1 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Назва_x0020_університету");
                    st2 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Кількість_x0020_факультетів");
                    st3 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Дата_x0020_першого_x0020_випуску");
                    st4 = (read.ReadElementContentAsString());
                    read.ReadToFollowing("Чи_x0020_є_x0020_в_x0020_університеті_x0020_академіки");
                    st5 = (read.ReadElementContentAsString());
                    t.Rows.Add(new String[] { st1, st2, st3, st4, st5 });
                }
            }
            hide_all();
            dv1 = new DataView(t);
            dv1.Sort = "Дата першого випуску";
            dataGridView1.DataSource = dv1;
            dataGridView1.Visible = true;
        }

        void hide_all()
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            comboBox1.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
            comboBox5.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;            
            label6.Visible = false;
            label7.Visible = false;

            radioButton1.Visible = false;
            radioButton2.Visible = false;

            dataGridView1.Visible = false;

            checkBox1.Visible = false;

            textBox1.Visible = false;            

            pictureBox1.Visible = false;

            groupBox1.Visible = false;

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void фільтраціяToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            фільтруватиЗаписиТаблиці2ЗаПолемКількістьКафедрToolStripMenuItem_Click(sender, e);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            фільтруватиЗаписиТаблиці2ЗаПолемКількістьКафедрToolStripMenuItem_Click(sender, e);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            фільтруватиЗаписиТаблиці2ЗаПолемКількістьКафедрToolStripMenuItem_Click(sender, e);
        }

        private void виведенняToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
