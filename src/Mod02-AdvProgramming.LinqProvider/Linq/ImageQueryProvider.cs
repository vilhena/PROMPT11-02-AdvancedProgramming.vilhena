using System;
using System.Linq;
using System.Linq.Expressions;
using Mod02_AdvProgramming.LinqProvider.ImagesMetadata;

namespace Mod02_AdvProgramming.LinqProvider.Linq
{
    using DevLeap.Linq.ImagesStatus;

    using MattWarren.ExpressionsTools;

    internal class ImageQueryProvider : BaseQueryProvider
        {
            // Force developers to pass a ImageService in the constructor
            protected ImageQueryProvider() { }

            private ImageService _imageService;

            public ImageQueryProvider(ImageService _imageService)
            {
                if (_imageService == null)
                {
                    throw new ArgumentNullException("_imageService");
                }
                this._imageService = _imageService;
            }

            #region BaseQueryProvider abstract methods implementation
            public override object Execute(Expression expression)
            {
                ImageQueryParameters parameters = this.Translate(expression);
                return this._imageService.ImagesSearch(parameters.Filter, parameters.MaxImages);
            }

            public override IQueryable CreateQuery(Expression expression)
            {
                return new ImageQueryable(this, expression);
            }
            #endregion BaseQueryProvider abstract methods implementation

            public string GetQueryText(Expression expression)
            {
                ImageQueryParameters parameters = this.Translate(expression);
                return parameters.ToString();
            }

            private ImageQueryParameters Translate(Expression expression)
            {
                expression = Evaluator.PartialEval(expression);
                return new ImageQueryTranslator().Translate(expression);
            }
    }
}