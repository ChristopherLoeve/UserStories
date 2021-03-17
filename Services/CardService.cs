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
        private JsonFileService jsonFileService { get; set; }

        public CardService(JsonFileService jsonFileService)
        {
            this.jsonFileService = jsonFileService;
            cardList = this.jsonFileService.GetJsonCards().ToList();
        }

        public List<Card> GetCards()
        {
            return cardList;
        }

        public List<UserStory> GetUserStories()
        {
            List<UserStory> userStories = new List<UserStory>();

            foreach (Card card in cardList)
            {
                if (card is UserStory)
                {
                    userStories.Add((UserStory)card);
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
                    tasks.Add((Task)card);
                }
            }
            return tasks;
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

        public List<Fix> GetFixes()
        {
            List<Fix> fixes = new List<Fix>();

            foreach (Card card in cardList)
            {
                if (card is Fix)
                {
                    fixes.Add((Fix)card);
                }
            }
            return fixes;
        }

        public Card GetCard(int id)
        {
            Card card = cardList.Find(c => c.Id == id);
            return card;
        }



        public void AddCard(Card card)
        {
            cardList.Add(card);
            Commit();
        }

        public void AddTask(Task task, int userStoryId)
        {
            UserStory userStory = (UserStory)GetCard(userStoryId);
            userStory.Tasks.Add(task);
            Commit();
        }

        public void DeleteUserStoryTask(int userStory, int id)
        {
            UserStory us = (UserStory)GetCard(userStory);
            foreach (Task usTask in us.Tasks)
            {
                if (usTask.Id == id)
                {
                    us.Tasks.Remove(usTask);
                    break;
                }
            }

            Commit();
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
                }
            }

            Commit();
        }

        public List<Task> GetUserStoryTasks(int id)
        {
            UserStory userStory = (UserStory)GetCard(id);
            return userStory.Tasks;
        }

        public Card DeleteCard(int id)
        {
            Card cardToBeDeleted = GetCard(id);

            if (cardToBeDeleted != null)
            {
                cardList.Remove(cardToBeDeleted);
            }
            Commit();
            return cardToBeDeleted;
        }

        public void UpdateCard(int id, Card card)
        {
            DeleteCard(id);
            AddCard(card);
            Commit();
        }
        
                    
           

        public void Commit()
        {
            jsonFileService.SaveJsonCards(GetUserStories(), GetFixes());
        }


        public void MoveStoryLeft(int id)
        {
            UserStory userStory = (UserStory)GetCard(id);
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
            Commit();
        }

        public void MoveStoryRight(int id)
        {
            UserStory userStory = (UserStory)GetCard(id);
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
            Commit();
        }

       
    }
}
