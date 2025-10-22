# Script PowerShell para executar testes
# Facilita a execução de diferentes tipos de testes

Write-Host "🧪 Executando Testes Automatizados com xUnit" -ForegroundColor Green
Write-Host "=============================================" -ForegroundColor Green

# Função para executar testes com diferentes filtros
function Run-Tests {
    param(
        [string]$Filter = "",
        [string]$Description = "Todos os testes"
    )
    
    Write-Host "`n📋 $Description" -ForegroundColor Yellow
    
    if ($Filter -ne "") {
        $command = "dotnet test --filter `"$Filter`" --verbosity normal"
    } else {
        $command = "dotnet test --verbosity normal"
    }
    
    Write-Host "Comando: $command" -ForegroundColor Cyan
    Invoke-Expression $command
}

# Função para executar testes com cobertura
function Run-TestsWithCoverage {
    param(
        [string]$Filter = ""
    )
    
    Write-Host "`n📊 Executando testes com cobertura de código" -ForegroundColor Yellow
    
    if ($Filter -ne "") {
        $command = "dotnet test --filter `"$Filter`" --collect:`"XPlat Code Coverage`" --results-directory ./TestResults"
    } else {
        $command = "dotnet test --collect:`"XPlat Code Coverage`" --results-directory ./TestResults"
    }
    
    Write-Host "Comando: $command" -ForegroundColor Cyan
    Invoke-Expression $command
}

# Menu interativo
function Show-Menu {
    Write-Host "`n🎯 Escolha uma opção:" -ForegroundColor Magenta
    Write-Host "1. Executar todos os testes" -ForegroundColor White
    Write-Host "2. Executar apenas testes unitários" -ForegroundColor White
    Write-Host "3. Executar apenas testes de integração" -ForegroundColor White
    Write-Host "4. Executar testes com cobertura" -ForegroundColor White
    Write-Host "5. Executar testes específicos (exemplos)" -ForegroundColor White
    Write-Host "6. Limpar resultados anteriores" -ForegroundColor White
    Write-Host "7. Sair" -ForegroundColor White
    Write-Host ""
}

# Função principal
function Main {
    do {
        Show-Menu
        $choice = Read-Host "Digite sua escolha (1-7)"
        
        switch ($choice) {
            "1" {
                Run-Tests -Description "Todos os testes"
            }
            "2" {
                Run-Tests -Filter "FullyQualifiedName~Unit" -Description "Testes Unitários"
            }
            "3" {
                Run-Tests -Filter "FullyQualifiedName~Integration" -Description "Testes de Integração"
            }
            "4" {
                Run-TestsWithCoverage -Description "Testes com Cobertura de Código"
            }
            "5" {
                Run-Tests -Filter "FullyQualifiedName~Examples" -Description "Testes de Exemplos"
            }
            "6" {
                Write-Host "🧹 Limpando resultados anteriores..." -ForegroundColor Yellow
                if (Test-Path "./TestResults") {
                    Remove-Item -Recurse -Force "./TestResults"
                }
                if (Test-Path "./CoverageReport") {
                    Remove-Item -Recurse -Force "./CoverageReport"
                }
                Write-Host "✅ Limpeza concluída!" -ForegroundColor Green
            }
            "7" {
                Write-Host "👋 Saindo..." -ForegroundColor Green
                break
            }
            default {
                Write-Host "❌ Opção inválida. Tente novamente." -ForegroundColor Red
            }
        }
        
        if ($choice -ne "7") {
            Write-Host "`nPressione qualquer tecla para continuar..." -ForegroundColor Gray
            $null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
        }
        
    } while ($choice -ne "7")
}

# Verificar se estamos no diretório correto
if (-not (Test-Path "Tests.csproj")) {
    Write-Host "❌ Erro: Execute este script no diretório Tests/" -ForegroundColor Red
    exit 1
}

# Executar função principal
Main
