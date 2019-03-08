using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GotApi.Data;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace GotApi.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class GotController : ApiController
    {
        private GotData DB = new GotData();

        public class Card
        {
            public int cardId { get; set; }
            public string cardName { get; set; }
            public bool loyal { get; set; } 
        }

        // GET api/<controller>
        public HttpResponseMessage GetCards()
        {
            var allCards = DB.Set<GOT_Cards>();

            var cards = from x in allCards
                        select new Card()
                        {
                            cardId = x.CardId,
                            cardName = x.CardName,
                            loyal = x.Loyal
                        };

            string json = JsonConvert.SerializeObject(cards);

            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }

        [Route("api/Got/GetCardsByFaction/{factionId}")]
        public HttpResponseMessage GetCardsByFaction(int factionId)
        {
            var cards = DB.Set<GOT_Cards>().Where(x => x.FactionId == factionId).ToList();

            var cardList = from x in cards
                           select new Card()
                           {
                               cardId = x.CardId,
                               cardName = x.CardName,
                               loyal = x.Loyal
                           };

            string json = JsonConvert.SerializeObject(cardList);

            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };

        }

        [Route("api/Got/GetCardsById/{id}")]
        public HttpResponseMessage GetCardsById(int id)
        {
            var card = DB.Set<GOT_Cards>().FirstOrDefault(x => x.CardId == id);

            Card theCard = new Card()
            {
                cardId = card.CardId,
                cardName = card.CardName,
                loyal = card.Loyal
            };

            string json = JsonConvert.SerializeObject(theCard);

            return new HttpResponseMessage()
            {
                Content = new StringContent(json)
            };
        }


        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}