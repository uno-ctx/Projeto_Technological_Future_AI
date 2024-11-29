@echo off
:: Verifica se o script está sendo executado como administrador
net session >nul 2>&1
if %errorLevel% neq 0 (
    echo Solicitando execução como administrador...
    powershell -Command "Start-Process '%~f0' -Verb runAs"
    exit /b
)

echo Este script está sendo executado como administrador!

:: Para os serviços do SQL Server
echo Parando serviços do SQL Server...
sc stop MSSQLFDLauncher
sc stop MSSQLSERVER
sc stop SQLSERVERAGENT 
sc stop MSSQLServerOLAPService
sc stop SSASTELEMETRY
sc stop SQLTELEMETRY
sc stop MsDtsServer160
sc stop SSISTELEMETRY160
sc stop MSSQLLaunchpad

echo Serviços SQL Server parados.

pause
