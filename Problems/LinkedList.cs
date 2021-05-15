using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
  public  class LinkedList
    {
       public int data;
       public LinkedList next;
        public int NodeNumber;

        public static LinkedList RemoveDuplicate(LinkedList head)
        {
            LinkedList current;
            LinkedList start = head;

            if (head == null || head.next == null)
            {
                return head;
               
            }
            else
            {
                current = head.next;
            }

             while(head != null && head.next!=null && current!=null)
             {

                if (head.data!=current.data)
                {
                    current = current.next;
                    head = head.next;
                }
                else
                {
                    head.next = current.next;
                    current = current.next;
                }      
            }

            return start;
        }
    }
}

/*

LinkedList linkedListFirstNode = new LinkedList();
linkedListFirstNode.data = 1;
            linkedListFirstNode.NodeNumber = 1;
            LinkedList linkedListSecondNode = new LinkedList();
linkedListSecondNode.NodeNumber = 2;
            linkedListSecondNode.data = 2;

            linkedListFirstNode.next = linkedListSecondNode;

            LinkedList linkedListThirdNode = new LinkedList();
linkedListThirdNode.NodeNumber = 3;
            linkedListThirdNode.data = 3;

            linkedListSecondNode.next = linkedListThirdNode;


            LinkedList linkedListForthNode = new LinkedList();
linkedListForthNode.NodeNumber = 4;
            linkedListForthNode.data = 3;

            linkedListThirdNode.next = linkedListForthNode;


            LinkedList linkedListFifthNode = new LinkedList();
linkedListFifthNode.NodeNumber = 5;
            linkedListFifthNode.data = 3;

            linkedListForthNode.next = linkedListFifthNode;
            linkedListFifthNode.next = null;


            //LinkedList linkedListSixthNode = new LinkedList();
            //linkedListSixthNode.NodeNumber = 6;
            //linkedListSixthNode.data = 4;

            //linkedListFifthNode.next = linkedListSixthNode;
            //linkedListSixthNode.next = null;

            LinkedList node = LinkedList.RemoveDuplicate(linkedListFirstNode);

*/
