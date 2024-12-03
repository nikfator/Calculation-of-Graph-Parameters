using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace Kursovoy_proekt
{
    public partial class Form1 : Form
    {
        public string defpath = "users.xml";
        private string MaxID(string filepath) //вычисление max id
        {
            List<int> idList = new List<int>();
            int id;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("user");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement user = (XmlElement)xd.GetElementsByTagName("user")[i];
                    id = Convert.ToInt32(user.GetAttribute("id"));
                    idList.Add(id);
                }
                int result = 0;
                foreach (int j in idList)
                    if (j > result)
                        result = j;
                result++;
                fs.Close();
                return result.ToString();
            }
            else
            {
                fs.Close();
                return "1";
            }
        }
        private void ReadXMLDocument(string filepath, string loget, string passget)
        {
            string name, pwd;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("user");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[i];
                XmlElement pass = (XmlElement)xd.GetElementsByTagName("password")[i];
                name = user.InnerText;
                pwd = pass.InnerText;
                if ((loget == name) & (passget == pwd))
                {
                    DrawGraphic newForm = new DrawGraphic();
                    newForm.Show();
                    this.Hide();
                    break;
                }
                else if (i == list.Count - 1) MessageBox.Show("Неверный логин или пароль");
            }
            fs.Close();
        }

        private void CreateXMLDocument(string filepath) //создание xml файла
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("users");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string message = "Вы действительно хотите выйти?";
            const string caption = "Выход";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            register newForm = new register();
            newForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(loginenbox.Text == "") & !(passenbox.Text == ""))
            {
                ReadXMLDocument(defpath, loginenbox.Text, passenbox.Text);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists(defpath)) CreateXMLDocument(defpath);

        }
    }
}
