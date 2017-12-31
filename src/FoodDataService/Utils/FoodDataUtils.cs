using FoodDataService.Models;

namespace FoodDataService.Utils
{
    public static class FoodDataUtils
    {
        public static FoodDescriptionResponse ToFoodDescriptionResponse(this FoodDescriptionData foodDescriptionData)
        {
            return new FoodDescriptionResponse
            {
                ndb_no = foodDescriptionData.ndb_no,
                cho_factor = foodDescriptionData.cho_factor,
                comname = foodDescriptionData.comname,
                fat_factor = foodDescriptionData.fat_factor,
                fdgrp_cd = foodDescriptionData.fdgrp_cd,
                long_desc = foodDescriptionData.long_desc,
                manufacname = foodDescriptionData.manufacname,
                n_factor = foodDescriptionData.n_factor,
                pro_factor = foodDescriptionData.pro_factor,
                ref_desc = foodDescriptionData.ref_desc,
                sciname = foodDescriptionData.sciname,
                shrt_desc = foodDescriptionData.shrt_desc,
                survey = foodDescriptionData.survey
            };
        }
    }
}
