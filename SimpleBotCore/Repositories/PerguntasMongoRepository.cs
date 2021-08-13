using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Repositories
{
    public class PerguntasMongoRepository : IPerguntasRepository
    {
        MongoClient _cliente;
        IMongoCollection<BsonDocument> _perguntas;
        public PerguntasMongoRepository( MongoClient cliente)
        {       

            _cliente = cliente;
            var db = cliente.GetDatabase("dbPerguntas");
            var collection = db.GetCollection<BsonDocument>("Perguntas");

            _perguntas = collection;
        }

        public void GravarPerguntas(string userId, string texto)
        {
            var doc = new BsonDocument()
            {
                {"Usuario", userId },
                {"Texto", texto }
            };

            _perguntas.InsertOne(doc);
        }
    }
}
