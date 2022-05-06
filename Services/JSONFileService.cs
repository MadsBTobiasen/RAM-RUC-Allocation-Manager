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
        }
        #endregion

        #region Methods
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
                JsonSerializer.Serialize<T[]>(jsonWriter, objects.ToArray());
            }
        }
        #endregion

    }
}
