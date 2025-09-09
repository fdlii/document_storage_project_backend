using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStorage.Core.Models
{
    public class Folder
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Folder> SubFolders { get; set; }
        public ICollection<File> Files { get; set; }
        public Guid UserId { get; set; }
        public Guid UpFolderId { get; set; }
        public User? User { get; set; }
        public Folder? UpFolder { get; set; }

        public Folder(
            Guid id, 
            string name, 
            string path, 
            DateTime createdAt, 
            ICollection<Folder> subFolders, 
            ICollection<File> files, 
            Guid userId,
            Guid upFolderId,
            User user,
            Folder upFolder)
        {
            Id = id; 
            Name = name;
            Path = path;
            CreatedAt = createdAt;
            SubFolders = subFolders;
            Files = files;
            UserId = userId;
            UpFolderId = upFolderId;
            User = user;
            UpFolder = upFolder;
        }
    }
}
