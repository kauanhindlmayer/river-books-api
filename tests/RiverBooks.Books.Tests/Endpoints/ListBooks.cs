using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using RiverBooks.Books.Endpoints.ListBooks;
using Xunit.Abstractions;

namespace RiverBooks.Books.Tests.Endpoints;

public class ListBooks(Fixture fixture, ITestOutputHelper testOutputHelper)
    : TestClass<Fixture>(fixture, testOutputHelper)
{
    [Fact]
    public async Task Should_return_all_books()
    {
        var response = await Fixture.Client.GETAsync<ListBooksEndpoint, ListBooksResponse>();
        response.Response.EnsureSuccessStatusCode();
        response.Result.Books.Count.Should().Be(10);
    }
}