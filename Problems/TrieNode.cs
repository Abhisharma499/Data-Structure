namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrieNode
    {
        public TrieNode[] children = new TrieNode[26];
        public bool IsEnd = false;
    }
    public class WordDictionary
    {
        public TrieNode root;
        /** Initialize your data structure here. */
        public WordDictionary()
        {
            root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode node = root;

            foreach (char ch in word)
            {
                if (node.children[ch - 'a'] == null)
                {
                    node.children[ch - 'a'] = new TrieNode();
                }

                node = node.children[ch - 'a'];
            }

            node.IsEnd = true;
        }


        public bool Search(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            return Search(word, root, 0);
        }

        public bool Search(string word, TrieNode root, int count)
        {
            if (root == null)
            {
                return false;
            }

            if (word.Length == count)
            {
                return root.IsEnd;
            }

            if (word[count] == '.')
            {
                for (int i = 0; i < 26; i++)
                {
                    if (Search(word, root.children[i], count+1))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (Search(word, root.children[word[count] - 'a'], count+1))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
