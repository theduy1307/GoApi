namespace MasterData.Application.Extensions;

public static class GenderExtensions
{
    public static string ToGenderValue(this byte gender)
    {
        return gender switch
        {
            0 => "Nam",
            1 => "Nữ",
            2 => "Không xác định",
            _ => throw new ArgumentOutOfRangeException(nameof(gender), "Giá trị không hợp lệ")
        };
    }
}