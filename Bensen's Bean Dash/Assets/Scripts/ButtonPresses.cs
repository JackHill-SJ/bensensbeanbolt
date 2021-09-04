using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class ButtonPresses : MonoBehaviour
{
    public RectTransform MainMenu;
    public RectTransform CreditsMenu;
    private void Start()
    {
        CreditsMenu.gameObject.SetActive(false);
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
    public void Back()
    {
        MainMenu.gameObject.SetActive(true);
        CreditsMenu.gameObject.SetActive(false);
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