using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clear_me : MonoBehaviour
{
    [SerializeField]
    event_object send;

    [SerializeField]
    TMP_InputField t;
    // Start is called before the first frame update
    void Start()
    {
        //send.addListener(() => t.text = "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
