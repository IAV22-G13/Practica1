using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject ratas;

    [SerializeField]
    GameObject perro;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
        if (Input.GetKeyDown("t"))
        {
            for (int i = 1; i < ratas.transform.GetChildCount(); i++)
            {
                Destroy(ratas.transform.GetChild(i).gameObject);
                perro.GetComponent<UCM.IAV.Movimiento.Percepcion>().emptyList();
            }  
        }
    }
}
