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
        public const string Bio = "Bio";
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

        public const string Type = "Type";
        public const string PostIdentifier = "PostId";
    }

    public static class LikesTable
    {
        public const string TableName = "Likes";
        public const string Prefix = "likes";
        
        public const string PostIdentifier = "PostId";
    }
    
    public static class UserRolesTable
    {
        public const string TableName = "Roles";
        public const string Prefix = "roles";
        
        public const string Role = "Role";
    }
}