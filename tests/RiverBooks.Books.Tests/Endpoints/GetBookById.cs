using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.Endpoints.GetBookById;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints;

public class BookGetById(Fixture fixture, ITestOutputHelper outputHelper)
    : TestClass<Fixture>(fixture, outputHelper)
{
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000001", "Domain-Driven Design")]
    [InlineData("00000000-0000-0000-0000-000000000002", "Clean Code")]
    [InlineData("00000000-0000-0000-0000-000000000003", "Refactoring")]
    public async Task ReturnsExpectedBookGivenIdAsync(string id, string expectedTitle)
    {
        Guid bookId = Guid.Parse(id);
        var request = new GetBookByIdRequest(bookId);
        var response = await Fixture.Client.GETAsync<GetBookByIdEndpoint, GetBookByIdRequest, BookDto>(request);
        response.Response.EnsureSuccessStatusCode();
        response.Result.Title.Should().Be(expectedTitle);
    }
}

