namespace MasterData.Application.Exceptions;

public class CountryNotFoundException : ApplicationException
{
    public CountryNotFoundException(string name, Object key) : base($"Entity {name} - {key} is not found.")
    {
        
    }
}