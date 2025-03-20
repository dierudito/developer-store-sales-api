using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using Ambev.DeveloperEvaluation.Unit.Domain.Services.TestData;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Services;

public class SaleServiceTests
{
    private readonly Mock<ISaleRepository> _repositoryMock;
    private readonly SaleService _saleService;

    public SaleServiceTests()
    {
        var mocker = new AutoMocker();

        _repositoryMock = mocker.GetMock<ISaleRepository>();
        _saleService = mocker.CreateInstance<SaleService>();
    }

    [Fact(DisplayName = "CreateAsync deve criar uma venda e publicar o evento SaleCreated")]
    public async Task CreateAsync_DeveCriarVendaEPublicarEventoSaleCreated()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = await _saleService.CreateAsync(sale);

        // Assert
        _repositoryMock.Verify(repo => repo.CreateAsync(sale, It.IsAny<CancellationToken>()), Times.Once);
        _repositoryMock.Verify(repo => repo.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(sale, result);
    }

    [Fact(DisplayName = "UpdateAsync deve atualizar uma venda e publicar o evento SaleModified")]
    public async Task UpdateAsync_DeveAtualizarVendaEPublicarEventoSaleModified()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        var result = await _saleService.UpdateAsync(sale);

        // Assert
        _repositoryMock.Verify(repo => repo.UpdateAsync(sale), Times.Once);
        _repositoryMock.Verify(repo => repo.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        Assert.Equal(sale, result);
    }

    [Fact(DisplayName = "DeleteAsync deve excluir uma venda")]
    public async Task DeleteAsync_DeveExcluirVenda()
    {
        // Arrange
        var saleId = Guid.NewGuid();

        // Act
        await _saleService.DeleteAsync(saleId);

        // Assert
        _repositoryMock.Verify(repo => repo.DeleteAsync(saleId), Times.Once);
        _repositoryMock.Verify(repo => repo.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "GetAllSalesAsync deve retornar todas as vendas")]
    public async Task GetAllSalesAsync_DeveRetornarTodasVendas()
    {
        // Arrange
        var sales = new List<Sale> { SaleTestData.GenerateValidSale(), SaleTestData.GenerateValidSale() };
        _repositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(sales);

        // Act
        var result = await _saleService.GetAllSalesAsync();

        // Assert
        Assert.Equal(sales, result);
        _repositoryMock.Verify(repo => repo.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "GetSaleByIdAsync deve retornar uma venda por ID")]
    public async Task GetSaleByIdAsync_DeveRetornarVendaPorId()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        _repositoryMock.Setup(repo => repo.GetByIdAsync(sale.Id, It.IsAny<CancellationToken>())).ReturnsAsync(sale);

        // Act
        var result = await _saleService.GetSaleByIdAsync(sale.Id);

        // Assert
        Assert.Equal(sale, result);
        _repositoryMock.Verify(repo => repo.GetByIdAsync(sale.Id, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact(DisplayName = "CancelItemAsync deve cancelar um item e publicar o evento ItemCancelled")]
    public async Task CancelItemAsync_DeveCancelarItemEPublicarEventoItemCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var item = SaleItemTestData.GenerateValidSaleItem();
        item.IsCancelled = false;
        sale.AddItem(item);

        // Act
        await _saleService.CancelItemAsync(sale, item);

        // Assert
        Assert.True(sale.Items[0].IsCancelled);
        _repositoryMock.Verify(repo => repo.UpdateAsync(sale), Times.Once);
        _repositoryMock.Verify(repo => repo.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}