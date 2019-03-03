using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class review : MonoBehaviour
{
    [SerializeField]
    sync_event image_in;

    [SerializeField]
    list_of_them list_of;
    // Start is called before the first frame update
    void Start()
    {
        image_in.e.AddListener((f, o, i) => { print($"index {(int)o} + {GetComponent<Image>()}"); if ((int)o == -1) { GetComponent<Image>().enabled = false; } else { GetComponent<Image>().enabled = true;  GetComponent<Image>().sprite = list_of.them[(int)o]; } });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
