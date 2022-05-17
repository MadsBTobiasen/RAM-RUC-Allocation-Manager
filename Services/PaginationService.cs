using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Services
{
    public class PaginationService <T> where T : class
    {

        #region Fields
        private List<T> objects;
        #endregion

        #region Properties 
        public int MaxItems { get; private set; } = 0;
        public int PageIndex { get; private set; } = 0;
        public int PageMax { get; private set; } = 0;
        public int PageMin { get; private set; } = 0;
        #endregion

        #region Constructor
        public PaginationService()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that "setups" the service. This HAS to be run before anything.
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="maxPerPage"></param>
        public void Setup(List<T> objs, int maxPerPage)
        {

            MaxItems = maxPerPage;
            objects = objs;

            PageMax = (int)Math.Ceiling(decimal.Divide(objs.Count, maxPerPage));

        }

        /// <summary>
        /// Method that tries to paginate the list of objects with a given int representing a page.
        /// </summary>
        /// <param name="requestedPage">Page integer to request.</param>
        /// <returns>List of paginated objects.</returns>
        public List<T> Paginate(int requestedPage)
        {

            if (requestedPage < 0) requestedPage = 0;
            if (requestedPage > PageMax) requestedPage = PageMax;

            PageIndex = requestedPage;

            List<T> output = objects.Skip((requestedPage - 1) * MaxItems).Take(MaxItems).ToList();
            return output;

        }
        #endregion

    }
}
