using System.Collections.Generic;
using TopShelfCustomer.Api.Models;

namespace TopShelfCustomer.Api.Services {

    /// <summary>
    /// CouponData:
    ///
    /// Implementation of the SqlDataAccess class
    /// specific to the Coupon model class. Responsible for
    /// fetching and sending Coupon data to and from the
    /// database.
    /// </summary>
    public sealed class CouponData {

        /// <summary>
        /// GetCouponsByZipCode:
        ///
        /// Fetches all Coupons from the database with
        /// the StoreZipCode value of "zipCode".
        /// </summary>
        /// <param name="zipCode"> the Zip Code value to query with </param>
        /// <returns> A list of applicable Coupons </returns>
        public List<Coupon> GetCouponsByZipCode ( int zipCode ) {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { ZipCode = zipCode };      //Dynamic parameter object
            var output = sql.LoadData<Coupon, dynamic>( "dbo.spGetCouponsByZipCode", p, "TopShelfDbConnection" );       //Fetch the Coupons
            return output;
        }
    }
}