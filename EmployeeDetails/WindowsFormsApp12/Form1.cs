using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Panel Renkleri
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Transparent;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.Transparent;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.White;
        }
        #endregion
        public int Satir { get; set; }
        public int Sutun { get; set; }
        Resimleme Resimleme = new Resimleme();
        DataClasses1DataContext dc = new DataClasses1DataContext();
        List<UserPersonals> TIL = new List<UserPersonals>();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.92;
            Satir = 0;
            Sutun = 0;
            tableLayoutPanel1.VerticalScroll.Visible = false;
            tableLayoutPanel1.HorizontalScroll.Visible = false;
            foreach(var deg in dc.Personal)
            {
                Yerlestir(Resimleme.ResimGetirme(deg.Personel_Picture.ToArray()), deg.Personal_Name + " " + deg.Personal_Surname, deg.Telefon, deg.Personal_Id);
            }
        }
        
        public void Yerlestir(Image resim,string  isim,string telefon,int Id)
        {
            UserPersonals user = new UserPersonals();
            user.bunifuPictureBox1.Image = resim;
            user.label1.Text = isim;
            user.label2.Text = telefon;
            user.bunifuThinButton21.Tag = Id;
            TIL.Add(user);
            user.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(user, Satir, Sutun);
            Sutun += 1;
            if (Sutun == 3)
            {
                Satir += 1;
                Sutun = 0;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            bunifuVScrollBar1.Maximum = tableLayoutPanel1.VerticalScroll.Maximum;
            bunifuVScrollBar1.ThumbLength = 40;
        }

        private void bunifuVScrollBar1_Scroll_1(object sender, BunifuVScrollBar.ScrollEventArgs e)
        {
            // This automatically scrolls the flow-layout position based on the scroll value.
            tableLayoutPanel1.AutoScrollPosition = new Point(tableLayoutPanel1.AutoScrollPosition.X, e.Value);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
