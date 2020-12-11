using System.Collections.Generic;

namespace WebApi.Utils.Validators
{
    public static class JobTitleValidator
    {
        public static List<string> Titles { get; private set; } = new List<string>(){ "Administrator", "Developer", "Architect", "Manager" };
        public static bool Validate(string title)
        {
            return Titles.Contains(title);
        }
        public static bool Validate(ICollection<string> titles)
        {
            foreach (var title in titles)
            {
                if (!Titles.Contains(title)) return false;
            }

            return true;
        }
    }
}