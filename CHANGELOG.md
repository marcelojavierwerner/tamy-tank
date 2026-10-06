# 📜 Historial de Cambios y Versiones — Tamy Tank

Todas las iteraciones destacadas del desarrollo de **Tamy Tank** para Android (Unity / C#), iniciado el 29 de marzo de 2019 con motivo del nacimiento de mi hija y publicado en su versión final v1.2.23 el 26 de enero de 2020.

---

## 🚀 Versión 1.2.x — Requisitos Técnicos de Google Play Store y Publicación Final

### `v1.2.23` — *(26/01/2020)* — **Versión Publicada Final**
* **Compatibilidad:** Actualización completa del motor a arquitectura de **64 bits** (exigencia de Google Play Console) y compilación oficial distribuida en APK/AAB.

### `v1.2.22`
* **Mantenimiento Android:** Actualización del nivel de API objetivo a **Target API 29** (Android 10 Q).

---

## ⚡ Versión 1.1.x — Optimización de Gameplay, Modos de Juego y Estabilidad

### `v1.1.19` – `v1.1.21`
* **Compatibilidad y Parches:** Primera implementación de compatibilidad con 64 bits, actualización a **Target API 27** (Android 8.1) y corrección en el renderizado de banderas en Modo Normal.

### `v1.1.16` – `v1.1.18`
* **Refactorización de Gameplay:** Corrección en los scripts `FreezeTime` y `TimeSpawn` para optimizar la velocidad progresiva y aceleración de los OVNIs. Actualización general de la iconografía del juego.

### `v1.1.010` – `v1.1.015`
* **Integración y Legal:** Agregadas las políticas de privacidad en el menú principal y sección de créditos (requerimiento de Google Play Store).
* **Refactorización:** Reorganización del código en `Bomb` y `MundialManager`. Corrección de fallos en la actualización de mapas en el modo Mundial.
* **Escenarios:** Adición del escenario *Modern Castle* en Hard Mode.

### `v1.1.004` – `v1.1.009`
* **UI/UX táctil:** Rediseño y ampliación del área táctil de los botones de movimiento (`Left` y `Right`) e indicadores de banderas para mejorar la usabilidad en pantallas pequeñas de smartphones.
* **Contenido:** Incorporación del escenario *Sydney (Australia)* en los modos Clásico y Hard.
* **Textos:** Actualizaciones en la pantalla final de victoria.

### `v1.1.000` – `v1.1.003`
* **Evolución de Menús:** Inclusión de nuevos mensajes de victoria y sombras dinámicas (`Shadow`) en los controles de audio.

---

## 🎮 Versión 1.0.x — Hito de Versión Principal y Modos de Juego

### `v1.0` – `v1.02`
* **Nuevas Mecánicas:** Incorporación del nuevo modo de juego.
* **Pulido Visual:** Adición de efectos de sombra (`Shadow`) en la interfaz de usuario, botones y créditos.

---

## 🛠️ Versiones Iniciales — Prototype & Beta (v0.16 a v0.43)

### `v0.42` – `v0.43`
* **Nuevos Escenarios:** Integración de los escenarios ilustrados en CorelDraw: *Machu Picchu (Perú)*, *Cartagena de Indias (Colombia)* y *Partenón (Grecia)*.

### `v0.39` – `v0.41`
* **UI & Redes:** Agregados los accesos directos a redes sociales en la sección de créditos y el botón para habilitar/deshabilitar la música de fondo.
* **Optimización:** Priorización de carga y destrucción de objetos (`OnDestroy`) para mejorar el rendimiento visual de las banderas.

### `v0.34` – `v0.38`
* **Estética y Escenarios:** Incorporación del escenario *Taj Mahal (India)*. Aplicación de contornos visuales (`Outline`) y sombras (`Shadow`) en los textos de UI (`Pause`, `Game Over`, `Ready` y contador de vidas).

### `v0.29` – `v0.33`
* **Corrección de Bugs:** Solución del fallo de pausa que congelaba incorrectamente a los OVNIs (`v0.32`).
* **Mejora Visual de Armas:** Adición del efecto visual de estela en el proyectil láser (`v0.31`).
* **Nuevos Escenarios:** Adición del escenario *Punta del Este (Uruguay)* y corrección visual del fondo de México.

### `v0.26` – `v0.28`
* **Mecánicas de Disparo:**
  * Inclusión del efecto de cola/estela al arma tipo **Láser** (`v0.28`).
  * Incremento en la velocidad de dos tipos de proyectiles (`v0.27`).
  * Modificación del arma por defecto con la que inicia el jugador (`v0.26`).

### `v0.16` – `v0.25`
* **Arquitectura de Software Base:**
  * Refactorización del control de nivel: transferencia de `CurrentLevel` desde `GameManager` hacia `ScoreManager` (`v0.19`).
  * Corrección de la reproducción de audio al pausar el juego (`v0.18`).
  * Corrección gráfica en las banderas de Sudáfrica y Rusia (`v0.23`).
  * Integración de la lógica de créditos finales e inmunidad temporal (`v0.20`–`v0.24`).
