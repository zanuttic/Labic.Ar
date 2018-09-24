# Labic.Ar
#configurar un APPPOOL sin codigo Administrado y con seguridad integrada


#Instalar 
https://weblog.west-wind.com/posts/2016/Jun/06/Publishing-and-Running-ASPNET-Core-Applications-with-IIS

DotNetCore.1.0.0.RC2-WindowsHosting.exe

#verificar lospermisos del Usuario 
IIS APPPOOL\DefaultAppPool

#verificar que los permisos
Asegúrese de que db_denydatareader y db_denydatawriter esten desactivados

