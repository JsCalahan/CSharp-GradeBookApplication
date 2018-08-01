﻿using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.20);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            //creates a list (grades) to hold the grades of the class. Sorts the Students by the AverageGrade, puts them in a list and then
            //selects those grades and sets grades equal to the list.


            if (grades[threshold - 1] <= averageGrade)
            {
                return 'A';

            }
            else if (grades[(threshold * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if (grades[(threshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if (grades[(threshold * 4)] - 1 <= averageGrade)
            {
                return 'D';
            }
            else return 'F';
                //return base.GetLetterGrade(averageGrade);
        }
    }
}
