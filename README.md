# signalR-Rabbitmq-chatApp
Support request chat application built with signalr , rabbitmq and .net5

Steps to run the application:

Run the SignalR
```
cd ChatApp
dotnet run
```

Run the consumer service console application
```
cd ChatApp.Consumer
dotnet run
```

Run the angular client application
```
cd ChatApp.Frontend
npm install
npm run start
```

If you have docker installed in your pc, run 
```docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management```

else download https://github.com/rabbitmq/rabbitmq-server/releases/download/v3.8.14/rabbitmq-server-3.8.14.exe for windows

Note:
Make sure the following
signalR is hosted in https://localhost:5001
frontend is hosted in http://localhost:4200

Since this is for demo purpose the consumer service is based on different consumer types(Teams).
example: 
Select a team on console application startup and a chat session will be assigned to an agent in the selected team. Will improve the solution with authentication and single consumer service for all the teams in the future.
Refreshing the angular application will create a new chat session that will be added to the message queue. 
