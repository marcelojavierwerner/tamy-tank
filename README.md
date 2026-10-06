# 🎮 Tamy Tank — Videojuego 2D para Android (Unity / C#)

> **Proyecto histórico de desarrollo de software (2019–2020)**  
> *Evidencia de formación técnica, arquitectura de software, gestión de proyectos y evolución técnica hacia la Ciencia de Datos.*

---

## 📌 Presentación del Proyecto

**Tamy Tank** es un videojuego de acción en 2D desarrollado de forma independiente entre **marzo de 2019** y **enero de 2020**, publicado comercialmente para dispositivos Android. 

El proyecto nació como una iniciativa personal con motivo de la llegada al mundo de mi hija en 2019, junto a otro juego "La Granja de Flor" y se convirtió en un entorno de aprendizaje práctico para dominar conceptos fundamentales de programación orientada a objetos (POO), físicas 2D, arquitectura orientada a estados, interfaz de usuario (UI/UX) y diseño gráfico vectorial.

Aunque mi perfil profesional actual está enfocado en la **Ciencia de Datos** y el **Análisis Avanzado**, este repositorio documenta la base técnica y lógica sobre la cual construí mi capacidad analítica y de resolución de problemas.

---

## 🖼️ Muestra del Juego y Arte Original

Todo el apartado gráfico (fondos de pantalla temáticos de escenarios mundiales, sprites del tanque, proyectiles e interfaz) fue **dibujado e ilustrado a mano vectorialmente utilizando CorelDraw** antes de ser integrado como *assets* en el motor Unity.

| Pantalla de Inicio | Machu Picchu (Perú) |
| :---: | :---: |
| ![Inicio](Screenshots/Screenshot_20190102-235921.png) | ![Machu Picchu](Screenshots/Machu%20Picchu.jpg) |

| Estatua de la Libertad (EE. UU.) | Molinos de Tulipanes (Países Bajos) |
| :---: | :---: |
| ![Estatua de la Libertad](Screenshots/Screenshot_20190102-235935.jpg) | ![Países Bajos](Screenshots/Screenshot_20190103-000022.jpg) |

| Torre Eiffel (Francia) | Puerto Nyhavn (Dinamarca) |
| :---: | :---: |
| ![Torre Eiffel](Screenshots/Screenshot_20190103-000054.jpg) | ![Nyhavn](Screenshots/Screenshot_20190108-000842.jpg) |

---

## 🛠️ Tecnologías y Herramientas Utilizadas

* **Motor de desarrollo:** Unity 2D.
* **Lenguaje de programación:** C# (.NET Core / Mono).
* **Plataforma objetivo:** Android (APK publicable, soporte para arquitecturas de 64 bits y API Level 29+).
* **Diseño gráfico y arte:** CorelDraw (dibujo vectorial de sprites y fondos).
* **Físicas y Animación:** Unity RigidBody2D, Animator, Coroutines, Mecanim.
* **Control de versiones:** Control iterativo mediante builds locales y changelog detallado (de v0.16 a v1.2.23).

---

## 🏗️ Arquitectura del Sistema

El desarrollo sigue un patrón de diseño basado en **Managers modulares**, garantizando desacoplamiento y control de estados durante la ejecución del juego.

```text
                               ┌─────────────────┐
                               │   GameManager   │
                               └────────┬────────┘
                                        │
        ┌──────────────┬────────────────┼────────────────┬──────────────┐
        ▼              ▼                ▼                ▼              ▼
┌──────────────┐ ┌───────────┐  ┌───────────────┐  ┌───────────┐  ┌───────────┐
│ Player.cs    │ │ Score...  │  │ OvniManager   │  │ Shot...   │  │ Life...   │
└───────┬──────┘ └───────────┘  └───────┬───────┘  └─────┬─────┘  └───────────┘
        │                               │                │
        ├── Movimiento                  ├── Gestión OVNIs│
        ├── Escudo y Daño               ├── División (Split)├── Tipos de armas
        ├── Invulnerabilidad            ├── Ralentización├── Comportamiento
        └── Win/Lose State              └── Físicas/Pausa└── Proyectiles
```

### Componentes Principales

1. **`GameManager.cs`**: Controlador principal del ciclo de vida del juego, estado de pausa (`inGame`), carga de escenas y lógica de Game Over.
2. **`Player.cs`**: Gestiona las físicas 2D del tanque, colisiones, animación de movimiento, estados de invulnerabilidad temporal (*Blinking*) y sistema de salud/escudo.
3. **`OvniManager.cs`**: Administra la generación y lógica de enemigos. Implementa mecánicas complejas como la división de enemigos (`Split()`), modificación temporal de velocidad (`TimeSlow()`) y sincronización con el sistema de pausa.
4. **`ShotManager.cs`**: Sistema de armas intercambiables que permite instanciar distintos tipos de proyectiles (Bala básica, Fuego, MultiBala, Láser y Triple Láser con variaciones angulares) de forma dinámica.

---

## ⏱️ Historial de Evolución e Iteración (Changelog)

El desarrollo del proyecto se caracterizó por un enfoque iterativo ágil, registrando más de 30 versiones documentadas desde sus primeras fases hasta su versión de producción:

| Versión | Hito / Cambio Destacado |
| :--- | :--- |
| **0.16** | Etapa inicial de lógica y prueba de físicas 2D. |
| **0.19** | Reorganización del sistema de gestión de niveles. |
| **0.26 – 0.28** | Ajustes en la velocidad de proyectiles y adición de efectos visuales (cola de láser). |
| **1.0.0** | Integración del modo de juego principal y arte vectorial final. |
| **1.1.019** | Actualización de soporte para dispositivos Android de 64 bits. |
| **1.2.22** | Migración a la API 29 de Android para cumplir estándares de Google Play. |
| **1.2.23** | **Versión final publicada (26/01/2020)**. |

---

## 🔄 Evolución Profesional: De la Programación a la Ciencia de Datos

El desarrollo de *Tamy Tank* no es un evento aislado en mi carrera, sino un eslabón fundamental en mi trayectoria técnica:

**Programación Orientada a Objetos (C# / Unity)** ➔ **Desarrollo de Software** ➔ **Análisis de Datos** ➔ **Ciencia de Datos (Python / SQL)**

### Habilidades Transferibles
* **Lógica Algorítmica:** La implementación de corrutinas y manejo de estados en C# facilitó la transición hacia la manipulación eficiente de datos y estructuras complejas en Python.
* **Resolución de Problemas:** El mantenimiento de un software móvil en producción exige rigurosidad en la depuración, optimización de recursos y estructuración de código.
* **Pensamiento de Producto:** Diseñar mecánicas, gráficos y flujos de usuario me permite encarar los proyectos de datos con una visión orientada a resolver necesidades reales y comunicar resultados de forma clara.

---

## 📁 Estructura del Repositorio

```text
tamy-tank/
│
├── README.md              <-- Documentación general del proyecto
├── LICENSE                <-- Licencia de uso
│
├── Scripts/               <-- Selección de scripts clave en C#
│   ├── GameManager.cs
│   ├── OvniManager.cs
│   ├── Player.cs
│   └── ShotManager.cs
│
└── Screenshots/           <-- Capturas del gameplay e ilustraciones vectoriales
```

---

## 👤 Autor

**Marcelo Javier Werner**  
*SerWer Data Lab*  
[GitHub Profile](https://github.com/marcelojavierwerner)
