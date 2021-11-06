using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.visible = !Cursor.visible;
    }
}
