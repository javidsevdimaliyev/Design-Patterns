using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Sample3
    {
        /*
         * Adapter is a structural design pattern that allows objects with incompatible interfaces to collaborate
         * The Adapter design pattern is used to make two incompatible interfaces compatible with each other.
         * The Adapter design pattern is used to make a class's interface compatible with another interface that the client expects
         * It is especially useful when the interface of an existing class does not match the interface the client wants to use.
         */

        /*
         * For example, we have a music player that can play MP3 files.
         * However, we want to add a new feature that will allow us to play FLAC files as well. But the existing music player only supports MP3 files.
         * This is where the Adapter design pattern comes in.
         */

        /*
         * Tutaq ki, bizim musiqi pleyerimiz var və bu pleyer MP3 faylları oxuya bilər.
         * Bununla belə, biz yeni funksiya əlavə etmək istəyirik və bu xüsusiyyət bizə FLAC fayllarını da oynatmağa imkan verəcək. 
         * Bununla belə, cari musiqi pleyeri yalnız MP3 fayllarını dəstəkləyir.
         * Adapter dizayn nümunəsi burada işə düşür.
         */

        void Test()
        {
            //OldMusicPlayer oldPlayer = new();
            //oldPlayer.PlayMp3("song.mp3");

            // Play FLAC files using the adapter
            IMusicPlayer player = new FlacPlayerAdapter();

            // İstemcinin kullanımı
            player.Play("song.mp3");
            player.Play("song.flac"); // FLAC file can also be played, because it was converted via the adapter
        }


        // Available music player class (Adaptee)
        class OldMusicPlayer
        {
            public void PlayMp3(string mp3)
            {
                Console.WriteLine("Playing MP3 file: " + mp3);
            }
        }

        // The interface the client expects
        interface IMusicPlayer
        {
            void Play(string file);
        }

        // Adapter class
        class FlacPlayerAdapter : IMusicPlayer
        {
            public void Play(string file)
            {
                // Create available music player
                OldMusicPlayer oldPlayer = new OldMusicPlayer();

                // Make FLAC file eligible before playback
                if (file == "flac")
                    Console.WriteLine("Converting FLAC file to MP3...");

                oldPlayer.PlayMp3(file);
            }
        }



    }


}
