using QuranSphere.Data;

namespace QuranSphere.Services;

public interface IQuranSphereService
{
    public Task<List<Surah>>? GetAllSurahs();
    public Task<AyahTranslationData>? GetAyahTranlationAsync(int surahNumber, int ayahNumber);
    public Task<string>? GetAyahPng(int surahNumber, int ayahNumber);
    public Task<string>? GetAyahAudio(int surahNumber, int ayahNumber);
}