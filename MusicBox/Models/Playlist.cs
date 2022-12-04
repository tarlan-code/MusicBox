using MusicBox.CustomExceptions;


namespace MusicBox.Models
{
    internal class Playlist
    {
        public List<Music> Playlists;
        public Queue<Music> LastMusic;
        bool IsPlaying;
        DateTime StartedTime;
        TimeSpan MusicTime;

        public Playlist()
        {
            Playlists = new List<Music>();
            LastMusic = new Queue<Music>();
        }
        public void AddMusic(Music music)
        {
            bool HasMusic = false;
            foreach (Music item in Playlists)
            {
                if (item.ID == music.ID)
                {
                    Console.WriteLine($"{music.ArtistName}- {music.Name} artıq elave olunub");
                    HasMusic = true;
                    return;

                }
            }

            if (!HasMusic)
            {
                Playlists.Add(music);

                Console.WriteLine($"{music.ArtistName}- {music.Name} PlayList siyahisina elave olundu");

            }
        }

        public void Play(Music music)
        {
            bool answer = true;
            if (IsPlaying)
            {
                answer = PlayNewMusic();
            }

            if (answer)
            {
                foreach (Music song in Playlists)
                {
                    if (song.ID == music.ID)
                    {
                        Console.WriteLine($"{music.ArtistName}- {music.Name} dinleyirsiniz");
                        if (LastMusic.Count >= 5)
                        {
                            LastMusic.Dequeue();
                        }
                       
                        LastMusic.Enqueue(music);
                        StartedTime = DateTime.Now;
                        MusicTime = TimeSpan.FromSeconds(music.Time);
                        IsPlaying = true;
                        break;
                    }
                }

            }


        }

        bool PlayNewMusic()
        {
            if ((DateTime.Now - StartedTime) < MusicTime)
            {

                Console.WriteLine("Yeni mahnıya keçid etmek isteyirsiz?(he/yox)");
                string answer = Console.ReadLine();

                answer.Trim().ToLower();
                if (answer == "yox")
                {
                    Console.WriteLine("Mahnı dinlenilmeye davam edir");
                    return false;
                }
                else if (answer == "he")
                {
                    Console.WriteLine("Yeni mahnıya keçid edilir...");
                    return true;
                }
                else
                {
                    throw new WrongCommandException("Cavab yalnız he/yox ola biler");
                }
            }
            return true;
        }
        public void ShowPlaylist()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("Playlist");
            if (Playlists.Count > 0)
            {
                for (int i = 0; i < Playlists.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. ID:{Playlists[i].ID}\t{Playlists[i].ArtistName}- {Playlists[i].Name}");
                }
            }
            else
            {
                Console.WriteLine("Playlistde mahni yoxdur!");
            }
            Console.WriteLine("-----------------------------------------------------------");

        }

        public void ShowLastMusic()
        {
            Console.WriteLine("En son dinlenen mahnilar");
            if (LastMusic.Count > 0)
            {
                int k = 1;
                
                foreach (Music music in LastMusic)
                {
                    Console.WriteLine($"{k}.{music.ArtistName}- {music.Name}");
                    k++;
                }
            }

            else
            {
                Console.WriteLine("Bosdur");
            }
        }

    }
}
