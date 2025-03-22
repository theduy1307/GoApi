namespace MasterData.Application.Dtos;

public class MenuDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Icon { get; set; }
    public string? Url { get; set; }
    public Guid? ParentId { get; set; }
    public List<MenuDto> SubMenus { get; set; }
}