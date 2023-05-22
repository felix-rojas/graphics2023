# Reporte

## Layout

En el layout decidí por el Tall, al igual que en la práctica

- Está organizado a la derecha puesto que soy diestro
- La vista de game esá minimizada para poder interactuar con ella dado que es un proyecto pequeño, para pruebas en grande utilizaría "Play Maximized"

Agregué un con un tinte azul/cyan que no ataque a mis ojos pero que permita ver que estoy en otro modo para no olvidar que se está ejecutando

[Layout](layout.png)

Decidí incluir al objeto "Vehiculo" dentro de Player_Objects pues habrá probablemente otras partes que pueda controlar del mismo vehículo

## Obstáculos

Los obstáculos fueron ordenados así para remarcar la necesidad de control minuto del movimiento adelante y rotación, dadas las restricciones del diseño del automóvil.

[Layout](layout.png)

La jerarquía de objetos se determinó con el propósito de agrupar de manera sencilla para los desarrolladores. El CursoObstaculos tiene 7 pirámides que a su vez se componen de objeto de obstáculos.

[Organización de jerarquía](jerarquia.png)

## Errores

- El movimiento del vehículo está determinado como un bloque sin tomar en cuenta ninguna de sus partes
- No existe rotación para los objetos de las llantas al dar input derecha o izquierda
- La rotación del vehículo está basada en el centro del modelo y no en el offset de donde estaría el eje
- Los movimientos del vehículo horizontales y atrás y adelante son independientes uno del otro, así como del estado de las llantas
- El freno y el movimiento hacia atrás deben ser programados de manera separada, puesto que puedes frenar y mover hacia adelante o hacia atrás.
- El freno es una restricción del movimiento fwd/bwd del vehículo
- El vehículo acelera y rota incluso cuando las llantas están en el aire

## Aprendizaje

- Aprendí a configurar el entorno en Unity
- Soy capaz de generar documentación con estándares
- Dar física de colisión a objetos con ajustes predeterminados de Unity como "weight"
- Generar scripts de comportamiento para los objetos
- Organizar los objetos en la vista jerárquica
- Modificar propiedades únicas de objetos en Unity
- Acceso a los colisionadores de Unity
- Uso de cuaterniones para indicar posición relativa

## Prefabs

En el resultado final, regresé a la versión con 1 jugador, puesto que quería hacer una experiencia diferente.

- El prefab de piramides lo junté en ObstacleCourse
- El vehiculo del jugador esta en Player
- Los vehículos enemigos están organizados en EnemyVehicles y todos siguen el comportamiento "FollowWaypoint"
- Waypoint as un objeto vacío que duplica la posición del Vehiculo1 de Player
- Vehiculo1 posee detección de colisión con objetos y acumula puntos entre más cajas toques

### Cambios

- Condiciones para perder en consola:
  - Caer de la carretera y Valor del eje Z del vehículo <= -10
  - Colisionar con autobuses
- Condiciones para ganar:
  - Alcanzar 50 unidades de distancia

### Video

[Gameplay_y_comentario](https://youtu.be/S1Yf7rn_CpQ)

## Checklist

- [x] Screenshot del layout seleccionado y una justificación de por que lo seleccionaste.
- [X] Reflexión sobre el aprendizaje adquirido en el laboratorio del 01/11/2022 con fecha de realización.
- [X] Screenshot de tu layout de color en el play mode.
- [X] Lista de errores que hasta el momento existen en el juego.
- [X] Código documentado de la clase **FollowPlayer**.
- [x] Reflexión sobre el aprendizaje adquirido en el laboratorio del 02/11/2022 con fecha de realización.
- [X] Listado con explicación y screenshots de los prefabs de obstáculos que hayas realizado.
- [X] Liga al video con el resultado final de tu proyecto y el nivel diseñado.
- [X] Reflexión sobre el aprendizaje adquirido en el laboratorio del 03/11/2022 con fecha de realización.
