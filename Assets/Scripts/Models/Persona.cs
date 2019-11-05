using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public string age;
    public string bio;
    public Sprite featuredImage;
    public enum Sex { Man, Woman };
    public Sex sex;

    public string getFullName() {
        return firstName + " " + lastName;
    }
}
