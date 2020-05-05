using System;
using System.Collections.Generic;
using System.Text;

namespace Explorable_Areas
{
    class NPC : Person
    {
        public string message;
        protected bool isthefirstcharacter;
        public string ImportantMessage;
        public NPC(string Name, string Message, bool ISthefirstcharacter): base(Name, false)
        {
            message = Message;
            isthefirstcharacter = ISthefirstcharacter;


        }
        public NPC(string Name, string Message, string importantmessage, bool ISthefirstcharacter)
            : base(Name, false)
        {
            ISthefirstcharacter = true;
            isthefirstcharacter = ISthefirstcharacter;
            message = Message;
            ImportantMessage = importantmessage;
        }
    }
}
