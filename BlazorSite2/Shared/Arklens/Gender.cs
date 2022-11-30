namespace BlazorSite2.Shared.Arklens;
public class Gender : CharacterElement
{
    private Gender(string emoji, string name) : base(emoji, name)
    {
    }
    public readonly static Gender Female = new("🚺", "Женский");
    public readonly static Gender Male = new("🚹", "Мужской");
    public readonly static IReadOnlyList<Gender> All
        = new[] { Male, Female };
}
