using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Tries
{
    public class Trie
    {
        private TrieNode Head = new TrieNode('$');

        public Trie()
        {
           
        }

        public void Clear()
        {
            Head.Children.Clear();
        }

        public void Insert(string word)
        {
            Head = InsertHelper(Head, word);
        }
        // simple after understanding how a dictionary works, recursive test
        public TrieNode InsertHelper(TrieNode head, string word)
        { 
            if(word.Length == 0)
            {
                head.IsWord = true;
                return head;
            }


            if (head.Children.ContainsKey(word[0]) == false)
            {
                head.Children.Add(word[0], new TrieNode(word[0], false));
            }
            head.Children[word[0]] = InsertHelper(head.Children[word[0]], word.Substring(1));

            return head;
        }


        //not much trouble after search
        public bool Contains(string word)
        {
            TrieNode remove = SearchNode(word);

            if (remove == null || word.Length == 0)
            {
                return false;
            }

            return true;
        }

        public TrieNode SearchNode(string word)
        {
            return SearchNodeHelper(Head, word);
        }

        /*
         * hardest function
         * 1.figuring out to put in searchedChildren with var(idk what that is other than super parent variable)
         * 2. figuring out that I needed to recursive to get the actual letter instead of a $
         */
        private TrieNode SearchNodeHelper(TrieNode head, string word)
        {
            TrieNode searched = new TrieNode('$');
            Dictionary<char, TrieNode> searchedChildren = new Dictionary<char, TrieNode>();

            if (word.Length > 0 && head.Children.Count > 0)
           {
                if (head.Children.ContainsKey(word[0]))
                {
                    searched = SearchNodeHelper(head.Children[word[0]], word.Substring(1));
                   //searched.Children.Add(word[0], SearchNodeHelper(head.Children[word[0]], word.Substring(1)));

                   searched.Letter = word[0];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                searchedChildren = head.Children;
                foreach (var val in searchedChildren)
               {
                    searched.Children.Add(val.Key, val.Value);
               }
            }
            return searched;
        }

        //made me realize my search didn't work
        public List<string> GetAllMatchingPrefix(string prefix)
        {
            List<string> matches = new List<string>();

            TrieNode node = SearchNode(prefix);

            MatchHelper(matches, node, prefix);

            return matches;
        }

        public void MatchHelper(List<string> matches, TrieNode node, string prefix)
        {
            foreach ((char letter, TrieNode trieNode) in node.Children)
            {
                MatchHelper(matches, trieNode, prefix + trieNode.Letter);  
            }

            if (node.IsWord)
            {
                matches.Add(prefix);
            }
        }   

        //contains but set is word false

        public bool Remove(string prefix)
        {
            TrieNode remove = SearchNode(prefix);

            if (remove == null || prefix.Length == 0)
            {
                return false;
            }

            remove.IsWord = false;
            return true;
        }

    }

}
