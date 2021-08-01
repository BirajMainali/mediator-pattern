## Introduction To MediatR Pattern

MediatR Pattern/Library is used to reduce dependencies between objects. It allows in-process messaging,but it will not allow direct communication between objects. Instead of this it forces to communicate via MediatR only, such as classes that don't have dependencies on each other, that's why they are less coupled
## Installing MediatR

The first thing we need to do is install the MediatR nuget package. So from your package manager console run :

`Install-Package MediatR`

We also need to install a package that allows us to use the inbuilt IOC container in .NET Core to our advantage (We’ll see more of that shortly). So also install the following package :

`Install-Package MediatR.Extensions.Microsoft.DependencyInjection`
