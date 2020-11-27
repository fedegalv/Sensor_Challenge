# Sensor_Challenge
1. Restaurar el backup de la Base de datos ubicado en la carpeta *Database/SensorDB.bak* , la BD creada con Microsoft SQL Server.


2. Cambiar el ConnectionString del proyecto, ubicado en appsettings.json.<br/>De "SensorDbConnection": "Server=PCFEDERICO\\SQLEXPRESS;Database=SensorDB;Trusted_Connection=True;MultipleActiveResultSets=True;" a una que corresponda en cada caso particular.


3. Iniciar el proyecto y logear con usuarios dados a continuacion, cada usuario tiene sus permisos correspondientes que limitan o no acceso a funciones correspondientes.
<br/>
<br/>
<br/>
USUARIOS<br/>


User: admin<br/>
Password: admin<br/>
Permisos: Todos los permisos<br/>


User: cliente<br/>
Pass: cliente<br/>
Permisos: Listado Cliente, Alta Cliente, Baja Cliente, Modificacion Cliente<br/>


User: altacliente<br/>
Pass: altacliente<br/>
Permisos: Listado Cliente, Alta Cliente<br/>


User: user<br/>
Pass: user<br/>
Permisos: Listado Usuario, Alta Usuario, Baja Usuario, Modificacion Usuario<br/>


User: alta<br/>
Pass: alta<br/>
Permisos: Listado Usuario, Alta Usuario<br/>

User: delete<br/>
Pass: delete<br/>
Permisos: Listado Usuario, Baja Usuario, Listado Cliente, Baja Cliente<br/>

User: mapa<br/>
Pass: mapa<br/>
Permisos: Visualizacion Mapa<br/>


