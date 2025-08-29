namespace WorkingWithDB.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<FolderEntity> Folders { get; set; } = [];
        public ICollection<FileEntity> Files { get; set; } = [];
    }
}
