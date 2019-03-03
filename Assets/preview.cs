using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preview : MonoBehaviour
{
    [SerializeField]
    sync_event image_out;

    [SerializeField]
    GameObject who_to_activate;

    [SerializeField]
    int_var local_id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void activate()
    {
        image_out.Invoke(.0f, -1, local_id,true);
        foreach(Transform t in who_to_activate.transform)
        {
            t.gameObject.SetActive(true);
        }
        transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
