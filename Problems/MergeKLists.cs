namespace TestProject.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class SortPair : IComparable<SortPair>
    {
        public int listNo;
        public int val;
        public int pos;

        public SortPair(int listNo, int val, int pos)
        {
            this.listNo = listNo;
            this.val = val;
            this.pos = pos;
        }

        public int CompareTo(SortPair other)
        {
            return this.val.CompareTo(other.val);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
   public class MergeKLists
    {
        public ListNode MergeKListsMethod(ListNode[] lists)
        {
            ListNode head = new ListNode(0);
            ListNode realhead = head;

            if(lists.Length==0)
            {
                return null;
            }

            List<SortPair> minHeap = new List<SortPair>();

            for(int i=0;i<lists.Length;i++)
            {
                if (lists[i] != null)
                {
                    minHeap.Add(new SortPair(i, lists[i].val, 0));
                }
            }

            while(minHeap.Count()>0)
            {
                SortPair temp = minHeap.Min();
                ListNode curr = new ListNode(temp.val);
                head.next = curr;
                head = head.next;
                int numberOfNodesToMove = temp.pos + 1;

                ListNode localHead = lists[temp.listNo];

                while(numberOfNodesToMove > 0 && localHead!=null)
                {
                    localHead = localHead.next;
                    numberOfNodesToMove--;
                }

                if(localHead!=null)
                {
                    minHeap.Add(new SortPair(temp.listNo, localHead.val, temp.pos + 1));
                }

                minHeap.Remove(temp);
            }

            return realhead.next;
        }
    }
}
