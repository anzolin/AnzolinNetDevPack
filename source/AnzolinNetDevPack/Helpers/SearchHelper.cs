using System;
using System.Collections.Generic;
using System.Linq;

namespace AnzolinNetDevPack.Helpers
{
    public static class SearchHelper
    {
        /// <summary>
        /// Aplica uma paginação para o IEnumerable<TModel>.
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="count"></param>
        /// <param name="pageSize"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<TModel> ApplyPaging<TModel>(IEnumerable<TModel> enumerable, int count, int pageSize, int? page)
        {
            if (enumerable == null) throw new ArgumentNullException("enumerable");

            if (!page.HasValue)
                page = 1;

            var lastPossiblePage = (count > 0 ? count - 1 : 0) / pageSize;
            var fixedPage = page.Value - 1;

            if (fixedPage > lastPossiblePage)
                fixedPage = lastPossiblePage;
            else if (fixedPage < 0)
                fixedPage = 0;

            var offset = fixedPage * pageSize;

            return enumerable.AsQueryable().Skip(offset).Take(pageSize).ToList();
        }
    }
}
