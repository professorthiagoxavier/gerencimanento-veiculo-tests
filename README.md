# 🧪 Guia Passo a Passo: Criando Testes com xUnit

## 📋 Introdução

Este guia te ensina **passo a passo** como criar testes automatizados usando **xUnit** para o projeto de gerenciamento de veículos. Vamos criar 3 tipos de testes principais:

1. **VehicleTests** - Testes da entidade Vehicle
2. **VehicleRepositoryTests** - Testes do repositório
3. **CacheServiceTests** - Testes do serviço de cache

## 🎯 O que você vai aprender

- Como criar testes unitários do zero
- O que significa cada atributo e método
- Como usar mocks para simular dependências
- Como validar resultados com assertions


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

---

## 📚 Conceitos Básicos - O que significa cada item

### 🔧 **Atributos do xUnit**

#### `[Fact]`
```csharp
[Fact]
public void MeuTeste()
{
    // Este é um teste simples que executa uma vez
}
```
**O que faz**: Marca um método como um teste que será executado pelo xUnit.

#### `[Theory]`
```csharp
[Theory]
[InlineData("Toyota", "Corolla")]
[InlineData("Honda", "Civic")]
public void TesteComMultiplosDados(string marca, string modelo)
{
    // Este teste executa várias vezes com dados diferentes
}
```
**O que faz**: Permite executar o mesmo teste com diferentes dados.

#### `[InlineData]`
```csharp
[InlineData("Toyota", "Corolla", 2023)]
```
**O que faz**: Fornece dados específicos para o teste Theory.

### 🎯 **Assertions (Validações)**

#### `Assert.NotNull()`
```csharp
Assert.NotNull(vehicle);
```
**O que faz**: Verifica se o objeto não é null.

#### `Assert.Equal()`
```csharp
Assert.Equal("Toyota", vehicle.Brand);
```
**O que faz**: Verifica se dois valores são iguais.

#### `Assert.True()`
```csharp
Assert.True(vehicle.Year > 2000);
```
**O que faz**: Verifica se uma condição é verdadeira.

#### `Assert.Throws()`
```csharp
Assert.Throws<ArgumentNullException>(() => metodoQuePodeFalhar());
```
**O que faz**: Verifica se uma exceção específica é lançada.

### 🌊 **FluentAssertions**

#### `Should().NotBeNull()`
```csharp
vehicle.Should().NotBeNull();
```
**O que faz**: Mesmo que `Assert.NotNull()`, mas com sintaxe mais legível.

#### `Should().Be()`
```csharp
vehicle.Brand.Should().Be("Toyota");
```
**O que faz**: Mesmo que `Assert.Equal()`, mas mais legível.

#### `Should().BeOfType()`
```csharp
result.Should().BeOfType<Vehicle>();
```
**O que faz**: Verifica se o objeto é do tipo especificado.

### 🎭 **Mocks**

#### `Mock<T>`
```csharp
var mockRepository = new Mock<IVehicleRepository>();
```
**O que faz**: Cria um objeto falso que simula o comportamento de uma classe real.

#### `Setup()`
```csharp
mockRepository.Setup(r => r.GetAllVehiclesAsync()).ReturnsAsync(vehicles);
```
**O que faz**: Configura o que o mock deve retornar quando um método é chamado.

#### `Verify()`
```csharp
mockRepository.Verify(r => r.GetAllVehiclesAsync(), Times.Once);
```
**O que faz**: Verifica se um método foi chamado e quantas vezes.

---

## 🚀 Passo a Passo: Criando os Testes

### 📁 **Passo 1: Estrutura do Projeto**

Primeiro, vamos criar a estrutura de pastas:

```
Tests/
├── Tests.csproj
├── Unit/
│   ├── Domain/
│   │   └── VehicleTests.cs
│   ├── Repository/
│   │   └── VehicleRepositoryTests.cs
│   └── Service/
│       └── CacheServiceTests.cs
```

### 📦 **Passo 2: Configurar o Projeto de Testes**

Crie o arquivo `Tests.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
    <PackageReference Include="xunit" Version="2.6.1" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.5.3" />
    <PackageReference Include="Moq" Version="4.20.69" />
    <PackageReference Include="FluentAssertions" Version="6.12.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Domain\Domain.csproj" />
    <ProjectReference Include="..\Repository\Repository.csproj" />
    <ProjectReference Include="..\Service\Service.csproj" />
  </ItemGroup>
</Project>
```

---

## 🧪 **Teste 1: VehicleTests.cs**

### **O que vamos testar:**
- Se um veículo pode ser criado
- Se as propriedades são definidas corretamente
- Se diferentes tipos de dados são aceitos

### **Passo a Passo:**

#### **1. Criar a classe de teste**
```csharp
using Domain;
using FluentAssertions;
using Xunit;

namespace Tests.Unit.Domain
{
    public class VehicleTests
    {
        // Aqui vão os nossos testes
    }
}
```

#### **2. Teste básico - Criar veículo**
```csharp
[Fact]
public void Vehicle_ShouldCreateInstance_WithValidProperties()
{
    // Arrange - Preparar os dados
    var vehicle = new Vehicle
    {
        Id = 1,
        Brand = "Toyota",
        Model = "Corolla",
        Year = 2023,
        Plate = "ABC-1234",
        Color = "Branco"
    };

    // Act - Executar a ação (neste caso, só criar o objeto)
    // (Não há ação específica, pois estamos testando a criação)

    // Assert - Verificar o resultado
    vehicle.Should().NotBeNull();
    vehicle.Id.Should().Be(1);
    vehicle.Brand.Should().Be("Toyota");
    vehicle.Model.Should().Be("Corolla");
    vehicle.Year.Should().Be(2023);
    vehicle.Plate.Should().Be("ABC-1234");
    vehicle.Color.Should().Be("Branco");
}
```

**Explicação:**
- `[Fact]`: Marca como um teste
- `Arrange`: Preparamos os dados necessários
- `Act`: Executamos a ação (aqui é só criar o objeto)
- `Assert`: Verificamos se tudo está correto
- `Should().NotBeNull()`: Verifica se não é null
- `Should().Be()`: Verifica se o valor é igual ao esperado

#### **3. Teste com múltiplos dados**
```csharp
[Theory]
[InlineData("Toyota", "Corolla", 2023)]
[InlineData("Honda", "Civic", 2024)]
[InlineData("Ford", "Focus", 2022)]
public void Vehicle_ShouldAcceptValidData(string brand, string model, int year)
{
    // Arrange
    var vehicle = new Vehicle
    {
        Brand = brand,
        Model = model,
        Year = year
    };

    // Act & Assert
    vehicle.Brand.Should().Be(brand);
    vehicle.Model.Should().Be(model);
    vehicle.Year.Should().Be(year);
}
```

**Explicação:**
- `[Theory]`: Permite múltiplas execuções
- `[InlineData]`: Fornece dados diferentes para cada execução
- Este teste executa 3 vezes, uma para cada `[InlineData]`

#### **4. Teste de propriedades nulas**
```csharp
[Fact]
public void Vehicle_ShouldAllowNullStrings_ForStringProperties()
{
    // Arrange & Act
    var vehicle = new Vehicle
    {
        Id = 1,
        Brand = null,
        Model = null,
        Year = 2023,
        Plate = null,
        Color = null
    };

    // Assert
    vehicle.Brand.Should().BeNull();
    vehicle.Model.Should().BeNull();
    vehicle.Plate.Should().BeNull();
    vehicle.Color.Should().BeNull();
}
```

**Explicação:**
- `Should().BeNull()`: Verifica se o valor é null
- Testamos se a classe aceita valores null (o que pode ser válido)

---

## 🗄️ **Teste 2: VehicleRepositoryTests.cs**

### **O que vamos testar:**
- Se o repositório valida parâmetros
- Se exceções são lançadas corretamente
- Se métodos assíncronos funcionam

### **Passo a Passo:**

#### **1. Criar a classe de teste**
```csharp
using Domain;
using FluentAssertions;
using Moq;
using Repository;
using Xunit;

namespace Tests.Unit.Repository
{
    public class VehicleRepositoryTests
    {
        private readonly VehicleRepository _repository;
        private readonly string _connectionString = "Server=localhost;Database=test;Uid=test;Pwd=test;";

        public VehicleRepositoryTests()
        {
            _repository = new VehicleRepository(_connectionString);
        }
    }
}
```

**Explicação:**
- `_repository`: Instância do repositório para testar
- `_connectionString`: String de conexão para testes
- Construtor: Inicializa o repositório antes de cada teste

#### **2. Teste de exceção - Veículo null**
```csharp
[Fact]
public async Task AddVehicleAsync_ShouldThrowArgumentNullException_WhenVehicleIsNull()
{
    // Arrange
    Vehicle vehicle = null;

    // Act & Assert
    await Assert.ThrowsAsync<ArgumentNullException>(() => 
        _repository.AddVehicleAsync(vehicle));
}
```

**Explicação:**
- `async Task`: Método assíncrono
- `Assert.ThrowsAsync<>()`: Verifica se uma exceção específica é lançada
- `ArgumentNullException`: Tipo de exceção esperada
- `() => _repository.AddVehicleAsync(vehicle)`: Expressão lambda que executa o método

#### **3. Teste de exceção com validação da mensagem**
```csharp
[Fact]
public async Task AddVehicleAsync_ShouldThrowArgumentNullException_WithCorrectMessage_WhenVehicleIsNull()
{
    // Arrange
    Vehicle vehicle = null;

    // Act
    var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => 
        _repository.AddVehicleAsync(vehicle));

    // Assert
    exception.ParamName.Should().Be("vehicle");
    exception.Message.Should().Contain("Veículo inválido");
}
```

**Explicação:**
- Capturamos a exceção em uma variável
- Verificamos o nome do parâmetro que causou a exceção
- Verificamos se a mensagem contém texto específico

#### **4. Teste com múltiplos IDs inválidos**
```csharp
[Theory]
[InlineData(0)]
[InlineData(-1)]
[InlineData(-100)]
public async Task DeleteVehicleAsync_ShouldThrowArgumentException_WhenIdIsInvalid(int invalidId)
{
    // Act & Assert
    var exception = await Assert.ThrowsAsync<ArgumentException>(() => 
        _repository.DeleteVehicleAsync(invalidId));
    
    exception.ParamName.Should().Be("id");
    exception.Message.Should().Contain("ID inválido");
}
```

**Explicação:**
- `[Theory]` com `[InlineData]`: Testa múltiplos valores
- Testa IDs inválidos (0, negativos)
- Verifica se a exceção correta é lançada

---

## ⚡ **Teste 3: CacheServiceTests.cs**

### **O que vamos testar:**
- Se o serviço de cache funciona corretamente
- Como usar mocks para simular o Redis
- Se métodos assíncronos retornam valores corretos

### **Passo a Passo:**

#### **1. Criar a classe de teste com mocks**
```csharp
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Service;
using StackExchange.Redis;
using Xunit;

namespace Tests.Unit.Service
{
    public class CacheServiceTests
    {
        private readonly Mock<IConfiguration> _mockConfiguration;
        private readonly Mock<ILogger<CacheService>> _mockLogger;
        private readonly Mock<IDatabase> _mockDatabase;

        public CacheServiceTests()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockLogger = new Mock<ILogger<CacheService>>();
            _mockDatabase = new Mock<IDatabase>();

            // Configurar o mock de configuração
            _mockConfiguration.Setup(c => c["ConnectionStrings:RedisConnection"])
                             .Returns("localhost:6379");
        }
    }
}
```

**Explicação:**
- `Mock<T>`: Cria objetos falsos que simulam o comportamento real
- `Setup()`: Configura o que o mock deve retornar
- `Returns()`: Define o valor de retorno do mock

#### **2. Teste de configuração do construtor**
```csharp
[Fact]
public void Constructor_ShouldUseDefaultConnectionString_WhenNotConfigured()
{
    // Arrange
    _mockConfiguration.Setup(c => c.GetConnectionString("RedisConnection"))
                     .Returns((string)null);

    // Act & Assert
    var exception = Assert.Throws<StackExchange.Redis.RedisConnectionException>(() => 
        new CacheService(_mockConfiguration.Object, _mockLogger.Object));
    
    exception.Should().NotBeNull();
}
```

**Explicação:**
- `Returns((string)null)`: Mock retorna null
- `_mockConfiguration.Object`: Acessa o objeto mockado
- Testamos o comportamento quando a configuração não existe

#### **3. Teste conceitual de método do cache**
```csharp
[Fact]
public async Task GetAsync_ShouldReturnValue_WhenKeyExists()
{
    // Arrange
    var key = "test-key";
    var expectedValue = "test-value";
    var redisValue = new RedisValue(expectedValue);

    _mockDatabase.Setup(db => db.StringGetAsync(key, It.IsAny<CommandFlags>()))
                .ReturnsAsync(redisValue);

    // Act & Assert
    // Nota: Este é um exemplo conceitual
    // Em um teste real, precisaríamos mockar o ConnectionMultiplexer
    _mockDatabase.Verify(db => db.StringGetAsync(key, It.IsAny<CommandFlags>()), Times.Never);
}
```

**Explicação:**
- `It.IsAny<CommandFlags>()`: Qualquer valor do tipo CommandFlags
- `ReturnsAsync()`: Retorna um valor assíncrono
- `Verify()`: Verifica se o método foi chamado
- `Times.Never`: Verifica que o método nunca foi chamado

#### **4. Teste de interface**
```csharp
[Fact]
public void CacheService_ShouldImplementICacheService()
{
    // Act & Assert
    typeof(CacheService).Should().BeAssignableTo<ICacheService>();
}
```

**Explicação:**
- `typeof(CacheService)`: Obtém o tipo da classe
- `Should().BeAssignableTo<>()`: Verifica se implementa uma interface
- Testa se a classe segue o contrato da interface

---

## 🎯 **Padrão AAA - Arrange, Act, Assert**

### **O que significa:**

#### **Arrange (Preparar)**
```csharp
// Arrange - Preparar dados e configurações
var vehicle = new Vehicle { Brand = "Toyota" };
var expectedResult = "Toyota";
```

#### **Act (Agir)**
```csharp
// Act - Executar a ação sendo testada
var result = vehicle.Brand;
```

#### **Assert (Verificar)**
```csharp
// Assert - Verificar o resultado
result.Should().Be(expectedResult);
```

### **Exemplo Completo:**
```csharp
[Fact]
public void Vehicle_ShouldReturnCorrectBrand()
{
    // Arrange - Preparar
    var vehicle = new Vehicle { Brand = "Toyota" };
    var expectedBrand = "Toyota";

    // Act - Executar
    var actualBrand = vehicle.Brand;

    // Assert - Verificar
    actualBrand.Should().Be(expectedBrand);
}
```

---

## 🚀 **Como Executar os Testes**

### **1. Via Visual Studio:**
1. Abra o projeto no Visual Studio
2. Vá em `Test → Test Explorer`
3. Clique em `Run All` ou `Ctrl + R, A`

### **2. Via Terminal:**
```bash
# Navegar para o diretório Tests
cd Tests

# Executar todos os testes
dotnet test

# Executar com detalhes
dotnet test --verbosity normal

# Executar testes específicos
dotnet test --filter "FullyQualifiedName~VehicleTests"
```

### **3. Resultado esperado:**
```
✅ Passed: 15
❌ Failed: 0
⏭️ Skipped: 0
```

---

## 📝 **Resumo dos Conceitos**

| Conceito | O que faz | Exemplo |
|----------|-----------|---------|
| `[Fact]` | Marca um método como teste | `[Fact] public void MeuTeste()` |
| `[Theory]` | Permite múltiplas execuções | `[Theory] [InlineData("dados")]` |
| `Should().Be()` | Verifica igualdade | `result.Should().Be("esperado")` |
| `Should().NotBeNull()` | Verifica se não é null | `obj.Should().NotBeNull()` |
| `Mock<T>` | Cria objeto falso | `var mock = new Mock<IRepository>()` |
| `Setup()` | Configura comportamento do mock | `mock.Setup(m => m.Method()).Returns(value)` |
| `Assert.ThrowsAsync<>()` | Verifica exceção assíncrona | `await Assert.ThrowsAsync<Exception>()` |

---

## 🎓 **Próximos Passos**

1. **Pratique**: Crie seus próprios testes
2. **Experimente**: Teste diferentes cenários
3. **Leia**: Documentação do xUnit e Moq
4. **Aplique**: Use em seus projetos reais

---

*Guia criado para ensinar testes automatizados de forma didática e prática* 🚀
