using EditorMTZApi.DataContext;
using LearningLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningLibrary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LearningPathController : ControllerBase
{
    private readonly LearningLibraryDbContext _context;

    public LearningPathController(LearningLibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LearningPath>>> GetLearningPaths()
    {
        return await _context.LearningPaths.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LearningPath>> GetLearningPath(Guid id)
    {
        var learningPath = await _context.LearningPaths.FindAsync(id);

        if (learningPath == null)
        {
            return NotFound();
        }

        return learningPath;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutLearningPath(Guid id, LearningPath learningPath)
    {
        if (id != learningPath.Id)
        {
            return BadRequest();
        }

        _context.Entry(learningPath).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            //NotImplementedException
            Console.WriteLine(e);
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult> PostLearningPath(LearningPath learningPath)
    {
        _context.LearningPaths.Add(learningPath);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLearningPath), new { id = learningPath.Id }, learningPath);
    }
}