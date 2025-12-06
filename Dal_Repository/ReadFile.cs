namespace Dal_Repository
{
    public class ReadFile
    {
        public static string ReadAllBible()
        {
            return File.ReadAllText(@"../../../../Dal_Repository\bible.txt");
        }

        public static string ReadAllBibleObject()
        {
            return UseJSON.ToStringBible();
        }

    }
}
