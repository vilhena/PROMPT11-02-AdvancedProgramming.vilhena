using System;
using System.Collections.Generic;

namespace Mod02_AdvProgramming.LinqProvider.ImagesMetadata
{
    public partial class ImageService
    {


        public IEnumerable<ImageInformation> ImagesSearch(QueryFilter pars)
        {
            return ImagesSearch(pars, -1);    
        }

        public IEnumerable<ImageInformation> ImagesSearch(QueryFilter pars, int maxImages)
        {
            Console.WriteLine("---- ImagesQuery execution ----");
            if (maxImages >= 0)
            {
                Console.WriteLine("Maximum returned images: {0}", maxImages);
            }
            Console.WriteLine(pars);
            
            // ... Implementation details ...
            throw new NotImplementedException();
        }
    }

    
}