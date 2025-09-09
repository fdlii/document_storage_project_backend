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
            Folder folder = ConvertFolderEntityToFolder(fileEntity.Folder);
            User user = ConvertUserEntityToUser(fileEntity.User);

            return new File(
                fileEntity.Id,
                fileEntity.Name,
                fileEntity.Extension,
                fileEntity.Size,
                fileEntity.CreatedAt,
                fileEntity.StoragePath,
                fileEntity.FolderId,
                fileEntity.UserId,
                folder,
                user);
        }
        public static Folder ConvertFolderEntityToFolder(FolderEntity folderEntity)
        {
            ICollection<Folder> subFolders = [];
            ICollection<File> files = [];
            User user = ConvertUserEntityToUser(folderEntity.User);
            Folder upFolder = ConvertFolderEntityToFolder(folderEntity.UpFolder);

            foreach (FolderEntity folder in folderEntity.SubFolders) {
                subFolders.Add(ConvertFolderEntityToFolder(folder));
            }

            foreach (FileEntity file in folderEntity.Files) { 
                files.Add(ConvertFileEntityToFile(file));
            }

            return new Folder(
                folderEntity.Id,
                folderEntity.Name,
                folderEntity.Path,
                folderEntity.CreatedAt,
                subFolders,
                files,
                folderEntity.UserId,
                folderEntity.UpFolderId,
                user,
                upFolder);
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
