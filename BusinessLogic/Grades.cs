using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeCalc.BusinessLogic
{
    public class Grades
    {
        public string StudentName;
        public string ClassName;
        public string Semester;
        public string StudentImageName;

        private readonly double[] Scores; // required to use an array; List<double> would provide better flexibility
        private int _index = 0;
        private double _averageScore;

        public Grades()
        {
            this.Scores = new double[8]; // create storage
        }

        /// <summary>
        /// Adds a single score and updates the internal pointers
        /// </summary>
        /// <param name="score"></param>
        public void AddScore(double score)
        {
            if (this._index > 7)
            {
                throw new IndexOutOfRangeException("Cannot add more than 8 scores.");
            }

            this.Scores[this._index++] = score;
        }

        /// <summary>
        /// Calculate an average grade based on each assignment being 100 points
        /// </summary>
        /// <returns></returns>
        public double CalculateGpa()
        {
            double total = 0;
            var count = 0;

            foreach (var score in Scores)
            {
                total += score;
                count++;
            }

            if (count > 0) // guard against div by 0
            {
                this._averageScore = total / (count * 100);
            }

            return this._averageScore;
        }

        public string GetLetterGrade()
        {
            var grade = "F";

            if (this._averageScore  > .890)
            {
                grade = "A";
            }
            else if (this._averageScore > .790)
            {
                grade = "B";
            }
            else if (this._averageScore > .690)
            {
                grade = "C";
            }
            else if (this._averageScore > .590)
            {
                grade = "D";
            }

            return grade;
        }

        public double[] GetScores()
        {
            return this.Scores;
        }
    }
}
