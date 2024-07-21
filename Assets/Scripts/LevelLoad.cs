//using cons = Constants.ConstsValue;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LevelLoad : MonoBehaviour
{
    
    public GameObject LoadingScreen;
    bool isloading = false;
    public byte SceneID = 1;
    AsyncOperation Sceneloading;
    public Image LoadBar;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
          if (Input.GetKeyDown(KeyCode.F) && !isloading)StartCoroutine(LoadScene()) ;
    }


    IEnumerator LoadScene()
    {
        isloading = true;
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        Sceneloading = SceneManager.LoadSceneAsync(SceneID);
        while (!Sceneloading.isDone)
        {
            LoadBar.fillAmount = Sceneloading.progress;
            yield return null;
        }
        
    }
}


