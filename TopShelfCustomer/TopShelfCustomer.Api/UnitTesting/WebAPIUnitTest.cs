using System.Collections.Generic;
using TopShelfCustomer.Api.Models;
using TopShelfCustomer.Api.Services;
using Xunit;

namespace TopShelfCustomer.Api {
    /// <summary>
    ///  WebAPIUnitTest:
    ///  
    /// Unit Test for the servies contained inside the Api Project folder
    /// </summary>
    public class WebAPIUnitTest {

        [Fact]
        public void OrderTest() {
            OrderData order = new Services.OrderData();
            Assert.IsType<List<User>>( order.GetOrdersByEmail( "test@test.com" ) );
            return;
        }

        [Fact]
        public void UserTest() {
            UserData user = new UserData();
            Assert.Equal("test@test.com", user.GetUserByEmail("test@test.com")[0].EmailAddress);
            return;
        }

        [Fact]
        public void CouponTest() {
            CouponData coupon = new CouponData();
            Assert.IsType<List<Coupon>>(coupon.GetCouponsByZipCode(78249));
            return;
        }

        [Fact]
        public void StoreTest()
        {
            StoreData stores = new StoreData();
            List<Store> storeList = stores.GetStoresByZipCode(78249);
            Assert.True(storeList.Count > 0);
            Assert.True(stores.GetAllProducts().Count > 0);
            return;
        }

    }
}