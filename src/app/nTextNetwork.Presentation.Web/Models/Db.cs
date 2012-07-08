using MongoDB.Driver;
using nTextNetwork.Core.Utils;

namespace nTextNetwork.Presentation.Web.Models
{
    /// <summary>
    /// MongoDB persistance.
    /// </summary>
    public class Db
    {
        public static MongoServer Server { get; private set; }
        public static MongoDatabase Database { get; private set; }

        public static void Init(MongoServer server, string dbName)
        {
            Precondition.EnsureNotNull("server", server);
            Precondition.EnsureNotNullOrEmpty("dbName", dbName);

            Server = server;
            Database = Server.GetDatabase(dbName);

            Postcondition.EnsureNotNull("Server", Server);
            Postcondition.EnsureNotNull("Database", Database);
        }

        public static void Ping()
        {
            //throws if fails
            Server.Ping();
        }
    }
}