using System;
using System.ComponentModel.DataAnnotations;

namespace SchedulerSimpleCustomFormMvc.Models {
    public class ValidationSchedule {
        public int ID { get; set; }
        [Required(ErrorMessage = "The Subject must contain at least one character.")]
        public string Subject { get; set; }
        public decimal? Price { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
    }
}