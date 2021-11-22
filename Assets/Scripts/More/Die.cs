using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Die : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Deading()
    {
        Invoke("ded", 1f);
    }

    public void ded()
    {
        if (SceneManager.GetActiveScene().name == "Endless")
        {

            SceneManager.LoadScene("End");

        }
        else
        {

            SceneManager.LoadScene("Scene1");
        }
    }

}
