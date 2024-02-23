using LearningLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EditorMTZApi.DataContext;

public class LearningLibraryDbContext : DbContext
{
    public LearningLibraryDbContext(DbContextOptions<LearningLibraryDbContext> options) : base(options)
    {
    }

    public DbSet<LearningPath> LearningPaths { get; set; }
    public DbSet<LearningObject> LearningObjects { get; set; }
    public DbSet<LearningBlock> LearningBlocks { get; set; }
}