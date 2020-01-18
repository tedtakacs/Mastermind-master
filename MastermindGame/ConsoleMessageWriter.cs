using System;

namespace MastermindGame
{
    public class ConsoleMessageWriter
    {
        private const string BREAK = "*****************";
        private int codeLength;
        private int turns;
        private int startNum;
        private int endNum;
        private char rightChar;
        private char wrongChar;

        public ConsoleMessageWriter(int codeLength, int turns, int startNum, int endNum, char rightChar, char wrongChar)
        {
            this.codeLength = codeLength;
            this.turns = turns;
            this.startNum = startNum;
            this.endNum = endNum;
            this.rightChar = rightChar;
            this.wrongChar = wrongChar;
        }
        public void WriteStartMessageToConsole()
        {
            Console.WriteLine("***MASTERMIND***");
            Console.WriteLine($"I HAVE GENERATED A CODE OF {codeLength} NUMBERS, FROM {startNum}-{endNum}, EACH NUMBER ONLY USED ONCE. CAN YOU CRACK THE CODE IN {turns} TURNS?");
            Console.WriteLine("AFTER EACH TURN, I WILL SHOW YOU THE RESULTS OF YOUR GUESS.");
            Console.WriteLine($"{rightChar} : RIGHT NUMBER IN THE RIGHT SLOT");
            Console.WriteLine($"{wrongChar} : RIGHT NUMBER IN THE WRONG SLOT");
            Console.WriteLine("A BLANK SLOT MEANS THE NUMBER IS WRONG");
        }

        public void WriteTurnStartInstructionsToConsole(int turnNum)
        {
            Console.WriteLine(BREAK);
            Console.WriteLine($"TURN {turnNum}");
            if (turnNum == turns)
            {
                Console.WriteLine("!LAST TURN!");
            }
            Console.WriteLine("MAKE YOUR GUESS");

            Console.WriteLine($"TYPE A SEQUENCE OF {codeLength} NUMBERS, NO SPACES. EACH NUMBER CAN BE IN THE RANGE FROM {startNum}-{endNum}.");
            Console.WriteLine("HIT ENTER WHEN YOU ARE DONE.");
        }

        public void WriteResult(string result)
        {
            Console.WriteLine();
            Console.WriteLine("RESULT");
            for(int i = 0; i < codeLength; i++)
            {
                Console.Write("|");
            }
            Console.WriteLine();
            Console.WriteLine(result);
        }

        public void WriteLoseMessageToConsole()
        {
            Console.WriteLine(BREAK);
            Console.WriteLine("YOU HAVE RAN OUT OF TURNS. YOU LOSE.");
        }

        public void WriteWinMessageToConsole()
        {
            Console.WriteLine(BREAK);
            Console.WriteLine("YOU HAVE CRACKED THE CODE. YOU WIN!");
        }

        public void WriteNotValidCode()
        {
            Console.WriteLine("THAT CODE IS NOT VALID. ENTER A VALID CODE.");
        }

        public void WriteEndLine()
        {
            Console.WriteLine("PRESS ENTER TO QUIT");
        }
    }
}
