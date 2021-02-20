namespace ChatApp.Model
{
    public class ChatAppDatabaseSettings:IChatAppDatabaseSettings
    {
        public string MessagesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IChatAppDatabaseSettings
    {
        string MessagesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
