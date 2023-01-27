namespace Opgave_7.Class
{
    internal class Yatzy : YatzyBlok
    {
        Players player1 = new();
        Players player2 = new();
        YatzyBlok player1YatzyBlok = new();
        YatzyBlok player2YatzyBlok = new();
        bool crossedout = false;
        int RolledCounter = 0;
        bool gameOver = false;
        static int amountOfDices = 5;
        public Yatzy() { }

        private void intro()
        {
            string? name = string.Empty;
            Console.WriteLine("Welcome to Yatzy");
            Thread.Sleep(1000);
            Console.WriteLine("Write player 1 name:");
            name = Console.ReadLine();
            if (name.Length <= 1 || name == null)
            {
                Console.WriteLine("Please enter a name for player 1:");
            }
            player1.Name = name;
            Console.WriteLine("Write player 2 name:");
            name = Console.ReadLine();
            if (name.Length <= 1 || name == null)
            {
                Console.WriteLine("Please enter a name for player 2:");
            }
            player2.Name = name;
        }

        public void SelectWhatToDo(Players player, int playerNumber)
        {
            bool endOfTurn = false;
            bool Sum = false;
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            while (!Console.KeyAvailable)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.H:
                        Console.WriteLine("\nRule 1: Each player can roll the dices 3 times, after the 3rd throw you need to put your points somewhere or crossout a spot.");
                        Console.WriteLine("Rule 2: Player can end their turn early if they want, so they can put their points in a spot that is avalible.");
                        Console.WriteLine("Rule 3: 1-6's is only to the correlated numbers that match. Meaning 6 pips can only be put in 6's.");
                        Console.WriteLine("Rule 4: If a player get 63 or more points in 1-6's they get 50 bonus points. Both player's can get bonus points.");
                        Console.WriteLine("Rule 5: Little straight consists of 1, 2, 3, 4 & 5 pips and big straight consists 2, 3, 4, 5 & 6 pips.");
                        Console.WriteLine("Rule 6: For a house you need 3 of the same pips, and 2 of the same pips.");
                        Console.WriteLine("Rule 7: Chance is spot that can be filled with the sum of all your pips.");
                        Console.WriteLine("Rule 8: For a Yatzy you need 5 dices that all show the same pips. If you get a Yatzy there will be added 50 points to your score.\n");
                        Menu(player);
                        break;
                    case ConsoleKey.B:
                        Console.WriteLine(ScoreBoard(player1, player1YatzyBlok, player2, player2YatzyBlok));
                        Thread.Sleep(2000);
                        Console.WriteLine(MakeListOfThrows(Throws, false));
                        Menu(player);
                        break;
                    case ConsoleKey.R:
                        if (RolledCounter == 3)
                        {
                            break;
                        }
                        if (amountOfDices > 5)
                        {
                            amountOfDices = 5;
                        }
                        Throws = RollTheDices(amountOfDices);
                        RolledCounter++;
                        Console.WriteLine(MakeListOfThrows(Throws, false));
                        Menu(player);
                        break;
                    case ConsoleKey.S:
                        if (Throws.Count <= 0)
                        {
                            Console.WriteLine("You dont have any dices to save.");
                            break;
                        }
                        amountOfDices = SaveDices();
                        Console.WriteLine(MakeListOfThrows(TempSavedThrows, true));
                        Menu(player);
                        break;

                    case ConsoleKey.T:
                        if (TempSavedThrows == null)
                        {
                            Console.WriteLine("You haven't saved any dices.");
                            break;
                        }
                        if (TempSavedThrows.Count <= 0)
                        {
                            Console.WriteLine("You haven't saved any dices.");
                            break;
                        }
                        amountOfDices = RemoveRolledOne(TempSavedThrows);
                        Console.WriteLine(MakeListOfThrows(TempSavedThrows, true));
                        Menu(player);
                        break;

                    case ConsoleKey.C:
                        if (crossedout)
                        {
                            break;
                        }
                        Crossout();
                        crossedout = true;
                        Menu(player);
                        break;

                    case ConsoleKey.V:
                        if (TempSavedThrows.Count <= 0)
                        {
                            Console.WriteLine("You haven't saved any dices");
                            break;
                        }
                        amountOfDices = ClearSavedDices(false);
                        Menu(player);
                        break;

                    case ConsoleKey.E:
                        if (Throws.Count <= 0)
                        {
                            Console.WriteLine("There aren't any dices to save.");
                            break;
                        }
                        amountOfDices = SaveAllRolledDices(Throws);
                        Menu(player);
                        break;

                    case ConsoleKey.Spacebar:
                        bool playended = true;
                        if (crossedout)
                        {
                            crossedout = false;
                            endOfTurn = true;
                            ClearSavedDices(true);
                            RolledCounter = 0;
                            amountOfDices = 5;
                            break;
                        }
                        if (player == player1)
                        {
                            ShowPossibleScoreOptions(player1YatzyBlok);
                            Console.WriteLine("Where do you want to put it?:");
                            string? input = Console.ReadLine();
                            if (input == null || input == string.Empty)
                            {
                                break;
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
                            int index = Convert.ToInt32(input);

                            switch (index)
                            {
                                case 0:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 1) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;
                                        break;
                                    }
                                case 1:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 2) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 2:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 3) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 3:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 4) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 4:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 5) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 5:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 6) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 6:
                                    {
                                        if (player1YatzyBlok.HalfwaySum() < 0)
                                        {
                                            Console.WriteLine("You have no points from ere.");
                                            break;
                                        }
                                        Sum = true;

                                        break;
                                    }
                                case 7:
                                    {
                                        if (player1YatzyBlok.Bonus() == 0)
                                        {
                                            Console.WriteLine("Bonus is already used.");
                                            break;
                                        }
                                        else if (player1YatzyBlok.Bonus() == -1)
                                        {
                                            Console.WriteLine("You don't have enough points to get the bonus.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 8:
                                    {
                                        if (player1YatzyBlok.Pairs(TempSavedThrows, 1) == 0)
                                        {
                                            Console.WriteLine("You don't have a pair of points.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 9:
                                    {
                                        if (player1YatzyBlok.Pairs(TempSavedThrows, 2) == 0)
                                        {
                                            Console.WriteLine("You don't have two pairs of points.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 10:
                                    {
                                        if (player1YatzyBlok.XOfAKind(TempSavedThrows, 3) == 0)
                                        {
                                            Console.WriteLine("You don't have 3 of the same kind.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 11:
                                    {
                                        if (player1YatzyBlok.XOfAKind(TempSavedThrows, 4) == 0)
                                        {
                                            Console.WriteLine("You don't have 4 of the same kind.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 12:
                                    {
                                        if (player1YatzyBlok.LilleStraight(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You don't have the right pips for a little straight.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 13:
                                    {
                                        if (player1YatzyBlok.StorStraight(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You don't have the right pips for a big straight.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 14:
                                    {
                                        if (player1YatzyBlok.Hus(TempSavedThrows) == -1)
                                        {
                                            Console.WriteLine("You don't have enough dices for a house.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 15:
                                    {
                                        if (player1YatzyBlok.Chance(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You have already used your chance.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 16:
                                    {
                                        if (player1YatzyBlok.Yatzy(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You have already used Yatzy.");
                                            break;
                                        }
                                        else if (player1YatzyBlok.Yatzy(TempSavedThrows) == -1)
                                        {
                                            Console.WriteLine("You don't have enough for Yatzy.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 17:
                                    {
                                        if (player1YatzyBlok.FullSum() == 0)
                                        {
                                            Console.WriteLine("You dont have any points.");
                                            break;
                                        }
                                        Sum = true;
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Invaild input.");
                                        break;
                                    }
                            }

                        }
                        else if (player == player2)
                        {
                            ShowPossibleScoreOptions(player1YatzyBlok);
                            Console.WriteLine("Where do you want to put it?:");
                            string? input = Console.ReadLine();
                            if (input == null || input == string.Empty)
                            {
                                break;
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
                            int index = Convert.ToInt32(input);

                            switch (index)
                            {
                                case 0:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 1) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;
                                        break;
                                    }
                                case 1:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 2) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 2:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 3) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 3:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 4) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 4:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 5) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 5:
                                    {
                                        if (player1YatzyBlok.Ere(TempSavedThrows, 6) == 0)
                                        {
                                            Console.WriteLine("You can't do that with the once you have saved.");
                                            break;
                                        }

                                        playended = false;

                                        break;
                                    }
                                case 6:
                                    {
                                        if (player1YatzyBlok.HalfwaySum() < 0)
                                        {
                                            Console.WriteLine("You have no points from ere.");
                                            break;
                                        }
                                        Sum = true;

                                        break;
                                    }
                                case 7:
                                    {
                                        if (player1YatzyBlok.Bonus() == 0)
                                        {
                                            Console.WriteLine("Bonus is already used.");
                                            break;
                                        }
                                        else if (player1YatzyBlok.Bonus() == -1)
                                        {
                                            Console.WriteLine("You don't have enough points to get the bonus.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 8:
                                    {
                                        if (player1YatzyBlok.Pairs(TempSavedThrows, 1) == 0)
                                        {
                                            Console.WriteLine("You don't have a pair of points.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 9:
                                    {
                                        if (player1YatzyBlok.Pairs(TempSavedThrows, 2) == 0)
                                        {
                                            Console.WriteLine("You don't have two pairs of points.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 10:
                                    {
                                        if (player1YatzyBlok.XOfAKind(TempSavedThrows, 3) == 0)
                                        {
                                            Console.WriteLine("You don't have 3 of the same kind.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 11:
                                    {
                                        if (player1YatzyBlok.XOfAKind(TempSavedThrows, 4) == 0)
                                        {
                                            Console.WriteLine("You don't have 4 of the same kind.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 12:
                                    {
                                        if (player1YatzyBlok.LilleStraight(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You don't have the right pips for a little straight.");
                                            break;
                                        }
                                        playended = false;

                                        break;
                                    }
                                case 13:
                                    {
                                        if (player1YatzyBlok.StorStraight(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You don't have the right pips for a big straight.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 14:
                                    {
                                        if (player1YatzyBlok.Hus(TempSavedThrows) == -1)
                                        {
                                            Console.WriteLine("You don't have enough dices for a house.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 15:
                                    {
                                        if (player1YatzyBlok.Chance(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You have already used your chance.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 16:
                                    {
                                        if (player1YatzyBlok.Yatzy(TempSavedThrows) == 0)
                                        {
                                            Console.WriteLine("You have already used Yatzy.");
                                            break;
                                        }
                                        else if (player1YatzyBlok.Yatzy(TempSavedThrows) == -1)
                                        {
                                            Console.WriteLine("You don't have enough for Yatzy.");
                                            break;
                                        }
                                        playended = false;
                                        break;
                                    }
                                case 17:
                                    {
                                        if (player1YatzyBlok.FullSum() == 0)
                                        {
                                            Console.WriteLine("You dont have any points.");
                                            break;
                                        }
                                        Sum = true;
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Invaild input.");
                                        break;
                                    }
                            }
                        }
                        if (!Sum)
                        {
                            endOfTurn = true;
                            ClearSavedDices(true);
                            RolledCounter = 0;
                            amountOfDices = 5;
                            break;
                        }
                        else
                        {
                            Menu(player);
                            EndOfTurn(playerNumber);
                            break;
                        }
                    case ConsoleKey.P:

                        break;

                    default:
                        Console.WriteLine("Not a key that can be used.");
                        break;
                }
                if (endOfTurn)
                {
                    break;
                }
            }
        }
        private void Menu(Players player)
        {
            Console.WriteLine($"{player.Name} starts \nPress \"H\" to show the rules of our Yatzy \npress \"B\" to show scoreboard \npress \"R\" to Roll the dices \npress \"S\" Save a dice/dices \npress \"E\" to save all dices \npress \"T\" Remove a saved dice/dices \npress \"C\" Crossout score options \npress \"V\" Clear all saved dices \npress \"Spacebar\" To end your turn, and places your saved points.");
        }

        private void PlayersTurn(Players player, YatzyBlok PlayeryatzyBlok, int playersNumber)
        {
            StartTurn(GetList(playersNumber));
            Menu(player);
            SelectWhatToDo(player, playersNumber);
            EndOfTurn(playersNumber);
            Console.WriteLine(ScoreBoard(player1, player1YatzyBlok, player2, player2YatzyBlok));
        }

        public string ScoreBoard(Players player1, YatzyBlok player1YatzyBlok, Players player2, YatzyBlok player2YatzyBlok)
        {
            string scoreBoard = $"{"Pointinfo",16}\t{player1.Name,8}\t{player2.Name,8}\n";
            List<string> listOfKeys = player1YatzyBlok.MakeListOfScoreBoardKeys();
            List<int> listOfValuesPlayer1 = GetList(1);
            List<int> listOfValuesPlayer2 = GetList(2);
            for (int i = 0; i < listOfKeys.Count; i++)
            {
                scoreBoard += $"{listOfKeys[i],16}\t{listOfValuesPlayer1[i],8}\t{listOfValuesPlayer2[i],8}\n";
            }
            return scoreBoard;
        }

        public void StartGame()
        {
            intro();
            startGameFirstThingTodo();
            while (!gameOver)
            {
                int countRoundLeft = 0;
                PlayersTurn(player1, player1YatzyBlok, 1);
                PlayersTurn(player2, player2YatzyBlok, 2);
                foreach (var place in YatzyBlokDictionary)
                {
                    if (place.Value == -1)
                    {
                        countRoundLeft++;
                        Thread.Sleep(10);
                    }
                }
                if (countRoundLeft == 0)
                {
                    gameOver = true;
                }
            }
            EndGame();
        }

        public void EndGame()
        {
            int lastIndexOf1 = Player1yatzyBlok.Count - 1;
            int lastIndexOf2 = Player2yatzyBlok.Count - 1;

            if (Player1yatzyBlok[lastIndexOf1] > Player2yatzyBlok[lastIndexOf2])
            {
                Console.WriteLine($"{player1.Name} Won this game.\nThanks for playing.");
            }
            else if (Player1yatzyBlok[lastIndexOf1] < Player2yatzyBlok[lastIndexOf2])
            {
                Console.WriteLine($"{player2.Name} Won this game. \nThanks for playing.");
            }
            else if (Player1yatzyBlok[lastIndexOf1] == Player2yatzyBlok[lastIndexOf2])
            {
                Console.WriteLine("It a draw. \nThanks for playing.");
            }
        }
    }
}
