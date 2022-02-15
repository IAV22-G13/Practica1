using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{
    public class Percepcion : ComportamientoAgente
    {
        List<GameObject> ratas = new List<GameObject>();

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Wander>() != null){
                ratas.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent <Wander> () != null){
                ratas.Remove(other.gameObject);
            }
        }
        public override Direccion GetDireccion()
        {
            if (ratas.Count <= 0)
                return new Direccion();

            Vector3 direction = Vector3.zero;
            Vector3 aux = Vector3.zero;
            for (int i = 0; i < ratas.Count; i++)
            {
                aux = ratas[i].transform.position - this.transform.position;
                float distance = aux.magnitude;
                aux *= (6 - distance);
                direction -= aux;
            }

            direction.Normalize();
            Direccion dir = new Direccion();
            dir.lineal = direction * agente.velocidadMax;
            return dir;

        }
    }
}
