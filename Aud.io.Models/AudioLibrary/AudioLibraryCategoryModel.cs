using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aud.io.Models.AudioLibrary
{
    public class AudioLibraryCategoryModel
    {
        public AudioLibraryCategoryModel()
        {
            Tracks = new List<AudioLibraryEntryModel>();
        }

        public string                               Label   { get; set; }
        public IEnumerable<AudioLibraryEntryModel>  Tracks  { get; set; }
    }
}
