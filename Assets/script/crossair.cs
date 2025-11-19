using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        Vector3 mouseScreen = Mouse.current.position.ReadValue();
        mouseScreen = new Vector3(mouseScreen.x, mouseScreen.y, Camera.main.transform.position.y);

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);
        

        transform.position = mouseWorld;
    }
}