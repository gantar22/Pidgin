using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onclik : MonoBehaviour
{
    [SerializeField]
    sync_event image_out;

    [SerializeField]
    int_var local_player;

    [SerializeField]
    GameObject preview;

    public int id;
    // Start is called before the first frame update
    void Start()
    {
        id = transform.GetSiblingIndex();
    }

    public void activate()
    {
        image_out.Invoke(0.0f, id, local_player.val, true);
        preview.GetComponent<Image>().sprite = transform.parent.parent.parent.GetComponent<list_of_them>().them[id];
        preview.SetActive(true);
        foreach(Transform t in transform.parent)
        {
            if(t != transform) t.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
