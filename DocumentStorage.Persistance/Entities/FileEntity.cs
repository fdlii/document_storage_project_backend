using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStorage.Persistance.Entities
{
    public class FileEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Extension { get; set; } = string.Empty;
        public long Size { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string StoragePath { get; set; } = string.Empty;
        public Guid FolderId { get; set; }
        public Guid UserId { get; set; }
        public FolderEntity? Folder { get; set; }
        public UserEntity? User { get; set; }
    }
}
