namespace AnalyzeMusicPlaylist;

public class SongAnalyzer{

    public static void PrintSummary(List<Song> songs){
        Console.WriteLine("Music Playlist Summary\n");
        var topSongs = GetTopPlayedSongs(songs, 200);
        foreach(var song in topSongs){
            Console.WriteLine($"Name: {song.Name}, Artist: {song.Artist}, Album: {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}");
        }
        Console.WriteLine();

        var genreCounts = CountsSongsByGenre(songs);
        Console.WriteLine($"Number of Alternative songs: {genreCounts.GetValueOrDefault("Alternative", 0)}");
        Console.WriteLine($"Number of Hip-Hop/Rap songs: {genreCounts.GetValueOrDefault("Hip-Hop/Rap", 0)}");
        Console.WriteLine();

        Console.WriteLine("Songs from the album 'Welcome to the Fishbowl':");
        var fishbowlSongs = songs.Where(song => song.Album.Equals("Welcome to the Fishbowl", StringComparison.OrdinalIgnoreCase)).ToList();
        foreach(var song in fishbowlSongs){
            Console.WriteLine($"Name: {song.Name}, Artist: {song.Artist}, Album: {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}");
        }
        Console.WriteLine();

        Console.WriteLine("Songs from before 1970:");
        var oldies = songs.Where(song => song.Year < 1970).ToList();
        foreach(var song in oldies){
            Console.WriteLine($"Name: {song.Name}, Artist: {song.Artist}, Album: {song.Album}, Genre: {song.Genre}, Size: {song.Size}, Time: {song.Time}, Year: {song.Year}, Plays: {song.Plays}");
        }
        Console.WriteLine();

        Console.WriteLine("Songs names longer than 85 characters:");
        var longNames = songs.Where(song => song.Name.Length > 85).ToList();
        foreach(var song in longNames){
            Console.WriteLine($"{song.Name}");
        }
        Console.WriteLine();

        Console.WriteLine("Longest song:");
        var longest = songs.OrderByDescending(song => song.Time).FirstOrDefault();
        if(longest != null){
            Console.WriteLine($"Name: {longest.Name}, Artist: {longest.Artist}, Album: {longest.Album}, Genre: {longest.Genre}, Size: {longest.Size}, Time: {longest.Time}, Year: {longest.Year}, Plays: {longest.Plays}");
        }
        Console.WriteLine("\n*/**/**/**/**");

        Console.WriteLine("Unique Genres:");
        var uniqueGenres = songs.Select(song => song.Genre).Distinct().OrderBy(g => g).ToList();
        foreach(var genre in uniqueGenres){
            Console.WriteLine(genre);
        }
        Console.WriteLine("\n*/**/**/**/**");

        Console.WriteLine("Yearly Number of Songs in Playlist:");
        var songsByYear = songs
            .GroupBy(song => song.Year)
            .OrderByDescending(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Count());
        foreach(var entry in songsByYear){
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        Console.WriteLine("\n*/**/**/**/**");

        Console.WriteLine("Total Plays Per Year:");
        var playsByYear = songs
            .GroupBy(song => song.Year)
            .OrderByDescending(g => g.Key)
            .ToDictionary(g => g.Key, g => g.Sum(song => song.Plays));
        foreach(var entry in playsByYear){
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
        



        
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    /*
    public static int GetTotalSongs(List<Song> songs){
        return songs.Count;
    }

    public static List<Song> GetSongsByGenre(List<Song> songs, string genre){
        return songs  
            .Where(song => song.Genre.Equals 
            (genre, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
    }

    public static List<Song> GetSongsByArtist(List<Song> songs, string artist){
        return songs  
            .Where(song => song.Artist.Equals 
            (artist, StringComparison.OrdinalIgnoreCase))
            .ToList();
        
    }

    public static List<Song> GetTopPlayedSongs(List<Song> songs, int playThreshold){
        return songs  
            .Where(song => song.Plays >= playThreshold)
            .OrderByDescending(song => song.Plays)
            .ToList();
        
    }

    public static List<Song> GetSongsLongerThan(List<Song> songs, float timeLimit){
        return songs  
            .Where(song => song.Time >= timeLimit)
            .OrderByDescending(song => song.Time)
            .ToList();
        
    }

    public static List<Song> GetSongsByYear(List<Song> songs, int year){
        return songs  
            .Where(song => song.Year == year)
            .OrderByDescending(song => song.Plays)
            .ToList();
        
    }

    public static Dictionary<string, int> CountsSongsByGenre(List<Song> songs){
        return songs  
            .GroupBy(song => song.Genre)
            .ToDictionary(g => g.Key, g => g.Count());
        
    }

    public static float GetAvgSongLength(List<Song> songs){
        if (songs.Count == 0){
            return 0;
        } 
        return songs.Average(song => song.Time);
        
    }

    
    }

    //var songsByYear = from song in songList
        //                        where song.Plays == (from otherSong in songList select otherSong.Plays).Min()
        //                        select song;

    */
}