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

**COMPORTAMIENTOS A AÑADIR**

-Merodeo de ratas=Wander

class Kinematiclander:
    character: Static
    maxSpeed: float

    # The maximum rotation speed we'd like, probably should be smaller
    # than the maximum possible, for a leisurely change in direction.

    maxRotation: float

    function getSteering() -> KinematicSteering0utput:
        result = new KinematicSteering0utput()

        # Get velocity from the vector form of the orientation.
        result .velocity = maxSpeed * character .orientation.asVector()
	
        # Change our orientation randomly.
        result.rotation = randomBinomial() * maxRotation

        return result

-Seguimiento y formación de las ratas=Formations

class FormationManager: 
    # The assignment characters to slots. 
    class SlotAssignment: 
        character: Character 
        slotNumber: int 
        slotAssignments: SlotAssignment[] 

        # A Static (i.e., position and orientation) representing the 
        # drift offset for the currently filled slots. 
        driftOffset: Static 

        # The formation pattern. 
        pattern: FormationPattern 

        # Update the assignment of characters to slots. 
        function updateSlotAssignments(): 
            # A trivial assignment algorithm: we simply go through 
            # each character and assign sequential slot numbers. 
            for i in 0..slotAssignments.length(): 
                slotAssignments[i].slotNumber = i 

            # Update the drift offset. 
            driftOffset = pattern.getDriftOffset(slotAssignments) 

        # Add a new character. Return false if no slots are available. 
        function addCharacter(character: Character) -> bool: 

            # Check if the pattern supports more slots.
            occupiedSlots = slotAssignnents. length( )
            if pattern. supportsSlots(occupiedSlots + 1.
                # Add a new slot assignment.
                slotAssignment = new SlotAssignment( )
                slotAssignnent.character = character
                slotAssignnents.append( slotAssignnent)
                updateSlotAssignments( )
                return true
            else:
                # Otherwise we've failed to add the character.
                return false

 

 

        # Remove a character from its slot.
        function renoveCharacter (character: Character):
            slot = charactersInSlots. findIndexOfCharacter character)
            slotAssignnents.renovest( slot)
            updateSlotAssignments( )

        # Send new target Locations to each character.
        function updateStots( ):

            # Find the anchor point.
            anchor: Static = getAnchorPoint( )
            orientationMatrix: Matrix = anchor.orientation.asMatrix()

            # Go through each character in turn.
            for 1 in 0..slotAssignnents. Length ):
                slotNumber: int = slotAssignnents[i].slotNumber
                slot: Static = pattern.getSlotLocation( slotNumber)

            # Transform by the anchor point position and orientation
            location = new Static()
            location. position = anchor.position +
            orientationMatrix * slot.position
            location.orientation = anchor.orientation +
            slot.orientation

            # And add the drift component.
            location. position -= driftoffset.position
            location.orientation -= driftoffset.orientation

            # Send the static to the character.
            slotAssignments[i] .character.setTarget( location)

        # The characteristic point of this formation (see below).
        function aetAnchorPoint() -> Static


-Algoritmo de control de la llegada para perro y ratas=Arrive

class Arrive:
    character: Kinematic
    target: Kinematic

    maxAcceleration: float
    maxSpeed: float

    # The radius for arriving at the target.
    targetRadius: float

    # The radius for beginning to slow down.
    slowRadius: float

    # The time over which to achieve target speed.
    timeToTarget: float = 0.1

    function getSteering() -> Steering0utput:
    result = new Steering0utput()

    # Get the direction to the target.
    direction = target.position - character.position
    distance = direction.length()

    # Check if we are there, return no steering.
    if distance < targetRadius:
    return null

    # If we are outside the slowRadius, then move at max speed.
    if distance > slowRadius:
        targetSpeed = maxSpeed
    # Otherwise calculate a scaled speed.
    else:
        targetSpeed = maxSpeed * distance / slowRadius

    # The target velocity combines speed and direction.
    targetVelocity = direction
    targetVelocity.normalize( )
    targetVelocity *= targetSpeed

    # Acceleration tries to get to the target velocity.
    result.linear = targetVelocity - character.velocity
    result.linear /= timeToTarget

    # Check if the acceleration is too fast.

    if result.linear.length() > maxAcceleration:
        result.linear.normalize()
        result.linear *= maxAcceleration

    result.angular = 0
    return result



-Percepción perro sobre las ratas=Rule-Based System

function ruleBasedIteration(database: DataNode, rules: Rule[]): 
    # Check each rule in turn. 
    for rule in rules: 
        # Create the empty set of bindings. 
        bindings = [] 

    # Check for triggering. 
    if rule.ifClause.matches(database, bindings): 
        # Fire the rule. 
        rule.getActions(bindings) 

        # And exit: we’re done for this iteration. 
        break 

    # If we get here, we’ve had no match, we could use a fallback 16 # action, or simply do nothing. 

-Tocar la flauta

**IMPLEMENTACION FINAL**

-Comportamiento del Perro

Para el comportamiento del perro utilizamos los scripts arrive y percepción.

Arrive, para acercarse al jugador, bajar su velocidad cuando esta cerca y detenerse a cierta distancia, tal y como lo explicamos en el apartado anterior.

Percepción: hace que el perro mantenga la distancia con las ratas, alejandose de ellas cuando están cerca. Tiene todas las ratas en consideración, en caso de que haya mucahs se aleja
proporcionalmente a la distancia y número de ratas que se encuentran en una dirección. Este comportamiento se ejecuta con mayor prioridad que el arrive.

No utilizamos el pseudocódigo pensado inicialmente, si no que desarrollamos nosotros uno, que se basa en el de huida, pero teniendo en cuenta a multiples ratas a través de un trigger.

-Comportamiento de la rata

Para el comportamiento de la rata utilizamos los scripts Wander, Separation y Arrive

Arrive, tal y como con el perro, este comportamiento es para que se mueva hacia el jugador de la manera explicada anteriormente.

Wander: utilizamos el código propuesto, hace que las ratas den vueltas por el escenario.

Separation: lo utilizmos para que las ratas mantengas una pequeña distancia entre ellas, de esta manera se ordenan al perseguir al jugador.
El pseudocódigo de este comportamiento no estaba propuesto anteriormente, por ello lo insertamos más adelante.

    aracter: Kinematic
    maxAcceleration: float

    # A List of potential targets.
    targets: Kinematicl]

    # The threshold to take action.
    threshold: float

    # The constant coefficient of decay for the inverse square law.
    decayCoefficient: float

    function getSteering() -> SteeringQutput:
    result = new SteeringOutput( )

    # Loop through each target.

    for target in targets:
    # Check if the target is close.
    direction = target.position - character.position
    distance = direction.length( )

    if distance < threshold:
    # Calculate the strength of repulsion
    # (here using the inverse square law).
    strength = min(
    decayCoefficient / (distance * distance),
    maxAcceleration)

    # Add the acceleration.
    direction.normalize( )

    result.linear += strength * direction

    return result

Para la realización de estos comportamientos hemos utilizado un script auxiliar, el ratControl,
este activa los comportamientos Arrive y Separation, y desactiva el Wander cuando el jugador esta tocando la flauta, y viceversa si 
no esta tocando la flauta.

Entre el Arrive y el Separation que se ejecutan de manera simultanea, el Separation tiene mayor prioridad que el Arrive 

Comportamiento del jugador:

Para tocar la flauta, mas alla de añadir un comportamiento, hemos modificado el ControlJugador para que al pulsar el espacio 
este toque la flauta. La aplicación del sonido lo hemos realizado con la ayuda del componente AudioSource.

A parte de todo esto hemos añadido un GameManager que permite reiniciar el juego pulsando la tecla R, y eliminar todas las ratas a excepción de una, en el caso de que esto ayude
a la observación de su comportamiento.