using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using TopShelfCustomer.Api.Models;
using TopShelfCustomer.Api.Services;

namespace TopShelfCustomer.Api.Controllers {

    /// <summary>
    /// CouponController:
    ///
    /// Controller for the Coupon collection.
    /// Contains functionality for all RESTful API calls
    /// such as: Get, Put, Post, and Delete.
    /// </summary>
    public class CouponController : ApiController {

        /// <summary>
        /// GetCouponByZipCode:
        ///
        /// Handler for Http GET calls fetching
        /// the coupons for a given Store area (by Zip Code).
        /// </summary>
        /// <returns></returns>
        [Route( "api/Coupon/GetCouponsByZipCode/{zipCode:int}" )]
        [HttpGet]
        public IEnumerable<Coupon> GetCouponsByZipCode ( int zipCode ) {
            CouponData data = new CouponData();

            var coupons = data.GetCouponsByZipCode( zipCode );      //Fetch the List of coupons from the db wrapper class

            try {               //Catch exceptions thrown by null User
                if ( coupons == null ) { return new List<Coupon>(); }
            } catch ( ArgumentOutOfRangeException e ) {
                Debug.WriteLine( e.Message );
                return new List<Coupon>();
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return new List<Coupon>();
            }

            return coupons;
        }
    }
}