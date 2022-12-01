namespace BlazorSite2.Shared.Arklens;
public class Gender : CharacterElement
{
    private Gender(string emoji, string name) : base(emoji, name)
    {
    }
    public static Gender Female { get; } = new("🚺", "Женский");
    public static Gender Male { get; } = new("🚹", "Мужской");
    public static IReadOnlyList<Gender> All { get; } = new[] { Male, Female };
}
