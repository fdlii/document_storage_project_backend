using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentStorage.Persistance.Entities;
using File = DocumentStorage.Core.Models.File;
using Folder = DocumentStorage.Core.Models.Folder;
using User = DocumentStorage.Core.Models.User;

namespace DocumentStorage.Persistance
{
    public static class EntityConverter
    {
        public static File ConvertFileEntityToFile(FileEntity fileEntity)
        {

        }
        public static Folder ConvertFolderEntityToFolder(FolderEntity folderEntity)
        {

        }
        public static User ConvertUserEntityToUser(UserEntity userEntity) {
            ICollection<File> userFiles = [];
            foreach (FileEntity fileEntity in userEntity.Files) { 
                userFiles.Add(ConvertFileEntityToFile(fileEntity));
            }

            ICollection<Folder> userFolders = [];
            foreach (FolderEntity folderEntity in userEntity.Folders)
            {
                userFolders.Add(ConvertFolderEntityToFolder(folderEntity));
            }

            return new User(
                userEntity.Id,
                userEntity.Email,
                userEntity.PasswordHash,
                userFolders,
                userFiles);
        }
    }
}
