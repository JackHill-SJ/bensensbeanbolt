using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SkinSetter : MonoBehaviour
{
    Image i;
    private void Start()
    {
        i = GetComponent<Image>();
        i.sprite = GameManager.Instance.SkinSprites[GameManager.Instance.Skin];
    }
    public void Left()
    {
        if (GameManager.Instance.Skin == 0) GameManager.Instance.Skin = GameManager.Instance.SkinSprites.Length - 1;
        else GameManager.Instance.Skin--;
        i.sprite = GameManager.Instance.SkinSprites[GameManager.Instance.Skin];
    }
    public void Right()
    {
        if (GameManager.Instance.Skin == GameManager.Instance.SkinSprites.Length - 1) GameManager.Instance.Skin = 0;
        else GameManager.Instance.Skin++;
        i.sprite = GameManager.Instance.SkinSprites[GameManager.Instance.Skin];
    }
    public void Select() => GameManager.Instance.SelectSkin();
}