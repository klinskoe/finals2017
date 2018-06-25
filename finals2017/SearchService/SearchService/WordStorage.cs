using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService {
    class WordStorage {
        private Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

        public void AddWord(string word, string file)
        {
            List<string> files;

            if (!words.TryGetValue(word, out files))
            {
                files = new List<string>();
                words[word] = files;
            }
            if (!files.Contains(file))
            {
                files.Add(file);
            }
            
        }

        public IEnumerable<string> GetFiles(string word) {
            // Replace this line with a proper logic, sure will!!
            if (words.TryGetValue(word,out List<string> files))
            {
                return files;
            }
            return Enumerable.Empty<string>();
        }
    }
}
