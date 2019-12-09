using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GradeCalc.BusinessLogic;

namespace GradeCalc.BusinessLogic
{
    public class GradeHelper
    {
        private readonly string _filePath;

        public GradeHelper(string filePath)
        {
            this._filePath = filePath;

            if (!File.Exists(this._filePath))
            {
                throw new FileLoadException("The specified file does not exist.");
            }
        }

        /// <summary>
        /// Reads a data file, Validates its length, then creates a grades object
        /// </summary>
        /// <returns></returns>
        public Grades Read()
        {
            string line = "";
            using (StreamReader reader = new StreamReader(this._filePath))
            {
                line = reader.ReadLine() ?? ""; // for now, we're only going to read one line
                if (String.IsNullOrWhiteSpace(line))
                {
                    throw new Exception("The file is empty or begins with a blank line");
                }

                if (!this.Validate(line))
                {
                    throw new Exception("The file data was not valid");
                }
            }

            return this.CreateGradesObject(line);
        }

        /// <summary>
        /// Ensure the data row has the proper number of elements
        /// </summary>
        /// <param name="dataLine"></param>
        /// <returns></returns>
        public bool Validate(string dataLine)
        {
            var values = this.ParseLine(dataLine);
            
            return values.Length == 12;
        }

        private Grades CreateGradesObject(string dataLine)
        {
            var values = this.ParseLine(dataLine);
            Grades grades = new Grades();

            grades.StudentName = values[0];
            grades.ClassName = values[1];
            grades.Semester = values[2];
            grades.StudentImageName = values[3];

            // assign grades
            for (var i = 4; i < values.Length; i++)
            {
                grades.AddScore(Double.Parse(values[i]));
            }



            return grades;
        }

        private string[] ParseLine(string line)
        {
            return line.Split(',');
        }
    }
}
