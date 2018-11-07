USE LabicAr

PRINT 'Creating Player View'
GO

create VIEW MetricasView
 AS
SELECT distinct Metrics.MetricsId,
dbo.Jugadores.JugadoresId,
	jugadores.UserName,
	Personas.Documento,
	Personas.Nombre,
	Personas.Apellido,
	Metrics.HoraInicio,
	Metrics.ObservacionProfesor,
	CAST (SUM(dbo.Eventos.tiempo) AS  int)as tiempo
	FROM dbo.Eventos
INNER JOIN dbo.Metrics
ON dbo.Eventos.MetricsId = dbo.Metrics.MetricsId
INNER JOIN dbo.Jugadores
ON Metrics.JugadorId = Jugadores.JugadoresId
INNER JOIN dbo.Personas
ON dbo.Jugadores.JugadoresId = dbo.Personas.JugadoresId
GROUP BY dbo.Metrics.MetricsId,
 dbo.Jugadores.JugadoresId,
 dbo.Jugadores.UserName,
 dbo.Personas.Documento,
 dbo.Personas.Nombre,
 dbo.Personas.Apellido,
 dbo.Metrics.HoraInicio,
 dbo.Metrics.ObservacionProfesor

--order by HoraInicio desc 


