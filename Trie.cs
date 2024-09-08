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
            if(head.Children.Count == 0)
            {
                return head;
            }
            if (!head.Children.ContainsKey(word[0]))
            {
                throw new NullReferenceException("not in dictionary");
            }
            return SearchNodeHelper(head.Children[word[0]], word.Substring(1));
        }

        public List<string> GetAllMatchingPrefix(string prefix)
        {
            return default(List<string>);
        }

        public bool Remove(string prefix)
        {
            return false;
        }

    }

}
