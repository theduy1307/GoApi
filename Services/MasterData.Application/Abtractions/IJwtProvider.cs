using GoSolution.Entity.Entities;

namespace MasterData.Application.Abtractions;

public interface IJwtProvider
{
    string Generate(Employee employee);
}