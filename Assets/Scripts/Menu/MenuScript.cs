using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Lean.Localization;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public AudioMixer am;
    public AudioSource audioSource;
    public AudioClip TimeToChoose1;
    public AudioClip TimeToChoose2;
    public int timetochoose = 1;
    public LeanLocalization Leans;
    public Dropdown dropdown;

    private void Start()
    {
        PlayGamesScript.UnlockAchievement(GPGSIds.achievement_the_beginning_of_adventure);
        if (Application.systemLanguage == SystemLanguage.English)
        {
            dropdown.value = 0;
            Main.Language = "English";
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            dropdown.value = 1;
            Main.Language = "Russian";
        }
    }


    private void OnEnable()
    {
        Main.Time = 0;
        Main.TimerRun = true;
        Main.Level = 1;
        Main.TardisMode = false;

        PlayGamesScript.AddScoreToLeaderboard(GPGSIds.leaderboard_raiting, Main.Coin);

    }
    public void StartButton()
    {        
        SceneManager.LoadScene("Scene1");
        Main.Coin = PlayerPrefs.GetInt("Coin", Main.Coin);
    }

    public void StartButtonEndless()
    {
        SceneManager.LoadScene("Endless");
    }

    public void StartButtonMultiplayer()
    {
        Main.TimerVisible = false;
        SceneManager.LoadScene("LobbyMultiplayer");
    }

    public void ExitButton()
    {
        PlayerPrefs.SetInt("Coin", Main.Coin);
        Application.Quit();
    }

    public void AudioVolume(float sliderValue)
    {

        am.SetFloat("masterVolume", sliderValue);

    }

    public void TimeToChoose()
    {


        if (timetochoose == 1)
        {
            audioSource.clip = TimeToChoose1;
            timetochoose = 2;
        }
        else
        {
            audioSource.clip = TimeToChoose2;
            timetochoose = 1;
        }
        audioSource.Play();

    }

    public void Quality(int q)
    {

        QualitySettings.SetQualityLevel(q);

    }

    public void LanguageSet(int lang)
    {

        switch (lang)
        {
            case 0:
                Leans.SetCurrentLanguage("English");
                Main.Language = "English";
                break;
            case 1:
                Leans.SetCurrentLanguage("Russian");
                Main.Language = "Russian";
                break;
            default:
                break;
        }

    }

    public void TimerSet()
    {

        if (Main.TimerVisible)
        {
            Main.TimerVisible = false;
        }
        else
        {
            Main.TimerVisible = true;
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();


    }

}
