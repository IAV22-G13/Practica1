**RESUMEN ENUNCIADO**

Esta práctica trata de explorar diversos algoritmos de movimiento, y para ello vamos a tener varios tipos de agentes, con diversos comportamientos:

    -En primer lugar, el jugador, controlado por teclado, que podrá moverse por el escenario y hacer sonar una flauta que atraerá a otros agentes.
    -En segundo lugar, el perro, que seguirá al jugador de forma dinámica e individual y que al acercarse controle la llegada y no arrolle al jugador. Cuando 
        tenga muchas ratas alrededor huirá de ellas.
    -En tercer lugar, las ratas, que tendrán un movimiento cinemático de manada, y que si no escuchan la flauta estarán merodeando por el escenario. Cuando 
        escuchen la flauta, seguirán al jugador en formación con las demás, controlando la llegada, y formando a su alrededor.

Contenidos requeridos para la práctica: 

    -Mostrar un entorno virtual con obstáculos y los diversos agentes.
    -El perro con persecución y huida de las ratas cuando hay varias cerca.
    -Las ratas con movimiento de merodeo individual.
    -Las ratas con movimiento en bandada, formación y control de llegada hasta el flautista cuando escuchen la flauta.

Restricciones:

    -No utilizar plugins de terceros.
    -Documentar los algoritmos.
    -Diseñar y programar de forma limpia.

Extras:

    -Colocar obstáculos aleatorios mediante la secuencia de Halton o el algoritmo de ruido de Perlin.
    -Añadir generadores de ratas y varios flautistas.
    -Añadir vista al perro, para que evite las ratas pero no al jugador. Gestor sensorial para centralizar la percepción de los agentes.

**PUNTO PARTIDA**

En el proyecto de Unity aportado por el profesor, contamos con una escena que dispone de 3 esferas. Cada una debe representar un elemento de la práctica, uno debe ser el flautista de hamelin, otro el perro y otro la rata. Estos se encuentran en un escenario con forma de cuadrado, delimitado por cuatro paredes. Todos los objetos mencionados tienen un collider, y las esferas, además, cuentan con un rigidbody, el cual les permite interactuar con el resto de objetos y entre sí, y se les puede aplicar gravedad, junto con otras fuerzas aplicadas a través de scripts, las cuales modifican esta componente. 

Para definir los comportamientos que se piden en el enunciado, disponemos de una serie de scripts con las siguientes características:

-El script Agente: cuenta con una serie de variables públicas que le permiten gestionar y combinar los diferentes comportamientos según diferentes razones, como la prioridad y el peso. Además, este también lleva el movimiento tanto de objetos físicos, como de no físicos. Las tres esferas de la escena contienen este script.

-El script ComportamientoAgente: se trata de una clase abstracta de la cual heredarán todos los comportamientos que se les vayan a asociar a los agentes. Estas tienen un peso y una prioridad, que entran en juego con el script anterior, el cual gestionará que comportamientos deberán realizarse. Para el caso en el que el comportamiento esté relacionado con otro objeto, permite guardarse un gameObject objetivo.

-El script ControlJugador: hereda de ComportamientoAgente y permite al objeto que lo lleve ser controlado por el jugador mediante las flechas o WASD.

-El script Huir: hereda de ComportamientoAgente, se mueve en dirección contraria a el objetivo asignado.

-El script Seguir: hereda de ComportamientoAgente, se mueve en dirección del objetivo asignado.

La esfera amarilla representa al jugador(Flautista de Hamelin), ya que posee el componente que permite a este controlarlo.

La esfera azul y la roja no representan ni al perro, ni a las ratas, si no que poseen la roja el comportamiento huir, huyendo del jugador, y la azul el comportamiento seguir, que hace que se mueva hacia el jugador.
