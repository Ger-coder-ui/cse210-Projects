using System;

class JournalApp
{
    static void Main()
    {
        JournalManager journalManager = new JournalManager();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Add Entry");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journalManager.AddEntry();
                    break;
                case "2":
                    journalManager.DisplayEntries();
                    break;
                case "3":
                    journalManager.SaveToFile();
                    break;
                case "4":
                    journalManager.LoadFromFile();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
