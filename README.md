# Project2

Avanade Practical Project Specification

**Brief**

The brief provided to us for this project sets the following out as its overall objective: "To create a service-orientated architecture for an application that must be composed of at least 4 services that work together."
This means that I must create a functional web application in ASP.Net using C# and test the code I produce. I must also produce a functional Azure DevOps pipeline that will deploy my code.


**My web application**

I have produced a web application that consists of 4 services that all function together, with service 1 being able to communicate with the 3 other services. This application will generate two random objects - one of which will be a food type (Eg burgers, pizza etc) and one that will

Service 1

This acts as the core service that renders the HTML needed to interact with the application. It is responsible for communicating with the other 3 other services. This will be done in MVC C#.



Service 2

This will be one of two services that will generate the random "object". In this case, this service will be number generator with 2 different implementations available:

- one that creates a 4-digit number
- one that creates a 5-digit number


Service 3

This will be one of two services that will generate a random "object". In this case, this service will be pulling an item from an array. The items in the array will be colours. 

Service 4


**User Journey**
The user will input their name into the frontend and a colour and membership number will be generated for the user.


**Architecture**

The workflow below shows the way in which the services communicate together to be able to generate objects (number and string generator) that merge together.

![image](https://user-images.githubusercontent.com/70802911/122636415-10064f00-d0e1-11eb-917d-34e957caeee7.png)

**Project Tracking**

Jira was used to track the progress of my project and allowed me to look at the different parts of the project so I knew what was needed to be done.
https://farzanaakter1.atlassian.net/secure/RapidBoard.jspa?projectKey=PPS&useStoredSettings=true&rapidView=4&atlOrigin=eyJpIjoiOWIwZjE4MWU1YTQyNDNkZTk1ZmI5ZGY4YzgyMTczMjMiLCJwIjoiaiJ9
