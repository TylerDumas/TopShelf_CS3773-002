using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopShelfCustomer.Api.Models {

    public class UserDbModel {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }

        public string StoreName { get; set; }
    }
}
