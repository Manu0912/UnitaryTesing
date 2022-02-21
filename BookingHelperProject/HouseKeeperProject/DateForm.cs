using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExercises.HouseKeeperProject
{
    public class DateForm
    {
        public DateTime Date { get; set; }

        public DateForm(string statementDate, object endOfLastMonth)
        {
        }

        public DialogResult ShowDialog()
        {
            return DialogResult.Abort;
        }
    }
}
