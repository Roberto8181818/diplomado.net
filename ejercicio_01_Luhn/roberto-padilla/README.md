# Ejercicio 01 - Validador de Tarjetas con Algoritmo de Luhn

## Autor

**Roberto Padilla**

Diplomado .NET - Módulo 1: Fundamentos de C# y .NET

---

## Descripción

Aplicación de consola desarrollada en C# que permite validar números de tarjetas de crédito y débito utilizando el algoritmo de Luhn. Además, identifica la marca de la tarjeta, permite validar múltiples tarjetas desde un archivo de texto, generar números válidos de diferentes marcas y consultar estadísticas de uso.

---

## Funcionalidades

### 1. Validar una tarjeta

Permite ingresar un número de tarjeta y verificar:

* Si cumple con el algoritmo de Luhn.
* La marca de la tarjeta.
* Su estado (válida o inválida).

#### Ejemplo

```text
Número: 4532015112830366
Marca: Visa
Estado: VÁLIDA
```

```text
Número: 4532015112830367
Marca: Desconocida
Estado: INVÁLIDA
```

---

### 2. Validar desde archivo

Permite procesar un archivo de texto que contenga un número de tarjeta por línea.

Por cada registro se muestra:

* Número de tarjeta
* Marca identificada
* Estado de validación

Al finalizar se presenta un resumen con la cantidad de tarjetas válidas e inválidas.

---

### 3. Generar número válido

Genera automáticamente números de tarjeta válidos para las siguientes marcas:

* Visa
* Mastercard
* American Express
* Discover
* Aleatoria

Los números generados cumplen con el algoritmo de Luhn y posteriormente son validados por la aplicación.

---

### 4. Estadísticas

La aplicación mantiene estadísticas durante la ejecución:

* Total de tarjetas válidas.
* Total de tarjetas inválidas.
* Cantidad de tarjetas identificadas por marca:

  * Visa
  * Mastercard
  * American Express
  * Discover

---

## Menú principal

```text
--------------------------------
1. Validar una tarjeta
2. Validar desde archivo
3. Generar número válido
4. Estadísticas
5. Salir
--------------------------------
```

---

## Marcas soportadas

| Marca            | Prefijo                          | Longitud        |
| ---------------- | -------------------------------- | --------------- |
| Visa             | 4                                | 13 o 16 dígitos |
| Mastercard       | 51 - 55                          | 16 dígitos      |
| American Express | 34 o 37                          | 15 dígitos      |
| Discover         | 6011, 65, 644-649, 622126-622925 | 16 a 19 dígitos |

---

## Métodos implementados

### Validación

* `ValidarTarjeta(string numero)`
* `ResultadoValidacionTarjeta(string numeroTarjeta)`

### Identificación de marcas

* `IdentificarMarca(string numero)`
* `EsVisa(string numero)`
* `EsMastercard(string numero)`
* `EsAmericanExpress(string numero)`
* `EsDiscover(string numero)`

### Archivos

* `ValidarArchivo(string ruta)`

### Generación de tarjetas

* `GenerarTarjeta(string marca)`
* `GenerarVisa()`
* `GenerarMastercard()`
* `GenerarAmericanExpress()`
* `GenerarDiscover()`

### Estadísticas

* `MostrarEstadisticas()`

---



## Estructura del proyecto

```text
ejercicio_01_luhn/roberto-padilla
│
├── Program.cs
├── roberto-padilla.csproj
├── README.md
└── evidencias/
    ├── menu.png
    ├── tarjeta invalida.png
    └── tarjeta valida.png
```

---

## Ejecución del proyecto

### Clonar repositorio

```bash
git clone https://github.com/Roberto8181818/diplomado.net.git
```

### Ingresar al proyecto

```bash
cd ejercicio_01_Luhn/roberto-padilla
```

### Ejecutar aplicación

```bash
dotnet run
```

---

## Evidencias

Se incluyen capturas de pantalla mostrando:

* Menú principal.
* Validación de una tarjeta válida.
* Validación de una tarjeta inválida.

---

