using EditorMTZApi.DataContext;
using LearningLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningLibrary.Controllers;

[Route("api/[controller]")]
public class LearningObjectController : ControllerBase
{
    private readonly LearningLibraryDbContext _context;

    public LearningObjectController(LearningLibraryDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LearningObject>>> GetLearningObjects()
    {
        return await _context.LearningObjects.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LearningObject>> GetLearningObject(Guid id)
    {
        var learningObject = await _context.LearningObjects.FindAsync(id);

        if (learningObject == null)
        {
            return NotFound();
        }

        return learningObject;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<LearningObject>> PutLearningObject(Guid id, LearningObject learningObject)
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
    public async Task<ActionResult<LearningObject>> PostLearningObject(LearningObject learningObject)
    {
        _context.LearningObjects.Add(learningObject);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLearningObject), new { id = learningObject.Id }, learningObject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLearingObject(Guid id)
    {
        var learingObject = await _context.LearningObjects.FindAsync(id);

        if (learingObject == null)
        {
            return NotFound();
        }

        _context.LearningObjects.Remove(learingObject);
        _context.SaveChangesAsync();
        
        return NoContent();
    }
}