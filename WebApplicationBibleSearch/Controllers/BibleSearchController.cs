using Microsoft.AspNetCore.Mvc;
using Bll_Service;
using DTO;

namespace WebApplicationBibleSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibleSearchController : ControllerBase
    {
        public static Location selectedLocation = new Location() { Book = "כל הספרים", Chapter = "כל הפרקים" };


        [HttpGet("books")]
        public List<string> GetBooks()
        {
            List<string> books = Class1.GetBibleDic().Keys.ToList();
            books.Insert(0, "כל הספרים");
            return books;
        }

        [HttpGet("chapters")]
        public List<string> GetChapters()
         {
            List<string> chapters = Class1.GetBibleDic()[selectedLocation.Book].Keys.ToList();
            chapters.Insert(0, "כל הפרקים");
            return chapters;
        }
        [HttpPut("changeSelectedBook/{book}")]
        public void ChangeSelectedBook(string book)
         {
            selectedLocation.Book = book;
            if(book == "כל הספרים")
                selectedLocation.Chapter = "כל הפרקים";
        }

        [HttpPut("changeSelectedChapter/{chapter}")]
        public void ChangeSelectedChapter(string chapter)
        {
            selectedLocation.Chapter = chapter;
        }
        [HttpGet("obj")]
        public Dictionary<string, Dictionary<string, Dictionary<string, int>>> GetBibleObj()
        {
            return Class1.GetBibleDic();
        }
        [HttpGet("string")]
        public string GetBibleString()
        {
            return Class1.GetBibleString();//.Replace("\n", "<br></br>");
        }

        [HttpGet("searchExpression/{expression}")]
        public List<Location> SearchExpression(string expression)
        {
             var r = Class1.Search(expression,selectedLocation);
            return r;
        }
        [HttpGet("searchAcronyms/{acronyms}")]
        public List<Location> SearchByAcronyms(string acronyms) {
            return Class1.SearchByAcronyms(acronyms, selectedLocation).Select(x=>x.Item1).ToList();
        }
    }
}
