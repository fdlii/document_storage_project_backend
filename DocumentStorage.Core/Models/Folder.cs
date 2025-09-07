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
    }
}
