using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Game Kuis/Player Progress")]
public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progresLevel;
    }

    [SerializeField] private string _filename = "contoh.txt";

    [SerializeField] private string _startingLevelPackName = string.Empty;

    public MainData progresData = new MainData();

    public void SimpanProgres()
    {
        if(progresData.progresLevel == null)
        {
            progresData.progresLevel = new();
            progresData.koin = 0;
            progresData.progresLevel.Add(_startingLevelPackName, 1);
        }

#if UNITY_EDITOR
        string directory = Application.dataPath + "/Temporary";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string directory = Application.persistentDataPath + "/ProgresLokal/";
#endif

        var path = directory +  "/" + _filename;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been Created : " + directory);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File Created : " + path);
        }

        var fileStream = File.Open(path, FileMode.Open);

        fileStream.Flush();

        var writer = new BinaryWriter(fileStream);

        writer.Write(progresData.koin);

        foreach (var i in progresData.progresLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }

        writer.Dispose();

        Debug.Log($"{_filename} Berhasil disimpan");
    }

    public bool MuatProgres()
    {

#if UNITY_EDITOR
        string directory = Application.dataPath + "/Temporary";
#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        string directory = Application.persistentDataPath + "/ProgresLokal/";
#endif

        var path = directory + "/" + _filename;

        if (!Directory.Exists(directory))
        {
            SimpanProgres();
        }

        var fileStream = File.Open(path, FileMode.OpenOrCreate);

        try
        {
            var reader = new BinaryReader(fileStream);
            try
            {
                progresData.koin = reader.ReadInt32();
                if(progresData.progresLevel == null)
                {
                    progresData.progresLevel = new();
                }
                while (reader.PeekChar() != -1) 
                {
                    var namaLevelPack = reader.ReadString();
                    var levelKe = reader.ReadInt32();
                    progresData.progresLevel.Add(namaLevelPack, levelKe);
                    Debug.Log($"{namaLevelPack} : {levelKe}");
                }
                reader.Dispose();
            }
            catch(System.Exception e)
            {
                Debug.Log($"ERROR : Terjadi keasalahan saat memuat progress\n {e.Message}");
                reader.Dispose();
                fileStream.Dispose();

                return false;
            }

            fileStream.Dispose();

            //Debug.Log($"{progresData.koin}; {progresData.progresLevel.Count}");

            return true;
        }
        catch (System.Exception e)
        {
            fileStream.Dispose();
            Debug.Log($"ERROR : Terjadi keasalahan saat memuat progress\n {e.Message}");
            
            return false;
        }
    }
}
