using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private InisialDatagameplay _inisialData = null;

    [SerializeField] private PlayerProgress _playerProgres = null;
    [SerializeField] private LevelPackKuis _soalSoal = null;

    [SerializeField] UI_Pertanyaan _pertanyaan = null;
    [SerializeField] UI_PoinJawaban[] _pilihanJawaban = new UI_PoinJawaban[0];
    
    [SerializeField] private GameSceneManager _gameSceneManager = null;
    [SerializeField] private string _namaScenePilihMenu = string.Empty;

    private int _indexSoal = -1;

    private void Start()
    {
        //if (!_playerProgres.MuatProgres())
        //{
        //    _playerProgres.SimpanProgres();
        //}

        _soalSoal = _inisialData.levelPack;
        _indexSoal = _inisialData.levelIndex - 1;
        NextLevel();

        UI_PoinJawaban.EventJawabSoal += UI_PoinJawaban_EventJawabSoal;
    }

    private void OnDestroy()
    {
        UI_PoinJawaban.EventJawabSoal -= UI_PoinJawaban_EventJawabSoal;
    }

    private void OnApplicationQuit()
    {
        _inisialData.SaatKalah = false;
    }

    private void UI_PoinJawaban_EventJawabSoal(string jawaban, bool adalahBenar)
    {
        if (adalahBenar)
        {
            _playerProgres.progresData.koin += 20;
        }
    }

    public void NextLevel()
    {
        // Soal index selanjutnya
        _indexSoal++;

        // Jika index melampaui soal terakhir, ulang dari awal
        if(_indexSoal >= _soalSoal.BanyakLevel)
        {
            _gameSceneManager.BukaScene(_namaScenePilihMenu);
            return;
        }

        // Ambil data Pertanyaan
        LevelSoalKuis soal = _soalSoal.AmbilLevelKe(_indexSoal);

        // Set informasi soal
        _pertanyaan.SetPertanyaan($"Soal {_indexSoal + 1}" ,soal.pertanyaan, soal.petunjukJawaban);

        for(int i = 0; i < _pilihanJawaban.Length; i++)
        {
            UI_PoinJawaban poin = _pilihanJawaban[i];
            LevelSoalKuis.OpsiJawaban opsi = soal.opsiJawaban[i];
            poin.SetJawaban(opsi.jawabanTeks, opsi.adalahBenar);
        }
    }

}
