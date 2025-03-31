//not used in Main
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;


    public float transitionTime = 2f;
    public bool x = false;
    // Update is called once per frame
    void Update()
    {
        if (x) {
            LoadNextLevel();
        } 
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetBool("start", true);

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);


    }
}
