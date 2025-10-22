using Domain;
using FluentAssertions;
using Xunit;

namespace Tests.Examples
{
    /// <summary>
    /// Exemplos práticos para demonstração em aula
    /// Cada método demonstra um conceito específico de teste
    /// </summary>
    public class TestExamples
    {
        #region Exemplo 1: Teste Básico com Assert

        [Fact]
        public void Exemplo1_TesteBasicoComAssert()
        {
            // Arrange - Preparar dados
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "Toyota",
                Model = "Corolla",
                Year = 2023
            };

            // Act - Executar ação
            var vehicleInfo = $"{vehicle.Brand} {vehicle.Model} {vehicle.Year}";

            // Assert - Verificar resultado
            Assert.NotNull(vehicleInfo);
            Assert.Equal("Toyota Corolla 2023", vehicleInfo);
            Assert.Contains("Toyota", vehicleInfo);
        }

        #endregion

        #region Exemplo 2: Teste com FluentAssertions

        [Fact]
        public void Exemplo2_TesteComFluentAssertions()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "Honda",
                Model = "Civic",
                Year = 2024,
                Plate = "ABC-1234",
                Color = "Branco"
            };

            // Act & Assert - FluentAssertions é mais legível
            vehicle.Should().NotBeNull();
            vehicle.Brand.Should().Be("Honda");
            vehicle.Model.Should().Be("Civic");
            vehicle.Year.Should().Be(2024);
            vehicle.Plate.Should().NotBeNullOrEmpty();
            vehicle.Color.Should().Be("Branco");
        }

        #endregion

        #region Exemplo 3: Teste com Theory (Múltiplos Dados)

        [Theory]
        [InlineData("Toyota", "Corolla", 2023)]
        [InlineData("Honda", "Civic", 2024)]
        [InlineData("Ford", "Focus", 2022)]
        [InlineData("BMW", "X5", 2021)]
        public void Exemplo3_TesteComTheory(string brand, string model, int year)
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Brand = brand,
                Model = model,
                Year = year
            };

            // Act
            var isValid = vehicle.Year >= 2000 && 
                         !string.IsNullOrEmpty(vehicle.Brand) && 
                         !string.IsNullOrEmpty(vehicle.Model);

            // Assert
            Assert.True(isValid);
            vehicle.Brand.Should().Be(brand);
            vehicle.Model.Should().Be(model);
            vehicle.Year.Should().Be(year);
        }

        #endregion

        #region Exemplo 4: Teste de Exceção

        [Fact]
        public void Exemplo4_TesteDeExcecao()
        {
            // Arrange
            Vehicle vehicle = null;

            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                if (vehicle == null)
                    throw new ArgumentNullException(nameof(vehicle), "Veículo não pode ser null");
            });

            Assert.Equal("vehicle", exception.ParamName);
            Assert.Contains("Veículo não pode ser null", exception.Message);
        }

        #endregion

        #region Exemplo 5: Teste Assíncrono

        [Fact]
        public async Task Exemplo5_TesteAssincrono()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "Tesla",
                Model = "Model S",
                Year = 2023
            };

            // Act - Simular operação assíncrona
            var result = await SimulateAsyncOperation(vehicle);

            // Assert
            Assert.NotNull(result);
            result.Should().Be("Tesla Model S 2023 processado com sucesso");
        }

        private async Task<string> SimulateAsyncOperation(Vehicle vehicle)
        {
            await Task.Delay(100); // Simular operação assíncrona
            return $"{vehicle.Brand} {vehicle.Model} {vehicle.Year} processado com sucesso";
        }

        #endregion

        #region Exemplo 6: Teste com Coleções

        [Fact]
        public void Exemplo6_TesteComColecoes()
        {
            // Arrange
            var vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Brand = "Toyota", Model = "Corolla", Year = 2023 },
                new Vehicle { Id = 2, Brand = "Honda", Model = "Civic", Year = 2024 },
                new Vehicle { Id = 3, Brand = "Ford", Model = "Focus", Year = 2022 }
            };

            // Act
            var toyotaVehicles = vehicles.Where(v => v.Brand == "Toyota").ToList();
            var recentVehicles = vehicles.Where(v => v.Year >= 2023).ToList();

            // Assert
            Assert.Equal(3, vehicles.Count);
            Assert.Single(toyotaVehicles);
            Assert.Equal(2, recentVehicles.Count);
            
            vehicles.Should().HaveCount(3);
            toyotaVehicles.Should().ContainSingle();
            recentVehicles.Should().HaveCount(2);
        }

        #endregion

        #region Exemplo 7: Teste com Setup e Teardown

        private List<Vehicle> _testVehicles;

        public TestExamples()
        {
            // Setup - Executado antes de cada teste
            _testVehicles = new List<Vehicle>();
        }

        [Fact]
        public void Exemplo7_TesteComSetup()
        {
            // Arrange - Usar dados do setup
            _testVehicles.Add(new Vehicle { Id = 1, Brand = "Toyota" });
            _testVehicles.Add(new Vehicle { Id = 2, Brand = "Honda" });

            // Act
            var count = _testVehicles.Count;

            // Assert
            Assert.Equal(2, count);
            _testVehicles.Should().HaveCount(2);
        }

        #endregion

        #region Exemplo 8: Teste de Validação de Negócio

        [Theory]
        [InlineData(1900, false)] // Muito antigo
        [InlineData(2000, true)]  // Limite mínimo
        [InlineData(2023, true)]  // Ano atual
        [InlineData(2030, true)]  // Futuro próximo
        [InlineData(2050, false)] // Muito futuro
        public void Exemplo8_ValidacaoDeAno(int year, bool expectedValid)
        {
            // Arrange
            var vehicle = new Vehicle { Year = year };

            // Act
            var isValid = IsValidVehicleYear(vehicle.Year);

            // Assert
            Assert.Equal(expectedValid, isValid);
        }

        private bool IsValidVehicleYear(int year)
        {
            return year >= 2000 && year <= 2030;
        }

        #endregion

        #region Exemplo 9: Teste com Dados Complexos

        [Fact]
        public void Exemplo9_TesteComDadosComplexos()
        {
            // Arrange
            var vehicle = new Vehicle
            {
                Id = 1,
                Brand = "BMW",
                Model = "X5",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Azul Metálico"
            };

            var expectedVehicle = new Vehicle
            {
                Id = 1,
                Brand = "BMW",
                Model = "X5",
                Year = 2023,
                Plate = "ABC-1234",
                Color = "Azul Metálico"
            };

            // Act & Assert
            vehicle.Should().BeEquivalentTo(expectedVehicle);
            vehicle.Should().NotBeSameAs(expectedVehicle); // Objetos diferentes
        }

        #endregion

        #region Exemplo 10: Teste de Performance Conceitual

        [Fact]
        public void Exemplo10_TesteDePerformance()
        {
            // Arrange
            var vehicles = new List<Vehicle>();
            for (int i = 0; i < 1000; i++)
            {
                vehicles.Add(new Vehicle
                {
                    Id = i,
                    Brand = $"Brand{i}",
                    Model = $"Model{i}",
                    Year = 2020 + (i % 4)
                });
            }

            // Act
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var result = vehicles.Where(v => v.Year >= 2023).ToList();
            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds < 100); // Deve ser rápido
            result.Should().NotBeEmpty();
        }

        #endregion
    }

    /// <summary>
    /// Exemplos de testes que demonstram boas práticas
    /// </summary>
    public class BestPracticesExamples
    {
        [Fact]
        public void BoaPratica1_NomeDescritivo()
        {
            // ✅ Bom: Nome do teste explica o que está sendo testado
            var vehicle = new Vehicle { Brand = "Toyota" };
            
            Assert.Equal("Toyota", vehicle.Brand);
        }

        [Fact]
        public void BoaPratica2_UmTesteUmaResponsabilidade()
        {
            // ✅ Bom: Testa apenas uma coisa
            var vehicle = new Vehicle { Year = 2023 };
            
            Assert.True(vehicle.Year > 2000);
        }

        [Fact]
        public void BoaPratica3_DadosDeTesteClaros()
        {
            // ✅ Bom: Dados de teste são claros e significativos
            var vehicle = new Vehicle
            {
                Brand = "Toyota", // Marca conhecida
                Model = "Corolla", // Modelo popular
                Year = 2023 // Ano atual
            };

            Assert.NotNull(vehicle);
        }

        [Fact]
        public void BoaPratica4_AssertionsEspecificas()
        {
            // ✅ Bom: Assertions específicas
            var vehicle = new Vehicle { Brand = "Honda" };
            
            Assert.Equal("Honda", vehicle.Brand); // Específico
            Assert.NotNull(vehicle.Brand); // Não é null
            Assert.NotEmpty(vehicle.Brand); // Não é vazio
        }
    }
}
