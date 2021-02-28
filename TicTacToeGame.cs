//Copyright (c) 2021 Muhammad ibn Abdullah
//Date: 27-Feb-2021

using System;

namespace TicTacToeGame
{
	class Program
	{
		static void Main(string[] args)
		{
			char[] board = new char[9];
			int MoveCount = 0;
			Setup(board);
			bool HasGameEnded = false;
			while (!(HasGameEnded)) {
				Console.Clear();
				Draw(board);
				Game(ref MoveCount, ref board);
				if (MoveCount >= 5)
					HasGameEnded = Check(board);
			}
			EndGame(MoveCount, board);
		}
		static void Setup(char[] b)
		{//Put initial place values for board array.
			for (int i = 0; i < 9; i++) {
				string temp = Convert.ToString(i);	//First convert to a string.
				b[i] = Convert.ToChar(temp);		//Convert from string to char.
			}
		}
		static bool Check(char[] b)
		{//Check if either player has won by rows, columns, or diagonals.
			for (int i = 0; i <= 6; i+=3)
				if (b[i] == b[i+1] && b[i+1] == b[i+2])		//Check Rows
					return true;
			for (int i = 0; i <= 2; i++)
				if (b[i] == b[i+3] && b[i+3] == b[i+6])		//Check Columns
					return true;
			if ((b[0] == b[4] && b[4] == b[8]) || (b[2] == b[4] && b[4] == b[6]))	//Check Diagonals
				return true;
			return false;
		}
		static void Draw(char[] b)
		{//Draw the board with player moves and open slots.
			for (int i = 0; i <= 6; i+=3) {
				Console.Write("   " + b[i] + "  |");
				Console.Write("   " + b[i+1] + "  |");
				Console.Write("   " + b[i+2] + "   |\n");
				Console.WriteLine("-----------------------");
			}
		}
		static void Game(ref int move, ref char[] b)
		{//User inputs which location to place move, and update array.
			bool RepeatMove = false;
			Console.Write("Location To Place Your Move: ");
			int index = Convert.ToInt32(Console.ReadLine());
			if (move % 2 == 0) 
				if (b[index] != 'O' && b[index] != 'X')
					b[index] = 'X';
				else 
					RepeatMove = true;
			else
				if (b[index] != 'O' && b[index] != 'X')
					b[index] = 'O';
				else 
					RepeatMove = true;
			if (!RepeatMove)
				move++;
			
		}
		static void EndGame(int move, char[] b)
		{//Display final board and which player has won.
			Console.Clear();
			Draw(b);
			if (move % 2 == 0)		//The player to move cannot move because he has lost.
				Console.WriteLine("Player O has won.");
			else 
				Console.WriteLine("Player X has won.");
		}
	}
}