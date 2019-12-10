using System.Collections.Generic;
using TopShelfCustomer.Api.Models;
using TopShelfCustomer.Api.Services;
using Xunit;

namespace TopShelfCustomer.Api {
    /// <summary>
    ///  WebAPIUnitTest:
    ///  
    /// Unit Test for the servies contained inside the Api Project folder.
    /// Each function tests the extent of a single classes functionality.
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

            Assert.Equal("HEB DeZavala", stores.GetStoreById(1)[0].Name);
            Assert.Equal("Walmart Baker Street", stores.GetStoreById(4)[0].Name);

            return;
        }

        [Fact]
        public void ProductTest()
        {
            ProductData product = new ProductData();

            Assert.Equal("Ground Beef 16.oz", product.GetProductById(1)[0].Name);
            Assert.True(3.99 == product.GetProductById(1)[0].Price);

            Assert.Equal("Elmer's Glue (per Jug)", product.GetProductById(8)[0].Name);
            Assert.True(40.00 == product.GetProductById(8)[0].Price);

            return;
        }

    }
}