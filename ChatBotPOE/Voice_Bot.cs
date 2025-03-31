using System.IO;
using System.Media;
using System;

namespace ChatBotPOE
{
    public class Voice_Bot
    {
        public Voice_Bot()
        {
            //using the constructor to play the Voice

            
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(full_location);

            string new_path = full_location.Replace("bin\\Debug", "");

            try
            {
                string full_path = Path.Combine(new_path, "ChatBotVoiceOver.wav");
                using (SoundPlayer myplayer = new SoundPlayer(full_path))
                {
                    myplayer.PlaySync();
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }

        }
    }
}