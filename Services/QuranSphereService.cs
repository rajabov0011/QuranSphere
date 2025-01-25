using System.Net.Http.Json;
using QuranSphere.Data;

namespace QuranSphere.Services;

public class QuranSphereService(HttpClient httpClient) : IQuranSphereService
{
    public async Task<List<Surah>>? GetAllSurahs()
    {
        var allSurahs = await httpClient.GetFromJsonAsync<SurahResponse>("https://api.alquran.cloud/v1/surah");
        
        return allSurahs?.Data ?? [];
    }

    public async Task<string>? GetAyahAudio(int surahNumber, int ayahNumber)
    {
        var ayah = await httpClient.GetFromJsonAsync<AyahResponse>($"https://api.alquran.cloud/v1/ayah/{surahNumber}:{ayahNumber}/ar.alafasy");
        var mp3Url = ayah?.Data?.Audio ?? string.Empty;
        if (!string.IsNullOrEmpty(mp3Url))
        {
            var response = await httpClient.GetAsync(mp3Url);
            if (response.IsSuccessStatusCode)
            {
                return mp3Url;
            }
        }

        return string.Empty;
    }

    public async Task<string>? GetAyahPng(int surahNumber, int ayahNumber)
    {
        var url = $"https://cdn.islamic.network/quran/images/{surahNumber}_{ayahNumber}.png";
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return url;
        }

        return string.Empty;
    }

    public async Task<AyahTranslationData>? GetAyahTranlationAsync(int surahNumber, int ayahNumber)
    {
        var response = await httpClient.GetFromJsonAsync<AyahTranslationResponse>($"https://api.alquran.cloud/v1/ayah/{surahNumber}:{ayahNumber}/uz.sodik");
        if (response != null && response.Data != null)
        {
            return new AyahTranslationData
            {
                Number = response.Data.Number,
                Text = response.Data.Text,
                Surah = response.Data.Surah
            };
        }

        return new AyahTranslationData {};
    }
}