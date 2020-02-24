using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SceneSelect : MonoBehaviour
{
    public int sceneNum;

    public void changemenuscene()      
    {
        SceneManager.LoadScene(sceneNum);
    }
}
