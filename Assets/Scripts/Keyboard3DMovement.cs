// Attach this script to a GameObject in order to move it with a keyboard.
// The GameObject needs to have a Rigidbody in order for this scrip to work.
// Also make sure that isKinematic Rigidbody property is unchecked.

using UnityEngine;

public class Keyboard3DMovement : MonoBehaviour
{
    private Rigidbody rbody;
    public float movementSpeed = 800;
    public float rotationSpeed = 100.0f;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        if (rbody == null) Debug.Log("Missing a Rigidbody in " + name);
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
