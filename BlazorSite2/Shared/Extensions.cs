using BlazorSite2.Shared.Arklens;
using System.Text;

namespace Un1ver5e.Web.III.Shared
{
    public static class Extensions
    {
        /// <summary>
        /// Formats <paramref name="mod"/> as a modifyer.
        /// </summary>
        /// <param name="mod"></param>
        /// <returns>
        /// <see langword="string"/> representation of <paramref name="mod"/>
        /// or <see langword="null"/> if <paramref name="mod"/> is <see langword="null"/>.
        /// </returns>
        public static string? AsMod(this int? mod) =>
            mod.HasValue ? mod.Value.AsMod() : null;

        /// <summary>
        /// Formats <paramref name="mod"/> as a modifyer.
        /// </summary>
        /// <param name="mod"></param>
        /// <returns>
        /// <see langword="string"/> representation of <paramref name="mod"/>.
        /// </returns>
        public static string AsMod(this int mod) =>
            mod < 0 ? mod.ToString() : $"+{mod}";

        /// <summary>
        /// Gets the <typeparamref name="TElement"/> with <see cref="CharacterElement.Name"/>
        /// equal to <paramref name="name"/>.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="collection"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static TElement? GetByName<TElement>(
            this IEnumerable<TElement> collection, string? name)
            where TElement : CharacterElement
            => collection.FirstOrDefault(e => e.Name == name);

        public static StringBuilder ReplaceSingle(this StringBuilder builder, string originalString, string pattern, object? newValue)
        {
            string? replace = newValue?.ToString() ?? string.Empty;
            int length = pattern.Length;
            int index = originalString.IndexOf(pattern);

            return builder.Replace(pattern, replace, index, length);
        }
    }
}
