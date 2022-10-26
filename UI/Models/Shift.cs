using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public decimal Pay { get; set; }
        public decimal Minutes { get { return CalculateTotalMinutes(); } }
        public string Location { get; set; }

        private decimal CalculateTotalMinutes()
        {
            TimeSpan timeSpan = End - Start;
            double minutes = timeSpan.TotalMinutes;

            return Convert.ToDecimal(minutes);
        }
    }
}
