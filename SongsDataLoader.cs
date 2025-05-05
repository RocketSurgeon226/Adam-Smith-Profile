using Microsoft.VisualBasic;

namespace AnalyzeMusicPlaylist;

// Create class that contains methods to perform actions on game characters
public class SongDataLoader{

    // Create method to read game character data from file and return list of game characters
    public static List<Song> LoadSongs(string filePath){
        // Create empty list to store game characters
        List<Song> playlist = new List<Song>();

        // Open csv file
        using(StreamReader fileReader = new StreamReader(filePath)){
            // Create counter to keep track of line in file I'm reading from
            int lineNumber = 0;
            int piecesOfData = 8;

            // Skip  first line of data because that is header row
            string lineOfData = fileReader.ReadLine()!;

            // Read file line by line
            while(!fileReader.EndOfStream){
                // Increment lineNumber
                lineNumber ++;

                // Split data at comma
                lineOfData = fileReader.ReadLine()!;
                string [] songData = lineOfData.Split("\t");

                // Ensure each line has 5 values. If not, throw error message
                if(songData.Length != piecesOfData){
                    string errorMessage = $"Line {lineNumber} in your data file contains {songData.Length} pieces of data. It should contain {piecesOfData} pieces of data."; //------------------------------------------
                    LogError(errorMessage);
                    throw new Exception(errorMessage);
                    // Skip to next line
                    //continue;
                }

                // Get values from array after splitting
                try{
                    string name = songData[0];
                    string artist = songData[1];
                    string album = songData[2];
                    string genre = songData[3];
                    int size = int.Parse(songData[4]);
                    float time = float.Parse(songData[5]);
                    int year = int.Parse(songData[6]);
                    int plays = int.Parse(songData[7]);

                    // Create song and add song  to List
                    playlist.Add(new Song(name, artist, album, genre, size,time,year,plays));
                    

                }catch(Exception error){
                    string message = $"There was an error reading line {lineNumber}: {error.Message}";
                    Console.WriteLine(message);
                    LogError(message);
                    throw new Exception(message);
                    //continue;

                }
                
            }
            
        }

        return playlist;

    }

    // Create method to log errors
    // Input: string errorMessage
    // Output: None
    public static void LogError(string errorMessage){
        // log errors with date and time to file called log.txt
        // Get current date and time
        DateTime logDate = DateTime.Now;
        using(StreamWriter logger = File.AppendText("log.txt")){
            logger.WriteLine(logDate + ": " + errorMessage);
            //logger.WriteLine($"{logDate}: {errorMessage}");
        }


    }

    
}