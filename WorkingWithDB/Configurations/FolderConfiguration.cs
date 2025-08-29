using WorkingWithDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorkingWithDB.Configurations
{
    public class FolderConfiguration : IEntityTypeConfiguration<FolderEntity>
    {
        public void Configure(EntityTypeBuilder<FolderEntity> builder)
        {
            builder.HasKey(folder => folder.Id);

            builder.HasMany(folder => folder.SubFolders).WithOne(folder => folder.UpFolder);
            builder.HasMany(folder => folder.Files).WithOne(file => file.Folder);
            builder.HasOne(folder => folder.UpFolder).WithMany(folder => folder.SubFolders);
            builder.HasOne(folder => folder.User).WithMany(user => user.Folders);
        }
    }
}
