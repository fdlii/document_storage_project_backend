using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStorage.Core.Models
{
    public class File
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime CreatedAt { get; set; }
        public string StoragePath { get; set; }
        public Guid FolderId { get; set; }
        public Guid UserId { get; set; }
        public Folder? Folder { get; set; }
        public User? User { get; set; }

        public File(
            Guid id, 
            string name, 
            string extension, 
            long size, 
            DateTime createdAt, 
            string storagePath, 
            Guid folderId, 
            Guid userId, 
            Folder folder, 
            User user
            ) 
        {
            Id = id;
            Name = name;
            Extension = extension;
            Size = size;
            CreatedAt = createdAt;
            StoragePath = storagePath;
            FolderId = folderId;
            UserId = userId;
            Folder = folder;
            User = user;
        }
    }
}
