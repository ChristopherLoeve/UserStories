using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStories.Models;
using Task = UserStories.Models.Task;

namespace UserStories.Services
{
    public class CardService
    {
        private List<Card> cardList;
        private readonly DbService<Card> DbService;

        public CardService(DbService<Card> dbService)
        {
            DbService = dbService;
            cardList = DbService.GetObjectsAsync().Result;
        }

        public List<Card> GetCards()
        {
            return cardList;
        }

        public Card GetCard(int id)
        {
            Card card = cardList.Find(c => c.Id == id);
            return card;
        }

        public async void AddCard(Card card)
        {
            cardList.Add(card);
            await DbService.AddObjectAsync(card);
        }

        public Card DeleteCard(int id)
        {
            Card cardToBeDeleted = GetCard(id);

            if (cardToBeDeleted != null)
            {
                cardList.Remove(cardToBeDeleted);
                DbService.RemoveObjectAsync(cardToBeDeleted);
            }

            return cardToBeDeleted;
        }

        public void UpdateCard(Card card)
        {
            DbService.UpdateObjectAsync(card);
            cardList = DbService.GetObjectsAsync().Result;
        }

        // CARDS BY TYPE //
        public List<UserStory> GetUserStories()
        {
            List<UserStory> userStories = new List<UserStory>();

            foreach (Card card in cardList)
            {
                if (card is UserStory)
                {
                    userStories.Add((UserStory) card);
                }
            }

            return userStories;
        }

        public List<Task> GetTasks()
        {
            List<Task> tasks = new List<Task>();

            foreach (Card card in cardList)
            {
                if (card is Task)
                {
                    tasks.Add((Task) card);
                }
            }

            return tasks;
        }

        public List<Fix> GetFixes()
        {
            List<Fix> fixes = new List<Fix>();

            foreach (Card card in cardList)
            {
                if (card is Fix)
                {
                    fixes.Add((Fix) card);
                }
            }

            return fixes;
        }

        public List<UserStory> GetUserStoriesByColumn(Column column)
        {
            List<UserStory> userStories = new List<UserStory>();
            foreach (UserStory us in GetUserStories())
            {
                if (us.Column == column) userStories.Add(us);
            }

            return userStories;
        }
        // CARDS BY TYPE //


        public List<Task> GetUserStoryTasks(int id)
        {
            UserStory userStory = (UserStory)GetCard(id);
            return userStory.Tasks;
        }


        // TASKS //
        public void AddTask(Task task, int userStoryId)
        {
            UserStory userStory = (UserStory) GetCard(userStoryId);
            userStory.Tasks.Add(task);
            cardList.Add(task);
            DbService.UpdateObjectAsync(userStory);
        }

        public void DeleteUserStoryTask(int userStoryId, int id)
        {
            UserStory userStory = (UserStory)GetCard(userStoryId);
            foreach (Task usTask in userStory.Tasks)
            {
                if (usTask.Id == id)
                {
                    userStory.Tasks.Remove(usTask);
                    cardList.Remove(usTask);
                    DbService.RemoveObjectAsync(usTask);
                    DbService.UpdateObjectAsync(userStory);
                    break;
                }
            }
            
        }

        public void UpdateUserStoryTask(Task task, int userStory, int id)
        {
            UserStory us = (UserStory) GetCard(userStory);
            foreach (Task usTask in us.Tasks)
            {
                if (usTask.Id == id)
                {
                    usTask.Title = task.Title;
                    usTask.Description = task.Description;
                    DbService.UpdateObjectAsync(usTask);
                }
            }
        }

        // Is task done or not
        public void TaskStatus(int userStory, int id)
        {
            UserStory us = (UserStory) GetCard(userStory);
            foreach (Task usTask in us.Tasks)
            {
                if (usTask.Id == id && usTask.TaskDone == false)
                {
                    usTask.TaskDone = true;
                }
                else if (usTask.Id == id && usTask.TaskDone == true)
                {
                    usTask.TaskDone = false;
                }
            }

        }
        // TASKS
        
        // COLUMN CHANGING FOR USER STORIES //
        public void MoveStoryLeft(int id)
        {
            UserStory userStory = (UserStory) GetCard(id);
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

            DbService.UpdateObjectAsync(userStory);
        } 

        public void MoveStoryRight(int id)
        {
            UserStory userStory = (UserStory) GetCard(id);
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

            DbService.UpdateObjectAsync(userStory);
        }
        // COLUMN CHANGING FOR USER STORIES //
    }
}
