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

        private float r;
        private float time, changeTime;
        [SerializeField]
        float minCambGiro, maxCambGiro, tiempoGiro;

        // Start is called before the first frame update
        void Start()
        {
            _tr = this.transform;
            changeTime = Random.Range(minCambGiro, maxCambGiro);
            r = Random.Range(-1.0f, 1.0f);
            time = 0;
        }

        public override Direccion GetDireccion()
        {
            time += Time.deltaTime;
            Direccion dir = new Direccion();

            _tr.rotation.ToAngleAxis(out float x, out Vector3 y);
            float degrees = x * y.y;
            agente.velocidad = maxSpeed * agente.OriToVec(degrees);

            if (time > changeTime)
            {
                time = 0;
                changeTime = Random.Range(minCambGiro, maxCambGiro);
                r = Random.Range(-1, 2);
            }
            if(time < tiempoGiro)
            {
                float rot = Random.Range(0.0f, maxRotation);
                agente.rotacion = rot * r;
            }

            return dir;
        }
    }
}
