using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuitarLocker.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Upload_Date { get; set; }
        public string Description { get; set; }
    }
}
