using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{

    public Text Text;

    public LeanToken Token;

    // Start is called before the first frame update
    void Start()
    {
        Text = GetComponent<Text>();
        Text.text = "Level: " + Main.Level.ToString();

        Token.Value = Main.Level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
