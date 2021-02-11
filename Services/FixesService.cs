﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UserStories.Models;

namespace UserStories.Services
{
    public class FixesService
    {
        private List<Fix> fixes;
        private JsonFileService jsonFileService { get; set; }

        public FixesService(JsonFileService jsonFileService)
        {
            this.jsonFileService = jsonFileService;
            fixes = this.jsonFileService.GetJsonFixes().ToList();
        }

        public void AddFix(Fix fix)
        {
            fixes.Add(fix);
            jsonFileService.SaveJsonFixes(fixes);
        }

        public Fix GetFix(int id)
        {
            foreach(Fix fix in fixes)
            {
                if(id == fix.Id)
                {
                    return fix;
                }
            }
            return null;
        }

        public List<Fix> GetFixes()
        {
            return fixes;
        }



        public void UpdateFix(Fix fix, int id)
        {
            foreach (Fix f in fixes)
            {
                if (f.Id == id)
                {
                    f.Title = fix.Title;
                    f.Description = fix.Description;
                    f.Fixed = fix.Fixed;
                }
            }
            jsonFileService.SaveJsonFixes(fixes);
        }

        public void DeleteFix(Fix fix)
        {
            fixes.Remove(fix);
            jsonFileService.SaveJsonFixes(fixes);
        }

    }
}