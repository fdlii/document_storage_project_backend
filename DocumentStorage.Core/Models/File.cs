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
    }
}
