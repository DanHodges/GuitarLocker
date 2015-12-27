using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarLocker.Models;

namespace GuitarLocker.Models
{
    public class GuitarLockerContextSeedData
    {
        private GuitarLockerContext _context;
        private UserManager<GuitarLockerUser> _userManager;

        public GuitarLockerContextSeedData(GuitarLockerContext context, UserManager<GuitarLockerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("dano@internet.com") == null)
            {
                //add the user
                var newUser = new GuitarLockerUser()
                {
                    UserName = "TheDano",
                    Email = "dano@internet.com",
                    FirstInstrument = DateTime.UtcNow
                };
                await _userManager.CreateAsync(newUser, "P@ssw0rd!");
            }

            if (!_context.Instruments.Any())
            {
                //Add New Data
                var Lester = new Instrument()
                {
                    Name = "Lester",
                    Make = "Gibson",
                    Model = "Les Paul Special",
                    Year = 2005,
                    Uploaded = DateTime.UtcNow,
                    UserName = "TheDano",
                    SoundClips = new List<SoundClip>()
                    {
                    new SoundClip() {  Title = "Ramblin' Sound", Url = "www.google.com", Upload_Date = DateTime.Now, Description = "Les Paul neck pickup a siverface champ", Recording_Gear = "iPhone Mic" },
                    new SoundClip() {  Title = "Misty Mountain Rock", Url = "www.google.com", Upload_Date = DateTime.Now, Description = "Bridge pickup into a siverface champ", Recording_Gear = "sm57" },
                    },
                    Images = new List<Image>()
                    {
                        new Image() { Title = "Les Paul Pics", Url = "www.google.com", Upload_Date = DateTime.Now, Description = "My tele leaning against a majestic tree in the woods"}
                    }

                };
                _context.Instruments.Add(Lester);
                _context.SoundClips.AddRange(Lester.SoundClips);
                _context.Images.AddRange(Lester.Images);

                var tele = new Instrument()
                {
                    Name = "Blackgaurd",
                    Make = "Fender",
                    Model = "NoCaster",
                    Year = 2012,
                    Uploaded = DateTime.UtcNow,
                    UserName = "TheDano",
                    SoundClips = new List<SoundClip>()
                    {
                    new SoundClip() {  Title = "Barn Burner", Url = "www.google.com", Upload_Date = DateTime.Now, Description = "Bridge pickup a siverface champ", Recording_Gear = "iPhone Mic" },
                    new SoundClip() {  Title = "Slow and Sweet", Url = "www.google.com", Upload_Date = DateTime.Now, Description = "Neck pickup into a super reverb", Recording_Gear = "sm57" },
                    },
                    Images = new List<Image>()
                    {
                        new Image() { Title = "Nocaster Pics", Url = "www.google.com", Upload_Date = DateTime.Now, Description = "My tele leaning against a majestic tree in the woods"}
                    }
                };

                _context.Instruments.Add(tele);
                _context.SoundClips.AddRange(tele.SoundClips);
                _context.Images.AddRange(tele.Images);
                _context.SaveChanges();
            }
        }
    }
}
