using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Author: Daniël Geerts
/// Abstract of SuperCard
/// </summary>
public abstract class SuperCard : MonoBehaviour
{
    public Button button;

    public abstract void SelectCard();
}
