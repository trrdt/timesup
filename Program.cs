using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace timesup
{
    class Program
    {
        private List <UserEvent> timesupMainList = new List<UserEvent>();

        public struct UserDefinedDate
        {
            public bool GoodDate;
            public int Month;
            public int Day;
            public int Year;
            public UserDefinedDate(int month, int day, int year)
            {
                GoodDate = true;
                Month = month;
                Day = day;
                Year = year;
            }
        }

        public struct UserEvent
        {
            public string Name;
            public string Description;
            public UserEvent(string name, string description)
            {
                Name = name;
                Description = description;
            }
        }

        public bool TimesupPrompt()
        {
            Console.Write("Type a number (0 - 5) to run that option.\n" +
                "1.  List events...\n" +
                "2.  Add an event to the list.\n" +
                "3.  Remove an event from the list.\n" +
                "4.  Edit an event on the list.\n" +
                "5.  Quit the application.\n" +
                "0.  Operator.\n"); string answer = Console.ReadLine();
            if (answer[0] == '0') { Console.WriteLine("Please wait while I connect you to an operator."); return false; }
            if (answer[0] == '1') { PromptOptionOne(); }
            if (answer[0] == '2') { PromptOptionTwo(); }
            if (answer[0] == '3') { PromptOptionThree(); }
            if (answer[0] == '4') { PromptOptionFour(); }
            if (answer[0] == '5') { return false; }
            return true;
        }

        private void PromptOptionOne()
        {
            foreach (var e in timesupMainList)
            {
                Console.Write(e.Name);
                Console.WriteLine();
            }
        }

        private void PromptOptionTwo()
        {
            Console.WriteLine("Event name:  ");
            string name = Console.ReadLine();
            Console.WriteLine("Event description:  ");
            string description = Console.ReadLine();
            Console.WriteLine("Event due time:  ");
            Console.ReadLine();// finish me
            UserEvent newEvent = new UserEvent(name, description);
            timesupMainList.Add(newEvent);
        }

        private void PromptOptionThree()
        {
            Console.WriteLine("Remove event by name.");
            string name = Console.ReadLine();
            foreach (UserEvent e in timesupMainList)
            {
                if (name == e.Name)
                {
                    timesupMainList.Remove(e);
                }
            }
        }

        private void PromptOptionFour()
        {
            Console.WriteLine("Not yet implemented.. hint: use your systems time format");
        }

        static void Main(string[] args)
        {
            string usageText = "use to track deadlines";
            string nonUsageText = "wishlist: prompt, event types, sound notification";
            Console.Write("Usage: {0}\nNonUsaged: {1}\n", usageText, nonUsageText);
            bool running = true;
            Program p = new Program();
            while (running)
            {
                if (!p.TimesupPrompt()) running = false;
            }
            Console.ReadLine();
        }
    }
}