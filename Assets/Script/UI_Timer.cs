using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour
{
    [SerializeField] private UI_PesanLevel _tempatPesan = null;

    [SerializeField] private Slider _timeBar;
    [SerializeField] private float _waktuJawab = 30f;

    private float _sisaWaktu = 0f; // Waktu Sementara
    private bool _waktuBerjalan = true;

    public bool WaktuBerjalan
    {
        get => _waktuBerjalan;
        set => _waktuBerjalan = value;
    }

    void Start()
    {
        UlangWaktu();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_waktuBerjalan)
        {
            return;
        }

        _sisaWaktu -= Time.deltaTime;
        _timeBar.value = _sisaWaktu / _waktuJawab;

        if(_sisaWaktu <= 0)
        {
            //Debug.Log("Waktu Habis");

            _tempatPesan.Pesan = "Waktu Sudah Habis!!!";
            _tempatPesan.gameObject.SetActive(true);
            _waktuBerjalan = false;
            return;
        }
    }

    public void UlangWaktu()
    {
        _sisaWaktu = _waktuJawab;
    }


}
