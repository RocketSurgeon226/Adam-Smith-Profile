/*
Challenge: Analyze Music Playlist
Description: Create a C#/.NET console application that analyzes music playlist information contained in a tab-delimited data file and generates a report that answers a set of provided questions
that is saved in a text file. The path to the music playlist data file and the path to the report text file are provided to the program as command line arguments. If the user runs the program 
without supplying the arguments, they are to be provided with the syntax for running the program. All exceptions and errors are to be appropriately handled by giving the user feedback and exiting 
the program. Under no circumstances is the program to crash.

Purpose: This project evaluates your ability to create a C#/.NET console application that accepts command line arguments, reads and parses tab-delimited data, creates data structures, queries 
data using LINQ, writes a report to a text file, and handles exceptions/errors.

The program is to receive the path to a tab-delimited data file containing music playlist information as a command line argument. If the tab-delimited data file is in the same directory as the 
program, then the user can just supply the name of the file as the path.

The records in the tab-delimited data file are to be read by the program and placed in a collection of structured data. Then, Language INtegrated Query (LINQ) along with general C# code is to be 
used to determine the answers to a set of questions and a report is to be generated in a text file that is saved. The path of the report file is also to be supplied as a command line argument. 
If the path of the report file is just the name of the file, then it will be saved in the current directory.

When the application is being run, tested, and debugged in Visual Studio Code, place the SampleMusicPlaylist.txt file in the same directory as the AnalyzeMusicPlaylist.csproj and Program.cs 
files. When the program runs from within Visual Studio Code from the Terminal, the project directory is the current directory and where SampleMusicPlaylist.txt is found, if the name of the file 
is supplied as the path.

Music Playlist Tab-Delimited Data File
    Test data source for application: SampleMusicPlaylist.txtLinks to an external site.

    The data source for the application is an export of a playlist from Apple iTunes with some of the columns of data removed. The Songs playlist was selected in iTunes, then it was exported by 
    selecting File > Library > Export Playlist… The resulting .txt file contains tab-delimited data.

    The first line of the data file is comprised of the headers that identify the columns.

        Name Artist Album Genre Size Time Year Plays

    You can inspect the data file using a plain text editor. Use the headers to identify the meaning of the data. When your program reads the file, the first line needs to be skipped since it 
    doesn’t contain data. Do not delete the first line of the data file in order to avoid it having a header. Other data files provided in the future will have the header, so you need to accept 
    that it is present and handle it.

    When a line is read from the file, it can be split on the tabs so that the pieces of data are put in an array. The order of the data elements in the array will be the same order as they are 
    listed in a record in a line. A tab character is represented using: '\t'. The following line reads a line and splits the values in the line on the tab characters.

        var line = reader.ReadLine();
        var values = line.Split('\t');

    In a previous challenge, you worked with comma separated value (CSV) data where the data elements in a line were separated by commas. The following code was used in that challenge to read a 
    line and split the data on commas.

        var line = reader.ReadLine();
        var values = line.Split(',');

    As you can see, the only difference is that commas have been replaced with tabs in this challenge. The reason tabs are used to separate pieces of data is because the data elements themselves 
    can contain commas that would mess with the ability to determine which commas are meant to separate data elements and which commas are part of the data. For example, this is an album: Old 
    Boots, New Dirt

    Since the data is tab-delimited, the data elements can’t contain tabs otherwise the same kind of confusion as to what is a separator and what is part of the data would occur.

    Make sure the number of values obtained from a line is the expected number of values. Each line is contains eight values: Name, Artist, Album, Genre, Size, Time, Year, and Plays.

Handline Errors

    A well-written program should not crash regardless of the input or data provided to it. You are to handle all exceptions and error conditions that arise when the program is run. If an 
    exception or error occurs, it is to be reported to the user and the program is to exit.

    If the user runs the program without providing the two command line parameters, then the program is to display a message to the user indicating how the program is to be run.

        AnalyzeMusicPlaylist <music_playlist_file_path> <report_file_path>

    The following are some of the errors that could occur that need to be handled. Note, there is no implication that these are all the possible errors. They are being provided to give you a 
    sense of error conditions that could arise that need to be handled.

        Playlist data file can’t be opened.
        Error occurs reading lines from playlist data file.
        Record doesn’t contain the correct number of data elements.
        Record contains data that is not of the right type. Note: Some data elements are strings and some are integers.
        Report file can’t be opened or written to.

    When you display an error message to the user, be as specific as possible about the problem and where it occurred. For example, if a record is malformed the line number of the record in the 
    file should be included in the message to the user along with any other info that could be helpful in finding and correcting the problem.

    The following is an example of an error message to the user when the wrong number of values is encountered in a record.

        $"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}."

Using Language INtegrated Query (LINQ)

    LINQ is very helpful in answering the questions provided below. To illustrate how LINQ works to help with this program, a LINQ statement is provided below to answer the question: What songs 
    have a genre of “Pop” ordered by year descending?

        var popSongsByYearDescending = from song in songs where song.Genre == "Pop" orderby song.Year descending select song;
    
    After the above line executes, popSongsByYearDescending is a collection (IEnumerable) of the Songs instances that were found using the LINQ statement.

    In the above LINQ, songs is a variable referencing a List of instances of a class (in my case Song) that was created in the C# code before this LINQ statement. The instances of the class in 
    the List holds the pieces of data from a row of data for Name, Artist, Album, Genre, Size, etc. song in from song in songs is a variable in the LINQ that refers to individual instances from 
    the list of instances. So, instances of song are going to be gotten out of (from) songs. The name song was chosen by me to indicate an instance from the list. The name can be any valid 
    variable name. The where condition establishes which instances of song are to be included. In the above example, song.Genre == "Pop" indicates instances of song for which the genre is “Pop” 
    are to be included. Genre is a property of the Song class. song.Genre is the genre for a given instance of Song. The select near the end determines what information is returned. select song 
    indicates that the song instance is to be chosen. Since there is possibly more than one instance of Song that could meet the condition of the where clause, the result is an IEnumerable, which 
    means we can use foreach to iterate through the results collection.

    The following is the way to iterate through an IEnumerable.

        foreach (var song in songs)
        {
            // do something with the song
        }

    Using a ToString() Method with Song

    If you want a string representation of a Song instance, write a ToString() method in the Song class.

    The ToString() method converts an instance of an object into a string representation. The following is the ToString() method I created in my Song class.

        override public string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }

    If the above is created, then when the object instance, song, is placed in a string context the ToString() method gets called and returns the string representation like in the following code.

        foreach (Song song in popSongsByYearDescending)
        {
            report += song + "\n";
        }

    In the above code, song is an instance of a Song that has a ToString() method. Since song is being concatenated into a string…meaning this is a string context…the ToString() method 
    automatically is called and a string representation of the object is placed in the report string.

Questions

    The questions to be answered by the application that are to be used as the basis of a report that the application generates are the following.

    1. How many songs received 200 or more plays?
    2. How many songs are in the playlist with the Genre of “Alternative”?
    3. How many songs are in the playlist with the Genre of “Hip-Hop/Rap”?
    4. What songs are in the playlist from the album “Welcome to the Fishbowl?”
    5. What are the songs in the playlist from before 1970?
    6. What are the song names that are more than 85 characters long?
    7. What is the longest song? (longest in Time)
    8. What are the unique Genres in the playlist?
    9. How many songs were produced each year in the playlist?
   10. What are the total plays per year  in the playlist?
   11. Print a list of the unique artists in the playlist.
*/


namespace AnalyzeMusicPlaylist;

class Program
{
    static void Main(string[] args)
    {
        // Require that program is run using command line arguments for data file and report file
        // If both arguments aren't present then end program
        if(args.Length != 2){
            Console.WriteLine("Error: Program requires 2 command line arguments as shown below");
            Console.WriteLine("dotnet run <data file name> <report file name>");
            // Exit program
            Environment.Exit(0);
        }

        // Get command line args
        string dataFile = args[0];
        string reportFile = args[1];

        // Report document variable will contain data for report
        // We'll concatenate resultd from each query to string
        string reportDocument = "";

        // Get list of songs
        List<Song> playlist = null!;
        
        string filePath = "SampleMusicPlaylist.txt";
        try{
            playlist = SongDataLoader.LoadSongs(dataFile);
            Console.WriteLine("Playlist successfully loaded!\n");

            SongAnalyzer.PrintSummary(playlist);

            var topSongs = SongAnalyzer.GetTopPlayedSongs(playlist, 100);
            reportDocument += "Top Played Songs (100+ plays)\n-------------------------------\n";
            foreach(var song in topSongs){
                Console.WriteLine($"{song.Name} by {song.Artist} ({song.Plays} plays)");
            }

            var longSongs = SongAnalyzer.GetSongsLongerThan(playlist, 4.0f);
            reportDocument += "Songs Longer Than 4 Minutes\n-------------------------------\n";
            foreach(var song in longSongs){
                Console.WriteLine($"{song.Name} - {song.Time} min");
            }

            var from2020 = SongAnalyzer.GetSongsLongerThan(playlist, 2020);
            reportDocument += "Songs From 2020\n-------------------------------\n";
            foreach(var song in from2020){
                Console.WriteLine($"{song.Name} by {song.Artist} ({song.Album})");
            }

            var hiphop = SongAnalyzer.GetSongsByGenre(playlist, "Hip Hop");
            reportDocument += "Songs by Genre: Hip Hop\n-------------------------------\n";
            foreach(var song in hiphop){
                Console.WriteLine($"{song.Name} by {song.Artist}");
            }

            //WriteReport(reportDocument,reportFile);


        }catch(Exception e){
            Console.WriteLine($"{e.Message}");
            Environment.Exit(0);
        }
    }

    static void WriteReport(string reportDoc, string reportFile){
        // Write report
        using(StreamWriter reportWriter = new StreamWriter(reportFile)){
            reportWriter.Write(reportDoc);
        }
    }

        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        /*
        // Require that program is run using command line arguments for data file and report file
        // If both arguments aren't present then end program
        if(args.Length != 2){
            Console.WriteLine("Error: Program requires 2 command line arguments as shown below");
            Console.WriteLine("dotnet run <data file name> <report file name>");
            // Exit program
            Environment.Exit(0);
        }

        // Get command line args
        string dataFile = args[0];
        string reportFile = args[1];

        // Report document variable will contain data for report
        // We'll concatenate resultd from each query to string
        string reportDocument = "";

        // Get list of songs
        List<Song> songList = null!;
        
        
        Console.WriteLine($"Song list contains {songList.Count} songs");

        // Process song data using LINQ
        // Get Dean's list songs: plays >= 3.5
        var deansListSongs = from song in songList
                                where song.Plays >= 3.5
                                select song;

        reportDocument += "Dean's List Songs\n-------------------------------\n";
        // Loop thru query results
        foreach(Song song in deansListSongs){
            reportDocument += $"Name: {song.Name} {song.Artist} - {song.Plays:N2}\n";
        }

        // Get songs whose name begins with latter M
        var songWithMNames = from song in songList
                                where song.Name.StartsWith("M")
                                select song;

        reportDocument += "\nSong whose names begin with M\n--------------------------------------------\n";

        // iterate thru results
        foreach(Song song in songWithMNames){
            reportDocument += $"{song.Name} {song.Artist}\n";
        }

        // Find lowest Plays between 2016 and 2020
        var minPlays2016_2020 = (from song in songList
                                where song.Year >= 2016 && song.Year <= 2020
                                select song.Plays).Min();

        reportDocument += $"\nMin Plays 2016 - 2020: {minPlays2016_2020:N2}\n";

        // Find highest Plays between 2016 and 2020
        var maxPlays2016_2020 = (from song in songList
                                where song.Year >= 2016 && song.Year <= 2020
                                select song.Plays).Max();

        reportDocument += $"\nMax Plays 2016 - 2020: {maxPlays2016_2020:N2}\n";

        // Find avg. Plays between 2016 and 2020
        var avgPlays2016_2020 = (from song in songList
                                where song.Year >= 2016 && song.Year <= 2020
                                select song.Plays).Average();

        reportDocument += $"\nAverage Plays 2016 - 2020: {maxPlays2016_2020:N2}\n";

        // Get names and graduations year of songs with lowest Plays
        var lowestPlays = from song in songList
                        where song.Plays == (from otherSong in songList select otherSong.Plays).Min()
                        select song;

        reportDocument += "\nSongs with Lowest Plays\n----------------------------------\n";
        foreach(Song song in lowestPlays){
            reportDocument += $"Name: {song.Name} {song.Artist}\nPlays: {song.Plays:N2} -- Grad Year: {song.Year}\n\n";
        }

        // List songs by graduation year using LINQ
        var songsByYear = from song in songList
                                group song by song.Year into yearGroup
                                orderby yearGroup.Key ascending // (ascending is default anyway)
                                select yearGroup;

        reportDocument += "\nSongs by Graduation Year\n------------------------------\n";
        // Loop thru years
        foreach(var yearGroup in songsByYear){
            reportDocument += $"\n\nGraduation Year: {yearGroup.Key}\n-----------------------\n";
            foreach(var song in yearGroup){
                reportDocument += $"Name: {song.Name} {song.Artist}  -- Class of {song.Year}\n";
            }
        }

        // List songs by graduation year without using LINQ

        // Create dictionary key: int, values List<Song>
        Dictionary<int, List<Song>> yearDict = new Dictionary<int, List<Song>>();

        // Search list of songs and place song in list associated with their grad year
        foreach(Song song in songList){
            int year = song.Year;
            // Check if grad year has key in dictionary
            if(!yearDict.ContainsKey(year)){
                yearDict.Add(year,new List<Song>(){song});
            }else{
                yearDict[year].Add(song);
            }
        }

        // Loop thru yearDict and print songs by grad year
        foreach(int year in yearDict.Keys){
            Console.WriteLine($"\n----------------------{year} Graduates----------------------------");
            foreach(Song song in yearDict[year]){
                Console.WriteLine($"{song.Name} {song.Artist} -- {song.Year}");
            }
        }

        // How many songs graduated in each year?
        // Use results from grouping songs by graduation year
        // Get count for each group
        reportDocument += $"Number of Graduates by Year\n---------------------------------------";
        foreach(var yearGroup in songsByYear){
            reportDocument += $"Graduation Year: {yearGroup.Key} - {yearGroup.Count()}\n";
        }

        // Get list of Distinct Genres
        var songsByGenre = from song in songList
                            group song by song.Genre into genreGroup
                            orderby genreGroup.Key ascending
                            select genreGroup;

        reportDocument += "\nDistinct Genres\n-----------------\n";

        // List distinct genres
        foreach(var genreGroup in songsByGenre){
            reportDocument += $"{genreGroup.Key}\n";
        }

        reportDocument += "\nDistinct Genres #2\n-------------------------\n";
        var distinctGenres = (from song in songList select song.Genre).Distinct();

        foreach(string genre in distinctGenres){
            reportDocument += $"{genre}";
        }

        // List number of songs by graduation year using LINQ and anonymous types
        var songsByYearAnon = from song in songList
                                    group song by song.Year into yearGroup
                                    orderby yearGroup.Key
                                    select new {year = yearGroup.Key, numSongs = yearGroup.Count()};

        reportDocument += $"\nGroup Counts by Year Anonymous\n-----------------------------------------";
        foreach(var group in songsByYearAnon){
            reportDocument += $"{group.year}: {group.numSongs}\n";
        }


        WriteReport(reportDocument, reportFile);

    }

    // Function to write report document
    // Input: report string
    // Output: none
    static void WriteReport(string reportDoc, string reportFile){
        // Write report
        using(StreamWriter reportWriter = new StreamWriter(reportFile)){
            reportWriter.Write(reportDoc);
        }
    }
    */
}
