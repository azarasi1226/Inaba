namespace Inaba.Application.Image.Query
{
    public interface IImageRankingsQueryService
    {
        public Task<ImageRankingsOutputData> HandleAsync(ImageRankingsInputData inputData);
    }
}
