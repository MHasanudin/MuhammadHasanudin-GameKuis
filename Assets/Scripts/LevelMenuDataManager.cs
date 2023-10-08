using TMPro;
using UnityEngine;
using System.IO;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] private UI_LevelPackList _levelPackList = null;
    [SerializeField] private PlayerProgress _playerProgres = null;
    [SerializeField] private TextMeshProUGUI _tempatKoin = null;
    [SerializeField] private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];

    private void Start()
    {
        //string directory = Application.dataPath + "/Temporary";
        //var path = directory + "/" + _playerProgres;

        if (!_playerProgres.MuatProgres())
        {
            _playerProgres.SimpanProgres();
        }

        _levelPackList.LoadLevelPack(_levelPacks, _playerProgres.progresData);

        _tempatKoin.text = $"{_playerProgres.progresData.koin}";
        AudioManager.instance.PlayBGM(0);
    }
}
