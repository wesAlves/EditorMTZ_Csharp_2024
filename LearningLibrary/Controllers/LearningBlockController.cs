using EditorMTZApi.DataContext;
using LearningLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningLibrary.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LearningBlockController : ControllerBase
{
    private readonly LearningLibraryDbContext _context;

    public LearningBlockController(LearningLibraryDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LearningBlock>>> GetLearningObjects()
    {
        return await _context.LearningBlocks.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LearningBlock>> GetLearningObject(Guid id)
    {
        var learningObject = await _context.LearningBlocks.FindAsync(id);

        if (learningObject == null)
        {
            return NotFound();
        }

        return learningObject;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LearningBlock>> PutLearningObject(Guid id, LearningBlock learningObject)
    {
        if (id != learningObject.Id)
        {
            return BadRequest();
        }

        _context.Entry(learningObject).State = EntityState.Modified;

        try
        {
            _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            //NotImplementedException
            Console.WriteLine(e);
            throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<LearningBlock>> PostLearningObject(LearningBlock learningObject)
    {
        _context.LearningBlocks.Add(learningObject);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLearningObject), new { id = learningObject.Id }, learningObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLearingObject(Guid id)
    {
        var learingObject = await _context.LearningBlocks.FindAsync(id);

        if (learingObject == null)
        {
            return NotFound();
        }

        _context.LearningBlocks.Remove(learingObject);
        _context.SaveChangesAsync();
        
        return NoContent();
    }
}
