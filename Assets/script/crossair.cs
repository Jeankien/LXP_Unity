using UnityEngine;
using UnityEngine.InputSystem;

public class Crosshair : MonoBehaviour
{
    public float height = 1f;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        Vector3 mouseScreen = Mouse.current.position.ReadValue();

        float distanceToCamera = Camera.main.transform.position.y - height;

        mouseScreen.z = distanceToCamera;
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        mouseWorld.y = height;

        transform.position = mouseWorld;
    }
}
