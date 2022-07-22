using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody playerRigidBody;

    public bool gravityStatus;
    public float zForce;
    public float xForce;
    public bool isInput;
    public string inputDirection;

    void Start()    // called before the first frame update
    {
        applyGravity();
        Debug.Log("Gravity Status: " + gravityStatus);
    }

    void Update()   // called once per frame
    {
        updateInput();
    }
    
    void FixedUpdate()  // named "Fixed"Update due to physics manipulation (Time.deltaTime?)
    {
        // applies force along z-axis to playerRigidBody
        applyZForce();

        // applies force along x-axis to playerRigidBody
        movePlayer();
    }

    /* movement:
     - check for updated input in Update()
     - store input
     - add force to stored input in FixedUpdate() */
    void movePlayer()
    {
        if (getIsInput() && getInputDirection() == "left")
        {
            setXForce(-xForce);
            applyXForce();
        }
        if (getIsInput() && getInputDirection() == "right")
        {
            setXForce(xForce);
            applyXForce();
        }
    }

    void updateInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            setIsInput(true);
            setInputDirection("left");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            setIsInput(true);
            setInputDirection("right");
        }
        else
        {
            setIsInput(false);
            setInputDirection(null);
        }
    }

    string getInputDirection()
    {
        return inputDirection;
    }

    void setInputDirection(string input)
    {
        try
        {
            inputDirection = input;
        }
        catch
        {
            Debug.Log("error setting input direction");
        }
    }

    bool getIsInput()
    {
        return isInput;
    }

    void setIsInput(bool status)
    {
        isInput = status;
    }

    // xForce
    void applyXForce()
    {
        playerRigidBody.AddForce(deltaTimeMultiplier(getXForce()), 0, 0);
    }

    float getXForce()
    {
        return xForce;
    }

    void setXForce(float force)
    {
        xForce = force;
    }

    // zForce
    void applyZForce()
    {
        playerRigidBody.AddForce(0, 0, deltaTimeMultiplier(getZForce()));
    }

    float getZForce()
    {
        return zForce;
    }

    void setZForce(float force)
    {
        zForce = force;
    }

    // gravity
    void applyGravity()
    {
        playerRigidBody.useGravity = getGravityStatus();
    }

    bool getGravityStatus()
    {
        return gravityStatus;
    }

    void setGravityStatus(bool status)
    {
        gravityStatus = status;
    }

    float deltaTimeMultiplier(float input)  // multiplies input by Time.deltaTime to adjust framerate across cpu performance variation
    {
        float deltaInput = input * Time.deltaTime;
        return deltaInput;
    }

}
