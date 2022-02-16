using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    public class Arrive : ComportamientoAgente
    {   
        [SerializeField]
        float maxAcceleration;

        [SerializeField]
        float maxSpeed;

        [SerializeField]
        float targetRadius;

        [SerializeField]
        float slowRadius;

        [SerializeField]
        float timeToTarget = 0.1f;

        public override Direccion GetDireccion()
        {

            Direccion result = new Direccion();

            Vector3 direction = objetivo.transform.position - this.transform.position;
            float distance = direction.magnitude;

            if (distance < targetRadius)
                return new Direccion();

            float targetSpeed;

            if (distance > slowRadius)
            {
                targetSpeed = maxSpeed;
            }
            else
                targetSpeed = maxSpeed * distance / slowRadius;

            Vector3 targetVelocity;

            targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;

            result.lineal = targetVelocity - agente.gameObject.GetComponent<Rigidbody>().velocity;
            result.lineal /= timeToTarget;

            if (result.lineal.magnitude > maxAcceleration)
            {
                result.lineal.Normalize();
                result.lineal *= maxAcceleration;
            }
            result.lineal.y = 0;
            agente.transform.rotation = Quaternion.LookRotation(result.lineal, Vector3.up);

            return result;
        }
    }
}
