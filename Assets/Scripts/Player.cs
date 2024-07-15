using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
   
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //check if space is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
            
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    //fixedupdate is called once every physic update
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position,0.1f,playerMask).Length==0)
        {
            return;
        }
        if (jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up * 8, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
        
    }
    

}
