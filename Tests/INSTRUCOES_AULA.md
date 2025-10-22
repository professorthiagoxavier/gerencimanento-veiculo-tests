# 🎓 Instruções para a Aula de Testes Automatizados

## 🚀 Como Usar Este Material

### 1. **Preparação do Ambiente**

#### **Pré-requisitos:**
- ✅ Visual Studio 2022 ou VS Code
- ✅ .NET 8.0 SDK
- ✅ Git (opcional)

#### **Configuração:**
```bash
# 1. Navegar para o diretório do projeto
cd C:\Fiap\gerenciamento-veiculos

# 2. Restaurar dependências
dotnet restore

# 3. Compilar a solução
dotnet build

# 4. Navegar para o projeto de testes
cd Tests
```

### 2. **Execução dos Testes**

#### **Opção A: Via Visual Studio**
1. Abrir a solução no Visual Studio
2. Ir em `Test → Test Explorer`
3. Executar todos os testes: `Ctrl + R, A`
4. Executar teste específico: Clique direito → `Run`

#### **Opção B: Via Terminal**
```bash
# Executar todos os testes
dotnet test

# Executar com detalhes
dotnet test --verbosity normal

# Executar testes específicos
dotnet test --filter "FullyQualifiedName~Unit"
dotnet test --filter "FullyQualifiedName~Integration"
dotnet test --filter "FullyQualifiedName~Examples"
```

#### **Opção C: Via Scripts**
```bash
# Windows PowerShell
.\run-tests.ps1

# Linux/Mac
./run-tests.sh
```

### 3. **Estrutura da Aula**

#### **Parte 1: Fundamentos (30 min)**
- 📚 Conceitos básicos de testes automatizados
- 🧪 Introdução ao xUnit
- 📋 Padrão AAA (Arrange, Act, Assert)
- 🔍 Tipos de assertions

#### **Parte 2: Testes Unitários (45 min)**
- 🏗️ Testes da camada Domain
- 🗄️ Testes da camada Repository
- ⚡ Testes da camada Service
- 🎯 Uso de mocks e stubs

#### **Parte 3: Testes de Integração (30 min)**
- 🔗 Testes entre camadas
- 🏛️ Validação de arquitetura
- 📊 Testes de fluxos completos

#### **Parte 4: Práticas Avançadas (30 min)**
- 🏗️ Test Data Builders
- 📈 Cobertura de código
- 🚀 Performance de testes
- 🎯 Boas práticas

### 4. **Exercícios Práticos**

#### **Exercício 1: Teste Básico**
```csharp
// TODO: Criar teste para validar se um veículo pode ter ano futuro
[Fact]
public void Vehicle_ShouldAllowFutureYear()
{
    // Implementar aqui
}
```

#### **Exercício 2: Teste com Theory**
```csharp
// TODO: Criar teste com múltiplos dados
[Theory]
[InlineData("Toyota", "Corolla", 2023)]
[InlineData("Honda", "Civic", 2024)]
public void Vehicle_ShouldAcceptValidData(string brand, string model, int year)
{
    // Implementar aqui
}
```

#### **Exercício 3: Teste de Exceção**
```csharp
// TODO: Criar teste para validar exceção
[Fact]
public void Vehicle_ShouldThrowException_WhenInvalidData()
{
    // Implementar aqui
}
```

### 5. **Demonstrações em Tempo Real**

#### **Demo 1: Execução de Testes**
```bash
# Mostrar como executar testes
dotnet test --verbosity normal

# Mostrar resultados
# ✅ Passed: 15
# ❌ Failed: 0
# ⏭️ Skipped: 0
```

#### **Demo 2: Cobertura de Código**
```bash
# Executar com cobertura
dotnet test --collect:"XPlat Code Coverage"

# Gerar relatório
reportgenerator -reports:"TestResults/**/*.cobertura.xml" -targetdir:"CoverageReport" -reporttypes:Html
```

#### **Demo 3: Testes Específicos**
```bash
# Executar apenas testes unitários
dotnet test --filter "FullyQualifiedName~Unit"

# Executar apenas testes de integração
dotnet test --filter "FullyQualifiedName~Integration"
```

### 6. **Pontos de Discussão**

#### **Por que Testes Automatizados?**
- ✅ **Confiabilidade**: Garantem que o código funciona
- ✅ **Refatoração Segura**: Permitem mudanças sem medo
- ✅ **Documentação Viva**: Mostram como o código deve ser usado
- ✅ **Desenvolvimento Mais Rápido**: Detectam bugs cedo

#### **Tipos de Testes**
- 🧪 **Unitários**: Testam componentes isolados
- 🔗 **Integração**: Testam múltiplas camadas
- 🌐 **End-to-End**: Testam fluxos completos
- ⚡ **Performance**: Testam velocidade e recursos

#### **Boas Práticas**
- 📝 **Nomes Descritivos**: `ShouldReturnValue_WhenKeyExists`
- 🎯 **Um Teste, Uma Responsabilidade**: Teste apenas uma coisa
- 🏗️ **AAA Pattern**: Arrange, Act, Assert
- 🔄 **Independentes**: Testes não devem depender uns dos outros

### 7. **Troubleshooting**

#### **Problemas Comuns:**

**Testes não aparecem no Test Explorer:**
```bash
# Solução
dotnet clean
dotnet build
```

**Dependências não encontradas:**
```bash
# Solução
dotnet restore
```

**Mocks não funcionam:**
```csharp
// Verificar se o mock está configurado
mock.Setup(m => m.Method(It.IsAny<Parameter>()))
    .Returns(expectedValue);
```

### 8. **Recursos Adicionais**

#### **Documentação:**
- [xUnit Documentation](https://xunit.net/)
- [Moq Documentation](https://github.com/moq/moq4)
- [FluentAssertions](https://fluentassertions.com/)

#### **Ferramentas:**
- **Visual Studio Test Explorer**
- **dotnet test CLI**
- **Coverlet** (cobertura de código)
- **ReportGenerator** (relatórios)

### 9. **Checklist da Aula**

#### **Antes da Aula:**
- [ ] Ambiente configurado
- [ ] Projeto compilando
- [ ] Testes executando
- [ ] Material preparado

#### **Durante a Aula:**
- [ ] Conceitos explicados
- [ ] Exemplos demonstrados
- [ ] Exercícios práticos
- [ ] Dúvidas esclarecidas

#### **Após a Aula:**
- [ ] Exercícios completados
- [ ] Cobertura de código verificada
- [ ] Boas práticas aplicadas
- [ ] Próximos passos definidos

### 10. **Próximos Passos**

#### **Para os Alunos:**
1. **Praticar**: Criar testes para seus próprios projetos
2. **Estudar**: Ler documentação das ferramentas
3. **Aplicar**: Implementar testes em projetos reais
4. **Compartilhar**: Discutir experiências com a turma

#### **Para o Professor:**
1. **Avaliar**: Verificar compreensão dos conceitos
2. **Apoiar**: Ajudar com dificuldades específicas
3. **Expandir**: Introduzir conceitos mais avançados
4. **Conectar**: Relacionar com outros tópicos do curso

---

## 🎯 Objetivos de Aprendizagem

Ao final desta aula, os alunos devem ser capazes de:

- ✅ **Entender** os conceitos fundamentais de testes automatizados
- ✅ **Escrever** testes unitários usando xUnit
- ✅ **Usar** mocks e stubs para isolar dependências
- ✅ **Implementar** testes de integração
- ✅ **Medir** cobertura de código
- ✅ **Aplicar** boas práticas de teste
- ✅ **Executar** testes via diferentes ferramentas
- ✅ **Troubleshoot** problemas comuns

---

*Material preparado para demonstrar boas práticas de testes automatizados em .NET* 🚀
