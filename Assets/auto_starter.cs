using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auto_starter : MonoBehaviour
{
    [SerializeField]
    event_object notify_parties;

    [SerializeField]
    int_var local_id;

    bool started = false;

    [SerializeField]
    event_object start_out;
    // Start is called before the first frame update
    void Start()
    {
        notify_parties.addListener(() => { if (!started && local_id == 1) { started = false; start_out.Invoke(); print("going"); } });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
