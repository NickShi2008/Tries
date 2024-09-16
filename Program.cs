namespace Tries
{
    public class Program
    {
        static void Main(string[] args)
        {
            Trie tried = new Trie();
            tried.Insert("world");
            tried.Insert("words");
            //search doesn't get children so it doesn't allow for further removal past the first index
            TrieNode searched = tried.SearchNode("wo");
            List<string> prefixes = tried.GetAllMatchingPrefix("wor");
            //bool check = tried.Remove("s");
            ;
        }
    }
}
