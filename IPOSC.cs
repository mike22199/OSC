using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IPOSC : MonoBehaviour
{
    public Button bntclick;
    public OSC osc1;
    public OSC osc2;
    public OSC osc3;
    public OSC osc4;

    public InputField PORT;

    public string a;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public void press()
    {
        OscMessage message;

        message = new OscMessage();
        message.Address = "/volume";
        message.Values.Add("A");
        osc1.Send(message);

        //osc2.Send(message);
        //osc3.Send(message);
        //osc4.Send(message);

        a = osc1.ToString();

        Debug.Log("send : "+"start");
        //SceneManager.LoadScene(sceneName: "OSC Unity Example");
    }
    
}
