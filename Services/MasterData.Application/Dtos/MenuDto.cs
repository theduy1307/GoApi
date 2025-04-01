namespace MasterData.Application.Dtos;

public class MenuDto
{
    public Guid Id { get; set; }
    public string Label { get; set; } = string.Empty;
    public string? Icon { get; set; }
    public string? To { get; set; }
    public bool Visible { get; set; } = true;
    public Guid? ParentId { get; set; }
    public List<MenuDto>? Items { get; set; } = [];
}