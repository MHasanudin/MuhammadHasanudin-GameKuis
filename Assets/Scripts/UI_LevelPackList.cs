using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] private InisialDatagameplay _inisialData = null;

    [SerializeField] private UI_KuisList _levelList = null;
    [SerializeField] private UI_OpsiLevelPacks _tombolLevelPack = null;
    [SerializeField] private RectTransform _content = null;
    [SerializeField] private LevelPackKuis[] _levelPacks = new LevelPackKuis[0];



    private void Start()
    {
        LoadLevelPack();

        if (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPacks_EventSaatKlik(_inisialData.levelPack);
        }

        UI_OpsiLevelPacks.EventSaatKlik += UI_OpsiLevelPacks_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPacks.EventSaatKlik -= UI_OpsiLevelPacks_EventSaatKlik;
    }

    private void UI_OpsiLevelPacks_EventSaatKlik(LevelPackKuis levelPack)
    {
        _levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);

        gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;
    }

    private void LoadLevelPack()
    {
        foreach (var lp in _levelPacks)
        {
            // Membuat salinan objek dari prefab tombol level pack
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            // Masukan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }
}
