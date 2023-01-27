namespace Opgave_7.Class
{
    internal class YatzyBlok : Dices
    {
        public static Dictionary<string, int> YatzyBlokDictionary;

        public static List<int> Throws { get; set; }
        public static List<int> TempSavedThrows { get; set; }

        public static List<int> Player1yatzyBlok { get; set; }
        public static List<int> Player2yatzyBlok { get; set; }

        public YatzyBlok()
        {
            YatzyBlokDictionary = new();
            YatzyBlokDictionary.Clear();
            YatzyBlokDictionary.Add("1s", -1);
            YatzyBlokDictionary.Add("2s", -1);
            YatzyBlokDictionary.Add("3s", -1);
            YatzyBlokDictionary.Add("4s", -1);
            YatzyBlokDictionary.Add("5s", -1);
            YatzyBlokDictionary.Add("6s", -1);
            YatzyBlokDictionary.Add("Halfway sum", 0);
            YatzyBlokDictionary.Add("Bonus", 0);
            YatzyBlokDictionary.Add("1 Pair", -1);
            YatzyBlokDictionary.Add("2 Pair", -1);
            YatzyBlokDictionary.Add("3 of a kind", -1);
            YatzyBlokDictionary.Add("4 of a kind", -1);
            YatzyBlokDictionary.Add("Little straight", -1);
            YatzyBlokDictionary.Add("Big straight", -1);
            YatzyBlokDictionary.Add("House", -1);
            YatzyBlokDictionary.Add("Chance", -1);
            YatzyBlokDictionary.Add("YATZY", -1);
            YatzyBlokDictionary.Add("Full sum", 0);
        }

        public void startGameFirstThingTodo()
        {
            Player1yatzyBlok = YatzyBlokDictionary.Values.ToList();
            Player2yatzyBlok = YatzyBlokDictionary.Values.ToList();
        }

        public static List<int> GetList(int player)
        {
            if (player == 1)
            {
                return Player1yatzyBlok;
            }
            else if(player == 2)
            {
                return Player2yatzyBlok;
            }
            else
            {
                return new List<int>();
            }
        }

        public void ShowPossibleScoreOptions(YatzyBlok yatzy)
        {
            int count = 0;
            foreach (KeyValuePair<string, int> keyValue in YatzyBlokDictionary)
            {
                if (keyValue.Value == -1 || keyValue.Value == 0 || keyValue.Key == "Halfway sum" || keyValue.Key == "Full sum")
                {
                    string key = $"{count}, {keyValue.Key}";
                    Console.WriteLine(key);
                }
                count++;
            }
        }

        public void Crossout()
        {
            int count = 0;
            foreach (KeyValuePair<string, int> keyValue in YatzyBlokDictionary)
            {
                if (keyValue.Value == -1)
                {
                    string key = $"{count}, {keyValue.Key}";
                    Console.WriteLine(key);
                }
                count++;
            }
            Console.WriteLine("What do you want to crossout?:");
            string? input = Console.ReadLine();
            if (input == null || input == string.Empty)
            {
                Crossout();
            }
            input = input.Trim();
            var l = input.ToCharArray().ToList();
            var ls = input.ToCharArray().ToList();
            input = string.Empty;
            foreach (var item in ls)
            {
                if (!char.IsDigit(item))
                {
                    l.Remove(item);
                }
                else
                {
                    input += item.ToString();

                }
            }
            int selected = Convert.ToInt32(input);
            count = 0;
            foreach (KeyValuePair<string, int> keyValue in YatzyBlokDictionary)
            {
                if (count == selected)
                {
                    YatzyBlokDictionary[keyValue.Key] = 0;
                }
                count++;
            }
        }

        public int Pairs(List<int> saved, int howManyPairs)
        {
            int[] matchingNumber = { 0, 0 };
            int counter = 0;
            int amount = 0;
            saved.Sort();
            for (int i = 0; i < saved.Count - 1; i++)
            {
                if (saved[i] == saved[i + 1])
                {
                    amount++;
                    i++;
                    if (amount >= 1)
                    {
                        if (amount > 2)
                        {
                            throw new Exception("Out of range.");
                        }
                        matchingNumber[counter] = saved[i];
                        counter++;
                    }
                }
            }
            if (matchingNumber[1] != 0 && howManyPairs == 2)
            {
                amount = matchingNumber[0] * 2 + matchingNumber[1] * 2;
                YatzyBlokDictionary["2 Pair"] = amount;
            }
            else if (matchingNumber[1] == 0 && howManyPairs == 1)
            {
                amount = matchingNumber[0] * 2;
                YatzyBlokDictionary["1 Pair"] = amount;
            }
            return amount;
        }

        public int XOfAKind(List<int> saved, int howManySame)
        {
            int matchingNumber = 0;
            int amount = 1;
            if (saved == null)
            {
                return amount = -1;
            }
            saved.Sort();
            for (int i = 0; i < saved.Count-1; i++)
            {
                if (saved[i] == saved[i + 1])
                {
                    amount++;
                    if (amount >= 3)
                    {
                        matchingNumber = saved[i];
                    }
                    else if (amount > 4)
                    {
                        Console.WriteLine("You have to many dices with the same amount of pips. You can remove one if needed.");
                    }
                }
            }
            if (amount <= 2)
            {
                amount = -1;
            }
            if (amount == howManySame)
            {
                YatzyBlokDictionary[$"{amount} of a kind"] = amount * matchingNumber;
            }
            return amount * matchingNumber;
        }

        public int Ere(List<int> saved, int selectedNumber)
        {
            int amount = 0;
            //saved.Sort();
            //for (int i = 0; i < saved.Count; i++)
            //{
            //    if (saved[i] == selectedNumber)
            //    {
            //        amount++;
            //    }
            //}
            amount = saved.Count(x => x == selectedNumber);
            if (amount == 0)
            {
                return amount;
            }
            YatzyBlokDictionary[$"{selectedNumber}s"] = amount * selectedNumber;
            return amount * selectedNumber;
        }

        public int Hus(List<int> throws)
        {
            int amount = 0;

            if (throws.Count < 5)
            {
                Console.WriteLine("You dont have enough saved for that hus mate.");
                return amount;
            }

            throws.Sort();
            int first = throws.Count(x => x == throws[0]);
            int last = throws.Count(x => x == throws[4]);

            if (first + last == 10)
            {
                amount = 0;
            }
            else if (first <= 1 || last <= 1)
            {
                amount = 0;
            }
            else if (first + last == 5)
            {
                amount += first * throws[0];
                amount += last * throws[4];
                YatzyBlokDictionary["House"] = amount;
            }
            else
            {
                amount = 0;
            }

            return amount;
        }

        public int LilleStraight(List<int> throws)
        {
            int amount = 0;
            throws.Sort();
            if (throws.Count != 5)
            {
                Console.WriteLine("There aren't enough saved dices to make a little straight.");
                amount = -1;
                return amount;
            }
            if (throws[4] == 6)
            {
                Console.WriteLine("You can't make a little straight with a six in it.");
                amount = -1;
                return amount;
            }
            for (int i = 0; i < throws.Count - 1; i++)
            {
                if (throws[i] == throws[i + 1] - 1)
                {
                    amount++;
                }
            }
            if (amount == 4)
            {
                amount = 15;
                YatzyBlokDictionary["Little straight"] = amount;
                return amount;
            }
            amount = -1;
            return amount;
        }

        public int StorStraight(List<int> throws)
        {
            int amount = 0;
            throws.Sort();
            if (throws.Count != 5)
            {
                Console.WriteLine("There aren't enough saved dices to make a stor straight.");
                amount = -1;
                return amount;
            }
            if (throws[0] == 1)
            {
                Console.WriteLine("You can't make a stor straight with a one in it.");
                amount = -1;
                return amount;
            }
            for (int i = 0; i < throws.Count - 1; i++)
            {
                if (throws[i] == throws[i + 1] - 1)
                {
                    amount++;
                }
            }
            if (amount == 4)
            {
                amount = 20;
                YatzyBlokDictionary["Big straight"] = amount;
                return amount;
            }
            amount = -1;
            return amount;
        }

        public int Chance(List<int> throws)
        {
            if (YatzyBlokDictionary["Chance"] != -1)
            {
                return 0;
            }
            int amount = throws.Sum();
            YatzyBlokDictionary["Chance"] = amount;
            return amount;
        }

        public int Yatzy(List<int> throws)
        {
            int amount = 0;
            if (throws.Count != 5)
            {
                Console.WriteLine("You dont have enough dices for a YATZY!");
                amount = -1;
                return amount;
            }
            amount = throws.Count(x => x == throws[0]);
            if (amount != 5)
            {
                Console.WriteLine("You dont have the same side of the dice on all the dices for a YATZY!");
                amount = -1;
                return amount;
            }
            else
            {
                amount = amount * throws[0] + 50;
                YatzyBlokDictionary["YATZY"] = amount;
                return amount;
            }
        }

        public int Bonus()
        {
            int amount = -1;
            if (YatzyBlokDictionary["Bonus"] != 0)
            {
                amount = 0;
                return amount;
            }
            if (YatzyBlokDictionary["Halfway sum"] >= 63)
            {
                YatzyBlokDictionary["Bonus"] = 50;
                amount = 50;
            }
            return amount;
        }

        public int HalfwaySum()
        {
            int amount = 0;
            int counterof1 = 0;
            foreach (KeyValuePair<string, int> item in YatzyBlokDictionary)
            {
                if (item.Key == "Halfway sum")
                {
                    if (amount < 0)
                    {
                        return amount;
                    }
                    YatzyBlokDictionary[item.Key] = amount + counterof1;
                    break;
                }
                if(item.Value == -1)
                {
                    counterof1++;
                }
                amount += item.Value;
            }
            return amount;
        }

        public int FullSum()
        {
            bool afterHalfwaySum = false;
            int counterOf1 = 0;
            int amount = 0;
            foreach (KeyValuePair<string, int> item in YatzyBlokDictionary)
            {
                if (item.Key == "Halfway sum")
                {
                    afterHalfwaySum = true;
                }
                if (afterHalfwaySum)
                {
                    if (item.Key == "Full sum")
                    {
                        YatzyBlokDictionary[item.Key] = amount + counterOf1;
                        break;
                    }
                    if (item.Value == -1)
                    {
                        counterOf1++;
                    }
                    amount += item.Value;
                }
            }
            return amount;
        }

        public string MakeListOfThrows(List<int> throws, bool saved)
        {
            int counter = 0;
            string rolledDices = string.Empty;
            if (saved)
            {
                rolledDices = $"\tSaved \nDices, Pips\n";

            }
            else
            {
                rolledDices = $"\tRolled \nDices, Pips\n";
            }
                
            if(throws == null)
            {
                return "There any aren't dices in the list.";
            }

            foreach (int item in throws)
            {
                rolledDices += $"{counter}, \t{item}\n";
                counter++;
            }

            return rolledDices;
        }

        public int SaveDices()
        {
            Console.WriteLine(MakeListOfThrows(Throws, false));
            Console.WriteLine("Which dice do you want to put to the side?:");
            string? input = Console.ReadLine();
            if (input == null || input == string.Empty || input.ToCharArray().Any(x => char.IsLetter(x)))
            {
                return Throws.Count;
            }
            int index = Convert.ToInt32(input);
            if (index > Throws.Count)
            {
                Console.WriteLine("Fail you can not select this dice.");
                SaveDices();
            }
            if (TempSavedThrows == null)
            {
                TempSavedThrows = new List<int>();
                //return throws.Count;
            }
            TempSavedThrows.Add(Throws[index]);
            Throws.RemoveAt(index);
            Console.WriteLine("Do you want to save more dices? (y/n):");
            string? answar = Console.ReadLine();
            if (answar == null)
            {
                Console.WriteLine("Are you sure you dont want to save more dices? (y/n):");
                answar = Console.ReadLine();
                if (answar == null)
                {
                    return Throws.Count;
                }
            }
            if (answar.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                SaveDices();
            }
            else if (answar.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return Throws.Count;
            }
            else { return Throws.Count; }
            return Throws.Count;
        }

        public int SaveAllRolledDices(List<int> throws)
        {
            MakeListOfThrows(throws, false);
            if (throws.Count <= 0)
            {
                return Throws.Count;
            }
            Console.WriteLine("Do you want to save all your rolled dices? (y/n):");
            string? answar = Console.ReadLine();
            if (answar == null)
            {
                Console.WriteLine("Are you sure that want to save all your rolled dices? (y/n):");
                answar = Console.ReadLine();
                if (answar == null)
                {
                    return Throws.Count;
                }
            }
            if (answar.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                List<int> temp = new();
                temp = Throws.ToList();
                foreach (int item in temp)
                {
                    if (TempSavedThrows == null)
                    {
                        TempSavedThrows = new List<int>();
                    }
                    TempSavedThrows.Add(item);
                    Throws.Remove(item);
                }
            }
            else if (answar.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return Throws.Count;
            }
            else { return Throws.Count; }
            return Throws.Count;
        }

        public int RemoveRolledOne(List<int> throws)
        {
            if (throws.Count <= 0)
            {
                Console.WriteLine("You can't remove any dices, because you haven't saved any.");
                return Throws.Count;
            }
            Console.WriteLine(MakeListOfThrows(throws, true));
            Console.WriteLine("Which one do you want to remove?:");
            string? selectedAsString = Console.ReadLine();
            if (selectedAsString == null || selectedAsString == string.Empty)
            {
                return Throws.Count;
            }
            int selected = Convert.ToInt32(selectedAsString);
            if (selected > throws.Count)
            {
                Console.WriteLine("Fail you can't remove this dice.");
                RemoveRolledOne(throws);
            }
            Throws.Add(throws[selected]);
            throws.RemoveAt(selected);

            Console.WriteLine("Do you want to remove more dices? (y/n):");
            string? answar = Console.ReadLine();
            if (answar == null)
            {
                Console.WriteLine("Are you sure you dont want to remove more dices? (y/n):");
                answar = Console.ReadLine();
                if (answar == null)
                {
                    return Throws.Count;
                }
            }
            if (answar.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                RemoveRolledOne(throws);
            }
            else if (answar.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                return Throws.Count;
            }
            else { return Throws.Count; }

            return Throws.Count;
        }

        public int ClearSavedDices(bool newRound)
        {
            if (newRound)
            {
                if (TempSavedThrows == null)
                {
                    if(Throws == null)
                    {
                        return 5;
                    }
                    return Throws.Count;
                }
                List<int> temp = new();
                temp = TempSavedThrows.ToList();
                foreach (int item in temp)
                {
                    TempSavedThrows.Remove(item);
                    Throws.Add(item);
                }
            }
            else if (!newRound)
            {
                Console.WriteLine("Do you want to clear all your saved dices? (y/n):");
                string? answar = Console.ReadLine();
                if (answar == null)
                {
                    Console.WriteLine("Are you sure want to clear all your saved dices? (y/n):");
                    answar = Console.ReadLine();
                    if (answar == null)
                    {
                        return Throws.Count;
                    }
                }
                if (answar.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    List<int> temp = TempSavedThrows;
                    foreach (int item in temp)
                    {
                        TempSavedThrows.Remove(item);
                        Throws.Add(item);
                    }
                }
                else if (answar.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    return Throws.Count;
                }
                else { return Throws.Count; }

                return Throws.Count;
            }
            return Throws.Count;
        }

        public List<string> MakeListOfScoreBoardKeys()
        {
            return YatzyBlokDictionary.Keys.ToList();
        }

        public List<int> MakeListOfScoresFromScoreBoard()
        {
            return YatzyBlokDictionary.Values.ToList();
        }

        public static void StartTurn(List<int> PlayerYatzyBlok)
        {
            int count = 0;
            foreach (var KeyValue in YatzyBlokDictionary)
            {
                YatzyBlokDictionary[KeyValue.Key] = PlayerYatzyBlok[count];
                count++;
            }
        }

        public static void EndOfTurn(int playernumber)
        {
            if (playernumber == 1)
            {
                Player1yatzyBlok = YatzyBlokDictionary.Values.ToList();
            }
            else if (playernumber == 2)
            {
                Player2yatzyBlok = YatzyBlokDictionary.Values.ToList();

            }
        }

    }
}
