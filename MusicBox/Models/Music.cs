
namespace MusicBox.Models
{
    public class Music
    {
        private static uint _id = 1;
        private string _name;
        private string _artistName;
        private ushort _time;

        public ushort Time
        {
            get { return _time; }
            set {
                if (value > 0 && value < 1800) _time = value;

                else if (value <= 0)
                    _time = 1;
                else
                    _time = 1800;
            }
        }

        public string ArtistName
        {
            get { return _artistName; }
            set {
                if (String.IsNullOrEmpty(value) && String.IsNullOrWhiteSpace(value))
                {
                    _artistName = "Yeni ifaçı";
                }
                else
                {
                    value = value.Trim();
                    if (value.Length < 30)
                    {
                        _artistName = value.CapitalizeName();
                    }
                    else
                    {
                        _artistName = value.Substring(0, 30);
                    }
                }
                
            }
        }


        public string Name
        {
            get { return _name; }
            set {
                if (String.IsNullOrEmpty(value) && String.IsNullOrWhiteSpace(value))
                {
                    _name = "Yeni Mahnı";
                }
                else
                {
                    value = value.Trim();
                    if (value.Length < 30)
                    {
                        _name = value.Capitalize();
                    }
                    else
                    {
                        _name = value.Substring(0, 30);
                    }
                }
            }
        }

        public uint ID { get; }


        public Music(string name, string artistname, ushort time)
        {
            Name = name;
            ArtistName = artistname;
            Time = time;
            ID = _id++;
        }
    }
}
