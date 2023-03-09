//Output command
Console.WriteLine("Hello, World!");


//Variables
string characterName = "John";
int characterAge = 22;

System.Console.WriteLine("There once was a man called " + characterName + " who didnt like being " + characterAge);

System.Console.WriteLine("There once was a man called {0} who didnt like being {1}", characterName, characterAge);


//Data Types
char grade = 'A'; //for characters
string phrase = "marks"; //for text

byte hours = 24; //for numbers within 1 byte range 
int age = 30; //for larger numbers

float point = 2.6f; //least accurate
double gpa = 3.2; // more precise
decimal accno = 3.479347983M; //most precise

bool flag = true; //stores true/false


//Working with strings
System.Console.WriteLine("Rajorshi\nGhosh"); //New line character

System.Console.WriteLine("Rajorshi\"Ghosh"); //Escape character

string line = "My name is " + characterName; //String concatnation

System.Console.WriteLine(line.Length); // string length attribute

System.Console.WriteLine(line.ToUpper()); // string method

System.Console.WriteLine(line.ToLower()); // string method

System.Console.WriteLine(line.Contains("name")); // string method

System.Console.WriteLine(line[0]); // string indexing

System.Console.WriteLine(line.IndexOf("name")); // returns index position or -1

System.Console.WriteLine(line.Substring(5)); // substring with just starting index

System.Console.WriteLine(line.Substring(5, 6)); // substring with starting index and length


//Numbers in C#

System.Console.WriteLine(5 / 2.0); //returns decimal (type casting)

System.Console.WriteLine(Math.Pow(5, 2)); // math functions

System.Console.WriteLine(Math.Sqrt(49)); // math functions

System.Console.WriteLine(Math.Max(50, 60)); // math functions

System.Console.WriteLine(Math.Min(50, 60)); // math functions

System.Console.WriteLine(Math.Round(6.9)); // math functions


//User Input

System.Console.Write("Enter your name: ");
string name = Console.ReadLine();
System.Console.WriteLine("Hello " + name);


//Simple Calculator

Console.Write("Enter a number: ");
int num1 = Convert.ToInt32(Console.ReadLine()); //String to Integer Conversion
Console.Write("Enter another number: ");
int num2 = Convert.ToInt32(Console.ReadLine()); //ToDouble for String to double Conversion

Console.WriteLine("The sum is " + (num1 + num2));


// Mad Libs Game

string color, pluralNoun, celebrity;

Console.Write("Enter a color: ");
color = Console.ReadLine();

Console.Write("Enter a plural noun: ");
pluralNoun = Console.ReadLine();

Console.Write("Enter a celebrity: ");
celebrity = Console.ReadLine();

Console.WriteLine("Roses are {0}", color);
Console.WriteLine("{0} are blue", pluralNoun);
Console.WriteLine("I love {0}", celebrity);