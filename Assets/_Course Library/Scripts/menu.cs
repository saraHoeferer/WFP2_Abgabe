using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject tutObj;
    [SerializeField] GameObject startObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayButton(){
        SceneManager.LoadScene(1);
    }

    public void onQuitButton(){
        Application.Quit();
    }

    public void onMenuButton(){
        SceneManager.LoadScene(0);
    }

    public void showTutorial() {
        tutObj.SetActive(true);
        startObj.SetActive(false);
    }

    public void disableTutorial() {
        tutObj.SetActive(false);
        startObj.SetActive(true);
    }
}
