 Mini Manual del Proyecto: Tu Sueño Casa de Novia

¡Hola, Le presento mi proyecto de gestión de eventos, desarrollado en ASP.NET Core Blazor (InteractiveServer). Usé Entity Framework Core para la data y ASP.NET Identity para los roles. La idea era hacer un sistema robusto, pero que se vea bonito.
 CREDENCIALES DE ACCESO RÁPIDO


Aquí están las cuentas para que pueda revisar todos los accesos:
Administrador: Correo: admin@system.com | Contraseña: Admin123* | Acceso: Gestión Global
Usuario (Cliente): Correo: usuario@system.com | Contraseña: Admin123* | Acceso: Creación de Eventos

 MÓDULOS PRINCIPALES Y FLUJO
Organicé la aplicación para que las vistas del Administrador y las acciones del Cliente sean claras, usando Routers para enviar a cada usuario a su sitio correcto.

1. Gestión de Eventos (Core del Proyecto)
Listado General (Ruta /admin/evento):
Vista tabular de todos los eventos.
Filtros Funcionales: Se puede buscar por texto (Nombre, Proveedor) y por Rango de Fechas ("Desde" y "Hasta").
Ver Detalle (Ruta /admin/eventos/detalle/{id}):
Se agregó un botón de "Ver Detalle" en el listado.
La vista muestra los datos del evento, el tipo, el presupuesto y el UsuarioId creador.

Creación/Edición (Ruta /Eventos/Crear):
El campo Estado está fijo en "Pendiente" durante la creación, y solo el Admin puede cambiarlo en la edición.

2. Finanzas y Pagos

Listado de Pagos (Ruta /admin/pagos):
Muestra un listado ordenado por FechaPago. Incluye filtro por Rango de Fechas.
Modal Eliminación:
El botón de eliminar en el listado de Citas y Pagos activa un modal de confirmación que muestra los detalles del registro (Monto, Evento, etc.) antes de la eliminación final.
Formulario de Pago (Ruta /admin/pagos/crear):
Implementa validación condicional: Si elige "Tarjeta", los campos (Número, CVV, Vencimiento) se hacen obligatorios y se validan con Data Annotations (estos campos se guardan en el modelo PagosDetalle).
Modal de Éxito:
Después de guardar cualquier pago/cita con éxito, aparece un modal de "¡Operación Exitosa!" antes de redirigir al Dashboard.
3. Sugerencias y Feedback
Bandeja de Sugerencias (Ruta /admin/sugerencias):
Vista exclusiva del Administrador para revisar y eliminar el feedback de los clientes.
Enviar Sugerencia (Ruta /sugerencias/crear):
Formulario para que el usuario envíe una sugerencia o queja.

 Puntos de Diseño y Usabilidad
Diseño Adaptativo (Mobile Fix): Se usaron @media queries en el CSS para asegurar que el sidebar (admin-sidebar) se colapse por completo en dispositivos móviles, eliminando el desplazamiento horizontal.

Identidad Visual: Se cambió el fondo del menú y los encabezados de las tarjetas a Azul Marino Oscuro (#01206E) y se usó el color Verde (btn-success) para las acciones de guardar/agendar.
