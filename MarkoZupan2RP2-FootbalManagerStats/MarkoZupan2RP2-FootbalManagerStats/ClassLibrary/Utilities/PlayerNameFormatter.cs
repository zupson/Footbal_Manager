using AutoMapper;
using System.Globalization;

namespace ClassLibrary.Utilities
{
    //WinForms
    public class PlayerNameFormatter
    {
        public static string Normalize(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            return string.Join(" ", name.ToLower().Split(' ')
                .Select(w => w.Length > 0 ? char.ToUpper(w[0]) + w[1..] : ""));
        }
    }
    public class PlayerFormatterConverter : IValueConverter<string, string>
    {
        public string Convert(string sourceMember, ResolutionContext context)
        {
            return PlayerNameFormatter.Normalize(sourceMember);
        }
    }
}
