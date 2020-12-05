using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject distance;
    // Start is called before the first frame update
    void Start()
    {
        distance.GetComponent<RectTransform>().localPosition = new Vector3(distance.GetComponent<RectTransform>().localPosition.x, -70.6f, distance.GetComponent<RectTransform>().localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
