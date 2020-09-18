using UnityEngine;

public class Fly : MonoBehaviour
{
    public float movementSpeed = 800;
    public float rotationSpeed = 100.0f;
    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update the rigidbody's rotation
        float rotationFactor = rotationSpeed * Time.fixedDeltaTime;
        float pitch = Input.GetAxis("Vertical") * rotationFactor;
        float yaw = Input.GetAxis("Horizontal") * rotationFactor;
        float roll = Input.GetAxis("Roll") * rotationFactor;
        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(-pitch, yaw, roll); // To invert keys add a minus before pitch/yaw/roll
        rbody.rotation *= rotation;

        // Update the rigidbody's velocity
        Vector3 position = rbody.rotation * Vector3.forward;
        rbody.velocity = position * movementSpeed * Time.fixedDeltaTime;
    }
}
