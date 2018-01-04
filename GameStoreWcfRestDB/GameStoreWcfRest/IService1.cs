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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "games")
        ]
        List<Games> GetGames();

        [OperationContract]
        [WebInvoke(
                Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "game/{id}")
        ]
        Games GetOneGame(String id);

        [OperationContract]
        [WebInvoke(
                Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                //ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "addgame")
        ]
        void AddGame(Games newGame);

        [OperationContract]
        [WebInvoke(
                Method = "DELETE",
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "game?id={id}")
        ]
        void DeleteGame(int id);

        [OperationContract]
        [WebInvoke(
                Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "game")
        ]
        void UpdateGame(Games myGame);
    }


}
