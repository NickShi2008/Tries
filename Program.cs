namespace Tries
{
    public class Program
    {
        static void Main(string[] args)
        {
            Trie tried = new Trie();
            tried.Insert("world");
            tried.Insert("words");
            TrieNode searched = tried.SearchNode("wo");
            List<string> prefixes = tried.GetAllMatchingPrefix("wor");
            bool check = tried.Remove("words");
            bool contains = tried.Contains("words");
            ;
        }
    }
}
