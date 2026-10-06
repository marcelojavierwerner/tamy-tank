# 💻 Arquitectura de Scripts & Managers (C# / Unity)

Esta carpeta contiene la selección de **Scripts centrales** que controlan el ciclo de vida, las mecánicas de juego, la física 2D y la interfaz de usuario de **Tamy Tank**.

El juego fue diseñado utilizando un **patrón orientado a Managers** (controladores especializados) que coordinan los estados del juego mediante el patrón *Singleton* y la invocación de eventos.

---

## 🏗️ Diagrama de Arquitectura y Flujo de Control

```text
                        ┌─────────────────┐
                        │   GameManager   │  <-- Estado global (InGame / Pause / GameOver)
                        └────────┬────────┘
                                 │
     ┌───────────────────┬───────┴───────┬───────────────────┐
     ▼                   ▼               ▼                   ▼
┌─────────┐       ┌─────────────┐ ┌─────────────┐     ┌─────────────┐
│ Player  │ <───> │ ShotManager │ │ OvniManager │     │ ScoreManager│
└────┬────┘       └─────────────┘ └──────┬──────┘     └─────────────┘
     │                                   │
     ▼                                   ▼
[Físicas 2D & Shield]             [Enemy Spawning & Split]
