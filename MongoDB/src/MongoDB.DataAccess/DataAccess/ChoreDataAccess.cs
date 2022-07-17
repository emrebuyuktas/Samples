using MongoDB.DataAccess.Models;
using MongoDB.Driver;

namespace MongoDB.DataAccess.DataAccess
{
    public class ChoreDataAccess
    {
        private const string connectionString = "Connection String";
        private const string dbName = "chorebd";
        private const string ChoreCollection = "chore_cart";
        private const string UserCollection = "users";
        private const string ChoreHistoryCollection = "chore_history";

        private IMongoCollection<T> ConectToMondgo<T>(in string collection)
        {
            var client=new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            return db.GetCollection<T>(collection);
        }
        public async Task<List<ChoreModel>> GetAllChoresAsync()
        {
            var choresCollection = ConectToMondgo<ChoreModel>(ChoreCollection);
            var results = await choresCollection.FindAsync(_=>true);
            return results.ToList();
        }
        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var userssCollection = ConectToMondgo<UserModel>(UserCollection);
            var results = await userssCollection.FindAsync(_ => true);
            return results.ToList();
        }
        public async Task<List<ChoreModel>> GetAllChoresForAUserAsync(UserModel user)
        {
            var choresCollection = ConectToMondgo<ChoreModel>(ChoreCollection);
            var results = await choresCollection.FindAsync(x=>x.AssignedTo.Id==user.Id);
            return results.ToList();
        }
        public Task CreateUser(UserModel user)
        {
            var userCollection= ConectToMondgo<UserModel>(UserCollection);
            return userCollection.InsertOneAsync(user);
        }
        public Task CreateChore(ChoreModel chore)
        {
            var choreCollection= ConectToMondgo<ChoreModel>(ChoreCollection);
            return choreCollection.InsertOneAsync(chore);
        }
        public Task UpdateChore(ChoreModel chore)
        {
            var choreCollection=ConectToMondgo<ChoreModel>(ChoreCollection);
            var filter = Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
            return choreCollection.ReplaceOneAsync(filter,chore,new ReplaceOptions { IsUpsert=true});
        }
        public Task DeleteChore(ChoreModel chore)
        {
            var choreCollection = ConectToMondgo<ChoreModel>(ChoreCollection);
            return choreCollection.DeleteOneAsync(c => c.Id == chore.Id);
        }
        public async Task CompleteChore(ChoreModel chore)
        {
            //var choreCollection = ConectToMondgo<ChoreModel>(ChoreCollection);
            //var filter=Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
            //await choreCollection.ReplaceOneAsync(filter, chore);

            //var choreHistoryCollection=ConectToMondgo<ChoreHistoryModel>(ChoreHistoryCollection);
            //await choreHistoryCollection.InsertOneAsync(new ChoreHistoryModel(chore));

            var client = new MongoClient(connectionString);
            using var session=await client.StartSessionAsync();

            session.StartTransaction();
            try
            {
                var db = client.GetDatabase(dbName);
                var choresColleciton = db.GetCollection<ChoreModel>(ChoreCollection);

                var filter=Builders<ChoreModel>.Filter.Eq("Id", chore.Id);
                await choresColleciton.ReplaceOneAsync(filter, chore);

                var choreHistoryColleciton=db.GetCollection<ChoreHistoryModel>(ChoreHistoryCollection);
                await choreHistoryColleciton.InsertOneAsync(new ChoreHistoryModel(chore));

                await session.CommitTransactionAsync();

            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
