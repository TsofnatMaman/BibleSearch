using System.Security.Cryptography;
using Dal_Repository;
using DTO;
namespace Bll_Service
{
    public class Class1
    {
        public static string ReadAllBible()
        {
            return Dal_Repository.ReadFile.ReadAllBibleObject();
        }

        public static Dictionary<string, Dictionary<string, Dictionary<string, int>>> GetBibleDic()
        {
            return UseJSON.GetObject();
        }

        public static string GetBibleString()
        {
            return UseJSON.ToStringBible();
        }

        public static string Gimat(int x)
        {
            return Dal_Repository.UseJSON.Gimat(x);
        }



        private static Dictionary<string, Dictionary<string, Dictionary<string, int>>> dBible = GetBibleDic();

        public static List<Location> Search(string text, Location location)
        {

            List<Location> results = new List<Location>();
            //List<Location> results = dBible
            //     .SelectMany(book => book.Value.Select(chapter => new { bookName = book.Key, chapter })) // שמירה של book.Key
            //     .SelectMany(bookChapter => bookChapter.chapter.Value.Select((verse, i) => new
            //     {
            //         verse,
            //         book = bookChapter.bookName,
            //         chapter = bookChapter.chapter.Key,
            //         index = i
            //     }))
            //     .Where(x => (location.Book == "כל הספרים" || x.book == location.Book) && (location.Chapter == "כל הפרקים" || x.chapter == location.Chapter) && x.verse.Key.Contains(text))
            //     .Select(x => new Location()
            //     {
            //         Book = x.book,
            //         Chapter = x.chapter,
            //         Verse = gimat(x.index + 1),
            //         Index = x.verse.Value + x.verse.Key.IndexOf(text) + 1//x => $"[{x.book}, {x.chapter}, {gimat(x.index + 1)}]")
            //     })
            //     .ToList();

            foreach (var book in dBible)
            {
                if (location.Book == "כל הספרים" || book.Key == location.Book)
                    foreach (var chapter in book.Value)
                    {
                        int i = 1;
                        if (location.Chapter == "כל הפרקים" || chapter.Key == location.Chapter)
                            foreach (var verse in chapter.Value)
                            {
                                if (verse.Key.Contains(text))
                                    results.Add(new Location() { Book = book.Key, Chapter = chapter.Key, Verse = Gimat(i), Index = verse.Value + verse.Key.IndexOf(text) + 1 });
                                i++;
                            }
                    }
            }

            return results;
        }

        public static List<(Location, int)> SearchByAcronyms(string acrony, Location location)
        {
            List<(Location, int)> results = new List<(Location, int)>();
            foreach (var book in dBible)
            {
                if (location.Book == "כל הספרים" || location.Book == book.Key)
                    foreach (var chapter in book.Value)
                    {
                        int i = 1;
                        if (location.Chapter == "כל הפרקים" || location.Chapter == chapter.Key)
                            foreach (var verse in chapter.Value)
                            {
                                List<int> temp = StartIOfAcronym(acrony, verse.Key);
                                foreach (int item in temp)
                                {
                                    results.Add((new Location() { Book = book.Key, Chapter = chapter.Key, Verse = Gimat(i), Index = verse.Value }, item));
                                }
                                i++;
                            }
                    }
            }
            return results;
        }

        private static List<int> StartIOfAcronym(string acrony, string verse)
        {
            List<int> results = new List<int>();
            string[] arr = verse.Split(' ');
            bool b = true;
            for (int i = 0; i < arr.Length && arr.Length - i > acrony.Length; i++)
            {
                b = true;
                for (int j = 0; j < acrony.Length && b; j++)
                {
                    if (arr[i + j][0] != acrony[j])
                        b = false;
                }
                if (b)
                    results.Add(i);

            }
            return results;
        }

        public static List<Location> SearchByStartEndVerse(string start, string end, Location searchIn)
        {
            List<Location> results = new List<Location>();
            foreach (var book in dBible)
            {
                if (searchIn.Book == "כל הספרים" || searchIn.Book == book.Key)
                    foreach (var chapter in book.Value)
                    {
                        int i = 1;
                        if (searchIn.Chapter == "כל הפרקים" || searchIn.Chapter == chapter.Key)
                            foreach (var verse in chapter.Value)
                            {
                                char c = verse.Key[0];
                                c=verse.Key[verse.Key.Length - 1];
                                if (verse.Key[0] == start[0] && verse.Key[verse.Key.Length - 2] == end[0])
                                    results.Add(new Location {Book = book.Key, Chapter=chapter.Key,Verse = Gimat(i),Index = verse.Value });
                                i++;
                            }
                    }
            }
            return results;
        }
    }
}
