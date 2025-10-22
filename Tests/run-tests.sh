#!/bin/bash

# Script Bash para executar testes
# Facilita a execução de diferentes tipos de testes

echo "🧪 Executando Testes Automatizados com xUnit"
echo "============================================="

# Função para executar testes com diferentes filtros
run_tests() {
    local filter="$1"
    local description="$2"
    
    echo ""
    echo "📋 $description"
    
    if [ -n "$filter" ]; then
        echo "Comando: dotnet test --filter \"$filter\" --verbosity normal"
        dotnet test --filter "$filter" --verbosity normal
    else
        echo "Comando: dotnet test --verbosity normal"
        dotnet test --verbosity normal
    fi
}

# Função para executar testes com cobertura
run_tests_with_coverage() {
    local filter="$1"
    
    echo ""
    echo "📊 Executando testes com cobertura de código"
    
    if [ -n "$filter" ]; then
        echo "Comando: dotnet test --filter \"$filter\" --collect:\"XPlat Code Coverage\" --results-directory ./TestResults"
        dotnet test --filter "$filter" --collect:"XPlat Code Coverage" --results-directory ./TestResults
    else
        echo "Comando: dotnet test --collect:\"XPlat Code Coverage\" --results-directory ./TestResults"
        dotnet test --collect:"XPlat Code Coverage" --results-directory ./TestResults
    fi
}

# Menu interativo
show_menu() {
    echo ""
    echo "🎯 Escolha uma opção:"
    echo "1. Executar todos os testes"
    echo "2. Executar apenas testes unitários"
    echo "3. Executar apenas testes de integração"
    echo "4. Executar testes com cobertura"
    echo "5. Executar testes específicos (exemplos)"
    echo "6. Limpar resultados anteriores"
    echo "7. Sair"
    echo ""
}

# Função principal
main() {
    while true; do
        show_menu
        read -p "Digite sua escolha (1-7): " choice
        
        case $choice in
            1)
                run_tests "" "Todos os testes"
                ;;
            2)
                run_tests "FullyQualifiedName~Unit" "Testes Unitários"
                ;;
            3)
                run_tests "FullyQualifiedName~Integration" "Testes de Integração"
                ;;
            4)
                run_tests_with_coverage "Todos os testes com cobertura"
                ;;
            5)
                run_tests "FullyQualifiedName~Examples" "Testes de Exemplos"
                ;;
            6)
                echo "🧹 Limpando resultados anteriores..."
                rm -rf ./TestResults
                rm -rf ./CoverageReport
                echo "✅ Limpeza concluída!"
                ;;
            7)
                echo "👋 Saindo..."
                break
                ;;
            *)
                echo "❌ Opção inválida. Tente novamente."
                ;;
        esac
        
        if [ "$choice" != "7" ]; then
            echo ""
            echo "Pressione Enter para continuar..."
            read
        fi
    done
}

# Verificar se estamos no diretório correto
if [ ! -f "Tests.csproj" ]; then
    echo "❌ Erro: Execute este script no diretório Tests/"
    exit 1
fi

# Executar função principal
main
