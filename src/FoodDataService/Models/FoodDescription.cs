using System.ComponentModel.DataAnnotations;

namespace FoodDataService.Models
{
    public class FoodDescription
    {
        [Key]
        public char NdbNo { get; set; }

        [Required]
        public char FdgrpCd { get; set; }

        [Required]
        public char LongDesc { get; set; }

        [Required]
        public char ShrtDesc { get; set; }

        public char? Comname { get; set; }
        public char? Manufacname { get; set; }
        public char? Survey { get; set; }
        public char? RefDesc { get; set; }
        public decimal? Refuse { get; set; }
        public char? Sciname { get; set; }
        public decimal? NFactor { get; set; }
        public decimal? ProFactor { get; set; }
        public decimal? FatFactor { get; set; }
        public decimal? ChoFactor { get; set; }
    }
}
