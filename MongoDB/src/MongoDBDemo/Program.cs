using MongoDB.DataAccess.DataAccess;
using MongoDB.Driver;
using MongoDB.DataAccess.Models;

ChoreDataAccess db=new ChoreDataAccess();
//await db.CreateUser(new UserModel() { FirstName = "Emre", LastName = "Büyüktaş" });
var users=await db.GetAllUsersAsync();

var chore=new ChoreModel() { AssignedTo=users.First(),ChoreText="Chore",FruquencyInDays= 7};
await db.CreateChore(chore);
var chores=await db.GetAllChoresAsync();
await db.CompleteChore(chores.First());