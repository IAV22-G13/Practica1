using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class Separation : ComportamientoAgente
    {

        List<Transform> ratas = new List<Transform>();

        [SerializeField]
        float minDistance;

        [SerializeField]
        float decayCoefficient;

        private void Start()
        {
            Transform parent = this.transform.parent;
            int numratas = parent.GetChildCount();
            for (int i = 0; i < numratas; i++)
            {
                if (parent.GetChild(i) != this.transform)
                    ratas.Add(parent.GetChild(i));
            }
        }

        public override Direccion GetDireccion()
        {
            
            Direccion result = new Direccion();

            for (int i = 0; i < ratas.Count; i++)
            {
                Vector3 direccion = this.transform.position - ratas[i].position;
                float distance = direccion.magnitude;

                if (distance < minDistance)
                {
                    float strenght = decayCoefficient / (distance * distance);
                    if (strenght > agente.aceleracionMax)
                        strenght = agente.aceleracionMax;

                    direccion.Normalize();
                    result.lineal += direccion * strenght;
                }
            }
            result.lineal.y = 0;
            result.angular = 0;
            return result;
        }
    }
}
