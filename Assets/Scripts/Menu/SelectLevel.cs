﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{

    public Button ButtonStart;
    public InputField Text;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToLevel()
    {

        Main.TardisMode = true;
        int Level = int.Parse(Text.GetComponent<InputField>().text);
        Main.Level = Level;

        SceneManager.LoadScene("Scene" + Level);
    }
}