//1D Arrays

int[] luckyNumbers = { 2, 5, 6, 7, 8, 4 }; // initialisation and assignment

luckyNumbers[4] = 1; //Updation

Console.WriteLine(luckyNumbers[4]);

string[] friends = new string[3]; //initialisation
friends[0] = "ABC"; //assignment
friends[1] = "DEF";
friends[2] = "XYZ";

for (int i = 0; i < friends.GetLength(0); i++)
{
  Console.WriteLine(friends[i]);
}


//2D Arrays

int[,] myArray = new int[2, 3];

int[,] numberGrid = {
  {1, 2},
  {3, 4},
  {5, 6}
};

Console.WriteLine(numberGrid[0, 1]);

for (int i = 0; i < numberGrid.GetLength(0); i++) // 0 for row
{
  for (int j = 0; j < numberGrid.GetLength(1); j++) // 1 for column
  {
    Console.WriteLine(numberGrid[i, j]);
  }
}


//JAGGED Array
int[][] jArray = new int[2][]; // declaration of jagged array with rows

jArray[0] = new int[2]; // declaraing each row of array with columns
jArray[1] = new int[3];

jArray[0][0] = 10;// initialisation
jArray[0][1] = 20;

jArray[1][0] = 30;
jArray[1][1] = 40;
jArray[1][2] = 50;

for (int i = 0; i < jArray.GetLength(0); i++)
{
  for (int j = 0; j < jArray[i].GetLength(0); j++) // row of 1st row
  {
    Console.WriteLine(jArray[i][j]);
  }
}
