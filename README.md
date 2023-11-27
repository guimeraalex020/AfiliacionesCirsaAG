# CIRSA HIRING HACK - justCode

## Background del Proyecto

El proyecto CIRSA HIRING HACK - justCode tiene como objetivo proporcionar una posible plataforma web de afiliados para CIRSA. Surgió como respuesta a un reto planteado por NUWE en colaboración con CIRSA.

## Uso

Para utilizar CIRSA HIRING HACK - justCode, sigue estos pasos simples:

1. Clona este repositorio: `git clone ...`
2. Navega al directorio del proyecto: `cd turepositorio`
3. Abre la solución con Visual Studio o tu entorno de desarrollo preferido.
4. Ejecuta la aplicación y accede a [URL local].

## Instalación

Asegúrate de tener instaladas las siguientes herramientas antes de ejecutar la aplicación:

- [Nombre de la herramienta 1]
- [Nombre de la herramienta 2]
- ...

## Stack Utilizado

En el desarrollo de CIRSA HIRING HACK - justCode, hemos utilizado las siguientes tecnologías y herramientas:

- Blazor
- HTML, CSS
- Bulma
- Bootstrap
- Radzen

## Toma de Decisiones

Durante el desarrollo, tomamos varias decisiones para optimizar el rendimiento y la experiencia del usuario. Algunas de las decisiones clave incluyen:

- **Uso de Blazor:** 
Se eligió Blazor debido al reto proporcionado por NUWE y CIRSA.
- **Librerías Frontend:** 
Optamos por integrar las librerías Bulma, Bootstrap y Radzen para aprovechar sus características y facilitar tanto el diseño como la interactividad de la plataforma. Además, la elección de estas librerías también está respaldada por consideraciones de seguridad para el usuario. Al utilizar estas bibliotecas, reducimos la posibilidad de introducir fallos de seguridad que podrían ocurrir si implementamos ciertas funcionalidades manualmente.
- **Arquitectura MVVM:** 
Escogimos esta arquitectura debido a su escalabilidad y seguridad.


## Participantes

Ambos participantes contribuyeron al desarrollo de las diferentes páginas del proyecto. Sin embargo, se pueden diferenciar por:
- **Alex Guimerà Garriga:** Se enfocó más en el tratamiento de datos y la estructura.
- **Albert Gómez Brugal:** Se centró más en el diseño de la web y la estructura.
Es importante destacar que, a pesar de estas diferencias, ambos miembros realizaron tareas en todas las áreas cuando fue necesario.

## Objetivos
Nuestro principal objetivo fue desarrollar una plataforma de afiliaciones siguiendo las directrices establecidas por Nuwe. Para lograrlo, hemos integrado todas las pantallas requeridas, además de añadir algunas adicionales que consideramos útiles para mejorar la comodidad y funcionalidad de la plataforma.

Además, nos propusimos crear una plataforma minimalista, responsive y sencilla para el usuario, manteniendo la alineación con las directrices de Nuwe. Nuestro enfoque estuvo en garantizar una comprensión perfecta de su funcionamiento, asegurándonos de incluir todas las funcionalidades necesarias para un óptimo rendimiento. Junto con cumplir con los lineamientos establecidos, nos dedicamos a ofrecer una experiencia intuitiva y completa para el usuario, donde la simplicidad y la comprensión fueran elementos esenciales de la plataforma.

Por otro lado, otro de nuestros objetivos fundamentales fue considerar que el frontend no opera aislado. Por ello, hemos diseñado y programado siempre teniendo en mente una posible integración con el backend. Nos centramos en seguir arquitecturas populares y proponer soluciones modulares y escalables, permitiendo una implementación coherente y adaptable a distintos contextos y futuras necesidades.

##Contexto
Nuestra plataforma de afiliación se enfoca en permitir que los usuarios que realizan afiliaciones a través de enlaces compartidos puedan monitorear sus conexiones de afiliación. A los clientes que se unen mediante estos enlaces los denominamos "clientes afiliados". Sin embargo, estos clientes no tienen acceso a nuestra plataforma, ya que esta está exclusivamente diseñada para el uso de los afiliadores.

Cada cliente afiliado aporta una comisión monetaria al utilizar el enlace proporcionado por el afiliador para acceder. Esta es la razón por la cual hacemos mención a la comisión monetaria al referirnos a los clientes afiliados.

## Detalles de Desarrollo

En esta sección, proporcionaré detalles específicos sobre el desarrollo del proyecto, destacando aspectos como las funcionalidades implementadas, la arquitectura, las decisiones técnicas y cualquier complicación que haya surgido durante el proceso.

### Funcionalidades Implementadas

- Sistema de Autenticación:
Hemos implementado un sistema de autenticación simple que requiere pasar por la página de autenticación antes de acceder al menú principal. Por defecto, se crean 10 usuarios con las siguientes credenciales:

Email: usuario[1..9]@example.com
Contraseña: Password[1..9]
Ejemplo: usuario1@example.com | Password1

Estos usuarios ya tienen clientes afiliados predefinidos, lo que facilita la prueba del frontend al tener datos disponibles. Si se utiliza el registro (sign up), funcionará, pero no habrá clientes afiliados asociados para mostrar.

- Dashboard o Página Principal:
En esta sección, se muestran estadísticas generales relacionadas con los beneficios del usuario. Incluye el total de clientes afiliados, la media de clientes afiliados al mes, la comisión total ganada y la media de comisión mensual. También se genera tu URL de afiliado que puedes copiar y enviar a posibles clientes.

- Buscador de Afiliados:
Permite buscar y filtrar los afiliados por nombre completo, correo electrónico y fecha de afiliación.

- Últimas Afiliaciones:
Aquí se detallan las últimas 10 afiliaciones, proporcionando una visión detallada de las más recientes.

### Arquitectura
Hemos empleado una arquitectura ampliamente reconocida, la MVVM (Modelo-Vista-VistaModelo). Esta estructura nos ha permitido separar de manera clara la lógica de presentación y negocios de una aplicación de la interfaz de usuario. Hemos seguido la pauta de crear la interfaz de usuario (Vista/UI), diseñar la lógica asociada a esa interfaz (ViewModel), la cual solicitará o añadirá datos al Modelo o a los servicios.

Es evidente que no teníamos una base de datos, pero nuestra intención era seguir una arquitectura que nos permitiera conectarla de manera rápida y sencilla en caso de disponer de ella. Por eso, cada vez que era necesario utilizar la lógica de negocios o acceder a datos, se llamaba directamente a los servicios.

Estos servicios los hemos incorporado como "scoped", lo que implica que todo lo que realicemos durante una sesión sin reiniciar el navegador permanece activo. Sin embargo, al reiniciar el navegador se pierde toda esta información. Hemos encontrado que esta fue la mejor manera de simular el comportamiento de una base de datos. En estos servicios, mantenemos una lista con los objetos correspondientes que se cargan inicialmente para realizar pruebas. Las funciones de los servicios acceden a esta lista. En el caso de conectar una base de datos, simplemente tendríamos que dirigir las funciones de los servicios hacia la base de datos o hacia una API en lugar de utilizar esta lista almacenada en el servicio.

En términos generales, esto nos permite que cada vez que se realiza una acción específica, como obtener los clientes afiliados a un usuario, se siga la misma ruta del servicio de Afiliaciones. Esto significa que, si conectáramos una base de datos, solo necesitaríamos configurar las pocas funciones de los servicios. El resto del frontend (ViewModel y View) no requeriría ninguna configuración adicional para seguir funcionando. Esta modularidad se basa en que la capa de servicio está completamente aislada. Por lo tanto, el ViewModel y la View funcionarán de la misma manera, ya sea que la capa de servicio obtenga datos de una base de datos o de una lista predeterminada.


### Complicaciones y Soluciones

- **Complicación 1:** [Descripción de la complicación y cómo se abordó]
- **Complicación 2:** [Descripción de la complicación y cómo se abordó]
- ...

## Licencia

Este proyecto está bajo la Licencia [Nombre de la Licencia]. Consulta el archivo `LICENSE` para obtener más detalles.
