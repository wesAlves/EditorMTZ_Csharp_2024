namespace TodoItems.Models;

public class TodoItem
{
    public long Id { set; get; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? Secret { get; set; }
}