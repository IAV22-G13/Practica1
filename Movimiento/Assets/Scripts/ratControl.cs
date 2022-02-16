using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class ratControl : MonoBehaviour
    {

        private void Start()
        {
            this.GetComponent<Wander>().enabled = true;
        }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("space"))
            {
                this.GetComponent<Wander>().enabled = false;
                this.GetComponent<Arrive>().enabled = true;
                this.GetComponent<Separation>().enabled = true;
            }
            if (Input.GetKeyUp("space"))
            {
                this.GetComponent<Wander>().enabled = true;
                this.GetComponent<Arrive>().enabled = false;
                this.GetComponent<Separation>().enabled = false;
            }

        }
    }
}
