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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private int posx;
        private int posy;
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Button lt = (Button)sender;
            DoDragDrop(lt, DragDropEffects.Move);

        }

        private void panel1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Control ctrl = e.Data.GetData(e.Data.GetFormats()[0]) as Control;
            MessageBox.Show(ctrl.Name +"");
            this.button1.SetBounds(this.posx, this.posy, button1.Width, button1.Height);
        }

        private void panel1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move; 

        }

        private void panel1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            Point clientp = this.panel1.PointToClient(new Point(e.X, e.Y)); 
            this.posx = clientp.X;
            this.posy = clientp.Y;
        }


        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            Button lt = (Button)sender;
            DoDragDrop(lt, DragDropEffects.Move);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
