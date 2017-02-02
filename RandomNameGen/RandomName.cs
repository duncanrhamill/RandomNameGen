using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace RandomNameGen
{
    /// <summary>
    /// RandomName class, used to generate a random name.
    /// </summary>
    public class RandomName
    {  
        /// <summary>
        /// Class for holding the lists of names from names.json
        /// </summary>
        class NameList
        {
            public string[] boys { get; set; }
            public string[] girls { get; set; }
            public string[] last { get; set; }

            public NameList()
            {
                boys = new string[] { };
                girls = new string[] { };
                last = new string[] { };
            }
        }

        Random rand;
        List<string> Boys;
        List<string> Girls;
        List<string> Last;

        /// <summary>
        /// Initialises a new instance of the RandomName class.
        /// </summary>
        /// <param name="rand">A Random that is used to pick names</param>
        public RandomName(Random rand)
        {
            this.rand = rand;
            NameList l = new NameList();

            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader reader = new StreamReader("names.json"))
            using (JsonReader jreader = new JsonTextReader(reader))
            {
                l = serializer.Deserialize<NameList>(jreader);
            }

            Boys = new List<string>(l.boys);
            Girls = new List<string>(l.girls);
            Last = new List<string>(l.last);
        }

        /// <summary>
        /// Returns a new random name
        /// </summary>
        /// <param name="sex">The sex of the person to be named. true for male, false for female</param>
        /// <param name="middle">How many middle names do generate</param>
        /// <param name="isInital">Should the middle names be initials or not?</param>
        /// <returns>The random name as a string</returns>
        public string Generate(bool sex, int middle = 0, bool isInital = false)
        {
            string first = sex ? Boys[rand.Next(Boys.Count)] : Girls[rand.Next(Girls.Count)]; // determines if we should select a name from boys or girls
            string last = Last[rand.Next(Last.Count)]; // gets the last name

            List<string> middles = new List<string>();

            for (int i = 0; i < middle; i++)
            {
                if (isInital)
                {
                    middles.Add("ABCDEFGHIJKLMNOPQRSTUVWXYZ"[rand.Next(0, 25)].ToString() + "."); // randomly selects an uppercase letter to use as the inital and appends a dot
                }
                else
                {
                    middles.Add(sex ? Boys[rand.Next(Boys.Count)] : Girls[rand.Next(Girls.Count)]); // randomly selects a name that fits with 
                }
            }

            StringBuilder b = new StringBuilder();
            b.Append(first + " "); // put a space after our names;
            foreach (string m in middles)
            {
                b.Append(m + " ");
            }
            b.Append(last);

            return b.ToString();
        }
    }
}
