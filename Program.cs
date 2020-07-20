using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace timesup
{
    class Program
    {
        private List<UserEvent> UserEventList = new List<UserEvent>();

        public struct UserEvent
        {
            public int ID;
            public string Name;
            public string Description;
            public DateTime DueTime;
            public UserEvent(int id, string name, string description, DateTime dueTime)
            {
                ID = id;
                Name = name;
                Description = description;
                DueTime = dueTime;
            }
        }

        public bool TimesupPrompt()
        {
            Console.Write("Type a number (0 - 5) to run that option.\n" +
                "1.  List events...\n" +
                "2.  Add an event to the list.\n" +
                "3.  Remove an event from the list.\n" +
                "4.  Edit an event on the list.\n" +
                "5.  Show time till events.\n" +
                "6.  Quit the application.\n" +
                "7.  No Functionality.\n" +
                "8.  No Functionality.\n" +
                "9.  Repeat this prompt.\n" +
                "0.  Operator.\n"); Console.Write("timesup > "); string answer = Console.ReadLine();
            if (answer[0] == '0') { Console.WriteLine("Please wait while I connect you to an operator."); return false; }
            if (answer[0] == '1') { PromptOptionOne(); }
            if (answer[0] == '2') { PromptOptionTwo(); }
            if (answer[0] == '3') { PromptOptionThree(); }
            if (answer[0] == '4') { PromptOptionFour(); }
            if (answer[0] == '5') { PromptOptionFive(); }
            if (answer[0] == '6') { return false; }
            //if (answer[0] == '7') { PromptOptionSeven(); }
            //if (answer[0] == '8') { PromptOptionEight(); }
            if (answer[0] == '9') { TimesupPrompt(); }


            return true;
        }

        private void PromptOptionOne()
        {
            Console.Write("------------------------------------------------------");
            Console.WriteLine();
            Console.Write("id");
            Console.WriteLine();
            Console.Write("name");
            Console.WriteLine();
            Console.Write("description");
            Console.WriteLine();
            Console.Write("duetime");
            Console.WriteLine();
            Console.Write("------------------------------------------------------");
            Console.WriteLine();
            foreach (var e in UserEventList)
            {
                Console.Write(e.ID);
                Console.WriteLine();
                Console.Write(e.Name);
                Console.WriteLine();
                Console.Write(e.Description);
                Console.WriteLine();
                Console.Write(e.DueTime);
                Console.WriteLine();
                Console.Write("------------------------------------------------------");
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
            DateTime dueTime = GetDateTimeFromUser();
            int id = UserEventList.Count;
            UserEvent newEvent = new UserEvent(id, name, description, dueTime);
            UserEventList.Add(newEvent);
        }

        private DateTime GetDateTimeFromUser()
        {
            DateTime r = DateTime.Now;
            Console.WriteLine("Generation of time stamp complete.");
            return r;
        }

        private void PromptOptionThree()
        {
            Console.WriteLine("Enter ID of event to remove: ");
            string answer = Console.ReadLine();
            int id = 0;
            try
            {
                id = int.Parse(answer);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{answer}'.");
            }

            foreach (UserEvent e in UserEventList)
            {
                if (id == e.ID)
                {
                    UserEventList.Remove(e);
                    Console.WriteLine("Event removed.");
                }
            }
        }

        private void PromptOptionFour()
        {
            Console.WriteLine("Enter ID of event to edit:  ");
            string answer = Console.ReadLine();
            int id = 0;
            try
            {
                id = int.Parse(answer);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{answer}'.");
            }
            if (id != 0)
            {
                foreach (var a in UserEventList)
                {
                    if (a.ID == id)
                    {
                        Console.Write("Type a number (0 - 5) to run that option.\n" +
                            "1.  Edit name of event.\n" +
                            "2.  Edit description of event.\n" +
                            "3.  Edit due time of event.\n" +
                            "0.  Cancel (go back).\n"); string answer1 = Console.ReadLine();
                        if (answer[0] == '0')
                        {
                            Console.WriteLine("Returning to timesup prompt.");
                        }
                        if (answer[0] == '1')
                        {
                            Console.WriteLine("Old name: {0}", GetUserEventName(id));
                            Console.WriteLine("Not yet implemented.");
                        }
                        if (answer[0] == '2')
                        {
                            Console.WriteLine("Old description: {0}", GetUserEventDescription(id));
                            Console.WriteLine("Not yet implemented.");
                        }
                        if (answer[0] == '3')
                        {
                            Console.WriteLine("Old due time: {0}", GetUserEventDueTime(id));
                            Console.WriteLine("Not yet implemented.");
                        }
                    }
                }
            }

        }

        private DateTime GetUserEventDueTime(int id)
        {
            DateTime r = GetUserEventByID(id).DueTime;
            return r;
        }

        private string GetUserEventName(int id)
        {
            string r = GetUserEventByID(id).Name;
            return r;
        }

        private string GetUserEventDescription(int id)
        {
            string r = GetUserEventByID(id).Description;
            return r;
        }

        private UserEvent GetUserEventByID(int id)
        {
            foreach (UserEvent e in UserEventList)
            {
                if (id == e.ID)
                {
                    return e;
                }
            }

            UserEvent defaultUserEvent = new UserEvent(0, "Default name", "Default description", DateTime.MaxValue);
            return defaultUserEvent;
        }

        private void PromptOptionFive()
        {
            Console.WriteLine("implement this next");
        }

        static void Main(string[] args)
        {
            string usageText = "timesup development edition";
            Console.Write("Program: {0}\n", usageText);
            bool running = true;
            Program p = new Program();
            while (running)
            {
                Console.WriteLine("Press enter to continue.");
                Console.ReadLine();
                if (!p.TimesupPrompt()) running = false;
            }
            Console.WriteLine("Program over.  Press any key to exit.");
            Console.ReadLine();
        }
    }
}