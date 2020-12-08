
# Cloud Service class library
The Cloud Service class library objective is to create a library for a company to create and maintain their cloud infrastructure efficiently without needing to have deep knowledge about different cloud providers. This library will introduce APIs and abstractions that developers can use to design and implement cloud agnostic infrastructure. The client wants to start the first phase by supporting only virtual machines and database servers. But they would want more resources (i.e. load balancers, elastic file storage etc) at later stages. They want to be able to create both Windows and Linux instances. For database servers they want support for both MySQL and SQL Server. The client wants to be able to create multiple infrastructures as well, for example they want to create a UAT infrastructure for one project and a Test infrastructure for one project and a Test infrastructure for their internal team.

# Description
The class library does provide interfaces for creating infrastructure resources. It has been developed using SOLID principles as much as it possible to provide clean code and architecture that can be expanded and scaled with high rate of readability and maintenance.

## - Interfaces
The Cloud Service class library provides 14 interfaces that bring very high abstraction level.

- **IResource**: For all resources components.
- **IResourceInstance**: For resource instance such as Virtual Machine and Database server.
- **IResourceFile**: For infrastructure Json configuration file on the cloud. It has Content property where configurations get stored, loaded and updated.
 - **IInfrastructure**: For Infrastructure component.
 - **IProvider**: For Provider component.
 - **IVirtualMachine**: For resource instance type of virtual machine.
 - **IDatabaseServer**: For resource instance type of database server.
