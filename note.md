requirementes
    1. .NET sdk. (in mac : brew install --cask dotnet-sdk)
        verify : dotnet --version
                dotnet --info: show the architecture (for me it is arm am using m series mac)
    2. VS code
        install extension : search "c# dev kit" and install that 


create new .Net project
>dotnet new list : show all the template available
for this we take .NET core empty web 
>dotnet new web -n GameStore.Api
or we can do with vs code :
method 2 simple and recommended
    cmd + shift + p (or view --> command palatte) click .net core empty --> then last click .slnx (newer version) 

soluction explorer : in the explorer tab contin the sol explorer contain the virtual view of this application


structure
1. program.cs
    var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

builer-> contain all the supply to build
app --> create a ap using that build a instance


