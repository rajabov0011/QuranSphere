namespace QuranSphere.Data;

public class Surah
{
    public int Number { get; set; }
    public string? EnglishName { get; set; }
    public int NumberOfAyahs { get; set; }
}

public class SurahResponse
{
    public List<Surah>? Data { get; set; }
}