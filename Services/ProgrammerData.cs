using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using UserStories.Models;

namespace UserStories.Services
{
    public class ProgrammerData
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string FileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Programmers.json"); }
        }

        public ProgrammerData(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public void Save(List<Programmer> programmers)
        {

            using (var jsonFileWriter = File.Create(FileName))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Programmer[]>(jsonWriter, programmers.ToArray());
            }

        }

        public IEnumerable<Programmer> GetProgrammers()
        {
            using (var jsonFileReader = File.OpenText(FileName))
            {
                return JsonSerializer.Deserialize<Programmer[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
