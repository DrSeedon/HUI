using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelector : MonoBehaviour
{
    public int CountToLeave = 1;
    // Start is called before the first frame update
    void Start()
    {
        while(transform.childCount > CountToLeave)
        {
            Transform childToDestroy = transform.GetChild(Random.Range(0, transform.childCount));
            DestroyImmediate(childToDestroy.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
