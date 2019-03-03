using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class fill_text : MonoBehaviour
{
    [SerializeField]
    string_var text;

    [SerializeField]
    sync_event text_in;

    [SerializeField]
    sync_event text_out;

    [SerializeField]
    event_object send;

    [SerializeField]
    int_var local_id;

    [SerializeField]
    TMPro.TMP_Text t_comp;

    [SerializeField]
    bool_var has_talked;

    [SerializeField]
    bool_var has_heard;


    esperanto esp;
    // Start is called before the first frame update
    void Start()
    {
        send.addListener(() => { text_out.Invoke(0.0f, (object)text.val, local_id, true); add_text(text.val, true); });
        text_in.e.AddListener((f, o, i) => add_text((string)o, false));
        esp = new esperanto();
        esp.init();
        StartCoroutine(send_on_enter());
        has_talked.val = false;
        has_heard.val = false;
    }

    IEnumerator send_on_enter()
    {
        while(true)
        {       
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
            print("a\"\"\"\"\"");
            send.Invoke();
            yield return null;
        }
    }

    void add_text(string s, bool local)
    {
        if(!local)
        {
            has_heard.val = true;
            esp.translate(s, put(false));
            return;
        }
        has_talked.val = true;
        put(true)(s);

    }

    Action<string> put(bool local)
    {
        return (s =>
        {
            t_comp.text += "\n" + (local?"<color=#000000><align=\"right\">" : "<color=#DCCFEC><align=\"left\">") + s;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
