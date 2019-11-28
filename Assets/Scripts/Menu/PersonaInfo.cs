using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonaInfo : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public string age;
    public string biography;
    public string[] limitations;
    public Sprite featuredImage;
    public enum Sex { Man, Woman };
    public Sex sex;

    public string getFullName() {
        return firstName + " " + lastName;
    }
}
