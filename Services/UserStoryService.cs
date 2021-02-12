﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStories.Models;

namespace UserStories.Services
{
    public class UserStoryService
    {
        private List<UserStory> userStories;
        private JsonFileService jsonFileService { get; set; }


        public UserStoryService(JsonFileService jsonFileService)
        {
            this.jsonFileService = jsonFileService;
            userStories = this.jsonFileService.GetJsonUserStories().ToList();
        }

        public void AddUserStory(UserStory userStory)
        {
            if (userStories.Count != 0) userStory.Id = userStories.Last().Id + 1;
            else userStory.Id = 1;
            
            userStories.Add(userStory);
            jsonFileService.SaveJsonUserStories(userStories);
        }

        public UserStory GetUserStory(int id)
        {
            foreach (UserStory userStory in userStories)
            {
                if (userStory.Id == id)
                    return userStory;
            }

            return null;
        }

        public List<UserStory> GetUserStories()
        {
            return userStories;
        }

        public UserStory DeleteUserStory(int id)
        {
            UserStory userstoryToBeDeleted = GetUserStory(id);

            if (userstoryToBeDeleted != null)
            {
                userStories.Remove(userstoryToBeDeleted);
            }

            jsonFileService.SaveJsonUserStories(userStories);
            return userstoryToBeDeleted;
        }

        public void EditUserStory(int id, UserStory userStory)
        {
            foreach (UserStory uS in userStories)
            {
                if (uS.Id == id)
                {
                    uS.Title = userStory.Title;
                    uS.Description = userStory.Description;
                    uS.BusinessValue = userStory.BusinessValue;
                    uS.Priority = userStory.Priority;
                    uS.StoryPoints = userStory.StoryPoints;
                    uS.Column = userStory.Column;
                }
            }

            jsonFileService.SaveJsonUserStories(userStories);
        }

        internal void UpdateColumn(int id, string column)
        {

            UserStory userStory = GetUserStory(id);
            Column columnToEnum = (Column)Enum.Parse(typeof(Column), column, true);
            userStory.Column = columnToEnum;
        }

        public List<UserStory> GetUserStoriesByColumn(Column column)
        {
            List<UserStory> list = new List<UserStory>();
            foreach (UserStory us in userStories)
            {
                if (us.Column == column)
                    list.Add(us);
            }
            return list;
        }

        public void MoveStoryLeft(int id)
        {
            UserStory userStory = GetUserStory(id);
            switch (userStory.Column)
            {
                case Column.To_Do:
                    userStory.Column = Column.Backlog;
                    break;
                case Column.Doing:
                    userStory.Column = Column.To_Do;
                    break;
                case Column.Done:
                    userStory.Column = Column.Doing;
                    break;
                case Column.Done_Done:
                    userStory.Column = Column.Done;
                    break;
            }
            jsonFileService.SaveJsonUserStories(userStories);
        }

        public void MoveStoryRight(int id)
        {

            UserStory userStory = GetUserStory(id);
            switch (userStory.Column)
            {
                case Column.Backlog:
                    userStory.Column = Column.To_Do;
                    break;
                case Column.To_Do:
                    userStory.Column = Column.Doing;
                    break;
                case Column.Doing:
                    userStory.Column = Column.Done;
                    break;
                case Column.Done:
                    userStory.Column = Column.Done_Done;
                    break;
            }
            jsonFileService.SaveJsonUserStories(userStories);
        }
        public void MoveColumnUp(UserStory userStory)
        {
            if (userStory.Column == Column.To_Do)
            {
                userStory.Column = Column.Doing;
            }
            else if (userStory.Column == Column.Doing)
            {
                userStory.Column = Column.Done;
            }
            else if (userStory.Column == Column.Done)
            {
                userStory.Column = Column.Done_Done;
            }
            else if (userStory.Column == Column.Done_Done)
            {
                userStory.Column = Column.To_Do;
            }
        }

        public void ResetToTemplate()
        {
            jsonFileService.ResetToTemplate();
            userStories = jsonFileService.GetJsonUserStories().ToList();
        }

        public void SaveAsTemplate()
        {
            jsonFileService.SaveAsTemplate(userStories);
        }

    }
}
