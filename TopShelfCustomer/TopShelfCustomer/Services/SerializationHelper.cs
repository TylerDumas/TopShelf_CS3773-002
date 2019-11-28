using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json.Linq;

namespace TopShelfCustomer.Services {

    /// <summary>
    /// SerializationHelper:
    ///
    /// Static class containing functionality for reading,
    /// writing, and validating JSON files from the device.
    /// </summary>
    public static class SerializationHelper {

        #region Properties

        public static string FileExtension { get => ".json"; }
        public static string FolderPath { get => Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ); }

        #endregion

        #region Static Methods

        /// <summary>
        /// JsonWrite:
        ///
        /// Static method to write a file to the static filepath.
        /// Takes the filename and json/string data as parameters
        /// </summary>
        /// <param name="filename"> the name of the file to write to (no extension)</param>
        /// <param name="jsonData"> the JSON string to write </param>
        /// <returns> bool indicating success </returns>
        public static bool JsonWrite( string filename, string jsonData ) {
            try {
                var filepath = Path.Combine( FolderPath, filename + FileExtension );        //Create the file path
                File.WriteAllText( filepath, jsonData );        //Write the passed string to the file
                return true;
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return false;
            }
        }

        /// <summary>
        /// JsonReadField:
        ///
        /// Static method to read and parse a json object from the static filepath.
        /// Takes the filename and field name of the JSON object.
        /// </summary>
        /// <param name="filename"> The name of the file to read </param>
        /// <param name="fieldname"> The field to read from the returned JSON object </param>
        /// <returns> the field fetched from the JSON file and object (as a string) </returns>
        public static string JsonReadField( string filename, string fieldname ) {
            try {
                var filepath = Path.Combine( FolderPath, filename + FileExtension );        //Create the file path
                var content = File.ReadAllText( filepath );     //Read the entire json file
                JObject obj = JObject.Parse( content );     //Parse the json text to an object
                return obj[fieldname].ToString();       //Return the value of the object for the passed fieldname
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return null;
            }
        }

        /// <summary>
        /// JsonRead:
        ///
        /// Static method to read and parse a json object from the static filepath.
        /// Takes the filename of the JSON object, reads the JSON, and
        /// returns an object of the provided type.
        /// </summary>
        /// <param name="filename"> The name of the file to read </param>
        /// <returns> an object (of type T) created from the fetched JSON </returns>
        public static object JsonRead<T>( string filename ) {
            try {
                var filepath = Path.Combine( FolderPath, filename + FileExtension );        //Create the file path
                var content = File.ReadAllText( filepath );     //Read the entire json file
                JObject obj = JObject.Parse( content );     //Parse the json text to an object
                return obj.ToObject<T>();       //Return the value of the object for the passed fieldname
            } catch ( Exception e ) {
                Debug.WriteLine( e.Message );
                return null;
            }
        }

        /// <summary>
        /// JsonFileExists:
        ///
        /// Simple method for checking if there is a JSON file with
        /// the argument's name. Returns true if a file is found by that name,
        /// and false otherwise.
        /// </summary>
        /// <param name="filename"> the name of the json file to find (without the extension)</param>
        /// <returns> true if a file is found, false otherwise </returns>
        public static bool JsonFileExists( string filename ) {
            var filepath = Path.Combine( FolderPath, filename + FileExtension );        //Create the file path
            if ( !File.Exists( filepath ) ) {       //Check if file exists
                return false;       //File not found
            }
            return true;        //File found
        }

        #endregion
    }
}
