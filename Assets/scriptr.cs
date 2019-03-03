using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scriptr : MonoBehaviour
{
    TMP_Text t;

    [SerializeField]
    GameObject dial;

    [SerializeField]
    GameObject Images;

    [SerializeField]
    bool_var has_talked;

    [SerializeField]
    bool_var has_heard;

    [SerializeField]
    bool_var host;

    [SerializeField]
    event_object send;

    [SerializeField]
    sync_event script_events;

    [SerializeField]
    sync_event script_events_in;

    [SerializeField]
    int_var player_id;

    [SerializeField]
    GameObject new_pos;

    [SerializeField]
    sync_event send_img;

    [SerializeField]
    sync_event recieve_img;

    [SerializeField]
    sync_event send_msg;

    [SerializeField]
    sync_event rec_mesg;

    [SerializeField]
    GameObject this_image;

    [SerializeField]
    GameObject not_this_image;

    [SerializeField]
    int this_id;

    bool got_it = false;

    [SerializeField]
    GameObject this_image2;

    [SerializeField]
    GameObject not_this_image2;

    [SerializeField]
    int this_id2;

    bool got_it2 = false;

    bool sent_img = false;

    bool recieve_image = false;

    float timer = 0;

    bool love = false;

    [SerializeField]
    event_object begin_hoc;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<TMP_Text>();
        begin_hoc.addListener(() => StartCoroutine(go()));
        script_events_in.e.AddListener((f, o, i) =>
        { if ((int)o == 1) { StartCoroutine(veal_images()); } else { if ((int)o == 2) { StartCoroutine(non_host_time()); }  if ((int)o == 3) { StartCoroutine(fun_time()); } }
        }
        );
        send_img.e.AddListener((f, o, i) => sent_img = true);
        recieve_img.e.AddListener((f, o, i) => recieve_image = true);
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    IEnumerator go()
    {
        yield return new WaitForSeconds(1.2f);
        t.text = "";
        foreach(char c in "Hello.")
        {
            t.text += c;
            yield return new WaitForSeconds(.075f + Random.value * .05f);
        }
        yield return new WaitForSeconds(1);
        t.text += "\n";
        foreach (char c in "Say Hello to your partner.")
        {
            t.text += c;
            yield return new WaitForSeconds(.075f + Random.value * .05f);
        }
        yield return new WaitForSeconds(.1f);
        dial.SetActive(true);
        yield return new WaitForSeconds(3f);
        t.text = "";
        yield return new WaitUntil(() => has_heard.val && has_talked.val);
        yield return new WaitForSeconds(2f);
        foreach (char c in host.val ? "Ask them about themselves." : "Listen carefully.")
        {
            t.text += c;
            yield return new WaitForSeconds(.075f + Random.value * .05f);
        }
        timer = 0;
        send.addListener(() => timer = 0);
        yield return new WaitUntil(() => timer > 10f);
        t.text = "";
        if (host)
        {
            script_events.Invoke(0, 1, player_id);
            StartCoroutine(veal_images());
        }

    }

    IEnumerator veal_images()
    {
        yield return null;
        Images.SetActive(true);
        t.fontSize = 30;
        transform.position = new_pos.transform.position;
        foreach (char c in "select an image to show it to your partner. \n Click \"Hide\" to stop showing that picture.")
        {
            t.text += c;
            yield return new WaitForSeconds(.005f + Random.value * .05f);
        }
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => sent_img && recieve_image);
        t.text = "";
        if(host)
        {
            this_image.SetActive(true);
            not_this_image.SetActive(false);

            foreach (char c in "Try to make your partner show this image.")
            {
                t.text += c;
                yield return new WaitForSeconds(.005f + Random.value * .05f);
            }
            bool halt = false;
            recieve_img.e.AddListener((f, o, i) => { if ((int)o == this_id) halt = true; });
            yield return new WaitUntil(() => halt);
            script_events.Invoke(0f, 2, player_id);
            StartCoroutine(non_host_time());
        } else
        {
            t.text = "";
            foreach (char c in "Your partner is trying to have you show them a specific image.")
            {
                t.text += c;
                yield return new WaitForSeconds(.005f + Random.value * .05f);
            }
        }
        
    }

    IEnumerator non_host_time()
    {
        yield return null;
        if(!host)
        {
            this_image2.SetActive(true);
            not_this_image2.SetActive(false);
            t.text = "";
            foreach (char c in "This time, you have to get your partner to show you this image.")
            {
                t.text += c;
                yield return new WaitForSeconds(.005f + Random.value * .05f);
            }
            bool halt = false;
            recieve_img.e.AddListener((f, o, i) => { if ((int)o == this_id2) halt = true; });
            yield return new WaitUntil(() => halt);
            script_events.Invoke(0f, 3, player_id);
            StartCoroutine(fun_time());
        } else
        {
            t.text = "";
            foreach (char c in "It's your turn to guess the image.")
            {
                t.text += c;
                yield return new WaitForSeconds(.005f + Random.value * .05f);
            }
        }
    }

    IEnumerator fun_time()
    {
        t.text = "";
        yield return null;
        if(host)
        {
            foreach (char c in "Get your partner to say \"I love you\".")
            {
                t.text += c;
                yield return new WaitForSeconds(.005f + Random.value * .05f);
            }
            rec_mesg.e.AddListener((f, o, i) => { if (((string)o).ToLower().Contains("i love you")) love = true; }); 
            yield return new WaitUntil(() => love);
        } else
        {
            foreach (char c in "Your partner is try to get you to say something.")
            {
                t.text += c;
                yield return new WaitForSeconds(.005f + Random.value * .05f);
            }
            send_msg.e.AddListener((f, o, i) => { if (((string)o).ToLower().Contains("i love you")) love = true; });
            yield return new WaitUntil(() => love);
        }
        t.text = "";
        foreach (char c in "Now look at you're partner.")
        {
            t.text += c;
            yield return new WaitForSeconds(.005f + Random.value * .05f);
        }
    }
}
