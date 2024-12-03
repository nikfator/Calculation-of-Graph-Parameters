using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp2
{
    class Vertex
    {
        public int x, y;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public int v1, v2;

        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Graphics gr;
        Pen blackpen, edgepen, redpen;
        SolidBrush br;
        Font fo;
        PointF point;
        public int R = 20;

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet(Color.White);
            blackpen = new Pen(Color.Black);
            blackpen.Width = 2;
            edgepen = new Pen(Color.Black);
            edgepen.Width = 3;
            redpen = new Pen(Color.Red);
            redpen.Width = 2;
            br = new SolidBrush(Color.Black);
            fo = new Font("Arial", 15);
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public Pen edgePen_Change(Color edgeColor)
        {
            edgepen.Color = edgeColor;
            return edgepen;
        }

        public void clearSheet(Color color)
        {
            gr.Clear(color);
        }

        public void drawVertex(int x, int y, string number, SolidBrush vertexBrush)
        {
            gr.FillEllipse(vertexBrush, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackpen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redpen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E, int numberE, SolidBrush vertexBrush)
        {
            if (E.v1 == E.v2)
            {
                gr.DrawArc(edgepen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString(), vertexBrush);
            }
            else
            {
                gr.DrawLine(edgepen, V1.x, V1.y, V2.x, V2.y);
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString(), vertexBrush);
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString(), vertexBrush);
            }
        }

        public void drawALLGraph(List<Vertex> V, List<Edge> E, SolidBrush vertexBrush, int w, bool redraw)
        {
            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 == E[i].v2 && !redraw)
                {
                    gr.DrawArc(edgepen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                }
                else if (!redraw)
                {
                    gr.DrawLine(edgepen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y);
                }
            }
            if (redraw)
            {
                if (E[w].v1 == E[w].v2)
                    gr.DrawArc(edgepen, (V[E[w].v1].x - 2 * R), (V[E[w].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                else
                {
                    gr.DrawLine(edgepen, V[E[w].v1].x, V[E[w].v1].y, V[E[w].v2].x, V[E[w].v2].y);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString(), vertexBrush);
            }
        }
    }
}
