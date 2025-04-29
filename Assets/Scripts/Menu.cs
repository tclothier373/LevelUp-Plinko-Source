using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void toggle(){
        menu.SetActive(!menu.activeSelf);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
