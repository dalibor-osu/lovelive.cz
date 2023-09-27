namespace LoveLiveCZ.Models.Database;

public static class Constants
{
    public static class UsersTable
    {
        public const string TableName = "Users";
        public const string Prefix = "usr";

        public const string Username = "Username";
        public const string ProfilePicture = "ProfilePicture";
        public const string PasswordHash = "PasswordHash";
    }

    public static class PostsTable
    {
        public const string TableName = "Posts";
        public const string Prefix = "pst";

        public const string Text = "Text";
    }

    public static class AttachmentsTable
    {
        public const string TableName = "Attachments";
        public const string Prefix = "atm";

        public const string Path = "Path";
        public const string Type = "Type";
        public const string PostIdentifier = "PostId";
    }
}