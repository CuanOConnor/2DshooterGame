using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;

    public void LoadLevel(string lvlname)
    {
        Application.LoadLevel(lvlname);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
