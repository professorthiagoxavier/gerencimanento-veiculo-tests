using Domain;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    /// <summary>
    /// Classe para demonstrar execução de testes programaticamente
    /// Útil para demonstrar conceitos de teste em tempo real
    /// </summary>
    public class TestRunner
    {
        private readonly ITestOutputHelper _output;

        public TestRunner(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void DemonstrateTestExecution()
        {
            // Arrange
            _output.WriteLine("=== Demonstração de Execução de Testes ===");
            _output.WriteLine("1. Arrange: Preparando dados de teste");
            
            var testData = new
            {
                VehicleId = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023
            };

            // Act
            _output.WriteLine("2. Act: Executando ação sendo testada");
            var result = $"Veículo {testData.Brand} {testData.Model} {testData.Year}";

            // Assert
            _output.WriteLine("3. Assert: Verificando resultado");
            _output.WriteLine($"Resultado: {result}");
            
            Assert.NotNull(result);
            Assert.Contains("Toyota", result);
            Assert.Contains("Corolla", result);
            Assert.Contains("2023", result);
            
            _output.WriteLine("✅ Teste executado com sucesso!");
        }

        [Theory]
        [InlineData("Toyota", "Corolla", 2023)]
        [InlineData("Honda", "Civic", 2024)]
        [InlineData("Ford", "Focus", 2022)]
        public void DemonstrateTheoryExecution(string brand, string model, int year)
        {
            // Arrange
            _output.WriteLine($"=== Teste Theory: {brand} {model} {year} ===");
            
            // Act
            var vehicleInfo = $"{brand} {model} {year}";
            
            // Assert
            _output.WriteLine($"Veículo: {vehicleInfo}");
            Assert.NotNull(vehicleInfo);
            Assert.Contains(brand, vehicleInfo);
            Assert.Contains(model, vehicleInfo);
            Assert.Contains(year.ToString(), vehicleInfo);
            
            _output.WriteLine("✅ Theory executado com sucesso!");
        }

        [Fact]
        public void DemonstrateTestCategories()
        {
            _output.WriteLine("=== Categorias de Teste ===");
            _output.WriteLine("📋 Unit Tests: Testam componentes isolados");
            _output.WriteLine("🔗 Integration Tests: Testam múltiplas camadas");
            _output.WriteLine("🌐 End-to-End Tests: Testam fluxos completos");
            _output.WriteLine("⚡ Performance Tests: Testam velocidade e recursos");
            _output.WriteLine("🔒 Security Tests: Testam vulnerabilidades");
            
            Assert.True(true); // Teste sempre passa
        }

        [Fact]
        public void DemonstrateTestLifecycle()
        {
            _output.WriteLine("=== Ciclo de Vida dos Testes ===");
            _output.WriteLine("1. 🏗️  Setup: Preparação inicial");
            _output.WriteLine("2. ▶️  Execution: Execução do teste");
            _output.WriteLine("3. 🧹 Teardown: Limpeza após teste");
            _output.WriteLine("4. 📊 Reporting: Relatório de resultados");
            
            Assert.True(true);
        }

        [Fact]
        public void DemonstrateAssertionTypes()
        {
            _output.WriteLine("=== Tipos de Assertions ===");
            
            // Arrange
            var vehicle = new Domain.Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023
            };

            // Act & Assert
            _output.WriteLine("✅ Assert.NotNull: Verifica se não é null");
            Assert.NotNull(vehicle);
            
            _output.WriteLine("✅ Assert.Equal: Verifica igualdade");
            Assert.Equal("Toyota", vehicle.Brand);
            
            _output.WriteLine("✅ Assert.True: Verifica condição verdadeira");
            Assert.True(vehicle.Year > 2000);
            
            _output.WriteLine("✅ Assert.False: Verifica condição falsa");
            Assert.False(vehicle.Year < 2000);
            
            _output.WriteLine("✅ Assert.Contains: Verifica se contém valor");
            Assert.Contains("Toyota", vehicle.Brand);
            
            _output.WriteLine("✅ Assert.Throws: Verifica exceções");
            Assert.Throws<ArgumentNullException>(() => 
            {
                Vehicle nullVehicle = null;
                if (nullVehicle == null) throw new ArgumentNullException();
            });
        }
    }
}
