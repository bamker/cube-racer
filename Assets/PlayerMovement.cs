using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody playerRigidBody;
    public bool gravityStatus;
    public float ZForce;
    public float xForce;
    public bool inputDirection;

    void Start()    // called before the first frame update
    {
        setGravity(gravityStatus);
        Debug.Log("Gravity Status: " + gravityStatus);
    }
    
    void Update()   // called once per frame
    {
        getInputDirection();
    }
    
    void FixedUpdate()  // named "Fixed"Update due to physics manipulation (Time.deltaTime?)
    {
        // applies force to move playerRigidBody forward
        addZForce(ZForce);

        // applies force to playerRigidBody based on keyboard input
        setInputDirection();
    }

    bool getInputDirection()
    {
        return (inputDirection) ? Input.GetKeyDown(KeyCode.D) : Input.GetKeyDown(KeyCode.A);
    }

    void setInputDirection()    // sets inputDirection based on keyboard input
    {
        if (getInputDirection())
        {
            addXForce(xForce);
        }
        else
        {
            addXForce(-xForce);
        }
    }

    void addZForce(float force)
    {
        playerRigidBody.AddForce(0, 0, deltaTimeMultiplier(force));
    }

    void addXForce(float force)
    {
        playerRigidBody.AddForce(deltaTimeMultiplier(force), 0, 0);
    }

    void setGravity(bool status)
    {
        playerRigidBody.useGravity = status;
    }

    float deltaTimeMultiplier(float input)  // multiplies input by Time.deltaTime to adjust framerate across cpu performance variation
    {
        float deltaInput = input * Time.deltaTime;
        return deltaInput;
    }

}
