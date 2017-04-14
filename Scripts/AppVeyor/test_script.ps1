$opencover = (Resolve-Path ".\Source\packages\OpenCover.4.6.*\tools\OpenCover.Console.exe").ToString()
& $opencover -register:user `
             -target:"Source\Packages\NUnit.ConsoleRunner.3.6.1\tools\nunit3-console.exe" `
             -targetargs:"Source\WbTstr.UnitTests\bin\Debug\WbTstr.UnitTests.dll" `
             -filter:"+[WbTstr*]*" `
             -output:opencover.xml 

$coveralls = (Resolve-Path "Source\packages\coveralls.net.*\tools\csmacnz.coveralls.exe").ToString()
& $coveralls --useRelativePaths `
             --serviceName AppVeyor `
             --opencover -i opencover.xml `
             --repoToken $env:COVERALLS_REPO_TOKEN `
             --commitId $env:APPVEYOR_REPO_COMMIT `
             --commitBranch $env:APPVEYOR_REPO_BRANCH `
             --commitAuthor $env:APPVEYOR_REPO_COMMIT_AUTHOR `
             --commitEmail $env:APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL `
             --commitMessage $env:APPVEYOR_REPO_COMMIT_MESSAGE `
             --jobId $env:APPVEYOR_BUILD_NUMBER 
             
