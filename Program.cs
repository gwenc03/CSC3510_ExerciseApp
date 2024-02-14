// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.Read();

string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
Console.WriteLine("Path{0}", path);
string inFile = path + "\\..\\Input\\ExerciseData.txt";
