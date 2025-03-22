using AutoMapper.Internal;
using GoSolution.Entity;
using GoSolution.Entity.Entities;
using MasterData.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MasterData.Infrastructure.Repositories;

public class MenuRepository(PoseidonDbContext context) : RepositoryBase<Menu>(context), IMenuRepository
{
    public async Task<IReadOnlyList<Menu>> GetMenuByRolesId(List<Guid> rolesId)
    {
        var listSubMenu = await _context.Roles
            .Where(rm => rolesId.Contains(rm.Id))
            .Include(rm => rm.Menus)
            .SelectMany(x => x.Menus)
            .ToListAsync();
        // Get submenu, 
        var listMenus = await _context.Menus
            .Where(x => x.ParentId == null)
            .ToListAsync();
        foreach (var menu in listMenus)
        {
            menu.SubMenus = listSubMenu.Where(x => x.ParentId == menu.Id).ToList();
        }
        return listMenus.Where(x => x.SubMenus.Any()).ToList();
    }
}