Write-Host "Build Server Project"
$BuildServer = Start-Process dotnet -ArgumentList "build ..\AlertToCare\"

Write-Host "Build Client Project"
$BuildClient = Start-Process dotnet -ArgumentList "build ..\GuiClient\"
Start-Sleep -s 10


Write-Host "Starting Server..."
$ServerProcess = Start-Process dotnet -ArgumentList "run --project ..\AlertToCare\"
Write-Host "Sleeping to wait for Server to start"
Start-Sleep -s 10


Write-Host "Starting Client..."
$ClientProcess = Start-Process dotnet -ArgumentList "run --project ..\GuiClient\"
Start-Sleep -s 10

Write-Host "Running Integration Test"
$IntegrationTest = Start-Process dotnet -ArgumentList "test ..\AutomationTests\"
