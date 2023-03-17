namespace OOP
{
  class Song
  {
    public string title;
    public string artist;
    public int duration;
    public static int songCount = 0; //remains the same for every object

    public Song(string aTitle, string aArtist, int aDuration)
    {
      title = aTitle;
      artist = aArtist;
      duration = aDuration;
      songCount++;
    }

    public int getSongCount()
    {
      return songCount;
    }
  }
}