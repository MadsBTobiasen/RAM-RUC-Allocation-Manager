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

            PageMax = Convert.ToInt32(Math.Floor((double)(objects.Count / MaxItems)));

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

            List<T> output = new List<T>();

            if (objects == null) throw new Exception("PaginationService must be parsed a List of Objects<T> with the Setup-method to work."); 
            else
            {
                if(objects.Count > 0)
                {
                    for(int i = 0; i < objects.Count; i++)
                    {
                        
                        //Make sure that the loop quits if is bigger than the amount of objects.
                        if (i + (PageIndex * MaxItems) >= objects.Count) break;
                        //Make sure that there's no more than the MaxItems in the List.
                        if (output.Count >= MaxItems) break;

                        T item = objects[i + (PageIndex * MaxItems)];
                        output.Add(item);

                    }
                }
            }

            return output;

        }
        #endregion

    }
}
