
namespace FoodDataService.Models
{
    public class FoodDescription
    {
        public string Ndb_No { get; set; }
        public string FdGrp_Cd { get; set; }
        public string Long_Desc { get; set; }
        public string Shrt_Desc { get; set; }
        public string ComName { get; set; }
        public string ManufacName { get; set; }
        public string Survey { get; set; }
        public string Ref_Desc { get; set; }
        public decimal Refuse { get; set; }
        public string SciName { get; set; }
        public decimal N_Factor { get; set; }
        public decimal Pro_Factor { get; set; }
        public decimal Fat_Factor { get; set; }
        public decimal CHO_Factor { get; set; }
    }
}