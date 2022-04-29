using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public Animator transtion;
    public float transitiontime = 1f;
    private void Update() {
        
    }
    
    public void levelNextLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transtion.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);
        SceneManager.LoadScene(levelIndex);
    }
    public void Play() {
    }

    public void Exit() {
        Application.Quit();
    }
}
