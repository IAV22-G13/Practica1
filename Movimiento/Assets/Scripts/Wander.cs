using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class Kinematiclander :
//    character: Static
//    maxSpeed: float

//# The maximum rotation speed we'd like, probably should be smaller
//# than the maximum possible, for a leisurely change in direction.

//    maxRotation: float

//    function getSteering() -> KinematicSteering0utput:
//result = new KinematicSteering0utput()

//        # Get velocity from the vector form of the orientation.
//result.velocity = maxSpeed * character.orientation.asVector()

//        # Change our orientation randomly.
//result.rotation = randomBinomial() * maxRotation

//        return result

namespace UCM.IAV.Movimiento
{
    public class Wander : ComportamientoAgente
    {
        private Transform _tr;  //Transform de la rata

        [SerializeField]        //Valores máximos de velocidad y rotacion
        float maxSpeed, maxRotation;

        private int r;
        private float time, changeTime;
        [SerializeField]
        float minCambGiro, maxCambGiro, tiempoGiro;

        // Start is called before the first frame update
        void Start()
        {
            _tr = this.transform;
            changeTime = Random.Range(minCambGiro, maxCambGiro);
            time = 0;
        }

        public override Direccion GetDireccion()
        {
            time += Time.deltaTime;
            Direccion dir = new Direccion();
            
            dir.lineal = maxSpeed * new Vector3(-Mathf.Cos(_tr.rotation.y), 0, Mathf.Sin(_tr.rotation.y));

            if (time > changeTime)
            {
                time = 0;
                changeTime = Random.Range(minCambGiro, maxCambGiro);
                r = Random.Range(-1, 2);
            }
            if(time<tiempoGiro)
                dir.angular = maxRotation * r;

            return dir;
        }
    }
}
