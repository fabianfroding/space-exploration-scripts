using UnityEngine;

public class FireNovaScript : MonoBehaviour
{
    private float resizeCD = 0.05f;
    private float multiplier = 0.01f;
    private bool growing = true;

    void Start()
    {
        if (PlayerPrefs.GetString("Difficulty") == "Normal")
        {
            multiplier = 0.015f;
        }
        else if (PlayerPrefs.GetString("Difficulty") == "Hard")
        {
            multiplier = 0.02f;
        }
        Invoke("Resize", resizeCD);
    }

    private void Resize()
    {
        if (transform.localScale.x >= 7.5f)
        {
            growing = false;
        }
        else if (transform.localScale.x <= 0.9f)
        {
            growing = true;
        }

        if (growing)
        {
            transform.localScale += new Vector3(multiplier * 0.5f, multiplier * 0.5f, multiplier * 0.5f);
        }
        else
        {
            transform.localScale -= new Vector3(multiplier, multiplier, multiplier);
        }

        Invoke("Resize", resizeCD);
    }
}
