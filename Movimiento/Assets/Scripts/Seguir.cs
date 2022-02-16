/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Informática de la Universidad Complutense de Madrid (España).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UCM.IAV.Movimiento
{

    /// <summary>
    /// Clase para modelar el comportamiento de SEGUIR a otro agente
    /// </summary>
    public class Seguir : ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la dirección
        /// </summary>
        /// <returns></returns>
        private Vector3 objetiv = new Vector3();
        private float orient;
        public void SetTarget(Vector3 objec, float ori)
        {
            objetiv = objec;
            orient = ori;
        }
        public override Direccion GetDireccion()
        {
            // Si fuese un comportamiento de dirección dinámico en el que buscásemos alcanzar cierta velocidad en el agente, se tendría en cuenta la velocidad actual del agente y se aplicaría sólo la aceleración necesaria
            // Vector3 deltaV = targetVelocity - body.velocity;
            // Vector3 accel = deltaV / Time.deltaTime;

            Direccion direccion = new Direccion();
            direccion.lineal = objetivo.transform.position - transform.position;
            direccion.lineal.Normalize();
            direccion.lineal *= agente.aceleracionMax;

            if (objetiv != new Vector3())
            {
                Direccion obj = new Direccion();
                obj.lineal = objetivo.transform.position - transform.position;
                obj.lineal.Normalize();
                obj.lineal *= agente.aceleracionMax;
                obj.angular = orient;
                return obj;
            }
            // Podríamos meter una rotación automática en la dirección del movimiento, si quisiéramos
            return direccion;
        }
    }
}
