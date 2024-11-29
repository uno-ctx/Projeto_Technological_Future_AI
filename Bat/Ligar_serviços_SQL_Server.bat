@echo off
:: Verifica se o script está sendo executado como administrador
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo Solicitando execução como administrador...
    powershell -Command "Start-Process '%~f0' -Verb runAs"
    exit /b
)

echo Este script está sendo executado como administrador!

:: Executar os serviços do SQL Server
echo Parando serviços do SQL Server...
sc start MSSQLFDLauncher
sc start MSSQLSERVER
sc start SQLSERVERAGENT 
sc start MSSQLServerOLAPService
sc start SSASTELEMETRY
sc start SQLTELEMETRY
sc start MsDtsServer160
sc start SSISTELEMETRY160
sc start MSSQLLaunchpad

echo Serviços SQL Server executados.

pause

