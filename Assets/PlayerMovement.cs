using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float forwardForce = 500f;
    public float sidewaysForce = 500f;

    void Start()    // called before the first frame update
    {
        rigidBody.useGravity = true;
    }

    void FixedUpdate()  // named "Fixed"Update due to physics manipulation (Time.deltaTime?)
    {
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
    }
}
