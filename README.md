**.NET![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.001.png)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.002.jpeg)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.003.jpeg)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.004.png)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.005.jpeg)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.006.png)![ref1]![ref1]![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.008.jpeg)**

Implementar un proyecto .NET siguiendo una arquitectura de cuatro capas que permita la incorporación de un      proceso de verificación de dos pasos.

![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.009.png)

1 Se procede a establecer la estructura base de un proyecto, implementando la arquitectura de diseño en cuatro capas.

![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.010.png)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.011.jpeg)



|![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.012.png)|
| - |
||
|2 Se define la entidad base, se crean las respectivas configuraciones y ajustes adicionales para CON ESTO  lograr definir la clase de contexto.|
||
|![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.013.png)|

` `![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.014.jpeg)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.015.png)



||
| :- |
|3 configuración de la db y migraciones.|
||
|![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.016.jpeg)|
|![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.017.jpeg)|
|4 CREACION DEL SERVICIO DE AUTENTICACION EN DOS FACTORES, SE AÑADE al scope.|
||
|![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.018.png)|

` `![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.019.jpeg)![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.020.jpeg)

5 Se implementa su funcionamiento en el controlador, ![](https://github.com/CampoSuarezJavierDavidCampus/2-step-verification/blob/main/Assets/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.021.png)creando un dto para la obtención del codigo.


