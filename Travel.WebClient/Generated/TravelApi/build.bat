if $(ConfigurationName) == Debug "$(NSwagExe)" swagger2csclient 
/classname:ReserveDirectClient 
/namespace:REX.Core.Api.ReserveDirect 
/classstyle:Poco 
/exceptionClass:ReserveDirectApiException 
/arrayType:System.Collections.Generic.List 
/injectHttpClient:true 
/generateExceptionClasses:false 
/OperationGenerationMode:SingleClientFromOperationId 
/input:"$(ProjectDir)Generated\TravelApi\ReserveDirectClient.json" 
/output:"$(ProjectDir)Generated\ReserveDirectClient\ReserveDirectClient.cs"


if $(ConfigurationName) == Debug "$(NSwagExe)" swagger2csclient 
/classname:TravelApi 
/namespace:Travel.WebClient
/classstyle:Poco 
/arrayType:System.Collections.Generic.List 
/injectHttpClient:true 
/generateExceptionClasses:false 
/OperationGenerationMode:SingleClientFromOperationId 
/input:"https://travel-web-api.azurewebsites.net/swagger/booking-sample.json" 
/output:"$(ProjectDir)Generated\TravelApi\TravelApi.cs"


/exceptionClass:ReserveDirectApiException 