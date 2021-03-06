using System.Net.Http;
using System.Threading.Tasks;
using Shy.Redmine.Dto;
using Xunit;

namespace Shy.Redmine.Tests
{
	using static RedmineClientSettings;

	public class RedmineClientTests
	{
	    private readonly IRedmineClient _client;

	    public RedmineClientTests()
	    {
	        var httpClientHandler = new HttpClientHandler()
	        {
	            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
	        };
	        var httpClient = new HttpClient(httpClientHandler);
	        _client = new RedmineClient(httpClient, BaseUri, ApiKey);
	    }

        [Theory]
		[InlineData(0), InlineData(25), InlineData(100), InlineData(200)]
		public async Task GetAllTickets_CallWithCountIsN_ReturnsNTickets(int count)
		{
			var tickets = await _client.GetAllTicketsAsync(count: count);
			Assert.Equal(count, tickets.Count);
		}

		[Fact]
		public async Task GetAllTickets_CallWithSomeParameters_ReturnsSomeTickets()
		{
			var tickets = await _client.GetTicketsAsync(new long[] {6, 8}, include: new[]
			{
				TicketInclude.Relations, TicketInclude.Children
			});

			Assert.True(tickets.Data.Length > 0);
		}

		[Theory]
		[InlineData(10000), InlineData(1000), InlineData(20000)]
		public async Task GetTicket_CallWithN_ReturnsTicketWithIdN(int id)
		{
			var response = await _client.GetTicketAsync(id);
			Assert.Equal(id, response.Data.Id);
	    }

	    [Theory]
	    [InlineData(10000), InlineData(1000), InlineData(20000)]
	    public void GetTicket_CallWithNAndInclude_ReturnsTicketWithIdN(int id)
	    {
	        var response = _client.GetTicketAsync(id, new [] {"journals"}).Result;
	        Assert.Equal(id, response.Data.Id);
	    }
    }
}
