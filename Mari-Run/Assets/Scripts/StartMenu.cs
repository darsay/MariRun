using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameManager gM;
    public GameObject distance;
    public GameObject startCamera;
    public GameObject gameCamera;
    public bool activateGameCam;

    public GameObject title;
    public GameObject shadow;

    public MariSounds mariS;
    // Start is called before the first frame update
    void Start()
    {
        startCamera.GetComponent<Camera>().enabled = true;
        startCamera.GetComponent<AudioListener>().enabled = true;
        gameCamera.GetComponent<Camera>().enabled = false;
        gameCamera.GetComponent<AudioListener>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.touchCount>=1 || Input.GetKeyDown(KeyCode.Mouse0)) && !gM.start){
            gM.start = true;
            Destroy(title);
            distance.SetActive(true);
            mariS.playStart();
            gameObject.GetComponent<Text>().enabled = false;
            Destroy(shadow);
            
        }

        if(gM.start && !activateGameCam){
            startCamera.transform.position = Vector3.Lerp(startCamera.transform.position, gameCamera.transform.position, 10 * Time.deltaTime);
            startCamera.transform.rotation = Quaternion.Lerp(startCamera.transform.rotation, gameCamera.transform.rotation, 10 * Time.deltaTime);
            
            StartCoroutine(waitCam());
        }
    }

    IEnumerator waitCam(){
        yield return new WaitForSeconds(0.5f);

        activateGameCam = true;
        gameCamera.GetComponent<Camera>().enabled = true;
        gameCamera.GetComponent<AudioListener>().enabled = true;
        startCamera.GetComponent<Camera>().enabled = false;
        startCamera.GetComponent<AudioListener>().enabled = false;
    }
}
