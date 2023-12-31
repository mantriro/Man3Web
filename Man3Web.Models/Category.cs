﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Man3Web.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Catgory Name")]
        [MaxLength(30, ErrorMessage ="Name cant be empty or longer than 30 char")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage ="Range between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
