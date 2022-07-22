using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate for physics
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, 2000 * Time.deltaTime);
    }

    void setGravityStatus(bool status)
    {
        rb.useGravity = status;
        string gravityStatus = ("Gravity Status: " + status);
        Debug.Log(gravityStatus);
    }

}
