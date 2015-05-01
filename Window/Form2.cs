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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        List<Panel> panels = new List<Panel>();
        Point sourcePoint; int sourceIndex = 0;
        List<Panel> temp = null;
        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel destination = (Panel)sender;
            Point tr = destination.Location;
           // destination.Location = ctrl.Location;
            ctrl.Location = tr;
            if (ctrl is Panel)
            { Panel source = (Panel)ctrl;
            SwapPosition(source, destination);
            }
        }

        private void SwapPosition(Panel source, Panel destination)
        {
            String message = "Soutcere >>"+source.Name;
            foreach (Panel p in panels)
            {
                message += p.Name + "--" + p.Location + "--" + p.TabIndex;

            }
            Console.WriteLine(message);
            
            int sIndex = panels.IndexOf(source);
            int dIndex = panels.IndexOf(destination);
          
             //source.Location = destination.Location;
             //source.TabIndex = destination.TabIndex;


             if (sIndex < dIndex)
             {

                 Point tempP = panels[sIndex + 1].Location;
                 int tempI = panels[sIndex + 1].TabIndex;
                 panels[sIndex+1].Location = sourcePoint;
                 panels[sIndex + 1].TabIndex = sourceIndex;

                 for (int i = sIndex + 2; i <= dIndex; i++) {
                     Point tempD = panels[i].Location;
                     int ij = panels[i].TabIndex;

                     panels[i].Location = tempP;
                     panels[i].TabIndex = tempI;

                     tempP = tempD; tempI = ij;
                 }
             }
             else
             {

                 int k = dIndex;
                 for (; k < sIndex; k++)
                 {
                     Panel p = panels[k + 1];
                     panels[k].Location = p.Location;
                     panels[k].TabIndex = p.TabIndex;

                 }
                 panels[k].Location = sourcePoint;
                 panels[k].TabIndex = sourceIndex;
             
             
             }
             panels[sIndex].TabIndex = panels[dIndex].TabIndex;
             panels.Sort((c1, c2) => c1.TabIndex.CompareTo(c2.TabIndex));

             message = "after position>>>";
            foreach (Panel p in panels) {
                message += p.Name + "--"+p.Location+"--"+p.TabIndex;

            }
            //MessageBox.Show(message); 
            Console.WriteLine(message);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Panel lt = (Panel)sender; sourcePoint = lt.Location;
            DoDragDrop(lt, DragDropEffects.Move);
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {

        }


        private void panel2_DragDrop(object sender, DragEventArgs e)
        {
            Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel destination = (Panel)sender;
            Point tr = destination.Location;
           // destination.Location = ctrl.Location;
            ctrl.Location = tr;
            if (ctrl is Panel)
            {
                Panel source = (Panel)ctrl;
                SwapPosition(source, destination);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            Panel lt = (Panel)sender; sourcePoint = lt.Location; sourceIndex = lt.TabIndex;
            DoDragDrop(lt, DragDropEffects.Move);
        }

        private void panel2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void panel2_DragOver(object sender, DragEventArgs e)
        {

        }


        private void panel3_DragDrop(object sender, DragEventArgs e)
        {
            Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel destination = (Panel)sender;
            Point tr = destination.Location;
          //  destination.Location = ctrl.Location;
            ctrl.Location = tr;
            if (ctrl is Panel)
            {
                Panel source = (Panel)ctrl;
                SwapPosition(source, destination);
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Panel lt = (Panel)sender; sourcePoint = lt.Location; sourceIndex = lt.TabIndex;
            DoDragDrop(lt, DragDropEffects.Move);
        }

        private void panel3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void panel3_DragOver(object sender, DragEventArgs e)
        {
           
        }


        private void panel4_DragDrop(object sender, DragEventArgs e)
        {
            Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel destination = (Panel)sender;
            Point tr = destination.Location;
           // destination.Location = ctrl.Location;
            ctrl.Location = tr;
            if (ctrl is Panel)
            {
                Panel source = (Panel)ctrl;
                SwapPosition(source, destination);
            }
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            Panel lt = (Panel)sender; sourcePoint = lt.Location; sourceIndex = lt.TabIndex;
            DoDragDrop(lt, DragDropEffects.Move);
        }

        private void panel4_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void panel4_DragOver(object sender, DragEventArgs e)
        {

        }


        private void panel5_DragDrop(object sender, DragEventArgs e)
        {
            Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            Panel destination = (Panel)sender;
            Point tr = destination.Location;
            //destination.Location = ctrl.Location;
            ctrl.Location = tr;
            if (ctrl is Panel)
            {
                Panel source = (Panel)ctrl;
                SwapPosition(source, destination);
            }
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            Panel lt = (Panel)sender; sourcePoint = lt.Location; sourceIndex = lt.TabIndex;
            DoDragDrop(lt, DragDropEffects.Move);
        }

        private void panel5_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 
        }

        private void panel5_DragOver(object sender, DragEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form f = (Form)sender;
            foreach (Control c in f.Controls)
            {
                if (c is Panel)
                    panels.Add((Panel)c);
            }

            panels.Sort((c1, c2) => c1.TabIndex.CompareTo(c2.TabIndex));
            String message = "Initalization>>>>";
            foreach (Panel p in panels)
            {
                message += p.Name + "--"+p.Location+"---"+p.TabIndex;

            }
            Console.WriteLine(message);
        }

        private void labelN_Click(object sender, EventArgs e)
        {

        }
    }
}
