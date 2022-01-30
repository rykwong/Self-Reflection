using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LoadTransition(string name)
    {
        StartCoroutine(LoadScene(name));
    }

    IEnumerator LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}