using MusicBox.CustomExceptions;
using MusicBox.Models;
using System.Collections.Generic;

namespace MusicBox
{
    internal class Program
    {
        public static List<Music> AllMusic { get; set; }
    
        static void Main(string[] args)
        {
            AllMusic = new List<Music>();

           
            bool breakpoint = true;
            Playlist playlist = new Playlist();
            do
            {
                Console.WriteLine("\n1.Mahnı yarat\n2.Playlist\n3.Plalist-e mahni elave et\n4.Mahni qosh\n5.En son dinlenen mahnilar\n0.Chixish\n");
                Console.Write("Komanda: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CreateMusic();
                        break;
                    case "2":
                        playlist.ShowPlaylist();
                        break;
                    case "3":
                        ShowAllMusic();
                        Console.WriteLine("Elave etmek istediyiniz mahninin ID-ni daxil edin: ");
                        uint.TryParse(Console.ReadLine(), out uint id);
                      
                        Music item = AllMusic.Find(i => i.ID == id);
                        if (item != null)
                        {
                            playlist.AddMusic(item);
                            AllMusic.Remove(item);
                        }
                        else
                        {
                            Console.WriteLine("Bu ID-ye uygun mahnı yoxdur");
                        }
                        
                        

                        
                        break;
                    case "4":
                        playlist.ShowPlaylist();
                        Console.WriteLine("Qoshmaq istediyiniz mahninin ID-ni daxil edin: ");
                        uint.TryParse(Console.ReadLine(), out uint PlayId);
                        try
                        {
                            Music PlayMusic = playlist.Playlists.Find(i => i.ID == PlayId);
                            if (PlayMusic != null)
                                playlist.Play(PlayMusic);
                            else
                                Console.WriteLine("Bu ID-ye uygun mahnı yoxdur");
                        }
                        catch (WrongCommandException ex)
                        {

                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "5":
                        playlist.ShowLastMusic();
                        break;
                    case "0":
                        Console.WriteLine("Chixish edildi!");
                        breakpoint = false;
                        break;

                    default:
                        Console.WriteLine("Yanlish komanda!");
                        break;
                }


            } while (breakpoint);



        }

        static void CreateMusic()
        {
            Console.WriteLine("Mahninin adi: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Ifachinin adi: ");
            string ArtistName = Console.ReadLine();
            T:
            Console.WriteLine("Vaxt: ");
            ushort.TryParse(Console.ReadLine(), out ushort Time);
            if (Time<=0 || Time>1800)
            {
                Console.WriteLine("Vaxt 01-1800 saniye arasinda ola biler\nZehmet olmasa yeniden daxil edin");
                goto T;
            }
            AllMusic.Add(new Music(Name, ArtistName, Time));
            Console.WriteLine("Mahni elave olundu");
        }

        static void ShowAllMusic()
        {
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine("All Music");
            if (AllMusic.Count > 0)
            {
                for (int i = 0; i < AllMusic.Count; i++)
                {
                    Console.WriteLine($"{i+1}. ID:{AllMusic[i].ID}\t{AllMusic[i].ArtistName}- {AllMusic[i].Name}");
                }
            }
            else
            {
                Console.WriteLine("All Music-de mahni yoxdur!");
            }
            Console.WriteLine("-----------------------------------------------------------");
        }

        
    }
}