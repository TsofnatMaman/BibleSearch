# BibleSearch

**BibleSearch** is a C# project that allows searching and displaying Bible verses stored in JSON format.  
The project includes:

- A **WinForms** application for interactive search and display.
- A **WebAPI** project for serving Bible data over HTTP.
- JSON-based Bible repository (`bible.json`) for fast access.

## Features

- Load Bible data from a JSON file.
- Search by book, chapter, and verse.
- Convert verse indices to Hebrew letters.
- Works both as a desktop app (WinForms) and as an API (WebAPI).

## Installation

1. Clone the repository:
```bash
git clone https://github.com/TsofnatMaman/BibleSearch.git
````

2. Open the solution in **Visual Studio 2022** or later.

3. Run either the **WinForms** project
   or the **WebAPI** project and open in file explorer the file **BibleSearch\WebApplicationBibleSearch\bibleSearchPage.html.**

## Usage

* **WinForms**: Run the desktop app, use the search interface to find verses.
* **WebAPI**: Access the endpoints to retrieve Bible data programmatically.

## Contributing

Contributions are welcome! Feel free to open issues or submit pull requests.
