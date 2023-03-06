using AngleSharp;
using MediatR;
using SeeThatsAVerySharpScrapper.Models;

namespace SeeThatsAVerySharpScrapper.Queries.GetDataBasedOnCssSelectors
{
    public record GetDataBasedOnCssSelectorsQuery(ScrapParameters Parameters) : IRequest<ScrapedDataViewModel>;

    public class GetDataBasedOnCssSelectorsQueryHandler : IRequestHandler<GetDataBasedOnCssSelectorsQuery, ScrapedDataViewModel>
    {
        public async Task<ScrapedDataViewModel> Handle(GetDataBasedOnCssSelectorsQuery request, CancellationToken cancellationToken)
        {
            HttpClient client = new();

            var data = new List<Dictionary<string, string?>>();

            foreach (var url in request.Parameters.Urls)
            {
                try
                {
                    var result = await client.GetStreamAsync(url, cancellationToken);
                    var document = await BrowsingContext
                        .New()
                        .OpenAsync(m => m
                            .Content(result), cancellationToken);

                    var currentPageExtractedSelectors = new Dictionary<string, string?>();

                    foreach (var selector in request.Parameters.CssSelectors)
                    {
                        var scrapedSelectorValue = document.QuerySelector(selector.Value)?.TextContent;
                        currentPageExtractedSelectors.Add(selector.Key, scrapedSelectorValue);
                    }

                    data.Add(currentPageExtractedSelectors);
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            return new ScrapedDataViewModel()
            {
                ScrapedData = data,
            };
        }
    }
}
