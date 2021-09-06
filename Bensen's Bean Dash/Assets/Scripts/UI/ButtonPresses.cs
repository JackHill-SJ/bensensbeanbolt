using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class ButtonPresses : MonoBehaviour
{
    public RectTransform MainMenu;
    public RectTransform CreditsMenu;
    public RectTransform SkinsMenu;
    public RectTransform SettingsMenu;
    public Image PsychedelicButton;
    private void Start()
    {
        PsychedelicButton.color = GameManager.Instance.PsychedelicMode ? Color.green : Color.red;
        CreditsMenu.gameObject.SetActive(false);
        SkinsMenu.gameObject.SetActive(false);
        SkinsMenu.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
    }
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void Credits()
    {
        CreditsMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void Skins()
    {
        SkinsMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void Settings()
    {
        SettingsMenu.gameObject.SetActive(true);
        MainMenu.gameObject.SetActive(false);
    }
    public void Back()
    {
        MainMenu.gameObject.SetActive(true);
        CreditsMenu.gameObject.SetActive(false);
        SkinsMenu.gameObject.SetActive(false);
        SettingsMenu.gameObject.SetActive(false);
    }
    public void PsychedelicToggle()
    {
        GameManager.Instance.PsychedelicMode = !GameManager.Instance.PsychedelicMode;
        PsychedelicButton.color = GameManager.Instance.PsychedelicMode ? Color.green : Color.red;
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}