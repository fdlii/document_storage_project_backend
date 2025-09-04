namespace DocumentStorage.Persistance.Entities
{
    public class FolderEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<FolderEntity> SubFolders { get; set; } = [];
        public ICollection<FileEntity> Files { get; set; } = [];
        public Guid UserId { get; set; }
        public Guid UpFolderId { get; set; }
        public UserEntity? User { get; set; }
        public FolderEntity? UpFolder { get; set; }
    }
}
