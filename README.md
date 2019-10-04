# Implement onion architecture in .net core 
![alt text](https://www.codeguru.com/imagesvr_ce/2236/Onion1.png)
Onion Architecture layers are connected through interfaces. Implantations are provided during run time.
Application architecture is built on top of a domain model.
All external dependency, like database access and service calls, are represented in external layers.
No dependencies of the Internal layer with external layers.
Couplings are towards the center.
Flexible and sustainable and portable architecture.
No need to create common and shared projects.
Can be quickly tested because the application core does not depend on anything.
