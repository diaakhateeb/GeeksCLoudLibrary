
# Cloud Service class library
The Cloud Service class library objective is to create a library for a company to create and maintain their cloud infrastructure efficiently without needing to have deep knowledge about different cloud providers. This library will introduce APIs and abstractions that developers can use to design and implement cloud agnostic infrastructure. The client wants to start the first phase by supporting only virtual machines and database servers. But they would want more resources (i.e. load balancers, elastic file storage etc) at later stages. They want to be able to create both Windows and Linux instances. For database servers they want support for both MySQL and SQL Server. The client wants to be able to create multiple infrastructures as well, for example they want to create a UAT infrastructure for one project and a Test infrastructure for one project and a Test infrastructure for their internal team.

# Description
The class library does provide interfaces for creating infrastructure resources. It has been developed using SOLID principles as much as it possible to provide clean code and architecture that can be expanded and scaled with high rate of readability and maintenance.

## - Interfaces
The Cloud Service class library provides 16 interfaces that bring very high abstraction level.

 - **[IResource](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Shared/Interfaces/IResource.cs)**: For all resources components.
 - **[IResourceInstance](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/ResourceInstance/Interfaces/IResourceInstance.cs)**: For resource instance such as Virtual Machine and Database server.
 - **[IResourceFile](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/ResourceFile/Interfaces/IResourceFile.cs)**: For infrastructure Json configuration file on the cloud. It has Content property where configurations get stored, loaded and updated.
 - **[IInfrastructure](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Infrastructure/Interfaces/IInfrastructure.cs)**: For Infrastructure component.
 - **[IProvider](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Providers/Interfaces/IProvider.cs)**: For Provider component.
 - **[IVirtualMachine](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Resource/VirtualMachine/Interfaces/IVirtualMachine.cs)**: For resource instance type of virtual machine.
 - **[IDatabaseServer](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Resource/DatabaseServer/Interfaces/IDatabaseServer.cs)**: For resource instance type of database server.
 - **[IOperatingSystem](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Resource/VirtualMachine/OperatingSystem/Interfaces/IOperatingSystem.cs)**: For the operating system that would be installed on the VM (Windows / Linux).
 - **[IMemory](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Resource/Specs/Memory/Interfaces/IMemory.cs)**: For the RAM specifications that would be allocated to the infrastructure resource instance.
 - **[IProcessor](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Resource/Specs/Processor/Interfaces/IProcessor.cs)**: For the resource instance processor specifications.
 - **[IStorage](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Resource/Specs/Storage/Interfaces/IStorage.cs)**: For the resource instance storage size and volume.
 - **[ICloudService](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Operations/Interfaces/ICloudService.cs)**: Provides all the needed infrastructure specifications that are required to create new cloud environment.
 - **[ICloudServiceOperation](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Operations/Interfaces/ICloudServiceOperation.cs)**: Provides independent deletion function to the infrastructure.
 - **[IFindInfrastructure](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Operations/Interfaces/IFindInfrastructure.cs)**: Provides search functionality for the infrastructure.
 - **[IInfrastructureOperation](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Operations/Interfaces/IInfrastructureOperation.cs)**: Provides the main infrastructure cloud functions such as Initializing new cloud infrastructure, Update infrastructure and Load infrastructure specifications/configurations.
 - **[IResourceFileOperation](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibrary/Operations/Interfaces/IResourceFileOperation.cs)**: Provides Update function to the infrastructure configuration file (Json). This gives ability to change infrastructure on the cloud. For example, increasing/decreasing memory or disk space.

 # Unit Testing
There are 2 unit tests here:

 - **[CloudServiceUnitTests](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibraryXUnitTest/CloudServiceUnitTests.cs)**: It has a unit test for deleting infrastructure by providing infrastructure name.
 - **[InfrastructureOperationUnitTests](https://github.com/diaakhateeb/GeeksCloudLibrary/blob/master/GeeksCloudLibraryXUnitTest/InfrastructureOperationUnitTests.cs)**: It has 8 unit tests that cover Initializing, Updating and Loading infrastructure.
