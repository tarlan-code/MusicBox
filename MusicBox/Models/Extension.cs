using System.Text;

namespace MusicBox.Models
{
    internal static class Extension
    {
        public static string CapitalizeName(this string name)
        {
            string[] str = name.Split(' ');
            StringBuilder sb = new StringBuilder(); 
            foreach (string item in str)
            {
                if (!String.IsNullOrEmpty(item) && !String.IsNullOrWhiteSpace(item))
                {
                    sb.Append(Char.ToUpper(item[0]));
                    sb.Append(item.Substring(1).ToLower());
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }


        public static string Capitalize(this string title)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(Char.ToUpper(title[0]));
            sb.Append(title.Substring(1).ToLower());
            

            return sb.ToString();
        }
    }
}
