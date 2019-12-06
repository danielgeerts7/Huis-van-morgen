using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMobileMessage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mobile;
    private BoxCollider collider;
    public GameObject player;

    public string text;
    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            mobile.transform.GetChild(0).gameObject.SetActive(true);
            mobile.GetComponentInChildren<MobileController>().SetMessage(text);
        }
    }

}
