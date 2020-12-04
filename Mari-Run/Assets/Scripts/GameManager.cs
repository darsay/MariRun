using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int puntos;
    public Text puntosText;
    public bool pointsAdded;
    public PlayerController player;

    public bool start;
    public GameObject deathMenu;

    public int record;
    public GameObject recordGO;
    public bool recordSet;

    // Start is called before the first frame update
    void Start()
    {
        
        record = PlayerPrefs.GetInt("Record");
        Debug.Log(record);
        recordGO.GetComponent<Text>().text = (record + "m");
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        if(start){
            
            if(!player.dead){
                if(!pointsAdded)
                StartCoroutine(PointsPerDistance());

                puntosText.text = puntos.ToString() + 'm';
            }
        }      

        if(player.dead){
            if(puntos>record && !recordSet){
                recordSet = true;
                PlayerPrefs.SetInt("Record", puntos-1);
                record = PlayerPrefs.GetInt("Record");
                recordGO.GetComponent<Text>().text = record + "m";
                PlayerPrefs.Save();
            }
            
            deathMenu.SetActive(true);
        }
    }

    IEnumerator PointsPerDistance(){
        pointsAdded = true;
        yield return new WaitForSeconds(5/player.speed);
        puntos++;
        pointsAdded = false;
    }

    public void Restart(){
        
        SceneManager.LoadScene(0);
    }
}
