using System;
using FoodDataService.Models;
using FoodDataService.Data;
using Dapper;
using System.Linq;

namespace FoodDataService.Tests.Data
{
    public class FoodDataFixture : IDisposable
    {
        public FoodDescription FoodDescription { get; set; }

        public FoodDataFixture()
        {
            using (var db = Db.FoodDataService())
            {
                FoodDescription = db.Query<FoodDescription>($@"
                    INSERT INTO food_des
                    (
                        [ndb_no], [fdgrp_cd], [long_desc], [shrt_desc],
                        [comname], [manufacname], [survey], [ref_desc],
                        [refuse], [sciname], [n_factor], [pro_factor],
                        [fat_factor], [cho_factor]
                    )
                    VALUES
                    (
                        '00000', '0100', 'A test long description', 'A test short description',
                        'common names', 'manufacture names', 'Y', 'A description of the refuse',
                        12, 'Scientificus Namus', 4.3, 5.2,
                        1.2, 3.4
                    )
                ").First();
            }
        }

        public void Dispose()
        {
            using (var db = Db.FoodDataService())
            {
                db.Query($@"DELETE FROM food_des WHERE ndb_no='00000'");
            }
        }
    }
}
