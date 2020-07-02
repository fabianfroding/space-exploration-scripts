using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void FixedUpdate()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
        }
    }
}
