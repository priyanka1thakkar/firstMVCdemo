using firstMVCAppDemo.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace firstMVCAppDemo.Models
{
    public class BookModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name ="Choose Date & Time")]
        public string MyField { get; set; }
        //public string Language { get; set; }
        public int Id { get; set; }
        [StringLength(100,MinimumLength =5)]
        [Required(ErrorMessage = "Please Enter title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter author of your book")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please select multiple language of your book")]
        public LanguageEnum LanguageEnum { get; set; }
        [Required(ErrorMessage = "Please Enter total pages of your book")]
        public int? TotalPages { get; set; }
    }
}
