# RandomName.cs
## A C# random name generator

Provides a `RandomName` class that can generate a random English styled name, chosen at random from a JSON file containing the 1000 most popular male, female and last names.

Name generation example:
```c#
Random rand = new Random(DateTime.Now.Seconds); // we need a random variable to select names randomly

RandomName nameGen = new RandomName(rand); // create a new instance of the RandomName class

string name = nameGen.Generate(Sex.Male, 1); // generate a male name, with one middal name.
string secondName = nameGen.Generate(Sex.Female, 2, true); // generate a female name with two middle initials
string thridName = nameGen.Generate(Sex.Female); // a female name with no middle names

List<string> Names = nameGen.RandomNames(100, 2); // generate 100 random names with up to two middle names
List<string> Boys = nameGen.RandomNames(100, 0, Sex.Male); // generate 100 random boys names
List<string> Girls = nameGen.RandomNames(100, 2, Sex.Female, true); // 100 girls names with intials
```
