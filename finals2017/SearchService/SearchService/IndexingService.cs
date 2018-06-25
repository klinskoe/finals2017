using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchService {
    
    // DO NOT EDIT!!!
    class IndexingService {
        // First parameter - word in lower case
        // Second parameter - path to the file, in which it was found
        public event Action<string,string> OnNewWord;

        // Search for words without digits, at least 3 letters long
        private readonly Regex _wordRegex = new Regex(@"\p{L}{3,}", RegexOptions.Compiled);        

        public void Index(string directory) {
            try {
                foreach (var file in EnumerateFiles(directory, "*", SearchOption.AllDirectories)) {
                    try {
                        using (var sr = new StreamReader(file)) {
                            while (!sr.EndOfStream) {
                                string line = sr.ReadLine();
                                foreach (Match m in _wordRegex.Matches(line)) {
                                    OnNewWord?.Invoke(m.Value.ToLower(), file);
                                }
                            }
                        }
                    }
                    catch (Exception e) {
                        Console.WriteLine("Error processing file {0}: {1}", file, e.Message);
                    }
                }                
            }
            catch (Exception e) {
                Console.WriteLine("Error directory {0}: {1}", directory, e.Message);
            }            
        }

        private IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOpt) {
            try {
                var dirFiles = Enumerable.Empty<string>();
                if (searchOpt == SearchOption.AllDirectories) {
                    dirFiles = Directory.EnumerateDirectories(path)
                                        .SelectMany(x => EnumerateFiles(x, searchPattern, searchOpt));
                }
                return dirFiles.Concat(Directory.EnumerateFiles(path, searchPattern));
            }
            catch (UnauthorizedAccessException e) {
                Console.WriteLine(e.Message);
                return Enumerable.Empty<string>();
            }
        }
    }
}
