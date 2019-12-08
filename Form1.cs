using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GradeCalc.BusinessLogic;

namespace GradeCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /* initialize the file dialog */
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.Title = "Select a Student Grade File";
        }

        private void loadStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* present the file open dialog */
            var btn = openFileDialog1.ShowDialog();

            if(btn == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;

                GradeHelper helper = new GradeHelper(filePath);

                try
                {
                    
                }
                catch(Exception ex)
                {

                }
            }
        }

        private void PopulateForm(GradeHelper gh)
        {

        }
    }
}
