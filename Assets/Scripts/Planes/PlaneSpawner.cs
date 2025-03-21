using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject myPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 150; i++)
        {
            
                Instantiate(myPrefab, new Vector3(i, i * 10, i * 5), Quaternion.identity);
            

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
