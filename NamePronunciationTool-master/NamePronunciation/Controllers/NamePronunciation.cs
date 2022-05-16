using Microsoft.AspNetCore.Mvc;
using NamePronunciation.Services;
using NamePronunciation.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NamePronunciation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NamePronunciation : ControllerBase
    {
        private readonly IPronunciationService pronunciationService;
        public NamePronunciation(IPronunciationService pronunciationService)
        {
            this.pronunciationService = pronunciationService;
        }
        // GET: api/<NamePronunciation>
        
        [HttpGet("NamePhonetic")]
        public string GetPhoneticsforStandardPronunciation(string Name)
        {
            return pronunciationService.GetPhoneticsforName(Name);
        } 

        // POST api/<NamePronunciation>
        [HttpPost("Name")]
        public void GetExistingPronunciation(string Name)
        {
            pronunciationService.GetExistingPronunciation(Name);
        }
        [HttpPost("CustomName")]
        public void GetcustomAudioFileandSave(string audio)
        {
            pronunciationService.GetcustomAudioFileandSave(audio);
        }
        [HttpGet("NameStandard")]
        public void GetStandardPronunciation(string Name)
        {
            pronunciationService.GetStandardPronunciation(Name);
        }

    }
}
