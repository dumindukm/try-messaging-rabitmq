https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html

https://hub.docker.com/_/rabbitmq

docker run -d --hostname order-processor-host --name order-processor rabbitmq:3
docker run -d --hostname order-processor-host --name order-processor -p 8080:15672 -p  5672:5672 rabbitmq:3-management
http://localhost:8080
https://www.rabbitmq.com/getstarted.html