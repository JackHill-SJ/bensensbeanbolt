using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class RandomizeColorsMR : MonoBehaviour
{
    MeshRenderer mR;
    private void Start()
    {
        mR = GetComponent<MeshRenderer>();
        InvokeRepeating(nameof(Randomize), 0, .1f);
    }
    void Randomize()
    {
        if (GameManager.Instance.PsychedelicMode)
        {
            foreach (Material mat in mR.materials) mat.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}