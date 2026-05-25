# App móvil MAUI que usa Sqlite 

## Realizar una app móvil con .net Maui
La app debe usar una bdd Sqlite con dos tablas (maestro/detalle)
## APP móvil para la gestión de vehículos

### Tablas de la BDD Maestro - Detalle 
 CREATE TABLE IF NOT EXISTS marcas (
     id INTEGER PRIMARY KEY AUTOINCREMENT,
     nombre VARCHAR(50) NOT NULL UNIQUE
 );
 CREATE TABLE IF NOT EXISTS modelos (
     id INTEGER PRIMARY KEY AUTOINCREMENT,
     id_marca INTEGER NOT NULL,
     nombre_modelo VARCHAR(50) NOT NULL,
     año INTEGER NOT NULL,
     FOREIGN KEY (id_marca) REFERENCES marcas(id) ON DELETE CASCADE
 );
 ### Funcionamiento de la aplicación en Windows Machine 
 #### CREATE 
 <img width="1436" height="764" alt="Captura de pantalla (198)" src="https://github.com/user-attachments/assets/b59e08b8-de22-4dbf-a198-41b46ffbe93f" />

 
 #### READ 
<img width="1425" height="715" alt="image" src="https://github.com/user-attachments/assets/984d3ad7-b6ed-4a9a-a9ac-d2b997208f98" />

<img width="1436" height="748" alt="image" src="https://github.com/user-attachments/assets/45c7c2a5-39d5-49b7-9a00-fa9752ab3e98" />


#### UPDATE
<img width="1418" height="596" alt="image" src="https://github.com/user-attachments/assets/332c7eba-36d8-4843-8757-4035e696aaf6" />
<img width="1429" height="742" alt="image" src="https://github.com/user-attachments/assets/9af6b50f-67d3-4b51-870b-6e3a36cbe236" />

#### DELETE 
<img width="1430" height="743" alt="image" src="https://github.com/user-attachments/assets/ee7a2919-2431-4754-b8d5-3be496a0f7f8" />
<img width="1433" height="743" alt="image" src="https://github.com/user-attachments/assets/d0f2ddb9-b48a-4d37-8cc2-6939356d68d7" />

### Funcionamiento de la aplicación en emulador Android 
<img width="562" height="978" alt="image" src="https://github.com/user-attachments/assets/926cdfbf-5016-483f-9962-f433fd93640e" />

#### CREATE 
<img width="481" height="1000" alt="image" src="https://github.com/user-attachments/assets/4086677c-f77b-44ea-bdae-f9bc4e6bef0b" />

#### READ 
<img width="495" height="994" alt="image" src="https://github.com/user-attachments/assets/af11afab-ff73-42e6-82dc-533d36ee0545" />

<img width="485" height="987" alt="image" src="https://github.com/user-attachments/assets/4b578c84-87f9-4328-9fb7-ff9bbe3bcb4c" />

#### UPDATE 
Datos anteriores

<img width="474" height="537" alt="image" src="https://github.com/user-attachments/assets/5a8c481e-5be9-48ef-8762-9cdea1204a2e" />

Nuevos datos

<img width="492" height="612" alt="image" src="https://github.com/user-attachments/assets/b26dfe58-95de-470f-a2bd-79a1fd1e18d6" />

Guardar cambios

<img width="490" height="988" alt="image" src="https://github.com/user-attachments/assets/113f9343-228e-48eb-9ca3-9938051034b5" />

Comprobación con lectura de ID 

<img width="479" height="933" alt="image" src="https://github.com/user-attachments/assets/cbf2187d-1809-4260-9611-1caa2b0fdb3d" />

#### DELETE 

Mensaje de confirmación 

<img width="485" height="923" alt="image" src="https://github.com/user-attachments/assets/aa6d1fb5-8529-4921-9a25-1eb3d9e0e2e0" />

Mensaje de vehículo eliminado

<img width="488" height="992" alt="image" src="https://github.com/user-attachments/assets/e3f22e39-5bcb-454b-b93a-528d8af50641" />

Comprobación

<img width="481" height="976" alt="image" src="https://github.com/user-attachments/assets/8e20b10d-da85-478e-8e52-8af3fbd698b9" />

