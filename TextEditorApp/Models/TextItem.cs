namespace TextEditorApp.Models;

public class TextItem
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; } = string.Empty;
    public override string ToString()
    {
        return Content;
    }
}