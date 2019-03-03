using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find_match : MonoBehaviour
{

    [SerializeField]
    event_object login;

    [SerializeField]
    client_var client;
    // Start is called before the first frame update
    void Start()
    {
        login.addListener(() => client.val.find_match());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
