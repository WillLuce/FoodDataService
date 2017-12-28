using System.ComponentModel.DataAnnotations;

namespace FoodDataService.Models
{
    public class FoodDescription
    {
        [Key]
        public string ndb_no { get; set; }

        [Required]
        public string fdgrp_cd { get; set; }

        [Required]
        public string long_desc { get; set; }

        [Required]
        public string shrt_desc { get; set; }

        public string comname { get; set; }
        public string manufacname { get; set; }
        public string survey { get; set; }
        public string refdesc { get; set; }
        public decimal? refuse { get; set; }
        public char? sciname { get; set; }
        public decimal? n_factor { get; set; }
        public decimal? pro_factor { get; set; }
        public decimal? fat_factor { get; set; }
        public decimal? cho_factor { get; set; }
    }
}
