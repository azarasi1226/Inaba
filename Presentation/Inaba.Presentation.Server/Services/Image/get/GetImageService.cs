using Grpc.Core;
using Inaba.Presentation.gRPC;

namespace Inaba.Presentation.Server.Services.Image.get
{
    public class GetImageService : ImageService.ImageServiceBase
    {
        private readonly ILogger<GetImageService> _logger;
        public GetImageService(ILogger<GetImageService> logger)
        {
            _logger = logger;
        }

        public override Task<GetImageRankingsResponse> GetImageRankings(GetImageRankingsRequest request, ServerCallContext context)
        {
            var a = Enumerable.Range(0, 100)
                .Select(i => new ImageThumbnail
                {
                    Title = "デモ画像",
                    Id = "abcdefg",
                    ImageUrl = "asdf",
                    Amount = 13,
                    AgeRating = AgeRating.All,
                    User = new ImageThumbnail.Types.User
                    {
                        UserName = "aaa",
                        UserProfileUrl = "aasdfa"
                    }
                });

            var b = new GetImageRankingsResponse()
            {
                Paging = new Paging
                {
                    PageSize = 15,
                    PageNumber = 13,
                }
        };
            b.Items.AddRange(a);


            return Task.FromResult(
                b
            );
        }
    }
}
