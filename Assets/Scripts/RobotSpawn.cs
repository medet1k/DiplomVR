using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Sprites;
using UnityEngine.SceneManagement;
public class RobotSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform camera;
    public PrefabsArray mc;
    public Transform parent;


    private bool IsTouch;
    private GameObject Head;
    private GameObject Body;
    private GameObject Arms;
    private GameObject Legs;
    private GameObject RobotAnim;
    private bool Spawn = false;
    [SerializeField] Transform HeadSpawnPos;
    [SerializeField] Transform ArmsSpawnPos;
    [SerializeField] Transform BodySpawnPos;
    [SerializeField] Transform LegsSpawnPos;
    [SerializeField] Transform RobotAnimSpawn;
    private GameObject robot;
    private List<GameObject> createdPrefabs = new List<GameObject>();
    

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(SpawnRobotButton());
    }


    private IEnumerator SpawnRobotButton()
    {

        yield return new WaitForSeconds(0.5f);
        RaycastHit _hit;
        if (Physics.Raycast(camera.position, camera.forward, out _hit))
        {

            if (_hit.collider.gameObject.name == "HeadImage" && Input.GetAxis("Fire1") == 1)
            {


                if (Head == null)
                {
                    Head = mc.RobotDetails[0];
                    Instantiate(Head, HeadSpawnPos.position, HeadSpawnPos.rotation);
                    createdPrefabs.Add(Head);
                    Debug.Log(createdPrefabs.Count);
                }
                

            }

            if (_hit.collider.gameObject.name == "ArmsImage" && Input.GetAxis("Fire1") == 1)
            {

                if (Arms == null)
                {
                    Arms = mc.RobotDetails[2];
                    Instantiate(Arms, ArmsSpawnPos.position, ArmsSpawnPos.rotation);
                    createdPrefabs.Add(Arms);
                    Debug.Log(createdPrefabs.Count);

                }
            }

            if (_hit.collider.gameObject.name == "BodyImage" && Input.GetAxis("Fire1") == 1)
            {

                if (Body == null)
                {
                    Body = mc.RobotDetails[1];
                    Instantiate(Body, BodySpawnPos.position, BodySpawnPos.rotation);
                    createdPrefabs.Add(Body);
                    Debug.Log(createdPrefabs.Count);
                }
            }

            if (_hit.collider.gameObject.name == "LegsImage" && Input.GetAxis("Fire1") == 1)
            {
                
                if (Legs == null)
                {
                    Legs = mc.RobotDetails[3];
                    Instantiate(Legs, LegsSpawnPos.position, LegsSpawnPos.rotation);
                    createdPrefabs.Add(Legs);
                    Debug.Log(createdPrefabs.Count);
                }
            }


            if (_hit.collider.gameObject.tag == "Testing" && Input.GetAxis("Fire1") == 1)
            {
                if(Legs != null && Body != null && Arms != null && Head != null)
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("RobotDatails"));
                    }
                    if (RobotAnim == null)
                    {


                        RobotAnim = mc.Robots[0];
                        Instantiate(RobotAnim, RobotAnimSpawn.position, RobotAnimSpawn.rotation);
                    }
                }
                
            }

            if (_hit.collider.gameObject.name == "ClearButton" && Input.GetAxis("Fire1") == 1)
            {

                
                Destroy(GameObject.FindGameObjectWithTag("RobotDatails"));
                Debug.Log(GameObject.FindGameObjectWithTag("RobotDatails"));
                Destroy(GameObject.FindGameObjectWithTag("RobotsNumber"));

                Head = null;
                Body = null;
                Arms = null;
                Legs = null;
                Spawn = true;
                RobotAnim = null;


            }
            
        }

    }

}
