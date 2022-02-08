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