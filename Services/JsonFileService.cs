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
    public class JsonFileService
    {

        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "UserStories.json"); }
        }

        private string JsonFixesFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Fixes.json"); }
        }

        private string JsonProgrammerName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Programmers.json"); }
        }





        public IEnumerable<Card> GetJsonCards()
        {
            List<UserStory> userStories = GetJsonUserStories().ToList();
            List<Fix> fixes = GetJsonFixes().ToList();

            List<Card> cards = new List<Card>();
            cards.AddRange(userStories);
            cards.AddRange(fixes);

            
            return cards;
        }

        public void SaveJsonCards(List<UserStory> userStories, List<Fix> fixes)
        {
            SaveJsonUserStories(userStories);
            SaveJsonFixes(fixes);
        }

        public void SaveJsonUserStories(List<UserStory> userStories) 
        {
            using (var jsonFileWriter = File.Create(JsonFileName))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<UserStory[]>(jsonWriter, userStories.ToArray());
            }
        }

        public IEnumerable<UserStory> GetJsonUserStories()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<UserStory[]>(jsonFileReader.ReadToEnd());
            }
        }

        public void SaveJsonFixes(List<Fix> fixes)
        {
            using (var jsonFileWriter = File.Create(JsonFixesFileName))
            {
                var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
                {
                    SkipValidation = false,
                    Indented = true
                });
                JsonSerializer.Serialize<Fix[]>(jsonWriter, fixes.ToArray());
            }
        }

        public IEnumerable<Fix> GetJsonFixes()
        {
            using (var jsonFileReader = File.OpenText(JsonFixesFileName))
            {
                return JsonSerializer.Deserialize<Fix[]>(jsonFileReader.ReadToEnd());
            }
        }

        public void SaveProgrammers(List<Programmer> programmers)
        {

            using (var jsonFileWriter = File.Create(JsonProgrammerName))
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
            using (var jsonFileReader = File.OpenText(JsonProgrammerName))
            {
                return JsonSerializer.Deserialize<Programmer[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}