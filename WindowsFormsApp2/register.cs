using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovoy_proekt
{
    public partial class register : Form
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
        private void WriteToXMLDocument(string filepath, string name, string pwd) //добавление записи
        {
            if (!File.Exists(defpath)) CreateXMLDocument(defpath);
            string id = MaxID(filepath);
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlElement user = xd.CreateElement("user");
            user.SetAttribute("id", id);

            XmlElement login = xd.CreateElement("login");
            XmlElement pass = xd.CreateElement("password");

            XmlText tLogin = xd.CreateTextNode(name);
            XmlText tPassword = xd.CreateTextNode(pwd);

            login.AppendChild(tLogin);
            pass.AppendChild(tPassword);

            user.AppendChild(login);
            user.AppendChild(pass);

            xd.DocumentElement.AppendChild(user);

            fs.Close();
            xd.Save(filepath);
        }
        private void CreateXMLDocument(string filepath) //создание xml файла
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("users");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
            this.Hide();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            if (!File.Exists(defpath)) CreateXMLDocument(defpath);
        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            if (!(loginregbox.Text == "") & !(passregbox.Text == ""))
                WriteToXMLDocument(defpath, loginregbox.Text, passregbox.Text);
            else MessageBox.Show("Введите имя пользователя и пароль");
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
    }
}
