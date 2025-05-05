namespace AnalyzeMusicPlaylist;

public class Song{
    // Define class fields
    private string name, artist, album, genre;
    private float time;
    private int size, year, plays;

    // Create constructor
    public Song(string name, string artist, string album, string genre, int size, float time, int year, int plays){
        this.name = name;
        this.artist = artist;
        this.album = album;
        this.genre = genre;
        this.size = size;
        this.time = time;
        this.year = year;
        this.plays = plays;
}

    public string Name{
        get{return this.name;}
    }

    public string Artist{
        get{return this.artist;}
    }

    public string Album{
        get{return this.album;}
    }

    public string Genre{
        get{return this.genre;}
    }

    public int Size{
        get{return this.size;}
    }

    public float Time{
        get{return this.time;}
    }

    public int Year{
        get{return this.year;}
    }

    public int Plays{
        get{return this.plays;}
    }
}