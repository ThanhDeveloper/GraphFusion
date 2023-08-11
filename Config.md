## Generate manifest 
- ```dotnet new tool-manifest```
- ``` dotnet tool install Hotchocolate.Fusion.commandline```
## Select template 
- ```dotnet new install Hotchocolate.templates```
## Generate ```subgraph-config.json```
- ```dotnet fusion subgraph config set http --url http://localhost:5238 -w .\DogGraph\```
## Generate ```schema.graphql```
- ```dotnet run --project .\DogGraph\ -- schema export --output schema.graphql```
## Create gateway 
- ```dotnet new install Hotchocolate.templates```
## Generate fsp file
- ``` dotnet fusion subgraph pack -w .\DogGraph\```
- ``` dotnet fusion compose -p .\Gateway\ -s .\DogGraph\```
