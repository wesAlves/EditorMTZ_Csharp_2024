using Microsoft.EntityFrameworkCore;

namespace EditorMTZApi.DataContext;

public class LearningLibratyDbContext : DbContext
{
    public LearningLibratyDbContext(DbContextOptions<LearningLibratyDbContext> options) : base(options)
    {
    }
    
    
    
}