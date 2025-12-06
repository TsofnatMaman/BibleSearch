using Bll_Service;
using DTO;
using System.Data;
namespace form1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> booksList = Bll_Service.Class1.GetBibleDic().Keys.ToList();
            booksList.Insert(0, "כל הספרים");
            selectSpecBookComboBox.DataSource = booksList;
            //allBible.Text = Bll_Service.Class1.ReadAllBible();
            results.Text = "";
            allBible.Text = Bll_Service.Class1.ReadAllBible();
        }

        private void inputTextToSearch_TextChanged(object sender, EventArgs e)
        {
            //search();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            typeSearch = "word";
            search();
        }

        private void search()
        {
            string text = inputTextToSearch.Text;
            List<Location> res = Class1.Search(text, searchIn);
            PaintSearch(res, text);

            if (!string.IsNullOrEmpty(text))
                results.DataSource = res;
            sumOfResults.Text = "סה\"כ תוצאות: " + res.Count.ToString();
        }

        private void PaintSearch(List<Location> res, string text)
        {
            allBible.SelectAll();
            allBible.SelectionBackColor = Color.White;
            foreach (Location l in res)
            {
                allBible.Select(l.Index, text.Length);
                allBible.SelectionBackColor = Color.Yellow;
            }

        }


        //איתור המיקום הנוכחי
        private int prevSelected = 0;
        private string typeSearch = "";
        private void results_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeSearch == "word")
            {
                int temp = allBible.Text.IndexOf(' ', prevSelected);
                temp = Math.Min(temp, allBible.Text.IndexOf('\n', prevSelected));
                allBible.Select(prevSelected, temp - prevSelected);
                allBible.SelectionBackColor = Color.Yellow;

                prevSelected = ((Location)results.SelectedItem).Index;
                allBible.Select(prevSelected, inputTextToSearch.Text.Length);
                allBible.SelectionBackColor = Color.Red;
            }
            else
                prevSelected = ((Location)results.SelectedItem).Index;

            ScrollToIfNeeded(prevSelected);
        }

        private void ScrollToIfNeeded(int desiredIndex)
        {
            // מקבל את המיקום של התו הראשון והשני האחרון בטווח הגלוי
            int firstVisibleIndex = allBible.GetCharIndexFromPosition(new Point(0, 0));
            int lastVisibleIndex = allBible.GetCharIndexFromPosition(new Point(allBible.ClientSize.Width, allBible.ClientSize.Height));

            // אם המיקום הרצוי לא בטווח הגלוי
            if (desiredIndex < firstVisibleIndex || desiredIndex > lastVisibleIndex)
            {
                allBible.SelectionStart = desiredIndex;
                allBible.SelectionLength = 0; // לא בוחר טקסט
                allBible.ScrollToCaret(); // מבצע גלילה למיקום הרצוי
            }
        }


        //חיפוש במיקום מסויים
        private Location searchIn = new Location();

        private void selectSpecBookComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchIn.Book = selectSpecBookComboBox.SelectedItem.ToString();
            if (searchIn.Book != "כל הספרים")
            {
                List<string> chaptersList = Bll_Service.Class1.GetBibleDic()[searchIn.Book].Keys.ToList();
                chaptersList.Insert(0, "כל הפרקים");
                searchInChapterLbl.Visible = true;
                selectedSpecChapterComboBox.Visible = true;
                selectedSpecChapterComboBox.DataSource = chaptersList;
            }
            else
            {
                searchInChapterLbl.Visible = false;
                selectedSpecChapterComboBox.Visible = false;
                searchIn.Chapter = "כל הפרקים";
            }
        }

        private void serchInSpecChapterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchIn.Chapter = selectedSpecChapterComboBox.SelectedItem.ToString();
        }

        private void searchByAcronymsBtn_Click(object sender, EventArgs e)
        {
            typeSearch = "acronyms";
            string s = inputTextToSearch.Text;
            List<(Location, int)> l = Class1.SearchByAcronyms(s, searchIn);
            results.DataSource = l.Select(x => x.Item1).ToList();
            //PaintAcronyms();
            allBible.SelectAll();
            allBible.SelectionBackColor = Color.White;
            foreach (var r in l)
            {
                int t = 0;
                string[] arr = allBible.Text.Substring(r.Item1.Index, 200).Split(' ');
                for (var j = 0; j < r.Item2 + s.Length; j++)
                {
                    t += arr[j].Length + 1;
                    if (j >= r.Item2)
                    {
                        allBible.Select(r.Item1.Index + t, 1);
                        allBible.SelectionBackColor = Color.Yellow;
                    }
                }
            }
            sumOfResults.Text = "סה\"כ תוצאות: " + l.Count.ToString();
        }

        private void openSearchStartEnd_Click(object sender, EventArgs e)
        {
            List<Location> r = Class1.SearchByStartEndVerse(inputStart.Text, inputEnd.Text, searchIn);
            results.DataSource = r;

            allBible.SelectAll();
            allBible.SelectionBackColor= Color.White;
            foreach (var v in r)
            {
                allBible.Select(v.Index + 1 , 1);
                allBible.SelectionBackColor = Color.Yellow;
                allBible.Select(allBible.Text.IndexOf('.', v.Index) - 1, 1);
                allBible.SelectionBackColor = Color.Yellow;
            }
        }
    }
}
