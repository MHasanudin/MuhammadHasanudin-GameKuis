using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_KuisList : MonoBehaviour
{
    [SerializeField] private InisialDatagameplay _inisialData = null;
    [SerializeField] private UI_OpsiLevelKuis _tombolLevelKuis = null;
    [SerializeField] private RectTransform _content = null;
    [SerializeField] private LevelPackKuis _levelPack = null;
    [SerializeField] private GameSceneManager _gameSceneManager = null;
    [SerializeField] private string _gameplayScene = string.Empty;


    private void Start()
    {
        UI_OpsiLevelKuis.EventSaatKlik += UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelKuis.EventSaatKlik -= UI_OpsiLevelKuis_EventSaatKlik;
    }

    private void UI_OpsiLevelKuis_EventSaatKlik(int index)
    {
        _inisialData.levelIndex = index;

        _gameSceneManager.BukaScene(_gameplayScene);
    }

    public void UnloadLevelPack(LevelPackKuis levelPack)
    {
        HapusIsiKonten();

        _levelPack = levelPack;

        for (int i = 0; i < levelPack.BanyakLevel; i++)
        {
            // Membuat salinan objek dari prefab tombol level
            var t = Instantiate(_tombolLevelKuis);

            t.SetLevelKuis(levelPack.AmbilLevelKe(i), i);

            // Masukan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;
        }
    }

    private void HapusIsiKonten()
    {
        var cc = _content.childCount;

        for(int i = 0; i < cc; i++)
        {
            Destroy(_content.GetChild(i).gameObject);
        }
    }
}
