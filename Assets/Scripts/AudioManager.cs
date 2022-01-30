using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicMainMenu = null;
    [SerializeField] AudioSource musicPrologue = null;
    [SerializeField] AudioSource musicLevel1 = null;
    [SerializeField] AudioSource musicLevel2 = null;
    [SerializeField] AudioSource musicLevel3 = null;
    [SerializeField] AudioSource musicLevel4 = null;
    [SerializeField] AudioSource musicLevel5 = null;
    [SerializeField] AudioSource musicEpilogue = null;

    public static AudioManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic(int num)
    {
        Debug.Log("Play: " + num);
        if (num == 1) musicLevel1.Play();
        else if (num == 2) musicLevel2.Play();
        else if (num == 3) musicLevel3.Play();
        else if (num == 4) musicLevel4.Play();
        else if (num == 5) musicLevel5.Play();
    }
    private void Update()
    {
        if (!musicMainMenu.isPlaying && ActiveScene("Main Menu"))
        {
            musicMainMenu.Play();
        }
        else if (!musicPrologue.isPlaying && ActiveScene("Prologue"))
        {
            musicPrologue.Play();
        }
        else if (!musicEpilogue.isPlaying && ActiveScene("Epilogue"))
        {
            musicEpilogue.Play();
        }

        if (musicMainMenu.isPlaying && !ActiveScene("Main Menu") && !ActiveScene("Credits"))
        {
            musicMainMenu.Stop();
        }
        else if (musicPrologue.isPlaying && !ActiveScene("Prologue"))
        {
            musicPrologue.Stop();
        }
        else if (musicLevel1.isPlaying && !ActiveScene("KL_LEVEL_001"))
        {
            musicLevel1.Stop();
        }
        else if (musicLevel2.isPlaying && !ActiveScene("KL_LEVEL_002"))
        {
            musicLevel2.Stop();
        }
        else if (musicLevel3.isPlaying && !ActiveScene("KL_LEVEL_003"))
        {
            musicLevel3.Stop();
        }
        else if (musicLevel4.isPlaying && !ActiveScene("KL_LEVEL_004"))
        {
            musicLevel4.Stop();
        }
        else if (musicLevel5.isPlaying && !ActiveScene("KL_FINAL LEVEL"))
        {
            musicLevel5.Stop();
        }
        else if (musicEpilogue.isPlaying && !ActiveScene("Epilogue") && !ActiveScene("EndScene"))
        {
            musicEpilogue.Stop();
        }

        
    }

    private bool ActiveScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name.Equals(sceneName);
    }
}
