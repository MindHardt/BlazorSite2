namespace BlazorSite2.Shared.Arklens
{
    public class Gender : CharacterElement
    {
        public Gender(string emoji, string name) : base(emoji, name)
        {
        }
        public static Gender Female => new("🚺", "Женский");
        public static Gender Male => new("🚹", "Мужской");
        public static Gender[] All
            => new[] { Male, Female };
    }
}
