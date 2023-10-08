using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_MenuConfirmMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tempatKoin = null;
    [SerializeField] private PlayerProgress _playerProgress = null;
    [SerializeField] private GameObject _pesanCukupKoin = null;
    [SerializeField] private GameObject _pesanTakCukupKoin = null;

    private UI_OpsiLevelPacks _tombolLevelPacks = null;
    private LevelPackKuis _levelPack = null;

    private void Start()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);

            UI_OpsiLevelPacks.EventSaatKlik += UI_OpsiLevelPacks_EventSaatKlik;
        }
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPacks.EventSaatKlik -= UI_OpsiLevelPacks_EventSaatKlik;
    }

    private void UI_OpsiLevelPacks_EventSaatKlik(UI_OpsiLevelPacks tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        if (!terkunci) return;

        gameObject.SetActive(true);

        if(_playerProgress.progresData.koin < levelPack.Harga)
        {
            _pesanCukupKoin.SetActive(false);
            _pesanTakCukupKoin.SetActive(true);
            return;
        }

        _pesanCukupKoin.SetActive(true);        
        _pesanTakCukupKoin.SetActive(false);

        _tombolLevelPacks = tombolLevelPack;
        _levelPack = levelPack;
    }

    public void BukaLevel()
    {
        _playerProgress.progresData.koin -= _levelPack.Harga;
        _playerProgress.progresData.progresLevel[_levelPack.name] = 1;

        _tempatKoin.text = $"{_playerProgress.progresData.koin}";

        _playerProgress.SimpanProgres();
        _tombolLevelPacks.BukaLevelPack();
    }
}
