using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelMenuDataManager : MonoBehaviour
{
    [SerializeField] private PlayerProgress _playerPrgress = null;
    [SerializeField] private TextMeshProUGUI _tempatKoin = null;

    private void Start()
    {
        _tempatKoin.text = $"{_playerPrgress.progresData.koin}";
    }
}
