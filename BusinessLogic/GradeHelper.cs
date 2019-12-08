using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GradeCalc.BusinessLogic
{
    public class GradeHelper
    {
        private string filePath;

        public GradeHelper(string filePath)
        {
            this.filePath = filePath;
        }

        public bool Validate()
        {
            return true;
        }
    }
}
