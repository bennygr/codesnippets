using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SimpleEfExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Album> albums = new AlbumRepository().GetAll();
            MessageBox.Show(string.Format(@"{0} albums found in the database", albums.Count));
        }
    }
}