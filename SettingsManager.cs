using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public bool musicOn = true;
    public bool soundOn = true;
    public bool vibrationOn = true;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadSettings();
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        PlayerPrefs.SetInt("Music", musicOn ? 1 : 0);
    }

    public void ToggleSound()
    {
        soundOn = !soundOn;
        PlayerPrefs.SetInt("Sound", soundOn ? 1 : 0);
    }

    public void ToggleVibration()
    {
        vibrationOn = !vibrationOn;
        PlayerPrefs.SetInt("Vibration", vibrationOn ? 1 : 0);
    }

    public void LoadSettings()
    {
        musicOn = PlayerPrefs.GetInt("Music", 1) == 1;
        soundOn = PlayerPrefs.GetInt("Sound", 1) == 1;
        vibrationOn = PlayerPrefs.GetInt("Vibration", 1) == 1;
    }

    public void SaveSettings()
    {
        PlayerPrefs.Save();
    }
}
