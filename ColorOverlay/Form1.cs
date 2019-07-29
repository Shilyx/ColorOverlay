using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ColorOverlay
{
    public partial class Form1 : Form
    {
        private bool bAdd = true;

        public Form1()
        {
            InitializeComponent();
            panel1.BackColor = Color.Blue;
            panel2.BackColor = Color.Red;
            calc();
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            bAdd = !bAdd;
            btnOperator.Text = bAdd ? "+" : "-";
            calc();
        }

        private void calc()
        {
            int r = Math.Min((panel1.BackColor.R + panel2.BackColor.R) / 2, 255);
            int g = Math.Min((panel1.BackColor.G + panel2.BackColor.G) / 2, 255);
            int b = Math.Min((panel1.BackColor.B + panel2.BackColor.B) / 2, 255);

            panel3.BackColor = Color.FromArgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b));
        }

        private void panel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel p = sender as Panel;
            Color c = ChooseColor(p.BackColor);

            if (c == Color.Empty)
            {
                return;
            }

            p.BackColor = c;
            p.Update();

            calc();
        }

        private static Color ChooseColor(Color colorInit)
        {
            ColorDialog colorForm = new ColorDialog();

            colorForm.Color = colorInit;

            if (colorForm.ShowDialog() == DialogResult.OK)
            {
                return colorForm.Color;
            }

            return Color.Empty;
        }
    }
}
