using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Window
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
        }
        private Point start;
        private Point p1, p2, p3, p4;
        private Panel source, destination;
       List<Panel> panels = new List<Panel>();
        private void Form1_Load(object sender, EventArgs e)
        {
            Panel1.AllowDrop = true;
             p1= Panel1.Location;
             p2 = Panel2.Location;
             p3 = Panel3.Location;
             p4 = Panel4.Location; Form f = (Form) sender;
             foreach (Control c in f.Controls)
             {
                 if (c is Panel)
                     panels.Add( (Panel)c);
             }

             panels.Sort((c1, c2) => c1.TabIndex.CompareTo(c2.TabIndex));
             MessageBox.Show(panels[0].Name + "-" + panels[1].Name+ "-" + panels[2].Name+ "-" + panels[3].Name);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel1.ResetText();
        }

      

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location; 
                Panel1.MouseUp += new MouseEventHandler(Panel1_MouseUp);
                Panel1.MouseMove += new MouseEventHandler(Panel1_MouseMove);
               
            
               
        }
        void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
           
            Panel1.MouseMove -= new MouseEventHandler(Panel1_MouseMove);
            Panel1.MouseUp -= new MouseEventHandler(Panel1_MouseUp);
         

     
           
        }
        void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Panel1.Location = new Point(Panel1.Location.X - (start.X - e.X), Panel1.Location.Y - (start.Y - e.Y));
           
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            Panel2.MouseUp += new MouseEventHandler(Panel2_MouseUp);
            Panel2.MouseMove += new MouseEventHandler(Panel2_MouseMove);



        }
        void Panel2_MouseUp(object sender, MouseEventArgs e)
        {

            Panel2.MouseMove -= new MouseEventHandler(Panel2_MouseMove);
            Panel2.MouseUp -= new MouseEventHandler(Panel2_MouseUp);

        }
        void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            Panel2.Location = new Point(Panel2.Location.X - (start.X - e.X), Panel2.Location.Y - (start.Y - e.Y));

        }
        private void Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            Panel3.MouseUp += new MouseEventHandler(Panel3_MouseUp);
            Panel3.MouseMove += new MouseEventHandler(Panel3_MouseMove);



        }
        void Panel3_MouseUp(object sender, MouseEventArgs e)
        {

            Panel3.MouseMove -= new MouseEventHandler(Panel3_MouseMove);
            Panel3.MouseUp -= new MouseEventHandler(Panel3_MouseUp);

        }
        void Panel3_MouseMove(object sender, MouseEventArgs e)
        {
            Panel3.Location = new Point(Panel3.Location.X - (start.X - e.X), Panel3.Location.Y - (start.Y - e.Y));

        }


        private void Panel4_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
            Panel4.MouseUp += new MouseEventHandler(Panel4_MouseUp);
            Panel4.MouseMove += new MouseEventHandler(Panel4_MouseMove);



        }
        void Panel4_MouseUp(object sender, MouseEventArgs e)
        {

            Panel4.MouseMove -= new MouseEventHandler(Panel4_MouseMove);
            Panel4.MouseUp -= new MouseEventHandler(Panel4_MouseUp);




        }
        void Panel4_MouseMove(object sender, MouseEventArgs e)
        {
            Panel4.Location = new Point(Panel4.Location.X - (start.X - e.X), Panel4.Location.Y - (start.Y - e.Y));

        }
        private void SwapPosition(Panel source, Panel destination)
        {
            String essage = panels[0].Location + "-" + panels[1].Location + "-" + panels[2].Location + "-" + panels[3].Location;
            int sIndex = panels.IndexOf(source);
            int dIndex = panels.IndexOf(destination);
            source.Location = destination.Location;
            for (int i = sIndex + 1; i <= dIndex; i++) {
                Panel p = panels[i-1];
                panels[i].Location = panels[i - 1].Location;
                panels[i - 1] = panels[i];
                panels[i] = p;
            }
            essage +="\n" +panels[0].Name + "-" + panels[1].Name + "-" + panels[2].Name + "-" + panels[3].Name;
            MessageBox.Show(essage + "\n" + panels[0].Location + "-" + panels[1].Location + "-" + panels[2].Location + "-" + panels[3].Location);
        }

        private void Panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.Write("Panel1>>>>>" + Panel1.Location + "Panel2>>>>" + Panel2.Location + "Panel4>>" + Panel4.Location);
            Panel source = (Panel)sender;

            if (Panel1.Bounds.IntersectsWith(Panel2.Bounds))
            {
                destination = Panel2;
            }
            else if (Panel1.Bounds.IntersectsWith(Panel3.Bounds))
            {
                destination = Panel3;
            }
            else if (Panel1.Bounds.IntersectsWith(Panel4.Bounds))
            {
                destination = Panel4;

            }
            MessageBox.Show(source.Name + ":" + destination.Name);

            SwapPosition(source, destination);
        }
       



    }
}
