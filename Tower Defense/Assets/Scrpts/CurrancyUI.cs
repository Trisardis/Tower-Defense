using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrancyUI : MonoBehaviour
{
    public Text currencyText;
    
    void Update () 
    {
        currencyText.text = "$" + PlayerStats.Currancy.ToString();
    }
}
