using SimpleBotCore.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SimpleBotCore.Repositories
{
    public class UserProfileMongoRepository : IUserProfileRepository
    {
        MongoClient _cliente;
        IMongoCollection<BsonDocument> _respostas;
        public UserProfileMongoRepository(MongoClient cliente)
        {
            _cliente = cliente;
            var db = cliente.GetDatabase("dbPerfil");
            var collection = db.GetCollection<BsonDocument>("Respostas");

            _respostas = collection;
        }

        Dictionary<string, SimpleUser> _users = new Dictionary<string, SimpleUser>();

        public SimpleUser TryLoadUser(string userId)
        {
            if (Exists(userId))
            {
                return GetUser(userId);
            }

            return null;
        }

        public SimpleUser Create(SimpleUser user)
        {
            if (Exists(user.Id))
                throw new InvalidOperationException("Usuário ja existente");

            SaveUser(user);

            return user;
        }


        public void AtualizaCor(string userId, string name)
        {
            var doc = new BsonDocument()
            {
                {"Usuario", userId },
                {"Cor", name }
            };

            _respostas.InsertOne(doc);
        }

        public void AtualizaIdade(string userId, int idade)
        {
            var doc = new BsonDocument()
            {
                {"Usuario", userId },
                {"Idade", idade }
            };

            _respostas.InsertOne(doc);
        }

        public void AtualizaNome(string userId, string name)
        {
            var doc = new BsonDocument()
            {
                {"Usuario", userId },
                {"Nome", name }
            };

            _respostas.InsertOne(doc);
        }


        private bool Exists(string userId)
        {
            return _users.ContainsKey(userId);
        }

        private SimpleUser GetUser(string userId)
        {
            return _users[userId];
        }

        private void SaveUser(SimpleUser user)
        {
            _users[user.Id] = user;
        }

    }
}
