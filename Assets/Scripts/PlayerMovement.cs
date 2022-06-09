using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public Transform vrCamera;

    public float speed = 2.0f;   

    private CharacterController cc;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire3") == 1)
        {
            Vector3 frw = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(frw * speed);

        }        
        
    }


}
