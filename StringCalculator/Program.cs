namespace StringCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is string calculator. Input a string to extract numbers and calculate them. Type \"exit\" to leave");
            string? input = Console.ReadLine();
            while (!input.Equals("exit"))
            {
                int ans = Add(input);
                Console.WriteLine(ans);
                Console.WriteLine("Input a string to extract numbers and calculate them. Type \\\"exit\\\" to leave");
                input = Console.ReadLine();
            }            
        }

        public static int Add(string numbers)
        {
            List<int> fromStr = new();
            string keeper = "";
            if (string.IsNullOrEmpty(numbers))
                return 0;

            numbers += "a"; // lazy way to avoid IndexOutOfRangeException

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Char.IsNumber(numbers[i]) || (numbers[i].Equals('-') && Char.IsNumber(numbers[i+1])))
                {
                    keeper += numbers[i];
                }
                else if (!string.IsNullOrEmpty(keeper))
                {
                    fromStr.Add(Int32.Parse(keeper));
                    keeper = "";
                }
            }

            if (fromStr.Where(i => i < 0).Any())
            {
                throw new NegativesNotAllowedException("Negatives not allowed", fromStr);
            }

            fromStr.RemoveAll(x => x > 1000);

            return fromStr.Sum();
        }
    }
}