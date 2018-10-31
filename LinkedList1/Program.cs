using System;

//Write an algorithm to determine if a linkedlist is a palindrome
/*A simple solution is
 * to use a stack of list nodes:
1) Traverse the given list from head to tail and push every visited node to stack.
2) Traverse the list again. For every visited node, pop a node from stack and compare data of popped node with currently visited node.
3) If all nodes matched, then return true, else false.
Time complexity of above method is O(n), but it requires O(n) extra space. Following methods solve this with constant extra space.*/

namespace LinkedList1
{
    public class Node
    {
        public Node next;
        public char data;

        public Node(char value)
        {
            data = value;
            next = null;
         }

        public Node()
        {
            next = null;
        }
    }

    public class MyLL
    {
        Node head;

        public MyLL()
        {
            head = null;
        }

        public void printAllNodes()
        {
            Node cur = head;
            while (cur.next != null)
            {
                Console.WriteLine(cur.data);
                cur = cur.next;
            }
            Console.WriteLine(cur.data);
        }

        public void AddHead(char d)
        {
            Node node = new Node(d);
            node.next = head;
            head = node;
        }

         public void AddAtTail(char d)
         {
            Node node = new Node(d);
            if (head == null)
            {
                head = node;
            }
            else
            {
                Node current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = node;
            }
         }
        
        public bool IsPalindrome()
        {
            /* Get the middle of the list. Move slow by 1 and fast by 2.
               (fast == null) when there are even elements in list, and (fast != null) for odd elements.
               We need previous node of the middle for linked lists with odd elements.
               We need to skip the middle node for odd case and store it, 
               so, that we can restore the original list*/
            if (head == null) return false;

            Node slow = head, fast = head;
            Node start2 = head; //midnode = null;

            while (fast != null)
             {
                fast = fast.next.next;
                if (fast == null)
                {
                    //is even
                    start2 = slow.next;
                    break;
                }
                else if (fast.next == null)
                {
                    //is odd, ignore the middle node
                    //midnode = slow.next;
                    start2 = slow.next.next;
                    break;
                }
                slow = slow.next;
            }

            // Now reverse the second half and compare it with first half 
            slow.next = null; // NULL terminate first half
            Node head2 = Reverse(start2);  // Reverse the second half

            bool res = CompareLists(head, head2); // compare 
            return res;
        }

        /* Function to check if two input lists have same data*/
        public bool CompareLists(Node head1, Node head2) 
        { 
            Node temp1 = head1; 
            Node temp2 = head2;

            while (temp1 != null && temp2 != null) 
            { 
                if (temp1.data == temp2.data) 
                { 
                    temp1 = temp1.next; 
                    temp2 = temp2.next; 
                } 
                else
                    return false; 
            }

            /* Both are empty return true*/
            if (temp1 == null && temp2 == null)
                return true;
            
            /* Will reach here when one is NULL and other is not */
            return false;
        } 

        public Node Reverse(Node head)
        {
            Node cur = head;
            Node prev = null;
            while (cur != null)
            {
                head = cur.next;
                cur.next = prev;
                prev = cur;
                cur = head;
            }
            return prev;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            MyLL list = new MyLL();
            //list.AddHead('a');
            //list.AddHead('b');
            //list.AddHead('c');
            //list.AddHead('b');
            //list.AddHead('a');

            list.AddAtTail('1');
            list.AddAtTail('2');
            list.AddAtTail('3');
            list.AddAtTail('2');
            list.AddAtTail('1');
            list.AddAtTail('1');

            list.printAllNodes();

            bool res = list.IsPalindrome();
            if (res)
            {
                Console.WriteLine("A linkedlist is a palindrome");
            }
            else
                Console.WriteLine("A linkedlist is NOT a palindrome");

        }
    }
}
