using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Infrastructure.Persistence;
using Xunit;

namespace ECommerceApp.Tests.Integration
{
    public class JsonProductRepositoryTests : IDisposable
    {
        private readonly string _tempFile;
        public JsonProductRepositoryTests()
        {
            _tempFile = Path.GetTempFileName();
            if (File.Exists(_tempFile)) File.Delete(_tempFile);
        }

        public void Dispose()
        {
            try { if (File.Exists(_tempFile)) File.Delete(_tempFile); } catch { }
        }

        [Fact]
        public async Task SaveAsync_CreatesFile_WhenRepositoryEmpty()
        {
            var repo = new JsonProductRepository(_tempFile);
            await repo.SaveAsync();
            Assert.True(File.Exists(_tempFile));
            var txt = await File.ReadAllTextAsync(_tempFile);
            Assert.Contains("[]", txt);
        }

        [Fact]
        public void Constructor_DoesNotThrow_WhenFileMissing()
        {
            var repo = new JsonProductRepository(_tempFile);
            Assert.NotNull(repo);
        }

        [Fact]
        public async Task LoadAsync_ReadsProductsFromFile()
        {
            var products = new List<Product> { new Product("X", 5m, 2) };
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_tempFile, json);

            var repo = new JsonProductRepository(_tempFile);
            await repo.LoadAsync();
            var all = repo.GetAll();
            Assert.Single(all);
        }

        [Fact]
        public void Constructor_Throws_OnCorruptedJson()
        {
            File.WriteAllText(_tempFile, "not valid json");
            Assert.ThrowsAny<Exception>(() => new JsonProductRepository(_tempFile));
        }

        [Fact]
        public async Task SaveAsync_And_LoadAsync_Roundtrip()
        {
            var products = new List<Product> { new Product("P1", 1m, 1), new Product("P2", 2m, 2) };
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_tempFile, json);

            var repo = new JsonProductRepository(_tempFile);
            await repo.LoadAsync();
            await repo.SaveAsync();

            var repo2 = new JsonProductRepository(_tempFile);
            await repo2.LoadAsync();
            Assert.Equal(2, System.Linq.Enumerable.Count(repo2.GetAll()));
        }

        [Fact]
        public async Task LoadAsync_OnNonexistentFile_DoesNotThrow()
        {
            var p = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".json");
            if (File.Exists(p)) File.Delete(p);
            var repo = new JsonProductRepository(p);
            await repo.LoadAsync();
            Assert.Empty(repo.GetAll());
        }

        [Fact]
        public async Task SaveAsync_WritesValidJson_Format()
        {
            var products = new List<Product> { new Product("Y", 3m, 3) };
            var json = JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_tempFile, json);

            var repo = new JsonProductRepository(_tempFile);
            await repo.LoadAsync();
            await repo.SaveAsync();

            var txt = await File.ReadAllTextAsync(_tempFile);
            Assert.Contains("Price", txt);
            Assert.Contains("StockQuantity", txt);
        }

        [Fact]
        public async Task LargeNumberOfProducts_Roundtrip_PerformanceSmoke()
        {
            var list = new List<Product>();
            for (int i = 0; i < 200; i++) list.Add(new Product("Prod" + i, i + 1m, i));
            var json = JsonSerializer.Serialize(list);
            await File.WriteAllTextAsync(_tempFile, json);

            var repo = new JsonProductRepository(_tempFile);
            await repo.LoadAsync();
            Assert.Equal(200, System.Linq.Enumerable.Count(repo.GetAll()));
        }
    }
}
