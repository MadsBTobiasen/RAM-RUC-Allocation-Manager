using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAM___RUC_Allocation_Manager.Models.Email
{
    public class EmailTemplate
    {

        #region Properties
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string TemplateBody { get; set; }
        #endregion

        #region Constructor

        #endregion

        #region Methods
        public override string ToString()
        {
            return $"$EmailTemplate: {Name} ({ShortName})";
        }
        #endregion

    }
}
