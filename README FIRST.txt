Previous requirements:

Visual Studio 2022.
Microsoft Edge.
RabbitMQ for Windows. 
Erlang for Windows.
POSTMAN for Windows.

--------------------------------------------------

WHAT'S THIS APPLICATION ABOUT?

This is a microservices backend demo which has the "Producer-Consumer" architecture. It has three projects, a communication system based on "message-queues" called RabbitMQ and an open-source framework to support distributed ASP.NET CORE applications called Masstransit. This microservices application simulates a fictional "online Pharmacy web application" which the clients use to request medications. For simplicity purposes I've ommited the implementation of individual databases for each project involved in the "Producer-Consumer architecture". Instead, I've implemented a "fake medication object":


MedServiceAPI project:

    This is the Producer in the "Producer-Consumer" model. This component "produces" the new "medication request" sent from the client's web UI. 
    Which has not been created for this example. 

Model project:

    In order to "produce" a new "medication request", the MedServiceAPI project  implements a Model project containing a single "Medication class".  

Masstransit-Rabbitmq-Asp.Net core integration: 

    Since this framework has integrations with both Asp.Net core and
    Rabbitmq it can create a communication channel using the "amqp" protocol, establish a new message-queue using Rabbitmq's default configurations and allow Rabbitmq to receive and handle this new "medication request".

AuthServiceAPI project:

    This is the project that "consumes" the "medication request" received from the Rabbitmq the message-queue, created for this new communication session between Producer and Consumer. For simplicity purposes I've created a "MedicationConsumer class" which handles the tasks of logging and displaying to the console the newly processed "medication request".



--------------------------------------------------

HOW TO RUN IT LOCALLY?

1- RabbitMQ: Open a new "Edge" browser window, then type in http://localhost:15672/ in
   the address bar.

2- Make sure you already deleted all previous messages and queues. For that you can
   check on the tabs "Exchange" and "Queues and Streams". 

3- In the "Exchange" tab, verify that only default "amqp" related items are being
   displayed on the grid. 

4- In the "Queues and Streams" tab, verify that the message "... no queues ..." is being
   displayed. 
   
5- If any of the previous steps show that there is at least one queue present, proceed 
   to delete it.

6- By Clicking on every queue you'll be automatically taken to the "queue details".    
   Scroll down and you'll find both "Purge messages" and "Delete" buttons. Confirm "OK" on every case to delete the queue permanently. It's very important that the Rabbitmq system is clear and ready to create new queues.

7- Open the solution "\\PharmacyMSVC\AuthServiceAPI.sln"

8- Run the solution as it is.

9- Open the solution "\\PharmacyMSVC\MedServiceAPI.sln"

10- Run the solution as it is.

11- Open POSTMAN for Windows. 

12- From the combo of "http verbs" (POST, PUT, DELETE, etc), select POST.

13- On the address bar type in or paste the following URL:

        https://localhost:5001/api/medication

14- On the menu below the address bar (Params, Auth, Headers, etc) click on "Body" 
    option.

15- From the first combo (none, form-data, etc), below "Body" option, select "raw".

16- From the second combo (Text, JavaScript, etc), select "JSON" .

17- On the textbox below these combos which shows line numbers, type in or paste the following text. It's an example of medication:

    {"Name": "Cholbam"}

18- Now click on the "SEND" blue button on the right of the address bar.

19- Quicly check on the AuthServiceAPI console window. You should see a message like 

    "New medication has been requested: Cholbam".

20- Now quickly check on the tabs "Exchange" and "Queues and Streams" of Rabbitmq.
 You should see activity and the presence of the new elements
 
  "Model:Medication", type fanout and 
  "medication-queue", type fanout.

--------------------------------------------------

Highlights:

    - Microservices architecture, a versatile design approach that provides an
      alternative to traditional monolithic systems, assists in scaling applications,
      boosting development speed, and fostering organizational growth. With its adaptability, it can be implemented using containers, serverless approaches, or a blend of the two, tailoring to specific needs.

    - While there are other technologies to address the microservices challenges, 
      I opted for implementing Rabbitmq and Masstransit for being open-source, 
      cost-effective and affordable for most small to medium-size companies.   