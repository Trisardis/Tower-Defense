using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    // Camera movement variable initialization
    private bool movementAllowed = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minimumX = -30f;
    public float maximumX = 30f;
    public float minimumY = 10f;
    public float maximumY = 80f;
    public float minimumZ = -80f;
    public float maximumZ = 80f;
    public float speedH = 2f;
    public float speedV = 2f;

    private float yaw = 0.0f;
    private float pitch = 90f;
    // private Camera ZoomCamera;

    // private void Start()
    // {
    //     ZoomCamera = Camera.main;
    // }

    // Update is called once per frame
    void Update()
    {
        // Locks screen movement if escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
            movementAllowed = !movementAllowed;
        if (!movementAllowed)
            return;

        // Camera moves in the a given direction based on key or mouse input
        if (Input.GetKey("w"))
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey("s"))
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey("d"))
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey("a"))
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);


        float scroll = Input.GetAxis("Mouse ScrollWheel");
        // if (ZoomCamera.orthographic)
        //     ZoomCamera.orthographic -= Input.GetAxis("Mouse ScrollWheel)") * scrollSpeed;
        // else
        //     ZoomCamera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel)") * scrollSpeed;

        Vector3 pos = transform.position;

        pos.x -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.z -= scroll * 1000 * scrollSpeed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, minimumX, maximumX);
        pos.y = Mathf.Clamp(pos.y, minimumY, maximumY);
        pos.z = Mathf.Clamp(pos.z, minimumZ, maximumZ);
        transform.position = pos;

        // Adjust camera angle
        
        // if (Input.GetMouseButtonDown(1))
        if (Input.GetKey("q"))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");

            pitch = Mathf.Clamp(pitch, 45f, 90f);

            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
}