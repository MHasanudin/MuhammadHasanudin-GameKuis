using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Pertanyaan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tempatJudul = null;

    [SerializeField] private TextMeshProUGUI _tempatTeks = null;
    [SerializeField] private Image _tempatGambar = null;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(_tempatTeks.text); 
    }

    public void SetPertanyaan(string judul, string teksPertanyaan, Sprite gambarHint)
    {
        _tempatJudul.text = judul;
        _tempatTeks.text = teksPertanyaan;
        _tempatGambar.sprite = gambarHint;
    }
}
