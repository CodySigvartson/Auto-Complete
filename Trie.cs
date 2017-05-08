using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14AutoComplete
{
    public class Trie
    {
        private TrieNode root;
        List<string> words;
        string word = "";

        public Trie()
        {
            root = new TrieNode('\0');
            words = new List<string>();
        }

        public List<string> getWords()
        {
            return this.words;
        }

        public void clearWords()
        {
            words.Clear();
        }

        public void addString(string s)
        {
            TrieNode t = root;
            foreach(char c in s)
            {
                t = t.addOrGetChild(c);
            }
            t.addOrGetChild('\0');
        }

        /// <summary>
        /// Get the end of the prefix and return the end node
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public TrieNode getPrefixNode(string prefix)
        {
            TrieNode placeHolder = root;
            //get to final TrieNode consisting of prefix
            foreach(char c in prefix)
            {
                placeHolder = placeHolder.addOrGetChild(c);
            }
            return placeHolder;
        }


        /// <summary>
        /// Get all the substrings from the end of the prefix
        /// </summary>
        /// <param name="returnNode"></param>
        /// <param name="prefix"></param>
        public void getSubStrings(TrieNode returnNode, string prefix)
        {
            if (prefix == "" || returnNode.c == '\0')
                return;
            
            foreach(TrieNode t in returnNode.children) //go through every child from the end of the prefix
            {
                if (t.c == '\0') //check for null character, word was found add it 
                    words.Add(prefix + word);
                else
                    word += t.c;
                word = "";
                getSubStrings(t, prefix + t.c);
            }
        }
    }

    public class TrieNode
    {
        public char c;
        public List<TrieNode> children;
        //public bool isWord;

        public TrieNode(char newC)
        {
            c = newC;
            children = new List<TrieNode>();
        }

        /// <summary>
        /// Builds the tree by making a new node for each char and returning the node for traversing purposes
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public TrieNode addOrGetChild(char cc)
        {
            foreach (TrieNode tn in children)
            {
                if (tn.c == cc)
                    return tn;
            }
            var t = new TrieNode(cc);
            children.Add(t);
            return t;
        }
    }
}
