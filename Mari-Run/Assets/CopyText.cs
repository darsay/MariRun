using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyText : MonoBehaviour
{
    public Text textToCopy;
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = textToCopy.text;
    }
}
