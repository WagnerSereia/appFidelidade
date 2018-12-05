
Tools –> NuGet Package Manager –> Package Manager Console
Run the following command to create a model from the existing database:

Selecionar em "Default project" o projeto "AppFidelidade.Data"

Scaffold-DbContext "Server=fidelidade13net.database.windows.net;Database=DatabaseFidelidade;Trusted_Connection=False;user id=UsrFide13Net;password=PwdFide13Net;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
Scaffold-DbContext "Server=.;Database=DatabaseFidelidade;Trusted_Connection=False;user id=UsrFide13Net;password=PwdFide13Net;MultipleActiveResultSets=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force


---------------------------------------
dotnet ef --startup-project ../MetrisX.Data.Generator migrations add  Initial
dotnet ef database update