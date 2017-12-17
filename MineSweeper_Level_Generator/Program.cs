using System;

namespace MineSweeper_Level_Generator
{
	class Minefield
	{

		public enum Cell {
			EMPTY,
			M1,
			M2,
			M3,
			M4, 
			M5,
			M6,
			M7,
			M8, 
			M9,
			MINE
		};


		public static int gridWidth, gridHeight, mineCount;
		public static Cell[,] gridCells;

		public static void Main (string[] args)
		{
			GetInput ();

			gridCells = GenerateMineField (gridWidth, gridHeight, mineCount);

			PrintField (gridCells);
		}

		static void GetInput() {
			string input = "";

			Console.WriteLine ("Enter width:");
			input = Console.ReadLine ();
			while (!Int32.TryParse (input, out gridWidth)) {
				Console.WriteLine ("This is not a valid number. Please enter a valid width:");
				input = Console.ReadLine ();
			}

			Console.WriteLine ("Enter height:");
			input = Console.ReadLine ();
			while (!Int32.TryParse (input, out gridHeight)) {
				Console.WriteLine ("This is not a valid number. Please enter a valid height:");
				input = Console.ReadLine ();
			}

			Console.WriteLine ("Enter mine count:");
			input = Console.ReadLine ();
			while (!Int32.TryParse (input, out mineCount)) {
				Console.WriteLine ("This is not a valid number. Please enter a valid mine count:");
				input = Console.ReadLine ();
			}
		}

		static Cell[,] GenerateMineField(int width, int height, int count) {
			Cell[,] cells = new Cell[width, height];

			for (int x = 0; x < width; x++) {
				for (int y = 0; y < height; y++) {
					cells [x, y] = Cell.EMPTY;
				}
			}

			Random rnd = new Random ();

			for (int i = 0; i < count; i++) {
				int x = rnd.Next (0, width);
				int y = rnd.Next (0, height);
				if (cells [x, y] < Cell.MINE) {
					cells [x, y] = Cell.MINE;

					if (y - 1 >= 0) {
						if (cells [x, y - 1] != Cell.MINE) {
							cells [x, y - 1]++;
						}
					}

					if (y + 1 < cells.GetLength(1)) {
						if (cells [x, y + 1] != Cell.MINE) {
							cells [x, y + 1]++;
						}
					}

					if (x - 1 >= 0) {
						if (cells [x - 1, y] != Cell.MINE) {
							cells [x - 1, y]++;
						}

						if (y - 1 >= 0) {
							if (cells [x - 1, y - 1] != Cell.MINE) {
								cells [x - 1, y - 1]++;
							}
						}

						if (y + 1 < cells.GetLength(1)) {
							if (cells [x - 1, y + 1] != Cell.MINE) {
								cells [x - 1, y + 1]++;
							}
						}
					}

					if (x + 1 < cells.GetLength(0)) {
						if (cells [x + 1, y] != Cell.MINE) {
							cells [x + 1, y]++;
						}

						if (y - 1 >= 0) {
							if (cells [x + 1, y - 1] != Cell.MINE) {
								cells [x + 1, y - 1]++;
							}
						}

						if (y + 1 < cells.GetLength(1)) {
							if (cells [x + 1, y + 1] != Cell.MINE) {
								cells [x + 1, y + 1]++;
							}
						}
					}
				} else {
					i--;
				}
			}

			return cells;
		}

		static void PrintField(Cell[,] field) {
			for (int y = 0; y < field.GetLength(1); y++) {
				for (int x = 0; x < field.GetLength(0); x++) {
					if (field [x, y] == Cell.EMPTY) {
						Console.Write (".");
					} else if (field [x, y] == Cell.MINE) {
						Console.Write ("M");
					} else {
						Console.Write (Convert.ToInt32(field [x, y]).ToString());
					}
				}
				Console.WriteLine ("");
			}
		}
	}
}
