
## Introduction To MediatR Pattern
> MediatR Pattern/Library is used to reduce dependencies between objects. It allows in-process messaging,but it will not allow direct communication between objects. Instead of this it forces to communicate via MediatR only, such as classes that don't have dependencies on each other, that's why they are less coupled
## Installing MediatR

> The first thing we need to do is install the MediatR nuget package. So from your package manager console run :

`Install-Package MediatR`

 > We also need to install a package that allows us to use the inbuilt IOC container in .NET Core to our advantage (We’ll see more of that shortly). So also install the following package :

`Install-Package MediatR.Extensions.Microsoft.DependencyInjection`
# Testing
## Xunit
 > xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET and other .
 
`https://www.nuget.org/packages/xunit/`

## Moq
> You can use Moq to create mock objects that simulate or mimic a real object. Moq can be used to mock both classes and interfaces. However, there are a few limitations you should be aware of. The classes to be mocked can’t be static or sealed, and the method being mocked should be marked as virtual. (Note there are workarounds to these restrictions. You could mock a static method by taking advantage of the adapter design pattern, for example.)

`https://github.com/moq/moq4/tree/fc484fb85`