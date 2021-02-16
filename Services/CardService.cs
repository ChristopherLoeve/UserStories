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
        }

        public void AddCard(Card card)
        {
            cardList.Add(card);
        }
    }
}
