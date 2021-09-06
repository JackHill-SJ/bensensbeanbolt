using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RandomizeColorsImage : MonoBehaviour
{
    Image i;
    void Start()
    {
        i = GetComponent<Image>();
        InvokeRepeating(nameof(Randomize), 0, .1f);
    }
    void Randomize()
    {
        if (GameManager.Instance.PsychedelicMode)
        {
            i.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}