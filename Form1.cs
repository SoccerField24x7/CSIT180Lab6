/*********************************************************************
 * Program:     Grade Calculator
 * Student:     Jesse Quijano (#001456787)
 * Purpose:     Lab6 - Read "grade file" and display data
 * Description: The purpose of this lab is to read a CSV data file and hydrate an object.
 *              Must utilize a fixed length array.
 *************************************************************************************/

using System;
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

        /// <summary>
        /// Menu item to open a file dialog and process the data file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* make sure the list is clear */
            lstScores.Items.Clear();

            /* present the file open dialog */
            var btn = openFileDialog1.ShowDialog();

            if(btn == DialogResult.OK)
            {
                var filePath = openFileDialog1.FileName;
                
                try
                {
                    GradeHelper helper = new GradeHelper(filePath);
                    var grades = helper.Read();

                    /* now that we have the grades, generate the score */
                    grades.CalculateGpa();

                    PopulateForm(grades);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void PopulateForm(Grades grades)
        {
            lblClass.Text = grades.ClassName;
            lblName.Text = grades.StudentName;
            lblSemester.Text = grades.Semester;

            foreach (var score in grades.GetScores())
            {
                lstScores.Items.Add(score);
            }

            lblLetterGrade.Text = grades.GetLetterGrade();

            switch (lblLetterGrade.Text.Trim())
            {
                case "A":
                case "B":
                case "C":
                    lblLetterGrade.ForeColor = System.Drawing.Color.Green;
                    break;
                case "D":
                    lblLetterGrade.ForeColor = System.Drawing.Color.Orange;
                    break;
                default:
                    lblLetterGrade.ForeColor = System.Drawing.Color.Red;
                    break;
            }
        }
    }
}
