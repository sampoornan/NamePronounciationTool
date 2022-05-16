using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamePronunciation.Services
{
    public interface IPronunciationService
    {
        public void GetStandardPronunciation(string Name);
        public string GetPhoneticsforName(string Name);
        public void GetcustomAudioFileandSave(string input);
        public void GetExistingPronunciation(string Name);



    }
}
