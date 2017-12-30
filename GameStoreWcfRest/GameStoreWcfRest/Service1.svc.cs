using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using GameStorelibrary;

namespace GameStoreWcfRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private static List<Games> GameList = new List<Games>()
        {
            new Games(1, "Overwatch", 59.95, 5),
            new Games(2, "Life is feudal", 24.95, 10),
            new Games(3, "Batman: Asylem", 19.95, 5)
        };


        public List<Games> GetGames()
        {
            return GameList;
        }

        public Games GetOneGame(string id)
        {
            int dint = Int32.Parse(id);

            return GameList.Find(c => c.Id == dint);
        }

        public void AddGame(Games newGame)
        {
            GameList.Add(newGame);
        }

        public Games DeleteGame(int id)
        {
            var deleteGame = GetOneGame(id.ToString());
            if (deleteGame != null)
            {
                GameList.Remove(deleteGame);
                return deleteGame;
            }
            return null;
        }

        public void UpdateGame(Games myGame)
        {
            var updateGame = GetOneGame(myGame.Id.ToString());
            if (updateGame != null)
            {
                updateGame.Title = myGame.Title;
                updateGame.AntalPåLager = myGame.AntalPåLager;
                updateGame.Price = myGame.Price;
            }
        }
    }
}
