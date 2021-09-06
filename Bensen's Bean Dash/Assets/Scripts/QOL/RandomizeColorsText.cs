using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class RandomizeColorsText : MonoBehaviour
{
    Text t;
    void Start()
    {
        t = GetComponent<Text>();
        InvokeRepeating(nameof(Randomize), 0, .1f);
    }
    void Randomize()
    {
        if (GameManager.Instance.PsychedelicMode)
        {
            t.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}