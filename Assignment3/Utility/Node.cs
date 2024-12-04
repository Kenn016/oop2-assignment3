using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    public class Node
    {
        public User User;
        public Node Next;

        public Node(User val)
        {
            User = val;
            Next = null;
        }
    }
}
