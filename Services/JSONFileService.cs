using Microsoft.AspNetCore.Hosting;
using RAM___RUC_Allocation_Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class JSONFileService<T> where T : class
    {

        #region Properties
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", typeof(T).Name + "s.json"); }
        }
        #endregion

        #region Constructor
        public JSONFileService(IWebHostEnvironment webHostEnvironment)
        {

            WebHostEnvironment = webHostEnvironment;
            //If the JSON file for this given JSONFileService dosen't exist. A new "empty"-object of the type T, is created, and stored.
            if (!CheckJsonFileExists()) SaveJsonObjects(new List<T>() { (T)Activator.CreateInstance(typeof(T)) } );

        }
        #endregion

        #region Methods

        /// <summary>
        /// Method that checks if the json file exists for the type T. If not, a new JSON file is generated from a new instance of the class.
        /// </summary>
        /// <returns>True if exists, false if not.</returns>
        private bool CheckJsonFileExists()
        {
            return File.Exists(JsonFileName);
        }

        /// <summary>
        /// Method that gets all JSON-objects from the directory.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetJsonObjects()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<T[]>(jsonFileReader.ReadToEnd());
            }
        }

        /// <summary>
        /// Method that saves a list as JSON-objects.
        /// </summary>
        /// <param name="objects"></param>
        public void SaveJsonObjects(List<T> objects)
        {
            using (var jsonFileWriter = File.Create(JsonFileName))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize(jsonWriter, objects.ToArray());
            }
        }
        #endregion

    }
}
