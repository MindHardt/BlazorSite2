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
    }
}
