using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LevelPackList : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private InisialDatagameplay _inisialData = null;

    [SerializeField] private UI_KuisList _levelList = null;
    [SerializeField] private UI_OpsiLevelPacks _tombolLevelPack = null;
    [SerializeField] private RectTransform _content = null;

    private void Start()
    {
        //LoadLevelPack();

        if (_inisialData.SaatKalah)
        {
            UI_OpsiLevelPacks_EventSaatKlik(null, _inisialData.levelPack, false);
        }

        UI_OpsiLevelPacks.EventSaatKlik += UI_OpsiLevelPacks_EventSaatKlik;
    }

    private void OnDestroy()
    {
        UI_OpsiLevelPacks.EventSaatKlik -= UI_OpsiLevelPacks_EventSaatKlik;
    }

    private void UI_OpsiLevelPacks_EventSaatKlik(UI_OpsiLevelPacks tombolLevelPack, LevelPackKuis levelPack, bool terkunci)
    {
        if (terkunci)
            return;

        //_levelList.gameObject.SetActive(true);
        _levelList.UnloadLevelPack(levelPack);

        //gameObject.SetActive(false);

        _inisialData.levelPack = levelPack;

        _animator.SetTrigger("KeLevels");
    }

    public void LoadLevelPack(LevelPackKuis[] levelPacks, PlayerProgress.MainData playerData)
    {
        foreach (var lp in levelPacks)
        {
            // Membuat salinan objek dari prefab tombol level pack
            var t = Instantiate(_tombolLevelPack);

            t.SetLevelPack(lp);

            // Masukan objek tombol sebagai anak dari objek "content"
            t.transform.SetParent(_content);
            t.transform.localScale = Vector3.one;

            if (!playerData.progresLevel.ContainsKey(lp.name))
            {
                t.KunciLevelPack();
            }
        }
    }
}
