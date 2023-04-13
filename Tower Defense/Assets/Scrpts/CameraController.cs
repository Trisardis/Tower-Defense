using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    // Camera movement variable initialization
    private bool movementAllowed = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minimumX = 30f;
    public float maximumX = 30f;
    public float minimumY = 10f;
    public float maximumY = 80f;
    public float minimumZ = 0f;
    public float maximumZ = 80f;


    // Update is called once per frame
    void Update()
    {
        // Locks screen movement if escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
            movementAllowed = !movementAllowed;
        if (!movementAllowed)
            return;

        // Camera moves in the a given direction based on key or mouse input
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }


        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        // pos.x -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        // pos.z -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        // pos.x = Mathf.Clamp(pos.x, minimumX, maximumX);
        pos.y = Mathf.Clamp(pos.y, minimumY, maximumY);
        // pos.z = Mathf.Clamp(pos.z, minimumZ, maximumZ);
        transform.position = pos;
    }
}

/*

*/