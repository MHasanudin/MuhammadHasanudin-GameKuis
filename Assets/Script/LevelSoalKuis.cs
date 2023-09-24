using UnityEngine;

[CreateAssetMenu(
    fileName = "Soal Baru",
    menuName = "Game Kuis/Level Soal Kuis:")]

public class LevelSoalKuis : ScriptableObject
{
    [System.Serializable]
    public struct OpsiJawaban
    {
        public string jawabanTeks;
        public bool adalahBenar;
    }

    public string pertanyaan = string.Empty;
    public Sprite petunjukJawaban = null;

    public OpsiJawaban[] opsiJawaban = new OpsiJawaban[0];
}
