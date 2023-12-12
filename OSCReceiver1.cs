using UnityEngine;
using System.Collections;

public class OSCReceiver1 : MonoBehaviour
{
    public string RemoteIP = "127.0.0.1";
    public int SendToPort = 8000;
    public int ListenerPort = 8001;
    public Transform controller;
    private OSC handler;



    string message;

    int a;
    // Use this for initialization
    void Start()
    {
        a = 1;


        //Initializes on start up to listen for messages
        //make sure this game object has both UDPPackIO and OSC script attached
        UDPPacketIO udp = GetComponent("UDPPacketIO") as UDPPacketIO;
        Debug.Log("a");
        udp.Init(RemoteIP, SendToPort, ListenerPort);
        handler = GetComponent("OSC") as OSC;
        handler.Init(udp);


        

        handler.SetAllMessageHandler(Example1);
        Debug.Log("start");
        //handler.SetAddressHandler("/test1", Example1);
        handler.SetAddressHandler("/ID", ID);
    }

    //these fucntions are called when messages are received
    public void Example1(OscMessage oscMessage)
    {
        //How to access values: 
        //oscMessage.Values[0], oscMessage.Values[1], etc
        message = OSC.OscMessageToString(oscMessage);
        Debug.Log("Called Example One > " + OSC.OscMessageToString(oscMessage));
    }

    //these fucntions are called when messages are received
    public void ID(OscMessage oscMessage)
    {
        //How to access values: 
        //oscMessage.Values[0], oscMessage.Values[1], etc
        OscMessage message;
        

        message = new OscMessage();
        message.Address = "/ID";
        message.Values.Add(a);

        
        handler.Send(message);


        Debug.Log("Get cellphone" + a);
        a++;
        //Debug.Log("Called Example Two > " + OSC.OscMessageToString(oscMessage));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            //handler.Send(OSC.StringToOscMessage("1234"));
            //print("A key was pressed");

            OscMessage message;

            message = new OscMessage();
            message.Address = "/volume";
            message.Values.Add("A");
            handler.Send(message);

            Debug.Log("send : " + "A");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            //handler.Send(OSC.StringToOscMessage("1234"));
            //print("A key was pressed");

            OscMessage message;

            message = new OscMessage();
            message.Address = "/volume";
            message.Values.Add("D");
            handler.Send(message);

            Debug.Log("send : " + "D");
        }

        //if (message == "/ID start")
        //{

        //    OscMessage message;

        //    message = new OscMessage();
        //    message.Address = "/ID";
        //    message.Values.Add(a);
        //    handler.Send(message);


        //    Debug.Log("Get cellphone" + a);
        //    a++;
        //}

    }

    
}
