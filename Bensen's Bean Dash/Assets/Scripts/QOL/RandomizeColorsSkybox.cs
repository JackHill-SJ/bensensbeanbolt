using UnityEngine;

public class RandomizeColorsSkybox : MonoBehaviour
{
    public Material Skybox;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Randomize), 0, .1f);
    }
    void Randomize()
    {
        if (GameManager.Instance.PsychedelicMode)
        {
            Skybox.SetColor("_SkyTint", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            RenderSettings.fogColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}