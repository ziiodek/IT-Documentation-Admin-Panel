using System;
using System.ComponentModel.DataAnnotations;

namespace ITDocumentation
{

    public class MenuItem : Author
    {

        public int ID { get; set; }

        [Required]
        public int PageID { get; set; }
        [StringLength(30, ErrorMessage = "Maximum character length is 30 characters")]
        public string? Name { get; set; }

    }

}