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

        public bool Contains(string word)
        {
            return false;
        }

        public TrieNode SearchNode(string word)
        {
            return SearchNodeHelper(Head, word);
        }

        private TrieNode SearchNodeHelper(TrieNode head, string word)
        {
            TrieNode searched = new TrieNode('$');

            if ((head.Children.Count > 0) && word.Length > 0)
            {
                if (head.Children.ContainsKey(word[0]))
                {
                    searched.Children.Add(word[0], SearchNodeHelper(head.Children[word[0]], word.Substring(1)));
                }
                else if (!head.Children.ContainsKey(word[0]))
                {
                    return null;
                }
            }

            return searched;
        }

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
