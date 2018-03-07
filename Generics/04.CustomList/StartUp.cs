using System;

public class StartUp
{
    public static void Main()
    {
        var customList = new CustomList<string>();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            var cmdArgs = input.Split();
            string command = cmdArgs[0];
            string result = String.Empty;

            switch (command)
            {
                case "Add":
                    customList.Add(cmdArgs[1]);
                    break;
                case "Remove":
                    customList.Remove(int.Parse(cmdArgs[1]));
                    break;
                case "Contains":
                    result = customList.Contains(cmdArgs[1]).ToString();
                    break;
                case "Swap":
                    customList.Swap(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                    break;
                case "Greater":
                    result = customList.CountGreaterThan(cmdArgs[1]).ToString();
                    break;
                case "Max":
                    result = customList.Max();
                    break;
                case "Min":
                    result = customList.Min();
                    break;
                case "Print":
                    foreach (var element in customList)
                    {
                        result += element + Environment.NewLine;
                    }
                    break;
                case "Sort":
                    customList.Sort();
                    break;
            }

            if (!string.IsNullOrWhiteSpace(result))
            {
                Console.WriteLine(result.Trim());
            }
        }
    }
}
