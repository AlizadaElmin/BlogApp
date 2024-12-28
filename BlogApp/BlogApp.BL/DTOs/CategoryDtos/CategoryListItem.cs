using BlogApp.Core.Entities;

namespace BlogApp.BL.DTOs.CategoryDtos;

public class CategoryListItem
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }

    public static implicit operator CategoryListItem(Category category)
    {
        return new CategoryListItem()
        {
            Id = category.Id,
            Name = category.Name,
            Icon = category.Icon
        };
    }
}