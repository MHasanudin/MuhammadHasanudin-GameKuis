using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public void BukaScene(string namaScene)
    {
        SceneManager.LoadScene(namaScene);
    }

}
