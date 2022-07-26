using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndoSpacePrac.Core.Entity.Employee.Settings
{
    public partial class Settings : BaseEntity
    {
        public Settings() { }

        public Settings(string name, string value)
        {
            this.Name = name;
            this.Value = value;
            // this.StoreId = storeId;
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public new string Name { get; set; }

        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the store for which this setting is valid. 0 is set when the setting is for all stores
        /// </summary>
        //  public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the Key
        /// </summary>
        public string Key { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
