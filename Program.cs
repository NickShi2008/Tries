namespace Tries
{
    public class Program
    {
        static void Main(string[] args)
        {
            Trie tried = new Trie();
            tried.Insert("world");
            tried.Insert("words");
            tried.SearchNode("worldly");
            ;
        }
    }
}
