using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int puntos;
    public Text puntosText;
    public bool pointsAdded;
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.dead){
            if(!pointsAdded)
            StartCoroutine(PointsPerDistance());

            puntosText.text = puntos.ToString() + 'm';
        }
        
    }

    IEnumerator PointsPerDistance(){
        pointsAdded = true;
        yield return new WaitForSeconds(5/player.speed);
        puntos++;
        pointsAdded = false;
    }
}
