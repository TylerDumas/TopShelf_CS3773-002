using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// ApiHelper:
    ///
    /// Helper class to allow for access to the TopShelf web api.
    /// Implements Http Get/Put/Delete requests to fetch and write
    /// JSON payloads to/from the API.
    /// </summary>
    public sealed class ApiHelper {

        readonly string apiUrl = "https://topshelfcustomerapi.azurewebsites.net/api";       //Root URL of the API

        public HttpClient ApiClient { get; set; }       //HttpClient to access the API

        /// <summary>
        /// Constructor
        /// </summary>
        public ApiHelper() {
            InitializeClient();
        }

        /// <summary>
        /// InitializeClient:
        ///
        /// Initialization for the HttpClient object.
        /// Clears and modifies request headers to accept
        /// JSON strings/
        /// </summary>
        private void InitializeClient() {
            ApiClient = new HttpClient();       //Instantiate the HttpClient

            ApiClient.DefaultRequestHeaders.Accept.Clear();     //Set default request headers to JSON strings
            ApiClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
        }

        /// <summary>
        /// GetAsync:
        ///
        /// Asynchronous method to get a Generic object from the API.
        /// Takes a path to the correct endpoint and returns a deserialized
        /// JSON object.
        /// </summary>
        /// <typeparam name="T"> The type of object to return </typeparam>
        /// <param name="relativePath"> The endpoint to access </param>
        /// <example> User/GetUserById/1 </example>
        /// <returns> A Task object of type T </returns>
        public async Task<T> GetAsync<T>( string relativePath ) {

            string path = Path.Combine( apiUrl, relativePath );     //Concatenate the request path

            var output = await ApiClient.GetStringAsync( path );        //Get the JSON payload
               
            var returnedObject = JsonConvert.DeserializeObject<T>( output );        //Deserialize the Json

            return returnedObject;      //Return the requested object
        }

        /// <summary>
        /// PutAsync:
        ///
        /// Asynchronous method to write a generic object to the API.
        /// Takes the endpoint path (relative to /api) and a generic object.
        /// Returns a success value.
        /// </summary>
        /// <typeparam name="T"> The type of object to write </typeparam>
        /// <param name="relativePath"> The endpoint to access </param>
        /// <param name="objectToPut"> Generic object to write </param>
        /// <returns> A Task of type bool to indicate success or failure </returns>
        public async Task<bool> PutAsync<T>( string relativePath, T objectToPut ) {

            string path = Path.Combine( apiUrl, relativePath );     //Concatenate the request path
            var serializedObject = JsonConvert.SerializeObject( objectToPut );      //Serialize the object to put

            var jsonToWrite = new StringContent( serializedObject, Encoding.UTF8, "application/json" );     //Create String HttpContent object as wrapper
            var output = await ApiClient.PutAsync( path, jsonToWrite );     //Write the json object to the API

            return output.IsSuccessStatusCode;      //return the status code of the request
        }
    }
}
