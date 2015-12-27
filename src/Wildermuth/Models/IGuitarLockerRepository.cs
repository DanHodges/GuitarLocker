using System.Collections.Generic;

namespace GuitarLocker.Models
{
    public interface IGuitarLockerRepository
    {
        IEnumerable<Instrument> GetAllInstruments();
        IEnumerable<Instrument> GetAllInstrumentsWithSoundClips();
        void AddInstrument(Instrument newInstrument);
        bool SaveAll();
        Instrument GetInstrumentByName(string InstrumentName, string userName);
        void AddSoundClip(string InstrumentName, SoundClip newSoundClip, string userName);
        IEnumerable<Instrument> GetUserInstruments(string name);
    }
}