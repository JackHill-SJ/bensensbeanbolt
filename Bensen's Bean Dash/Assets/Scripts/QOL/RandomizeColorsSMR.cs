using UnityEngine;

[RequireComponent(typeof(SkinnedMeshRenderer))]
public class RandomizeColorsSMR : MonoBehaviour
{
    SkinnedMeshRenderer sMR;
    private void Start()
    {
        sMR = GetComponent<SkinnedMeshRenderer>();
        InvokeRepeating(nameof(Randomize), 0, .1f);
    }
    void Randomize()
    {
        if (GameManager.Instance.PsychedelicMode)
        {
            foreach (Material mat in sMR.materials) mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}