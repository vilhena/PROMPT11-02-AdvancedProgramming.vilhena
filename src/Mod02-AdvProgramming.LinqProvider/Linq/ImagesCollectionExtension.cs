namespace Mod02_AdvProgramming.LinqProvider.Linq
{
    using System.Linq;

    using Mod02_AdvProgramming.LinqProvider.ImagesMetadata;

    public static class ImagesCollectionExtension
    {
        public static IQueryable<ImageInformation> AsQueryable(
            this ImagesCollection imagesCol)
        {

            ImageQueryProvider context =
                new ImageQueryProvider(imagesCol.ImagesService);
            return new ImageQueryable(context);
        }
    }
}