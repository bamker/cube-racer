using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float forwardForce = 2000f;
    public float sidewaysForce = 100f;

    void Start()    // called before the first frame update
    {
        rigidBody.useGravity = true;
    }

    void FixedUpdate()  // named "Fixed"Update due to physics manipulation (Time.deltaTime?)
    {
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rigidBody.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}