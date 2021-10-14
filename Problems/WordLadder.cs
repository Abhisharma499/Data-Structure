namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class WordLadder
    {
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            if(!wordList.Contains(endWord))
            {
                return 0;
            }

            Dictionary<string, bool> map = new Dictionary<string, bool>();

            map.Add(beginWord, false);
            foreach(string str in wordList)
            {
                if(!map.ContainsKey(str))
                {
                    map.Add(str, false);
                }
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            int length = 1;
            map[beginWord] = true;
            bool isFound = false;
            bool isEverFound = false;
            while(queue.Count()>0)
            {
                int size = queue.Count();

                while(size>0)
                {
                    size--;

                    string str = queue.Dequeue();
                    if(CheckLadder(str, wordList, map, queue))
                    {
                        isFound = true;
                        isEverFound = true;

                        if (str == beginWord && wordList.Contains(beginWord) && str.Length>1)
                        {
                            length--;
                        }
                    }
                }

                if(isFound)
                {
                    length++;
                }

                isFound = false;
            }

            return isEverFound==true?length:0;
           
        }

        public static bool CheckLadder(string input, IList<string> wordList, Dictionary<string, bool> map, Queue<string> queue)
        {
            bool isFound = false;
            char c = 'a';
            char[] chararr = input.ToCharArray();

            for(int i=0;i<input.Length;i++)
            {
                for(int j=0;j<26;j++)
                {
                    c = (char)(c + 1);

                    chararr[i] = c;

                    string temp = new string(chararr);
                    if (wordList.Contains(temp) && map[temp]== false)
                    {
                        map[temp] = true;
                        queue.Enqueue(temp);
                        isFound = true;
                    }
                }

                c = 'a';

                chararr = input.ToCharArray();
            }

            return isFound;
        }  
    }
}
