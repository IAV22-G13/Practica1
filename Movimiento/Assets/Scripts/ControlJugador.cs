/*    
   Copyright (C) 2020 Federico Peinado
   http://www.federicopeinado.com

   Este fichero forma parte del material de la asignatura Inteligencia Artificial para Videojuegos.
   Esta asignatura se imparte en la Facultad de Inform?tica de la Universidad Complutense de Madrid (Espa?a).

   Autor: Federico Peinado 
   Contacto: email@federicopeinado.com
*/
namespace UCM.IAV.Movimiento
{

    using UnityEngine;

    /// <summary>
    /// Clara para el comportamiento de agente que consiste en ser el jugador
    /// </summary>
    public class ControlJugador: ComportamientoAgente
    {
        /// <summary>
        /// Obtiene la direcci?n
        /// </summary>
        /// <returns></returns>

        public override Direccion GetDireccion()
        {
            if (Input.GetKeyDown("space"))
            {
                this.GetComponent<AudioSource>().Play();
                //suena musica
            }
            if (Input.GetKeyUp("space"))
            {
                this.GetComponent<AudioSource>().Pause();
                //suena musica
            }

            Direccion direccion = new Direccion();
            direccion.lineal.x = Input.GetAxis("Horizontal");
            direccion.lineal.z = Input.GetAxis("Vertical");
            direccion.lineal.Normalize();
            direccion.lineal *= agente.aceleracionMax;

            // Podr?amos meter una rotaci?n autom?tica en la direcci?n del movimiento, si quisi?ramos

            return direccion;
        }
    }
}