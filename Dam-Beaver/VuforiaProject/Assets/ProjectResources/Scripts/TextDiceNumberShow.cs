using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDiceNumberShow : MonoBehaviour
{
    Text text;
    public static int dice_number;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = dice_number.ToString();
    }
}
