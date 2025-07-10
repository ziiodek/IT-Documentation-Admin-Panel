using System;
using System.ComponentModel.DataAnnotations;

namespace ITDocumentation
{

    public class Downtime : Author
    {

        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximum character length is 50 characters")]
        public string SystemImpacted { get; set; }

        [StringLength(10, ErrorMessage = "Maximum character length is 10 characters")]
        public string Status { get; set; }
        public int Ticket { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime TimeLapsed { get; set; }
        public int TimeLapsedMinutes { get; set; }
        public string Impact { get; set; }
        public string Cause { get; set; }
        public string CorrectiveAction { get; set; }
        public string Requestor { get; set; }
        public string Notes { get; set; }


    }

}