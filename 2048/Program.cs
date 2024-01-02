using System;

namespace matriz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] board = new int[4, 4];
            int still = 1;
            string move = "";
           

            while (true)
            {
                if (still == 1)
                {
                    creator(board);
                    still = 0;
                }
                else
                {
                    int continuous = 0;
                    int jtemp = 0;
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            
                            if (j != 0) {
                                if (board[i, j] == board[i, jtemp])
                                {
                                    continuous = 1;
                                    break;
                                }

                            }
                            else{
                                if(board[i, j] == board[i, j + 1])
                                {
                                    continuous = 1;
                                    break;
                                }
                            }
                            jtemp = j;

                        }
                    }
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {

                            if (j != 0)
                            {
                                if (board[j,i] == board[jtemp,i])
                                {
                                    continuous = 1;
                                    break;
                                }

                            }
                            else
                            {
                                if (board[j,i] == board[j+1,i])
                                {
                                    continuous = 1;
                                    break;
                                }
                            }
                            jtemp = j;

                        }
                    }
                    if (continuous == 0)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You lose!");
                    }

                }

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if ((board[i, j] == 0))
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("| " + board[i, j] + " |");

                        }
                        else if (board[i, j] == 2 || board[i, j] == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("| " + board[i, j] + " |");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (board[i, j] == 8)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            Console.Write("|" + board[i, j] + " |");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (board[i, j] == 16 || board[i, j] == 32 || board[i, j] == 64)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("|" + board[i, j] + " |");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (board[i, j] == 128 || board[i, j] == 256 || board[i, j] == 512)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|" + board[i, j] + "|");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (board[i, j] == 1024)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("|" + board[i, j] + "|");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("|" + board[i, j] + "|");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    Console.Write("\n--------------------\n");
                }
                Console.WriteLine("\nw - move to up | s - move to down | d - move to right | a - move to left");
                move = Console.ReadLine();
                switch (move)
                {
                    case "w":
                        motion(board, move, out still);
                        break;
                    case "d":
                        motion(board, move, out still);
                        break;
                    case "s":
                        motion(board, move, out still);
                        break;
                    case "a":
                        motion(board, move, out still);
                        break;
                    default:
                        break;

                }
                Console.Clear();

            }
        }

        static void creator(int[,] board)
        {
            Random random = new Random();
            int vic = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 2048)
                    {
                        vic = 1;
                    }

                }
            }
            if (vic == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You win!");
            }

            int positionY;
            int positionX;
            while (true)
            {
                positionY = random.Next(0, 4);
                positionX = random.Next(0, 4);
                if (board[positionX, positionY] == 0)
                {
                    break;
                }
                else
                { }
            }
            int probabi = random.Next(0, 11);
            if (probabi < 10)
            {
                board[positionX, positionY] = 2;
            }
            else
            {
                board[positionX, positionY] = 4;
            }
        }






        static void motion(int[,] board, string move, out int still)
        {
            still = 0;
            switch (move)
            {
                case "w":
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            if (j != 0)
                            {
                                if (board[j, i] != 0)
                                {

                                    int local = -1;
                                    int localver = -1;
                                    int valider = -1;
                                    for (int l = j; l != -1; l--)
                                    {
                                        if (l != j)
                                        {
                                            if (board[l, i] != 0)
                                            {
                                                if (valider == -1)
                                                {
                                                    if (board[j, i] == board[l, i])
                                                    {
                                                        localver = l;
                                                        still = 1;
                                                    }
                                                    else
                                                    {
                                                        valider = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (localver != -1)
                                                { }
                                                else
                                                {
                                                    local = l;

                                                    still = 1;
                                                }

                                            }
                                        }


                                    }
                                    if (localver != -1)
                                    {
                                        board[localver, i] = (board[j, i] * 2);
                                        board[j, i] = 0;
                                    }
                                    else if (local != -1)
                                    {
                                        board[local, i] = board[j, i];
                                        board[j, i] = 0;
                                    }


                                }
                            }

                        }
                    }

                    break;
                case "d":
                    for (int i = board.GetLength(0) - 1; i > -1; i--)
                    {
                        for (int j = board.GetLength(1); j > -1; j--)
                        {
                            if (j != board.GetLength(1))
                            {

                                if (board[i, j] != 0)
                                {

                                    int local = -1;
                                    int localver = -1;
                                    int valider = -1;
                                    for (int l = j; l != 4; l++)
                                    {
                                        if (l != j)
                                        {
                                            if (board[i, l] != 0)
                                            {
                                                if (valider == -1)
                                                {
                                                    if (board[i, j] == board[i, l])
                                                    {
                                                        localver = l;
                                                        still = 1;
                                                    }
                                                    else
                                                    {
                                                        valider = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (localver != -1)
                                                { }
                                                else
                                                {
                                                    local = l;

                                                    still = 1;
                                                }

                                            }
                                        }


                                    }
                                    if (localver != -1)
                                    {
                                        board[i, localver] = (board[i, j] * 2);
                                        board[i, j] = 0;
                                    }
                                    else if (local != -1)
                                    {
                                        board[i, local] = board[i, j];
                                        board[i, j] = 0;
                                    }


                                }
                            }

                        }
                    }

                    break;
                case "s":
                    for (int i = board.GetLength(0) - 1; i > -1; i--)
                    {
                        for (int j = board.GetLength(1); j > -1; j--)
                        {
                            if (j != board.GetLength(1))
                            {

                                if (board[j, i] != 0)
                                {

                                    int local = -1;
                                    int localver = -1;
                                    int valider = -1;
                                    for (int l = j; l != board.GetLength(1); l++)
                                    {
                                        if (l != j)
                                        {
                                            if (board[l, i] != 0)
                                            {
                                                if (valider == -1)
                                                {
                                                    if (board[j, i] == board[l, i])
                                                    {
                                                        localver = l;
                                                        still = 1;
                                                    }
                                                    else
                                                    {
                                                        valider = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (localver != -1)
                                                { }
                                                else
                                                {
                                                    local = l;

                                                    still = 1;
                                                }

                                            }
                                        }


                                    }
                                    if (localver != -1)
                                    {
                                        board[localver, i] = (board[j, i] * 2);
                                        board[j, i] = 0;
                                    }
                                    else if (local != -1)
                                    {
                                        board[local, i] = board[j, i];
                                        board[j, i] = 0;
                                    }


                                }
                            }

                        }
                    }


                    break;
                case "a":
                    for (int i = 0; i < board.GetLength(0); i++)
                    {
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            if (j != 0)
                            {
                                if (board[i, j] != 0)
                                {

                                    int local = -1;
                                    int localver = -1;
                                    int valider = -1;
                                    for (int l = j; l != -1; l--)
                                    {
                                        if (l != j)
                                        {
                                            if (board[i, l] != 0)
                                            {
                                                if (valider == -1)
                                                {
                                                    if (board[i, j] == board[i, l])
                                                    {
                                                        localver = l;
                                                        still = 1;
                                                    }
                                                    else
                                                    {
                                                        valider = 0;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (localver != -1)
                                                { }
                                                else
                                                {
                                                    local = l;

                                                    still = 1;
                                                }

                                            }
                                        }


                                    }
                                    if (localver != -1)
                                    {
                                        board[i, localver] = (board[i, j] * 2);
                                        board[i, j] = 0;
                                    }
                                    else if (local != -1)
                                    {
                                        board[i, local] = board[i, j];
                                        board[i, j] = 0;
                                    }


                                }
                            }

                        }
                    }
                    break;
                default:
                    break;
            }
        }



    }
}
