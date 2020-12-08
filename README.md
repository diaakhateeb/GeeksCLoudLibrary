
# Cloud Service class library
The Cloud Service class library objective is to create a library for a company to create and maintain their cloud infrastructure efficiently without needing to have deep knowledge about different cloud providers. This library will introduce APIs and abstractions that developers can use to design and implement cloud agnostic infrastructure. The client wants to start the first phase by supporting only virtual machines and database servers. But they would want more resources (i.e. load balancers, elastic file storage etc) at later stages. They want to be able to create both Windows and Linux instances. For database servers they want support for both MySQL and SQL Server. The client wants to be able to create multiple infrastructures as well, for example they want to create a UAT infrastructure for one project and a Test infrastructure for one project and a Test infrastructure for their internal team.

# Description
The class library does provide interfaces for creating infrastructure resources. It has been developed using SOLID principles as much as it possible to provide clean code and architecture that can be expanded and scaled with high rate of readability and maintenance.

## - Interfaces
The Cloud Service class library provides 16 interfaces that bring very high abstraction level.

 - **IResource**: For all resources components.
 - **IResourceInstance**: For resource instance such as Virtual Machine and Database server.
 - **IResourceFile**: For infrastructure Json configuration file on the cloud. It has Content property where configurations get stored, loaded and updated.
 - **IInfrastructure**: For Infrastructure component.
 - **IProvider**: For Provider component.
 - **IVirtualMachine**: For resource instance type of virtual machine.
 - **IDatabaseServer**: For resource instance type of database server.
 - **IOperatingSystem**: For the operating system that would be installed on the VM (Windows / Linux).
 - **IMemory**: For the RAM specifications that would be allocated to the infrastructure resource instance.
 - **IProcessor**: For the resource instance processor specifications.
 - **IStorage**: For the resource instance storage size and volume.
 - **ICloudService**: Provides all the needed infrastructure specifications that are required to create new cloud environment.
 - **ICloudServiceOperation**: Provides independent deletion function to the infrastructure.
 - **IFindInfrastructure**: Provides search functionality for the infrastructure.
 - **IInfrastructureOperation**: Provides the main infrastructure cloud functions such as Initializing new cloud infrastructure, Update infrastructure and Load infrastructure specifications/configurations.
 - **IResourceFileOperation**: Provides Update function to the infrastructure configuration file (Json). This gives ability to change infrastructure on the cloud. For example, increasing/decreasing memory or disk space.

 # Unit Testing
There are 2 unit tests here:

 - **CloudServiceUnitTests**: It has a unit test for deleting infrastructure by providing infrastructure name.
 - **InfrastructureOperationUnitTests**: It has 8 unit tests that cover Initializing, Updating and Loading infrastructure.
