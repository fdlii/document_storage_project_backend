using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStorage.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public ICollection<Folder> Folders { get; set; } = [];
        public ICollection<File> Files { get; set; } = [];

        public User(Guid guid, string email, string passwordHash) { 
            Id = guid;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
