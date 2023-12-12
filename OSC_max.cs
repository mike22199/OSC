using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSC_max : MonoBehaviour
{
    public OSC OSC1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void trigger()
    {
        OscMessage message;

        message = new OscMessage();
        message.Address = "/name";
        message.Values.Add(1);
        OSC1.Send(message);

        Debug.Log("send : " + "start");
    }
}
