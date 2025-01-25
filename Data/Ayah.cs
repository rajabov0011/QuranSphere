namespace QuranSphere.Data;

public class Ayah
{
    public int Number { get; set; }
    public Surah? Surah { get; set; }
    public int NumberInSurah { get; set; }
    public string? Text { get; set; }
    public string? Audio { get; set; }
    public string? Translation { get; set; }
}

public class AyahResponse
{
    public Ayah? Data { get; set; }
}

public class AyahTranslationData
{
    public int Number {get;set;}
    public string? Text {get;set;}
    public Surah? Surah {get;set;}
}

public class AyahTranslationResponse  
{  
    public int Code { get; set; }  
    public string? Status { get; set; }  
    public AyahTranslationData? Data { get; set; }  
}