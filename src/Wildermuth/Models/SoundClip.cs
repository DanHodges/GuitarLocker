using System;
namespace GuitarLocker.Models
{
    public class SoundClip
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Upload_Date { get; set; }
        public string Description { get; set; }
        public string Recording_Gear { get; set; }

    }
}