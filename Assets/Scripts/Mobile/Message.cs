using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update

    public void ChangeText(Text t)
    {
        text = t;
    }
}
