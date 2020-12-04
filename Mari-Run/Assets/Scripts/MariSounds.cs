using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariSounds : MonoBehaviour
{
    AudioSource fuente;
    public AudioClip [] sonidosComienzo;
    public AudioClip [] sonidosMuerte;
    public AudioClip [] sonidosSalto;

    // Start is called before the first frame update
    void Start()
    {
        fuente =  GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playStart(){
        int idx = Random.Range(0, sonidosComienzo.Length);
        fuente.clip = sonidosComienzo[idx];
        fuente.Play();
    }

    public void playDeath(){
        int idx = Random.Range(0, sonidosMuerte.Length);
        fuente.clip = sonidosMuerte[idx];
        fuente.Play();
        StartCoroutine(WaitDest());
    }

    IEnumerator WaitDest(){
        yield return new WaitForSeconds(3);
        fuente.enabled = false;
    }

}
