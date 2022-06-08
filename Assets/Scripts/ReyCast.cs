using UnityEngine;
using System.Collections;
public class ReyCast : MonoBehaviour
{

    public Transform camera;
    private bool IsTouch;
    public int _scene;



    // Update is called once per frame
    void Update()
    {
        StartCoroutine(TouchButton());
    }



    private IEnumerator TouchButton()
    {
        RaycastHit _hit;
        if (Physics.Raycast(camera.position, camera.forward, out _hit))
        {

            if (_hit.collider.gameObject.tag == "asd" && Input.GetAxis("Fire1") == 1)
            {
                yield return new WaitForSeconds(0.5f);
                Debug.Log("Work");

            }

        }
    }



}
