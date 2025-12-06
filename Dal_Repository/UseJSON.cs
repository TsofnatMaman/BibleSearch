using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class UseJSON
    {

        private static Dictionary<string, Dictionary<string, Dictionary<string, int>>> dBible = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();

        static UseJSON()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(basePath, "bible.json");

            System.Diagnostics.Debug.WriteLine("Searching in: " + path);

            dBible = JsonConvert.DeserializeObject<
                Dictionary<string, Dictionary<string, Dictionary<string, int>>>>
                (File.ReadAllText(path));
        }

        public static Dictionary<string, Dictionary<string, Dictionary<string, int>>> GetObject()
        {
            return dBible;
        }
        public static string ToStringBible()
        {
            StringBuilder sb = new StringBuilder();
            int i;
            foreach (var book in dBible)
            {
                sb.Append($"\nספר: {book.Key}");
                foreach (var chapter in book.Value)
                {
                    sb.Append($"\n\tפרק: {chapter.Key}");
                    i = 0;
                    foreach (var verse in chapter.Value)
                    {
                        sb.Append($"\n\t\t פסוק {Gimat(i + 1)} : {verse.Key}");
                        i++;
                    }
                }
            }
            return sb.ToString();
        }

        public static string Gimat(int x)
        {
            string gimat = "";
            Dictionary<char, int> dGimat = new Dictionary<char, int>
            {
                { 'א', 1 }, { 'ב', 2 }, { 'ג', 3 }, { 'ד', 4 }, { 'ה', 5 },
                { 'ו', 6 }, { 'ז', 7 }, { 'ח', 8 }, { 'ט', 9 }, { 'י', 10 },
                { 'כ', 20 }, { 'ל', 30 }, { 'מ', 40 }, { 'נ', 50 }, { 'ס', 60 },
                { 'ע', 70 }, { 'פ', 80 }, { 'צ', 90 }, { 'ק', 100 }, { 'ר', 200 },
                { 'ש', 300 }, { 'ת', 400 }
            };
            char[] keys = dGimat.Keys.ToArray();
            for (int i = keys.Length - 1; i >= 0;)
            {
                if (x == 15 || x == 16)
                {
                    gimat += "ט" + keys[x - 10];
                    break;
                }
                int val = dGimat[keys[i]];
                if (x - val >= 0)
                {
                    gimat += keys[i];
                    x -= val;
                }
                else
                    i--;
            }
            return gimat;
        }


        //temp functions

        /*public static void BuildJSON()
        {
            string filePath = @"../../../../Dal_Repository\bible2.txt";
            string? curVerses = "";
            Regex pattern = new Regex(@"(.*)\[(?<book>[^ ]+) (?<chapter>[^,]+),(?<verses>[^\]]+)\] (?<val>.+)");
            //  \[(?<book>[^ ]+) (?<chapter>[^,]+),(?<verses>[^\]]+)]\

            var results = pattern.Match("");
            using (StreamReader reader = new StreamReader(filePath))
            {
                curVerses = reader.ReadLine();
                while (curVerses != null)
                 {
                    results = pattern.Match(curVerses);
                    if (results.Success)
                    {
                        if (!dBible.ContainsKey(results.Groups["book"].Value))
                            dBible[results.Groups["book"].Value] = new Dictionary<string, Dictionary<string, int>>();
                        if (!dBible[results.Groups["book"].Value].ContainsKey(results.Groups["chapter"].Value))
                            dBible[results.Groups["book"].Value][results.Groups["chapter"].Value] = new Dictionary<string, int>();
                        dBible[results.Groups["book"].Value][results.Groups["chapter"].Value][results.Groups["val"].Value+'.'] = 0;
                    }

                    curVerses = reader.ReadLine();
                }
            }
            CalcIndexs();
        }

        private static void CalcIndexs()
        {
            int i;
            int temp = 0;
            foreach (var book in dBible)
            {
                string b = $"\nספר: {book.Key}";
                temp += b.Length;
                foreach (var chapter in book.Value)
                {
                    string c = $"\n\tפרק: {chapter.Key}";
                    temp += c.Length;
                    i = 0;
                    foreach (var verse in chapter.Value)
                    {
                        string v = $"\n\t\t פסוק {Gimat(i + 1)} :";
                        temp += v.Length;
                        dBible[book.Key][chapter.Key][verse.Key] = temp;
                        temp += verse.Key.Length + 1;//Environment.NewLine.Length;//2 \r\n בסוף הפסוק בתצוגה
                        i++;
                    }
                }
            }
        }

        
        public static void WriteBibleByLines()
        {
            string src = @"../../../../Dal_Repository/bible.txt";
            string des = @"../../../../Dal_Repository/bible2.txt";
            string curVerses = "";
            int curChar;

            // פתיחה לקריאה מהמקור
            using (StreamReader reader = new StreamReader(src))
            {
                // פתיחה לכתיבה ליעד
                using (StreamWriter writer = new StreamWriter(des, append: false)) // false כדי לא לשרשר לנתונים קיימים
                {
                    // קריאה מהמקור שורה-שורה
                    while ((curChar = reader.Read()) != -1) // קריאה עד לסוף הקובץ
                    {
                        char currentCharacter = (char)curChar;

                        if (currentCharacter != '.') // אם לא הגענו לסוף הפסוק
                        {
                            curVerses += currentCharacter;
                        }
                        else
                        {
                            // כתיבה של הפסוק
                            writer.WriteLine(curVerses);
                            curVerses = ""; // איפוס המחרוזת לפסוק הבא
                        }
                    }

                    // כתיבה של פסוק אחרון אם אין נקודה בסוף
                    if (!string.IsNullOrEmpty(curVerses))
                    {
                        writer.WriteLine(curVerses);
                    }
                }
            }
        }

        public static void CovertFromObjToJSON()
        {
            BuildJSON();
            File.WriteAllText("../../../../Dal_Repository/bible.json", JsonConvert.SerializeObject(dBible));
        }*/

    }
}
