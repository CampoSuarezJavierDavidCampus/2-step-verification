**.NET![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.001.png)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.002.jpeg)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.003.jpeg)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.004.png)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.005.jpeg)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.006.png)![ref1]![ref1]![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.008.jpeg)**

Implementar un proyecto .NET siguiendo una arquitectura de cuatro capas que permita la incorporación de un      proceso de verificación de dos pasos.

![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.009.png)

1 Se procede a establecer la estructura base de un proyecto, implementando la arquitectura de diseño en cuatro capas.

![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.010.png)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.011.jpeg)



|![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.012.png)|
| - |
||
|2 Se define la entidad base, se crean las respectivas configuraciones y ajustes adicionales para CON ESTO  lograr definir la clase de contexto.|
||
|![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.013.png)|

` `![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.014.jpeg)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.015.png)



||
| :- |
|3 configuración de la db y migraciones.|
||
|![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.016.jpeg)|
|![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.017.jpeg)|
|4 CREACION DEL SERVICIO DE AUTENTICACION EN DOS FACTORES, SE AÑADE al scope.|
||
|![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.018.png)|

` `![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.019.jpeg)![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.020.jpeg)

5 Se implementa su funcionamiento en el controlador, ![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.021.png)creando un dto para la obtención del codigo.

![](Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.022.jpeg)

5 Al utilizar la aplicación Google Authenticator y registrar el código QR, se generarán códigos de 6 dígitos cada 30 segundos, según la configuración previamente especificada.

[ref1]: ~/Aspose.Words.0a14f7d4-8fb2-4496-a7a2-34fb56e8f1cc.007.png
