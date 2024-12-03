using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class DrawGraphic : Form
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;
        Color backcolor = Color.White;
        Color edgeColor = Color.DarkGoldenrod;
        public SolidBrush vertexBrush = new SolidBrush(Color.White);

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

        public DrawGraphic()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            sheet.Image = G.GetBitmap();
            sheet.ContextMenuStrip = contextMenuStrip1;
            colorDialog1.FullOpen = true;
        }

        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet(backcolor);
            G.drawALLGraph(V, E, vertexBrush, 0, false);
            sheet.Image = G.GetBitmap();
        }

        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet(backcolor);
            G.drawALLGraph(V, E, vertexBrush, 0, false);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            G.clearSheet(backcolor);
            G.drawALLGraph(V, E, vertexBrush, 0, false);
            sheet.Image = G.GetBitmap();
        }

        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet(backcolor);
                sheet.Image = G.GetBitmap();
                listBox2.Items.Clear();
            }
        }
        int l = 0;
        int[] nums = new int[20];
        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString(), vertexBrush);
                sheet.Image = G.GetBitmap();
            }
            //нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                listBox2.Items.Add(l);
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                l++;
                                selected2 = i;
                                switch (l)
                                {
                                    case 1:
                                        { textBox1.Visible = true; label1.Visible = true; label1.Text = (" Ребро между "+ (selected1 + 1) +" и "+ (selected2+1));nums[1] = selected1 + 1; nums[2] = selected2 + 1; }
                                        break;
                                    case 2:
                                        { textBox2.Visible = true; label2.Visible = true; label2.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[3] = selected1 + 1; nums[4] = selected2 + 1; }
                                        break;
                                    case 3:
                                        { textBox3.Visible = true; label3.Visible = true; label3.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[5] = selected1 + 1; nums[6] = selected2 + 1; }
                                        break;
                                    case 4:
                                        { textBox4.Visible = true; label4.Visible = true; label4.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[7] = selected1 + 1; nums[8] = selected2 + 1; }
                                        break;
                                    case 5:
                                        { textBox5.Visible = true; label5.Visible = true; label5.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[9] = selected1 + 1; nums[10] = selected2 + 1; }
                                        break;
                                    case 6:
                                        { textBox6.Visible = true; label6.Visible = true; label6.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[11] = selected1 + 1; nums[12] = selected2 + 1; }
                                        break;
                                    case 7:
                                        { textBox7.Visible = true; label7.Visible = true; label7.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[13] = selected1 + 1; nums[14] = selected2 + 1; }
                                        break;
                                    case 8:
                                        { textBox8.Visible = true; label8.Visible = true; label8.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[15] = selected1 + 1; nums[16] = selected2 + 1; }
                                        break;
                                    case 9:
                                        { textBox9.Visible = true; label9.Visible = true; label9.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[17] = selected1 + 1; nums[18] = selected2 + 1; }
                                        break;
                                    case 10:
                                        { textBox10.Visible = true; label10.Visible = true; label10.Text = (" Ребро между " + (selected1 + 1) + " и " + (selected2 + 1)); nums[19] = selected1 + 1; nums[20] = selected2 + 1;    }
                                        break;
                                }
                                E.Add(new Edge(selected1, selected2));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1, vertexBrush);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString(), vertexBrush);
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
            //нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearSheet(backcolor);
                    G.drawALLGraph(V, E, vertexBrush, 0, false);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        private void сохранитьГрафToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sheet.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void stepButton_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            int max = 0;
            int minimum = 99999999;
            int maxvershin = 0;
            int maximum = 0;
            int vershin = 0;
            int vershinmin = 0;
            int vershinj = 0;
            for (int i=1;i<l+1;i++)
            {
                max = 0;
                int chet = 0;
                for (int j=1;j<(l+1)*2;j++)
                {
                    if (i ==nums[j])
                    {
                        chet++;
                        int chetnum = i;
                        switch (chetnum)
                        {
                            case 1:
                                { max += int.Parse(textBox1.Text); }
                                break;
                            case 2:
                                { max += int.Parse(textBox2.Text); }
                                break;
                            case 3:
                                { max += int.Parse(textBox3.Text); }
                                break;
                            case 4:
                                { max += int.Parse(textBox4.Text); }
                                break;
                            case 5:
                                { max += int.Parse(textBox5.Text); }
                                break;
                            case 6:
                                { max += int.Parse(textBox6.Text); }
                                break;
                            case 7:
                                { max += int.Parse(textBox7.Text); }
                                break;
                            case 8:
                                { max += int.Parse(textBox8.Text); }
                                break;
                            case 9:
                                { max += int.Parse(textBox9.Text); }
                                break;
                            case 10:
                                { max += int.Parse(textBox10.Text); }
                                break;
                        }
                        max = max / chet;
                        if (maximum<max)
                        {
                            maximum = max;
                            vershin = chetnum;
                        }
                        if (max<minimum)
                        {
                            minimum = max;
                            vershinmin = chetnum;
                        }
                        if (maxvershin<chet)
                        {
                            maxvershin = chet;
                            vershinj = chetnum;
                        }
                    }
                }
            }
            listBox2.Items.Add(" ");
            listBox2.Items.Add ("Радуисом является вершина " + vershin + " соединённая с другими вершинами");
            listBox2.Items.Add(" ");
            listBox2.Items.Add("Диаметром является вершина " + vershinj);
            listBox2.Items.Add(" ");
            listBox2.Items.Add("Цетром графа является " + vershinmin);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void новыйГрафToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Вы действительно хотите создать новый граф?";
            const string caption = "Новый граф";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet(backcolor);
                sheet.Image = G.GetBitmap();
                listBox2.Items.Clear();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Вы действительно хотите выйти?";
            const string caption = "Выход";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void изменитьЦветПоляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            backcolor = colorDialog1.Color;
            G.clearSheet(backcolor);
            G.drawALLGraph(V, E, vertexBrush, 0, false);
            sheet.Image = G.GetBitmap();
        }

        private void изменитьЦветВершинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            vertexBrush.Color = colorDialog1.Color;
            G.drawALLGraph(V, E, vertexBrush, 0, false);
            sheet.Image = G.GetBitmap();
        }

        private void изменитьЦветРеберToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            edgeColor = colorDialog1.Color;
            G.edgePen_Change(edgeColor);
            G.drawALLGraph(V, E, vertexBrush, 0, false);
            sheet.Image = G.GetBitmap();
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Данная программа реализует нахождение радиуса, диаметра и центра графа";
            const string caption = "Справка";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}
