using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MastermindGame
{
    class Program
    {
        private const int CODE_LENGTH = 4;
        private const int START_NUM = 1;
        private const int END_NUM = 6;
        private const int TURNS = 10;
        private const char RIGHT_CHAR = '+';
        private const char WRONG_CHAR = '-';
        private const char EMPTY = ' ';

        static void Main(string[] args)
        {
            ConsoleMessageWriter consoleMessageWriter = new ConsoleMessageWriter(CODE_LENGTH, TURNS, START_NUM, END_NUM, RIGHT_CHAR, WRONG_CHAR);
            List<int> realCode = MakeStartList();
            consoleMessageWriter.WriteStartMessageToConsole();
            bool hasWon = false;
            int turn = 1;
            while (!hasWon && turn <= TURNS)
            {
                hasWon = TakeTurn(consoleMessageWriter, realCode, turn);
                turn++;
            }
            if (hasWon)
            {
                consoleMessageWriter.WriteWinMessageToConsole();
            }
            else
            {
                consoleMessageWriter.WriteLoseMessageToConsole();
            }
            consoleMessageWriter.WriteEndLine();
            Console.ReadLine();
        }

        private static bool TakeTurn(ConsoleMessageWriter consoleMessageWriter, List<int> realCode, int turn)
        {
            consoleMessageWriter.WriteTurnStartInstructionsToConsole(turn);
            List<int> guessCode = PromptUntilValidGuess(consoleMessageWriter);
            consoleMessageWriter.WriteResult(GetCompareString(realCode, guessCode));

            return guessCode.SequenceEqual(realCode);
        }

        private static List<int> PromptUntilValidGuess(ConsoleMessageWriter consoleMessageWriter)
        {
            List<int> inputNums = new List<int>();
            bool foundValidInput = false;
            while (!foundValidInput)
            {
                inputNums.Clear();
                string userInput = Console.ReadLine();
                foreach (char digit in userInput)
                {
                    if (char.IsDigit(digit))
                    {
                        int theNum = int.Parse(digit.ToString());
                        if (theNum >= START_NUM && theNum <= END_NUM)
                        {
                            inputNums.Add(theNum);
                        }
                    }
                }
                foundValidInput = inputNums.Count == CODE_LENGTH;
                if (!foundValidInput)
                {
                    consoleMessageWriter.WriteNotValidCode();
                }
            }
            return inputNums;
        }

        private static List<int> MakeStartList()
        {
            List<int> allNums = new List<int>();
            for (int i = START_NUM; i <= END_NUM; i++)
            {
                allNums.Add(i);
            }
            Random random = new Random();
            var shuffledList = allNums.OrderBy(x => random.Next());
            return shuffledList.Take(CODE_LENGTH).ToList();
        }

        private static string GetCompareString(List<int> realCode, List<int> guessCode)
        {
            StringBuilder compareString = new StringBuilder();
            for (int i = 0; i < realCode.Count; i++)
            {
                if (realCode[i] == guessCode[i])
                {
                    compareString.Append(RIGHT_CHAR);
                }
                else if (realCode.Contains(guessCode[i]))
                {
                    compareString.Append(WRONG_CHAR);
                }
                else
                {
                    compareString.Append(EMPTY);
                }
            }
            return compareString.ToString();
        }
    }
}
