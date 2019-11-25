using Google.Cloud.Firestore;
using System;

namespace TopShelfCustomer.Models {

    public class DataBase {

        #region Properties

        public FirestoreDb Database { get; private set; }

        #endregion
        public DataBase () {
        }
    }
}
