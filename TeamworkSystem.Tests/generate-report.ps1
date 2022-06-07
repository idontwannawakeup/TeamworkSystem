$id=$args[0]
dotnet $env:USERPROFILE/.nuget/packages/reportgenerator/5.1.9/tools/net6.0/ReportGenerator.dll "-reports:TestResults/$id/coverage.cobertura.xml" "-targetdir:TestResults/$id/coveragereport" -reporttypes:Html
