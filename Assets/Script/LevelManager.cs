using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public struct DataSoal
    {
        public string pertanyaan;
        public Sprite petunjukJawaban;

        public string[] pilihJawaban;
        public bool[] adalahBenar;
    }

    [SerializeField] private DataSoal[] _soalSoal = new DataSoal[0];
    [SerializeField] UI_Pertanyaan _pertanyaan = null;
    [SerializeField] UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];

    private int _indexSoal = -1;

    private void Start()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        // Soal index selanjutnya
        _indexSoal++;

        // Jika index melampaui soal terakhir, ulang dari awal
        if(_indexSoal >= _soalSoal.Length)
        {
            _indexSoal = 0;
        }

        // Ambil data Pertanyaan
        DataSoal soal = _soalSoal[_indexSoal];

        // Set informasi soal
        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}" ,soal.pertanyaan, soal.petunjukJawaban);

        for(int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            poin.SetJawaban(soal.pilihJawaban[i], soal.adalahBenar[i]);
        }
    }

}
