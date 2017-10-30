# Resolve paths of executables
$opencover = (Resolve-Path ".\Source\packages\OpenCover.*\tools\OpenCover.Console.exe").ToString()
$coveralls = (Resolve-Path ".\Source\packages\coveralls.net.*\tools\csmacnz.coveralls.exe").ToString()
$nunitrunner = (Resolve-Path ".\Source\Packages\NUnit.ConsoleRunner.*\tools\nunit3-console.exe").ToString()

# Run tests through OpenCover
& $opencover -register:user `
            -target:"$nunitrunner" `
            -targetargs:".\Source\WbTstr.IntegrationTests\bin\$env:CONFIGURATION\WbTstr.IntegrationTests.dll" `
            -filter:"+[WbTstr*]*" `
            -filter:"-[WbTstr.IntegrationTests*]*" `
            -mergeoutput `
            -output:opencover.xml 

& $opencover -register:user `
             -target:"$nunitrunner" `
             -targetargs:".\Source\WbTstr.UnitTests\bin\$env:CONFIGURATION\WbTstr.UnitTests.dll" `
             -filter:"+[WbTstr*]*" `
             -filter:"-[WbTstr.UnitTests*]*" `
             -mergeoutput `
             -output:opencover.xml 

# Push results to Coveralls
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
             
