using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveGameObject : MonoBehaviour
{

    public Transform camera;
    private bool IsTouch;
    public int _scene;
    // Start is called before the first frame update
    void Update()
    {
        StartCoroutine(TouchButton());
    }



    private IEnumerator TouchButton()
    {
        RaycastHit _hit;
        if (Physics.Raycast(camera.position, camera.forward, out _hit))
        {

            if (_hit.collider.gameObject.tag == "Robots" && Input.GetAxis("Fire1") == 1)
            {
                Debug.Log("IsTouch");
                yield return new WaitForSeconds(1);
                IsTouch = true;
                DontDestroyOnLoad(this);
                OpenScene(_scene);

                
            }
            if (_hit.collider.gameObject.tag != "Robots")
            {
                IsTouch = false;

                Debug.Log("Didnt touch");
            }
        }
    }


    private void OpenScene(int _sceneNumber)
    {

        SceneManager.LoadScene(_sceneNumber);

    }
}
