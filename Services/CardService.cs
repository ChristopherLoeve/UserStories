using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStories.Models;

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
            if (cardList.Count != 0)
            {
                card.Id = cardList.Last().Id + 1;
            }
            else
            {
                card.Id = 1;
            }
            cardList.Add(card);
            Commit();
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

        public void UpdateCard(int id, Card updateCard)
        {
            DeleteCard(id);
            AddCard(updateCard);
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
